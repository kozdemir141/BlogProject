$(document).ready(function () {

    /*DataTables Start Here. */

    const dataTable = $('#articlesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Add',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {
                }
            },
            {
                text: 'Refresh',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Article/GetAllArticles/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#articlesTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const articleResult = jQuery.parseJSON(data);
                            dataTable.clear();
                            console.log(articleResult);
                            if (articleResult.Data.ResultStatus === 0) {
                                let categoriesArray = [];
                                $.each(articleResult.Data.Articles.$values,
                                    function (index, article) {
                                        const newArticle = getJsonNetObject(article, articleResult.Data.Articles.$values);
                                        let newCategory = getJsonNetObject(newArticle.Category, newArticle);
                                        if (newCategory !== null) {
                                            categoriesArray.push(newCategory);
                                        }
                                        if (newCategory === null) {
                                            newCategory = categoriesArray.find((category) => {
                                                return category.$id === newArticle.Category.$ref;
                                            });
                                        }
                                        console.log(newArticle);
                                        console.log(newCategory);
                                        const newTableRow = dataTable.row.add([
                                            newArticle.Id,
                                            newCategory.Name,
                                            newArticle.Title,
                                            `<img src="/img/${newArticle.Thumbnail}" alt="${newArticle.Title}" class="my-image-table" />`,
                                            convertToShortDate(newArticle.Date),
                                            newArticle.WievsCount,
                                            newArticle.CommentCount,
                                            convertFirtLetterToUpperCase(newArticle.IsActive.toString()),
                                            convertFirtLetterToUpperCase(newArticle.IsDeleted.toString()),
                                            convertToShortDate(newArticle.CreatedDate),
                                            newArticle.CreatedByName,
                                            convertToShortDate(newArticle.ModifiedDate),
                                            newArticle.ModifiedByName,
                                            `
                                <a class="btn btn-primary btn-sm btn-update" href="/Admin/Article/Update?articleId=${newArticle.Id}"><span class="fas fa-edit"></span></a>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${newArticle.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${newArticle.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#articlesTable').fadeIn(1400);
                            } else {
                                toastr.error(`${articleResult.Data.Messages}`, 'Unsuccesful Transactions!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#articlesTable').fadeIn(1000);
                            toastr.error(`${err.statusText}`, 'Unsuccesful Transactions!');
                        }
                    });
                }
            }
        ],
    });

    /* DataTables ends here */

    /* Ajax POST / Deleting a User starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const articleTitle = tableRow.find('td:eq(2)').text();
            Swal.fire({
                title: 'Are You Sure Want To Delete?',
                text: `${articleTitle} Will Be Deleted!`,
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
                        data: { articleId: id },
                        url: '/Admin/Article/Delete/',
                        success: function (data) {
                            const articleResult = jQuery.parseJSON(data);
                            if (articleResult.ResultStatus === 0) {
                                Swal.fire(
                                    'Deleted!',
                                    `${articleResult.Message}`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Oops...',
                                    text: `${articleResult.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Error!")
                        }
                    });
                }
            });
        });
});