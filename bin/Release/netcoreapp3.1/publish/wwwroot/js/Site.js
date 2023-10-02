$(document).ready(function () {
    $('#rmTable').DataTable({
        initComplete: function () {
            this.api()
                .columns()
                .every(function () {
                    var column = this;
                    var select = $('<select><option value=""></option></select>')
                        .appendTo($(column.header()).empty())
                        .on('change', function () {
                            var val = $.fn.dataTable.util.escapeRegex($(this).val());
                            column.search(val ? '^' + val + '$' : '', true, false).draw();
                        });
                    column
                        .data()
                        .unique()
                        .sort()
                        .each(function (d, j) {
                            select.append('<option value="' + d + '">' + d + '</option>');
                        });
                });
        },
        'rowCallback': function (row, data, index) {
            //if (data[9] == '00:00:00') {
            //    $(row).find('td:eq(9)').css('color', 'green');
            //}
            if (data[9] > '00:00:00') {
                $(row).find('td:eq(9)').css('color', '#F7A4A4');
            }
            //if (data[9] > '02:00:00') {
            //    $(row).find('td:eq(9)').css('color', 'red');
            //}
            if (data[13] > '01:00:00') {
                $(row).find('td:eq(13)').css('color', '#F7A4A4');
            }
        }
    });
});

$(document).ready(function () {
    $('#reConcile').DataTable();
});

$(document).ready(function () {
    $('#bTime').DataTable();
});


function updateDataTableSelectAllCtrl(table) {
    var $table = table.table().node();
    var $chkbox_all = $('tbody input[type="checkbox"]', $table);
    var $chkbox_checked = $('tbody input[type="checkbox"]:checked', $table);
    var chkbox_select_all = $('thead input[name="select_all"]', $table).get(0);

    // If none of the checkboxes are checked
    if ($chkbox_checked.length === 0) {
        chkbox_select_all.checked = false;
        if ('indeterminate' in chkbox_select_all) {
            chkbox_select_all.indeterminate = false;
        }

        // If all of the checkboxes are checked
    } else if ($chkbox_checked.length === $chkbox_all.length) {
        chkbox_select_all.checked = true;
        if ('indeterminate' in chkbox_select_all) {
            chkbox_select_all.indeterminate = false;
        }

        // If some of the checkboxes are checked
    } else {
        chkbox_select_all.checked = true;
        if ('indeterminate' in chkbox_select_all) {
            chkbox_select_all.indeterminate = true;
        }
    }
}

$(document).ready(function () {
    // Array holding selected row IDs
    var rows_selected = [];
    var table = $('#example').DataTable({
        initComplete: function () {
            this.api()
                .columns()
                .every(function () {
                    var column = this;
                    var select = $('<select><option value=""></option></select>')
                        .appendTo($(column.header()).empty())
                        .on('change', function () {
                            var val = $.fn.dataTable.util.escapeRegex($(this).val());

                            column.search(val ? '^' + val + '$' : '', true, false).draw();
                        });

                    column
                        .data()
                        .unique()
                        .sort()
                        .each(function (d, j) {
                            select.append('<option value="' + d + '">' + d + '</option>');
                        });
                });
        },
        'columnDefs': [{
            'targets': 0,
            'searchable': false,
            'orderable': false,
            'width': '1%',
            'className': 'dt-body-center',
            'render': function (data, type, full, meta) {
                return '<input type="checkbox">';
            }
        }],
        'order': [[1, 'asc']],
        'rowCallback': function (row, data, dataIndex) {
            // Get row ID
            var rowId = data[0];

            // If row ID is in the list of selected row IDs
            if ($.inArray(rowId, rows_selected) !== -1) {
                $(row).find('input[type="checkbox"]').prop('checked', true);
                $(row).addClass('selected');
            }
        }
    });

    // Handle click on checkbox
    $('#example tbody').on('click', 'input[type="checkbox"]', function (e) {
        var $row = $(this).closest('tr');

        // Get row data
        var data = table.row($row).data();

        // Get row ID
        var rowId = data[0];

        // Determine whether row ID is in the list of selected row IDs
        var index = $.inArray(rowId, rows_selected);

        // If checkbox is checked and row ID is not in list of selected row IDs
        if (this.checked && index === -1) {
            rows_selected.push(rowId);

            // Otherwise, if checkbox is not checked and row ID is in list of selected row IDs
        } else if (!this.checked && index !== -1) {
            rows_selected.splice(index, 1);
        }

        if (this.checked) {
            $row.addClass('selected');
        } else {
            $row.removeClass('selected');
        }

        // Update state of "Select all" control
        updateDataTableSelectAllCtrl(table);

        // Prevent click event from propagating to parent
        e.stopPropagation();
    });

    // Handle click on table cells with checkboxes
    $('#example').on('click', 'tbody td, thead th:first-child', function (e) {
        $(this).parent().find('input[type="checkbox"]').trigger('click');
    });

    // Handle click on "Select all" control
    $('thead input[name="select_all"]', table.table().container()).on('click', function (e) {
        if (this.checked) {
            $('#example tbody input[type="checkbox"]:not(:checked)').trigger('click');
        } else {
            $('#example tbody input[type="checkbox"]:checked').trigger('click');
        }

        // Prevent click event from propagating to parent
        e.stopPropagation();
    });

    // Handle table draw event
    table.on('draw', function () {
        // Update state of "Select all" control
        updateDataTableSelectAllCtrl(table);
    });

    // Handle form submission event
    //$('#frm-example').on('submit', function (e) {
    //    var form = this;
    //    var arr = [];

    //    // Iterate over all selected checkboxes
    //   var str = $.each(rows_selected, function (index, rowId) {
    //        // Create a hidden element
    //        $(form).append(
    //            $('<input>')
    //                .attr('type', 'hidden')
    //                .attr('name', 'id[]')
    //                .val(rowId)
    //        );
    //    });

    //    //var str = $(form).rows_selected;
    //    console.log(str);
    //    arr.push(str);

    //    for (var i = 0; i < arr.length; i++) {

    //        alert(arr[i]);
    //    }
    //    //$('#example-console').text($(form).serialize());
    //    //console.log("Form submission", $(form).serialize());


    //    //// Remove added elements
    //    //$('input[name="id\[\]"]', form).remove();

    //    e.preventDefault();
    //    var url = 'Approve';
    //    fetch(url, {
    //        method: 'POST', // or 'PUT'
    //        body: JSON.stringify(str),
    //        headers: {
    //            'Accept': 'application/json; charset=utf-8',
    //            'Content-Type': 'application/json;charset=UTF-8'
    //        }
    //    }).then(res => res.json())
    //        .then(response => console.log('Success:'))
    //        .catch(error => console.error('Error:', error));
    //    window.location = 'http://localhost:10001/RMscreen/index'

    //});


    //$('#frm-example1').on('submit', function (e) {
    //    var form = this;
    //    var arr = [];

    //    // Iterate over all selected checkboxes
    //    var str = $.each(rows_selected, function (index, rowId) {
    //        // Create a hidden element
    //        $(form).append(
    //            $('<input>')
    //                .attr('type', 'hidden')
    //                .attr('name', 'id[]')
    //                .val(rowId)
    //        );
    //    });

    //    //var str = $(form).rows_selected;
    //    console.log(str);
    //    arr.push(str);

    //    for (var i = 0; i < arr.length; i++) {

    //        alert(arr[i]);
    //    }
    //    //$('#example-console').text($(form).serialize());
    //    //console.log("Form submission", $(form).serialize());


    //    //// Remove added elements
    //    //$('input[name="id\[\]"]', form).remove();

    //    e.preventDefault();
    //    var url = 'Reject';
    //    fetch(url, {
    //        method: 'POST', // or 'PUT'
    //        body: JSON.stringify(str),
    //        headers: {
    //            'Accept': 'application/json; charset=utf-8',
    //            'Content-Type': 'application/json;charset=UTF-8'
    //        }
    //    }).then(res => res.json())
    //        .then(response => console.log('Success:'))
    //        .catch(error => console.error('Error:', error));
    //    window.location = 'http://localhost:10001/RMscreen/index'

    //});

    $('#frm-example-approve').on('submit', function (e) {
        var form = this;
        var arr = [];

        // Iterate over all selected checkboxes
        var str = $.each(rows_selected, function (index, rowId) {
            // Create a hidden element
            $(form).append(
                $('<input>')
                    .attr('type', 'hidden')
                    .attr('name', 'id[]')
                    .val(rowId)
            );
        });

        //var str = $(form).rows_selected;
        console.log(str);
        arr.push(str);

        for (var i = 0; i < arr.length; i++) {

            //alert(arr[i]);
        }

        e.preventDefault();
        var url = 'Approve';
        fetch(url, {
            method: 'POST', // or 'PUT'
            body: JSON.stringify(str),
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            }
        }).then(res => res.json())
            .then(response => console.log('Success:'))
            .catch(error => console.error('Error:', error));
        window.location = 'http://localhost:10001/RMscreen/index'

    });


    $('#frm-example-reject').on('submit', function (e) {
        var form = this;
        var arr = [];

        // Iterate over all selected checkboxes
        var str = $.each(rows_selected, function (index, rowId) {
            // Create a hidden element
            $(form).append(
                $('<input>')
                    .attr('type', 'hidden')
                    .attr('name', 'id[]')
                    .val(rowId)
            );
        });

        //var str = $(form).rows_selected;
        console.log(str);
        arr.push(str);

        for (var i = 0; i < arr.length; i++) {

            //alert(arr[i]);
        }

        e.preventDefault();
        var url = 'Reject';
        fetch(url, {
            method: 'POST', // or 'PUT'
            body: JSON.stringify(str),
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            }
        }).then(res => res.json())
            .then(response => console.log('Success:'))
            .catch(error => console.error('Error:', error));
        window.location = 'http://localhost:10001/RMscreen/index'

    });

    $('#approve-btn').on('click', async function (e) {

        var form = this;
        var arr = [];

        // Iterate over all selected checkboxes
        var str = $.each(rows_selected, function (index, rowId) {
            // Create a hidden element
            $(form).append(
                $('<input>')
                    .attr('type', 'hidden')
                    .attr('name', 'id[]')
                    .val(rowId)
            );
        });

        //var str = $(form).rows_selected;
        //console.log(str);
        arr.push(str);

        for (var i = 0; i < arr.length; i++) {

            //alert(arr[i]);
        }

        e.preventDefault();
        var url = 'Approve';
        await fetch(url, {
            method: 'POST', // or 'PUT'
            body: JSON.stringify(str),
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            }
        }).then(res => res.json())
            .then(response => console.log('Success:'))
            .catch(error => console.error('Error:', error));
        window.location = 'https://mytime-uat.in.myatos.net/RM_SCREEN/Index'
    });

    $('#reject-btn').on('click', async function (e) {

        var form = this;
        var arr = [];

        // Iterate over all selected checkboxes
        var str = $.each(rows_selected, function (index, rowId) {
            // Create a hidden element
            $(form).append(
                $('<input>')
                    .attr('type', 'hidden')
                    .attr('name', 'id[]')
                    .val(rowId)
            );
        });

        //var str = $(form).rows_selected;
        //console.log(str);
        arr.push(str);

        for (var i = 0; i < arr.length; i++) {

            //alert(arr[i]);
        }

        e.preventDefault();
        var url = 'Reject';
        await fetch(url, {
            method: 'POST', // or 'PUT'
            body: JSON.stringify(str),
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            }
        }).then(res => res.json())
            .then(response => console.log('Success:'))
            .catch(error => console.error('Error:', error));
        window.location = 'https://mytime-uat.in.myatos.net/RM_SCREEN/Index'
    });


    $('#reconcile-btn').on('click', async function (e) {

        var form = this;
        var arr = [];

        // Iterate over all selected checkboxes
        var str = $.each(rows_selected, function (index, rowId) {
            // Create a hidden element
            $(form).append(
                $('<input>')
                    .attr('type', 'hidden')
                    .attr('name', 'id[]')
                    .val(rowId)
            );
        });

        //var str = $(form).rows_selected;
       // console.log(str);
        arr.push(str);

        for (var i = 0; i < arr.length; i++) {

            //alert(arr[i]);
        }

        e.preventDefault();
        var url = 'GoToReconcile';
        await fetch(url, {
            method: 'Post',
            body: JSON.stringify(str),
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            }
        }).then(response => {
            var redirectURL = "";
            for (let i = 0; i < str.length; i++) {
                if (i < str.length - 1) {
                    redirectURL += "checkedInputs=" + str[i] + "&";
                }
                else {
                    redirectURL += "checkedInputs=" + str[i];
                }
            }
            //window.location.href = 'http://192.168.103.112:82/RM_SCREEN/Reconcile?' + redirectURL;
            window.location.href = 'https://mytime-uat.in.myatos.net/RM_SCREEN/Reconcile?' + redirectURL;
        })
            .catch(error => console.log('Error:', error));
    });
});