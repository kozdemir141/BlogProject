$(document).ready(function () {

    /*DataTables Start Here. */

    const dataTable = $('#usersTable').DataTable({
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
                        url: '/Admin/User/GetAllUsers/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#usersTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const userListDto = jQuery.parseJSON(data);
                            dataTable.clear();
                            if (userListDto.ResultStatus === 0) {
                                $.each(userListDto.Users.$values,
                                    function (index, user) {
                                        const newTableRow = dataTable.row.add([
                                            user.Id,
                                            user.UserName,
                                            user.Email,
                                            user.FirstName,
                                            user.LastName,
                                            user.PhoneNumber,
                                            user.About.length > 75 ? user.About.substring(0, 75) : user.About,
                                            `<img src="/img/${user.Picture}" alt="${user.UserName}" class="my-image-table" />`,
                                            `
                                <button class="btn btn-info btn-sm btn-detail" data-id="${user.Id}"><span class="fas fa-newspaper"></span></button>
                                <button class="btn btn-warning btn-sm btn-assign" data-id="${user.Id}"><span class="fas fa-user-shield"></span></button>
                                <button class="btn btn-primary btn-sm btn-update" data-id="${user.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${user.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${user.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#usersTable').fadeIn(1400);
                            } else {
                                toastr.error(`${userListDto.Messages}`, 'Unsuccesful Transactions!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#usersTable').fadeIn(1000);
                            toastr.error(`${err.statusText}`, 'Unsuccesful Transactions!');
                        }
                    });
                }
            }
        ],
    });

    /* DataTables ends here */
    /* Ajax GET / Getting the _UserAddPartial as Modal Form Here */

    $(function () {
        const url = '/Admin/User/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        /* Ajax GET / Getting the _UserAddPartial as Modal Form Here */

        /* Ajax POST / Posting the Form Data as UserAddDto Starts Form Here */

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                const form = $('#form-user-add');
                const actionUrl = form.attr('action');
                const dataToSend = new FormData(form.get(0));
                $.ajax({
                    url: actionUrl,
                    type: 'POST',
                    data: dataToSend,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        const userAddAjaxModel = jQuery.parseJSON(data);
                        const newFormBody = $('.modal-body', userAddAjaxModel.UserAddPartial);
                        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                        const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            placeHolderDiv.find('.modal').modal('hide');
                            const newTableRow = dataTable.row.add([
                                userAddAjaxModel.UserDto.User.Id,
                                userAddAjaxModel.UserDto.User.UserName,
                                userAddAjaxModel.UserDto.User.Email,
                                userAddAjaxModel.UserDto.User.FirstName,
                                userAddAjaxModel.UserDto.User.LastName,
                                userAddAjaxModel.UserDto.User.PhoneNumber,
                                userAddAjaxModel.UserDto.User.About.length > 75 ? userAddAjaxModel.UserDto.User.About.substring(0, 75) : userAddAjaxModel.UserDto.User.About,
                                `<img src="/img/${userAddAjaxModel.UserDto.User.Picture}" alt="${userAddAjaxModel.UserDto.User.UserName}" class="my-image-table" />`,
                                `
                                <button class="btn btn-info btn-sm btn-detail" data-id="${userAddAjaxModel.UserDto.User.Id}"><span class="fas fa-newspaper"></span></button>
                                <button class="btn btn-warning btn-sm btn-assign" data-id="${userAddAjaxModel.UserDto.User.Id}"><span class="fas fa-user-shield"></span></button>
                                <button class="btn btn-primary btn-sm btn-update" data-id="${userAddAjaxModel.UserDto.User.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${userAddAjaxModel.UserDto.User.Id}"><span class="fas fa-minus-circle"></span></button>
                            `
                            ]).node();
                            const jqueryTableRow = $(newTableRow);
                            jqueryTableRow.attr('name', `${userAddAjaxModel.UserDto.User.Id}`);
                            dataTable.row(newTableRow).draw();
                            toastr.success(`${userAddAjaxModel.UserDto.Messages}`, 'Succesful Transaction!');
                        }
                        else {
                            let summaryText = "";
                            $('#validation-summary > ul > li').each(function () {
                                let text = $(this).text();
                                summaryText = `* ${text}\n`;
                            });
                            toastr.warning(summaryText);
                        }
                    },
                    error: function (err) {
                        console.log(err);
                        toastr.error(`${err.statusText}`, 'Unsuccesful Transactions!');
                    }
                });
            });
    });

    /* Ajax POST / Posting the FormData as UserAddDto ends here. */

    /* Ajax POST / Deleting a User starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const userName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Are You Sure Want To Delete?',
                text: `${userName} User Will Be Deleted!`,
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
                        data: { userId: id },
                        url: '/Admin/User/Delete/',
                        success: function (data) {
                            const userDto = jQuery.parseJSON(data);
                            if (userDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${userDto.User.UserName} Deleted Succesfully.`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Oops...',
                                    text: `${userDto.Messages}`,
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

    /* Ajax GET / Getting the _UserUpdatePartial as Modal Form starts from here. */

    $(function () {
        const url = '/Admin/User/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { userId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function (err) {
                    toastr.error(`${err.statusText}`, 'Unsuccesful Transactions!');
                });
            });

        /* Ajax POST / Updating a User starts from here */

        placeHolderDiv.on('click',
            '#btnUpdate',
            function (event) {
                event.preventDefault();

                const form = $('#form-user-update');
                const actionUrl = form.attr('action');
                const dataToSend = new FormData(form.get(0));
                $.ajax({
                    url: actionUrl,
                    type: 'POST',
                    data: dataToSend,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        const userUpdateAjaxModel = jQuery.parseJSON(data);
                        console.log(userUpdateAjaxModel);
                            
                        let id;
                        let tableRow;
                        if (userUpdateAjaxModel.UserDto != null)
                        {
                            id = userUpdateAjaxModel.UserDto.User.Id;
                            tableRow = $(`[name="${id}"]`);
                        }
                        const newFormBody = $('.modal-body', userUpdateAjaxModel.UserUpdatePartial);
                        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                        const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            placeHolderDiv.find('.modal').modal('hide');
                            dataTable.row(tableRow).data([
                                userUpdateAjaxModel.UserDto.User.Id,
                                userUpdateAjaxModel.UserDto.User.UserName,
                                userUpdateAjaxModel.UserDto.User.Email,
                                userUpdateAjaxModel.UserDto.User.FirstName,
                                userUpdateAjaxModel.UserDto.User.LastName,
                                userUpdateAjaxModel.UserDto.User.PhoneNumber,
                                userUpdateAjaxModel.UserDto.User.About.length > 75 ? userUpdateAjaxModel.UserDto.User.About.substring(0, 75) : userUpdateAjaxModel.UserDto.User.About,
                                `<img src="/img/${userUpdateAjaxModel.UserDto.User.Picture}" alt="${userUpdateAjaxModel.UserDto.User.UserName}" class="my-image-table" />`,
                                `
                                <button class="btn btn-info btn-sm btn-detail" data-id="${userUpdateAjaxModel.UserDto.User.Id}"><span class="fas fa-newspaper"></span></button>
                                <button class="btn btn-warning btn-sm btn-assign" data-id="${userUpdateAjaxModel.UserDto.User.Id}"><span class="fas fa-user-shield"></span></button>
                                <button class="btn btn-primary btn-sm btn-update" data-id="${userUpdateAjaxModel.UserDto.User.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${userUpdateAjaxModel.UserDto.User.Id}"><span class="fas fa-minus-circle"></span></button>
                            `
                            ]);
                            tableRow.attr("name", `${id}`);
                            dataTable.row(tableRow).invalidate();
                            toastr.success(`${userUpdateAjaxModel.UserDto.Messages}`, "Succesfull Transactions!");
                        } else {
                            let summaryText = "";
                            $('#validation-summary > ul > li').each(function () {
                                let text = $(this).text();
                                summaryText = `* ${text}\n`;
                            });
                            toastr.warning(summaryText);
                        }
                    },
                    error: function (error) {
                        console.log(error);
                        toastr.error(`${err.statusText}`, 'Unsuccesful Transactions!');
                    }
                });
            });

    });
    // Get Detail Ajax Operation

    $(function () {

        const url = '/Admin/User/GetDetail/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-detail',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { userId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function (err) {
                    toastr.error(`${err.responseText}`, 'Error!');
                });
            });
    });

    $(function () {
        const url = '/Admin/Role/Assign/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-assign',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { userId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function (err) {
                    toastr.error(`${err.responseText}`, 'Error!');
                });
            });

        /* Ajax POST / Updating a RoleAssign starts from here */

        placeHolderDiv.on('click',
            '#btnAssign',
            function (event) {
                event.preventDefault();
                const form = $('#form-role-assign');
                const actionUrl = form.attr('action');
                const dataToSend = new FormData(form.get(0));
                $.ajax({
                    url: actionUrl,
                    type: 'POST',
                    data: dataToSend,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        const userRoleAssignAjaxModel = jQuery.parseJSON(data);
                        console.log(userRoleAssignAjaxModel);
                        const newFormBody = $('.modal-body', userRoleAssignAjaxModel.RoleAssignPartial);
                        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                        const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            const id = userRoleAssignAjaxModel.UserDto.User.Id;
                            const tableRow = $(`[name="${id}"]`);
                            //placeHolderDiv.find('.modal').modal('hide');
                            toastr.success(`${userRoleAssignAjaxModel.UserDto.Messages}`, "Succesful Transaction!");
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
});