window.onload = function () {
    var date = new Date();
    var year = date.getFullYear();
    var month = date.getMonth() + 1;
    function getISOWeeksInMonth(month, year) {
        var d = new Date();
        var weekStart = new Date(d.setDate(d.getDate() - (d.getDay() + 6)));
        var weekEnd = new Date(weekStart);
        weekEnd.setDate(weekEnd.getDate() + 6);
        let weekNum = moment(weekStart, "YYYY-MM-DD").week()
        weekNum = weekNum - 2
        let wk = weekNum + 6;
        let weeks = [];
        do {
            weeks.push({
                weekNum: weekNum++,
                start: new moment(weekStart).format('ll').split(',')[0],
                end: new moment(weekEnd).format('ll').split(',')[0]
            });
            weekStart.setDate(weekStart.getDate() - 7);
            weekEnd.setDate(weekEnd.getDate() - 7);
        } while (weekNum < wk);
        console.log(weeks);
        for (var i in weeks) {
            var row = `<tr>
                <td>${weeks[i].weekNum}</td>
                 <td>${weeks[i].start}</td>
                  <td>${weeks[i].end}</td>
                  </tr>`
            var table = $('#table_body')
            table.append(row)
        }
        var getfirstmonday = document.getElementById("tablegetweeknum").rows[1].cells.item(1).innerHTML;
        var getfirstsunday = document.getElementById("tablegetweeknum").rows[1].cells.item(2).innerHTML;
        var getstartenddatefirst_weeknum = getfirstmonday + " " + 'To' + " " + getfirstsunday;
        document.getElementById("getwknum").rows[0].cells[1].innerHTML = getstartenddatefirst_weeknum;
        //alert(getstartenddatefirst_weeknum);
        var getsecmonday = document.getElementById("tablegetweeknum").rows[2].cells.item(1).innerHTML;
        var getsecsunday = document.getElementById("tablegetweeknum").rows[2].cells.item(2).innerHTML;
        var getstartenddatesec_weeknum = getsecmonday + " " + 'To' + " " + getsecsunday;
        document.getElementById("getwknum").rows[0].cells[2].innerHTML = getstartenddatesec_weeknum;
        //alert(getstartenddatesec_weeknum);
        var getthirdmonday = document.getElementById("tablegetweeknum").rows[3].cells.item(1).innerHTML;
        var getthirdsunday = document.getElementById("tablegetweeknum").rows[3].cells.item(2).innerHTML;
        var getstartenddatethird_weeknum = getthirdmonday + " " + 'To' + " " + getthirdsunday;
        document.getElementById("getwknum").rows[0].cells[3].innerHTML = getstartenddatethird_weeknum;
        //alert(getstartenddatethird_weeknum);
        var getfourthmonday = document.getElementById("tablegetweeknum").rows[4].cells.item(1).innerHTML;
        var getfourthsunday = document.getElementById("tablegetweeknum").rows[4].cells.item(2).innerHTML;
        var getstartenddatefourth_weeknum = getfourthmonday + " " + 'To' + " " + getfourthsunday;
        document.getElementById("getwknum").rows[0].cells[4].innerHTML = getstartenddatefourth_weeknum;
        //alert(getstartenddatefourth_weeknum);
        var getfifthmonday = document.getElementById("tablegetweeknum").rows[5].cells.item(1).innerHTML;
        var getfifthsunday = document.getElementById("tablegetweeknum").rows[5].cells.item(2).innerHTML;
        var getstartenddatefifth_weeknum = getfifthmonday + " " + 'To' + " " + getfifthsunday;
        document.getElementById("getwknum").rows[0].cells[5].innerHTML = getstartenddatefifth_weeknum;
        //alert(getstartenddatefifth_weeknum);
        return weeks;
    }
    getISOWeeksInMonth(month, year).forEach(week => console.log(
        'Week : ' + week.weekNum +
        '\nStart: ' + week.start +
        '\nEnd  : ' + week.end)
    );


    document.getElementById("approvevh").onclick = async function approveVH() {
        var url = 'Approve';
        /*var username = 'example'*/
        var checkedInputs = []
        var inputs = document.querySelectorAll('input[type=checkbox]')
        inputs = Array.from(inputs)
        if (document.getElementById('select-all').checked) {
            inputs.shift();
        }
        inputs.forEach(item => {
            if (item.checked)
                checkedInputs.push(item.getAttribute('data-id'))
        })
        await fetch(url, {
            method: 'POST', // or 'PUT'
            body: JSON.stringify(checkedInputs),
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            }
        }).then(res => res.json())
            .then(response => console.log('Success:'))
            .catch(error => console.error('Error:', error));
        // window.location = 'http://192.168.103.112:82/VH_SCREEN/Index'
        window.location = 'https://mytime-uat.in.myatos.net/VH_SCREEN/Index'
    }


    document.getElementById("rejectvh").onclick = async function rejectVH() {
        var url = 'Reject';
        /*var username = 'example'*/
        var checkedInputs = []
        var inputs = document.querySelectorAll('input[type=checkbox]')
        inputs = Array.from(inputs)
        if (document.getElementById('select-all').checked) { inputs.shift(); } inputs.forEach(item => {
            if (item.checked)
                checkedInputs.push(item.getAttribute('data-id'))
        })
        await fetch(url, {
            method: 'POST', // or 'PUT'  
            body: JSON.stringify(checkedInputs),
            headers: { 'Accept': 'application/json; charset=utf-8', 'Content-Type': 'application/json;charset=UTF-8' }
        }).then(res => res.json()).
            then(response => console.log('Success:')).
            catch(error => console.error('Error:', error));
        //window.location = 'http://192.168.103.112:82/VH_SCREEN/Index'
        window.location = 'https://mytime-uat.in.myatos.net/VH_SCREEN/Index'
    }

    document.getElementById("select-all").onclick = function selectAll() {
        var checkAll = document.getElementById('select-all');
        var inputs = document.querySelectorAll('input[type=checkbox]');
        if (checkAll.checked) {
            inputs.forEach(item => { item.checked = true; })
        }
        else {
            inputs.forEach(item => { item.checked = false; })
        }
    }
    //$(document).ready(function () {
    //    $('#getTableRow').DataTable({
    //        "scrollX": true,
    //        "scrollY": 200,
    //        "searching": false,
    //        "info": false,
    //        "paging": false
    //    });
    //    $('.dataTables_length').addClass('bs-select');
    //});
    $(document).ready(function () {
        $('#getTableRow').DataTable({
            "scrollX": true,
            "scrollY": 200,
            "searching": false,
            "info": false,
            "paging": false,
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
        $('.dataTables_length').addClass('bs-select');
    });
    $(document).ready(function () {
        $('#getwknum').DataTable({
            "scrollX": false,
            "scrollY": false,
            "searching": false,
            "info": false,
            "paging": false,
            'rowCallback': function (row, data, index) {
                //if (data[2] == '00:00:00') {
                //    $(row).find('td:eq(2)').css('background-color', '#E1FFB1');
                //}
                //if (data[3] == '00:00:00') {
                //    $(row).find('td:eq(3)').css('background-color', '#E1FFB1');
                //}
                //if (data[4] == '00:00:00') {
                //    $(row).find('td:eq(4)').css('background-color', '#E1FFB1');
                //}
                //if (data[5] == '00:00:00') {
                //    $(row).find('td:eq(5)').css('background-color', '#E1FFB1');
                //}
                //if (data[6] == '00:00:00') {
                //    $(row).find('td:eq(6)').css('background-color', '#E1FFB1');
                //}#DC3535
                if (data[2] > '00:00:00') {
                    $(row).find('td:eq(2)').css('background-color', '#F7A4A4');
                }
                if (data[3] > '00:00:00') {
                    $(row).find('td:eq(3)').css('background-color', '#F7A4A4');
                }
                if (data[4] > '00:00:00') {
                    $(row).find('td:eq(4)').css('background-color', '#F7A4A4');
                }
                if (data[5] > '00:00:00') {
                    $(row).find('td:eq(5)').css('background-color', '#F7A4A4');
                }
                if (data[6] > '00:00:00') {
                    $(row).find('td:eq(6)').css('background-color', '#F7A4A4');
                }

            }
        });
        $('.dataTables_length').addClass('bs-select');
    });
}
