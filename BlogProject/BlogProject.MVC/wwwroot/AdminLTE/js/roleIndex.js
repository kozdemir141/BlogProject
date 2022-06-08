$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#rolesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Role/GetAllRoles/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#rolesTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const rolesResult = jQuery.parseJSON(data);
                            dataTable.clear();
                            console.log(rolesResult);
                            if (rolesResult.Roles) {
                                const articlesArray = [];
                                $.each(rolesResult.Roles,
                                    function (index, role) {
                                        const newTableRow = dataTable.row.add([
                                            role.Id,
                                            role.Name
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${role.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#rolesTable').fadeIn(1400);
                            } else {
                                toastr.error(`Unexcepted Error`, 'Unsuccesfull Transactions');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#rolesTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Error!');
                        }
                    });
                }
            }
        ],
    });
});