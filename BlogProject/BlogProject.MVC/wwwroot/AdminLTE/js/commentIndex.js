$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#commentsTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Refresh',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Comment/GetAllComments/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#commentsTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const commentResult = jQuery.parseJSON(data);
                            dataTable.clear();
                            console.log(commentResult);
                            if (commentResult.Data) {
                                const articlesArray = [];
                                $.each(commentResult.Data.Comments.$values,
                                    function (index, comment) {
                                        const newComment = getJsonNetObject(comment, commentResult.Data.Comments.$values);
                                        let newArticle = getJsonNetObject(newComment.Article, newComment);
                                        if (newArticle !== null) {
                                            articlesArray.push(newArticle);
                                        }
                                        if (newArticle === null) {
                                            newArticle = articlesArray.find((article) => {
                                                return article.$id === newComment.Article.$ref;
                                            });
                                        }
                                        const newTableRow = dataTable.row.add([
                                            newComment.Id,
                                            newArticle.Title,
                                            newComment.Text.length > 75 ? newComment.Text.substring(0, 75) : newComment.Text,
                                            convertFirtLetterToUpperCase(newComment.IsActive.toString()),
                                            convertFirtLetterToUpperCase(newComment.IsDeleted.toString()),
                                            convertToShortDate(newComment.CreatedDate),
                                            newComment.CreatedByName,
                                            convertToShortDate(newComment.ModifiedDate),
                                            newComment.ModifiedByName,
                                            getButtonsForDataTable(newComment)
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${newComment.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#commentsTable').fadeIn(1400);
                            } else {
                                toastr.error(`${commentResult.Message}`, 'Unsuccesful Transactions!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#commentsTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Unsuccesful Transactions!');
                        }
                    });
                }
            }
        ],
    });

    /* DataTables end here */

    /* Ajax POST / Deleting a Comment starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            let commentText = tableRow.find('td:eq(2)').text();
            commentText = commentText.length > 75 ? commentText.substring(0, 75) : commentText;
            Swal.fire({
                title: 'Are You Sure Want To Delete?',
                text: `${commentText} Comment Will Be Deleted!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, Delete It!',
                cancelButtonText: 'Cancel.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { commentId: id },
                        url: '/Admin/Comment/Delete/',
                        success: function (data) {
                            const commentResult = jQuery.parseJSON(data);
                            console.log(commentResult);
                            if (commentResult.Data) {
                                Swal.fire(
                                    'Deleted!',
                                    `Comment Deleted Succesfully`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Oops...',
                                    text: `${commentResult.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Error!");
                        }
                    });
                }
            });
        });

    /* Ajax GET / Getting the _CommentUpdatePartial as Modal Form starts from here. */

    $(function () {
        const url = '/Admin/Comment/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { commentId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function (err) {
                    toastr.error(`${err.responseText}`, 'Error!');
                });
            });

        /* Ajax POST / Updating a Comment starts from here */

        placeHolderDiv.on('click',
            '#btnUpdate',
            function (event) {
                event.preventDefault();
                const form = $('#form-comment-update');
                const actionUrl = form.attr('action');
                const dataToSend = new FormData(form.get(0));
                $.ajax({
                    url: actionUrl,
                    type: 'POST',
                    data: dataToSend,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        const commentUpdateAjaxModel = jQuery.parseJSON(data);
                        console.log(commentUpdateAjaxModel);

                        let id;
                        let tableRow;
                        if (commentUpdateAjaxModel.CommentDto != null) {
                            id = commentUpdateAjaxModel.CommentDto.Comment.Id;
                            tableRow = $(`[name="${id}"]`);
                        }
                        const newFormBody = $('.modal-body', commentUpdateAjaxModel.CommentUpdatePartial);
                        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                        const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            placeHolderDiv.find('.modal').modal('hide');
                            dataTable.row(tableRow).data([
                                commentUpdateAjaxModel.CommentDto.Comment.Id,
                                commentUpdateAjaxModel.CommentDto.Comment.Article.Title,
                                commentUpdateAjaxModel.CommentDto.Comment.Text.length > 75 ? commentUpdateAjaxModel.CommentDto.Comment.Text.substring(0, 75) : commentUpdateAjaxModel.CommentDto.Comment.Text,
                                convertFirtLetterToUpperCase(commentUpdateAjaxModel.CommentDto.Comment.IsActive.toString()),
                                convertFirtLetterToUpperCase(commentUpdateAjaxModel.CommentDto.Comment.IsDeleted.toString()),
                                convertToShortDate(commentUpdateAjaxModel.CommentDto.Comment.CreatedDate),
                                commentUpdateAjaxModel.CommentDto.Comment.CreatedByName,
                                convertToShortDate(commentUpdateAjaxModel.CommentDto.Comment.ModifiedDate),
                                commentUpdateAjaxModel.CommentDto.Comment.ModifiedByName,
                                getButtonsForDataTable(commentUpdateAjaxModel.CommentDto.Comment)
                            ]);
                            tableRow.attr("name", `${id}`);
                            dataTable.row(tableRow).invalidate();
                            toastr.success(`The Article Was Successfully Updated.`, "Succesful Transaction!");
                        } else {
                            let summaryText = "";
                            $('#validation-summary > ul > li').each(function () {
                                let text = $(this).text();
                                summaryText = `*${text}\n`;
                            });
                            toastr.warning(summaryText);
                        }
                    },
                    error: function (error) {
                        console.log(error);
                        toastr.error(`${err.responseText}`, 'Unsuccesful Transactions!');
                    }
                });
            });

    });

    // Get Detail Ajax Operation

    $(function () {
        const url = '/Admin/Comment/GetDetail/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-detail',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { commentId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function (err) {
                    toastr.error(`${err.responseText}`, 'Error!');
                });
            });
    });

    /* Ajax POST / Deleting a Comment starts from here */

    $(document).on('click',
        '.btn-approve',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            let commentText = tableRow.find('td:eq(2)').text();
            commentText = commentText.length > 75 ? commentText.substring(0, 75) : commentText;
            Swal.fire({
                title: 'Are You Sure Want To Approve?',
                text: `${commentText} Comment Will Be Approved!`,
                icon: 'info',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, Approve It!',
                cancelButtonText: 'Cancel.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { commentId: id },
                        url: '/Admin/Comment/Approve/',
                        success: function (data) {
                            const commentResult = jQuery.parseJSON(data);
                            console.log(commentResult);
                            if (commentResult.Data) {
                                dataTable.row(tableRow).data([
                                    commentResult.Data.Comment.Id,
                                    commentResult.Data.Comment.Article.Title,
                                    commentResult.Data.Comment.Text.length > 75 ? commentResult.Data.Comment.Text.substring(0, 75) : commentResult.Data.Comment.Text,
                                    convertFirtLetterToUpperCase(commentResult.Data.Comment.IsActive.toString()),
                                    convertFirtLetterToUpperCase(commentResult.Data.Comment.IsDeleted.toString()),
                                    convertToShortDate(commentResult.Data.Comment.CreatedDate),
                                    commentResult.Data.Comment.CreatedByName,
                                    convertToShortDate(commentResult.Data.Comment.ModifiedDate),
                                    commentResult.Data.Comment.ModifiedByName,
                                    getButtonsForDataTable(commentResult.Data.Comment)
                                ]);
                                tableRow.attr("name", `${id}`);
                                dataTable.row(tableRow).invalidate();
                                Swal.fire(
                                    'Approved!',
                                    `Comment Approved.`,
                                    'success'
                                );
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Oops...',
                                    text: `Unexpected Error
`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Error!");
                        }
                    });
                }
            });
        });

    function getButtonsForDataTable(comment) {
        if (!comment.IsActive) {
            return `
                                <button class="btn btn-warning btn-sm btn-approve" data-id="${comment.Id
                }"><span class="fas fa-thumbs-up"></span></button>
                                <button class="btn btn-info btn-sm btn-detail" data-id="${comment.Id
                }"><span class="fas fa-newspaper"></span></button>
                                <button class="btn btn-primary btn-sm mt-1 btn-update" data-id="${comment.Id
                }"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm mt-1 btn-delete" data-id="${comment.Id
                }"><span class="fas fa-minus-circle"></span></button>
                                            `;
        }
        return `<button class="btn btn-info btn-sm btn-detail" data-id="${comment.Id}"><span class="fas fa-newspaper"></span></button>
                                <button class="btn btn-primary btn-sm mt-1 btn-update" data-id="${comment.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm mt-1 btn-delete" data-id="${comment.Id}"><span class="fas fa-minus-circle"></span></button>`


    }

});