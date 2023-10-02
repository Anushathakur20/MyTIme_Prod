window.onload = function () {
    document.getElementById("viewlogdata").onclick = function () {

        var id = localStorage.getItem("ID")

        window.location = 'https://mytime.in.myatos.net/Home/Viewlog/' + id;
    }
    if (localStorage.getItem("log") != null) {
        document.getElementById("Logout_BTN").style.display = "block";
    }
    //if (localStorage.getItem("C_Status") == "LOGOUT") {
    //    window.location = 'https://mytime.in.myatos.net/Home/Index'
    //}
    $(document).ready(function () {
        $('#getTableRow').DataTable({
            "scrollX": true,
            "scrollY": 200,
            "searching": false,
            "info": false,
            "paging": false,
            'rowCallback': function (row, data, index) {
                //if (data[8] == '00:00:00') {
                //    $(row).find('td:eq(8)').css('color', 'green');
                //}
                if (data[8] > '00:00:00') {
                    $(row).find('td:eq(8)').css('color', '#F7A4A4');
                }
                //if (data[8] >= '02:00:00') {
                //    $(row).find('td:eq(8)').css('color', 'red');
                //}
                if (data[12] > '01:00:00') {
                    $(row).find('td:eq(12)').css('color', '#F7A4A4');
                }
            }
        });
        $('.dataTables_length').addClass('bs-select');
    });


    //var table = document.getElementById("getTableRow");
    //for (var i = 0, row; row = table.rows[i]; i++) {
    //    for (var j = 0, cell; cell = row.cells[j]; j++) {
    //        if (cell.innerText == '') {
    //            cell.style.backgroundColor = 'white';
    //        } else if (cell.innerText >= '00:00:00' ) {
    //            cell.style.backgroundColor = 'green';
    //        }
    //    }
    //}
    //$(document).ready(function () {
    //    $('#getTableRow tr td').each(function () {
    //        if ($(this).text() >= '00:00:00') {
    //            $(this).css('background-color', 'red');
    //        }
    //        //} else if ($(this).text() > 15 && $(this).text() <= 20) {
    //        //    $(this).css('background-color', 'RGBA(170,214,136,0.4)');
    //        //} else if ($(this).text() > 20 && $(this).text() <= 25) {
    //        //    $(this).css('background-color', 'RGBA(152,195,119,0.6)');
    //        //} else if ($(this).text() > 25 && $(this).text() <= 30) {
    //        //    $(this).css('background-color', 'RGBA(139,189,120,0.9)');
    //        //} else if ($(this).text() > 30) {
    //        //    $(this).css('background-color', 'RGBA(94,167,88,0.9)');
    //        //}
    //    });
    //});
    if (localStorage.getItem("C_Status") != null) {
        var Status = localStorage.getItem("C_Status");
        document.getElementById("Current_Status_txt").value = Status;
        var p_status = document.getElementById("Current_Status_txt").value
    }


    var T_Login = localStorage.getItem("log");
    if (T_Login == null) {
        console.log(T_Login);
    }
    else {
        document.getElementById("c_Time").value = T_Login;
        var Act_Second = localStorage.getItem("Activity_Second");
        if (Act_Second == null) {
        }
        else {
            var Act_First = localStorage.getItem("Activity_First");
            var datetime1 = moment(Act_Second, "YYYY-MM-DD HH:mm:ss");
            var datetime2 = moment(Act_First, "YYYY-MM-DD HH:mm:ss");
            var duration = moment.duration(datetime1.diff(datetime2));
            var hours = parseInt(duration.asHours());
            var minutes = parseInt(duration.asMinutes()) % 60;
            var seconds = parseInt(duration.asSeconds()) % 60;

            if (minutes < 10) minutes = '0' + minutes;
            if (hours < 10) hours = '0' + hours;
            if (seconds < 10) seconds = '0' + seconds;

            var result = hours + ':' + minutes + ':' + seconds;
            //console.log(result);
            document.getElementById("Total_txt").value = result;
            //alert(result);


        }
    }
    //if (login_t == " ") {
    var login_T = localStorage.getItem("Login_time");
    document.getElementById('log').value = login_T;


    if (document.getElementById("Current_Status_txt").value == "LOGIN") {
        document.getElementById("GetNow").disabled = true;
        //document.getElementById("btn").style.display = "block";
    }
    if (document.getElementById("Current_Status_txt").value == "WORK" || document.getElementById("Current_Status_txt").value == "LOGOUT") {
        document.getElementById("work").disabled = true;
        //document.getElementById("btn").style.display = "block";
    }
    if (document.getElementById("Current_Status_txt").value == "MEETING" || document.getElementById("Current_Status_txt").value == "LOGOUT") {
        document.getElementById("meeting").disabled = true;
        //document.getElementById("btn").style.display = "block";
    }
    if (document.getElementById("Current_Status_txt").value == "TRAINING" || document.getElementById("Current_Status_txt").value == "LOGOUT") {
        document.getElementById("training").disabled = true;
        //document.getElementById("btn").style.display = "block";
    }
    if (document.getElementById("Current_Status_txt").value == "BREAK" || document.getElementById("Current_Status_txt").value == "LOGOUT") {
        document.getElementById("breaks").disabled = true;
        //document.getElementById("btn").style.display = "block";
    }
    if (document.getElementById("Current_Status_txt").value == "AUXILIARY" || document.getElementById("Current_Status_txt").value == "LOGOUT") {
        document.getElementById("auxiliary").disabled = true;
        //document.getElementById("btn").style.display = "block";
    }
    if (document.getElementById("Current_Status_txt").value == "LOGOUT") {
        document.getElementById("Logout_BTN").disabled = true;
        //document.getElementById("btn").style.display = "block";
    }

    document.getElementById("GetNow").onclick = async function GetNow() {

        var url = 'InsertActivity';
        var now = moment();
        var datetimeString = now.format("YYYY-MM-DD HH:mm:ss");
        console.log(datetimeString); // Output: "2023-04-03 14:30:00"
        localStorage.setItem("Login_time", "login");
        localStorage.setItem("log", datetimeString);

        var login_T = localStorage.getItem("Login_time");
        var Comment = document.getElementById("Comment").value;

        var checkedInputs = 'Login' + '|' + document.getElementById("Comment").value;
        var state = 'LOGIN';
        localStorage.setItem("C_Status", state);

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
        //window.location = 'https://localhost:44363/Home/Index'
        window.location = 'https://mytime.in.myatos.net/Home/Index'


    }
    document.getElementById("work").onclick = async function work() {
        if (document.getElementById("log").value == "") {
            Swal.fire({
                title: "Alert",
                text: "Please Login First!",
                icon: 'warning',
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Okay!'
            })
        }
        else {
            var now = moment();
            var datetimeString = now.format("YYYY-MM-DD HH:mm:ss");
            console.log(datetimeString);
            var Act_Status = localStorage.getItem("C_Status");
            if (Act_Status == "LOGIN") {
                localStorage.setItem("Activity_First", datetimeString);
            }
            else {
                localStorage.setItem("Activity_Second", datetimeString);
            }

            var url = 'InsertActivity';
            var checkedInputs = 'Work' + '|' + document.getElementById("Comment").value;
            var state = 'WORK';
            localStorage.setItem("C_Status", state);

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
            //window.location = 'https://localhost:44363/Activity/Index'
            window.location = 'https://mytime.in.myatos.net/Home/Index'
        }
    }
    document.getElementById("meeting").onclick = async function meeting() {
        if (document.getElementById("log").value == "") {
            Swal.fire({
                title: "Alert",
                text: "Please Login First!",
                icon: 'warning',
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Okay!'
            })
        }
        else {
            var now = moment();
            var datetimeString = now.format("YYYY-MM-DD HH:mm:ss");
            console.log(datetimeString);
            var Act_Status = localStorage.getItem("C_Status");
            if (Act_Status == "LOGIN") {
                localStorage.setItem("Activity_First", datetimeString);
            }
            else {
                localStorage.setItem("Activity_Second", datetimeString);
            }

            var url = 'InsertActivity';
            var checkedInputs = 'Meeting' + '|' + document.getElementById("Comment").value;
            var state = 'MEETING';
            localStorage.setItem("C_Status", state);


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
            //window.location = 'https://localhost:44363/Activity/Index'
            window.location = 'https://mytime.in.myatos.net/Home/Index'
        }
    }
    document.getElementById("training").onclick = async function training() {
        if (document.getElementById("log").value == "") {
            Swal.fire({
                title: "Alert",
                text: "Please Login First!",
                icon: 'warning',
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Okay!'
            })
        }
        else {
            var now = moment();
            var datetimeString = now.format("YYYY-MM-DD HH:mm:ss");
            console.log(datetimeString);
            var Act_Status = localStorage.getItem("C_Status");
            if (Act_Status == "LOGIN") {
                localStorage.setItem("Activity_First", datetimeString);
            }
            else {
                localStorage.setItem("Activity_Second", datetimeString);
            }

            var url = 'InsertActivity';
            var checkedInputs = 'Training' + '|' + document.getElementById("Comment").value;
            var state = 'TRAINING';
            localStorage.setItem("C_Status", state);


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
            //window.location = 'https://localhost:44363/Activity/Index'
            window.location = 'https://mytime.in.myatos.net/Home/Index'
        }
    }
    document.getElementById("breaks").onclick = async function breaks() {
        if (document.getElementById("log").value == "") {
            Swal.fire({
                title: "Alert",
                text: "Please Login First!",
                icon: 'warning',
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Okay!'
            })
        }
        else {

            var now = moment();
            var datetimeString = now.format("YYYY-MM-DD HH:mm:ss");
            console.log(datetimeString);
            var Act_Status = localStorage.getItem("C_Status");
            if (Act_Status == "LOGIN") {
                localStorage.setItem("Activity_First", datetimeString);
            }
            else {
                localStorage.setItem("Activity_Second", datetimeString);
            }

            var url = 'InsertActivity';
            var checkedInputs = 'Break' + '|' + document.getElementById("Comment").value;
            var state = 'BREAK';
            localStorage.setItem("C_Status", state);


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
            //window.location = 'https://localhost:44363/Activity/Index'
            window.location = 'https://mytime.in.myatos.net/Home/Index'
        }
    }
    document.getElementById("auxiliary").onclick = async function auxiliary() {
        if (document.getElementById("log").value == "") {
            Swal.fire({
                title: "Alert",
                text: "Please Login First!",
                icon: 'warning',
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Okay!'
            })
        }
        else {
            var now = moment();
            var datetimeString = now.format("YYYY-MM-DD HH:mm:ss");
            console.log(datetimeString);
            var Act_Status = localStorage.getItem("C_Status");
            if (Act_Status == "LOGIN") {
                localStorage.setItem("Activity_First", datetimeString);
            }
            else {
                localStorage.setItem("Activity_Second", datetimeString);
            }

            var url = 'InsertActivity';

            var checkedInputs = 'Auxiliary' + '|' + document.getElementById("Comment").value;
            var state = 'AUXILIARY';
            localStorage.setItem("C_Status", state);


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
            //window.location = 'https://localhost:44363/Activity/Index'
            window.location = 'https://mytime.in.myatos.net/Home/Index'
        }
    }
    //document.getElementById("btn").onclick =  function btn() {
    //        var url = 'LogoutActivity';
    //        localStorage.clear();
    //        sessionStorage.clear();
    //         var state = 'LOGOUT';
    //        localStorage.setItem("C_Status", state);
    //         fetch(url, {
    //            method: 'POST', // or 'PUT'
    //            body: JSON.stringify(),
    //            headers: {
    //                'Accept': 'application/json; charset=utf-8',
    //                'Content-Type': 'application/json;charset=UTF-8'
    //            }
    //        }).then(res => res.json())
    //            .then(response => console.log('Success:'))
    //            .catch(error => console.error('Error:', error));
    //        window.location = 'https://localhost:44363/Home/Index'
    //        //window.location = 'https://mytime.in.myatos.net/Home/Index'

    //}

    document.getElementById("Logout_BTN").onclick = async function () {
        var url = 'LogoutActivity';
        localStorage.clear();
        sessionStorage.clear();
        var state = 'LOGOUT';
        localStorage.setItem("C_Status", state);
        await fetch(url, {
            method: 'POST', // or 'PUT'
            body: JSON.stringify(),
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            }
        }).then(res => res.json())
            .then(response => console.log('Success:'))
            .catch(error => console.error('Error:', error));
        //window.location.href ='https://localhost:44363/Home/index'
        window.location = 'https://mytime.in.myatos.net/Home/Index'
    }

    if (document.getElementById("getloginlogouttotal").rows[1].cells.item(0).innerHTML != " ") {
        var getlogin = document.getElementById("getloginlogouttotal").rows[1].cells.item(0).innerHTML;
        document.getElementById("c_Time").value = getlogin;
        var gettotaltime = document.getElementById("getloginlogouttotal").rows[1].cells.item(2).innerHTML;
        document.getElementById("Total_txt").value = gettotaltime;
        var getlogout = document.getElementById("getloginlogouttotal").rows[1].cells.item(1).innerHTML;
        document.getElementById("getctime").value = getlogout;

        if (Act_Second == null) {
        }
        else {

            var resultTime = moment.duration(result);
            var totalTime = moment.duration(gettotaltime);
            var sumTime = resultTime.add(totalTime);

            var hoursSum = Math.floor(sumTime.asHours());
            var minutesSum = Math.floor(sumTime.asMinutes() % 60);
            var secondsSum = Math.floor(sumTime.asSeconds() % 60);

            if (minutesSum < 10) minutesSum = '0' + minutesSum;
            if (hoursSum < 10) hoursSum = '0' + hoursSum;
            if (secondsSum < 10) secondsSum = '0' + secondsSum;

            var totalTimeSum = hoursSum + ":" + minutesSum + ":" + secondsSum;
            document.getElementById("Total_txt").value = totalTimeSum;

        }
    }
    //} else {
    //    document.getElementById("c_Time").value = "";
    //    document.getElementById("Total_txt").value = "";
    //    document.getElementById("getctime").value = "";
    //}


}





////window.onload = function () {
////    document.getElementById("viewlogdata").onclick = function () {

////        var id = localStorage.getItem("ID")

////        window.location = 'https://mytime.in.myatos.net/Home/Viewlog/' + id;
////    }
////    if (localStorage.getItem("log") != null) {
////        document.getElementById("Logout_BTN").style.display = "block";
////    }
////    //if (localStorage.getItem("C_Status") == "LOGOUT") {
////    //    window.location = 'https://mytime.in.myatos.net/Home/Index'
////    //}
////    $(document).ready(function () {
////        $('#getTableRow').DataTable({
////            "scrollX": true,
////            "scrollY": 200,
////            "searching": false,
////            "info": false,
////            "paging": false,
////            'rowCallback': function (row, data, index) {
////                //if (data[8] == '00:00:00') {
////                //    $(row).find('td:eq(8)').css('color', 'green');
////                //}
////                if (data[8] > '00:00:00') {
////                    $(row).find('td:eq(8)').css('color', '#F7A4A4');
////                }
////                //if (data[8] >= '02:00:00') {
////                //    $(row).find('td:eq(8)').css('color', 'red');
////                //}
////                if (data[12] > '01:00:00') {
////                    $(row).find('td:eq(12)').css('color', '#F7A4A4');
////                }
////            }
////        });
////        $('.dataTables_length').addClass('bs-select');
////    });


////    //var table = document.getElementById("getTableRow");
////    //for (var i = 0, row; row = table.rows[i]; i++) {
////    //    for (var j = 0, cell; cell = row.cells[j]; j++) {
////    //        if (cell.innerText == '') {
////    //            cell.style.backgroundColor = 'white';
////    //        } else if (cell.innerText >= '00:00:00' ) {
////    //            cell.style.backgroundColor = 'green';
////    //        }
////    //    }
////    //}
////    //$(document).ready(function () {
////    //    $('#getTableRow tr td').each(function () {
////    //        if ($(this).text() >= '00:00:00') {
////    //            $(this).css('background-color', 'red');
////    //        }
////    //        //} else if ($(this).text() > 15 && $(this).text() <= 20) {
////    //        //    $(this).css('background-color', 'RGBA(170,214,136,0.4)');
////    //        //} else if ($(this).text() > 20 && $(this).text() <= 25) {
////    //        //    $(this).css('background-color', 'RGBA(152,195,119,0.6)');
////    //        //} else if ($(this).text() > 25 && $(this).text() <= 30) {
////    //        //    $(this).css('background-color', 'RGBA(139,189,120,0.9)');
////    //        //} else if ($(this).text() > 30) {
////    //        //    $(this).css('background-color', 'RGBA(94,167,88,0.9)');
////    //        //}
////    //    });
////    //});
////    if (localStorage.getItem("C_Status") != null) {
////        var Status = localStorage.getItem("C_Status");
////        document.getElementById("Current_Status_txt").value = Status;
////        var p_status = document.getElementById("Current_Status_txt").value   
////    }
////    var T_Login = localStorage.getItem("log");
////    if (T_Login != "") {
////        document.getElementById("c_Time").value = T_Login;
////    }
////    //if (login_t == " ") {
////        var login_T = localStorage.getItem("Login_time");
////        document.getElementById('log').value = login_T;    
////    /*} else{*/
////        //var getlogin = document.getElementById("getloginlogouttotal").rows[1].cells.item(0).innerHTML;
////        //document.getElementById("c_Time").value = getlogin;
////        //var 
////        //document.getElementById("getloginlogouttotal").rows[1].cells.item(2).innerHTML;
////        //document.getElementById("Total_txt").value = gettotaltime;
////        //var getlogout = document.getElementById("getloginlogouttotal").rows[1].cells.item(1).innerHTML;
////        //document.getElementById("getctime").value = getlogout;
////    /*  }*/
   
////    if (document.getElementById("Current_Status_txt").value == "LOGIN" ) {
////        document.getElementById("GetNow").disabled = true;
////        //document.getElementById("btn").style.display = "block";
////    }
////    if (document.getElementById("Current_Status_txt").value == "WORK" || document.getElementById("Current_Status_txt").value == "LOGOUT") {
////        document.getElementById("work").disabled = true;
////        //document.getElementById("btn").style.display = "block";
////    }
////    if (document.getElementById("Current_Status_txt").value == "MEETING" || document.getElementById("Current_Status_txt").value == "LOGOUT") {
////        document.getElementById("meeting").disabled = true;
////        //document.getElementById("btn").style.display = "block";
////    }
////    if (document.getElementById("Current_Status_txt").value == "TRAINING" || document.getElementById("Current_Status_txt").value == "LOGOUT") {
////        document.getElementById("training").disabled = true;
////        //document.getElementById("btn").style.display = "block";
////    }
////    if (document.getElementById("Current_Status_txt").value == "BREAK" || document.getElementById("Current_Status_txt").value == "LOGOUT") {
////        document.getElementById("breaks").disabled = true;
////        //document.getElementById("btn").style.display = "block";
////    }
////    if (document.getElementById("Current_Status_txt").value == "AUXILIARY" || document.getElementById("Current_Status_txt").value == "LOGOUT") {
////        document.getElementById("auxiliary").disabled = true;
////        //document.getElementById("btn").style.display = "block";
////    }
////    if (document.getElementById("Current_Status_txt").value == "LOGOUT") {
////        document.getElementById("Logout_BTN").disabled = true;
////        //document.getElementById("btn").style.display = "block";
////    }

////    document.getElementById("GetNow").onclick = async function GetNow() {
     
////        var url = 'InsertActivity';
////        var date = new Date();
////        var current_date = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
////        var current_time = date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
////        var date_time = current_date + " " + current_time;
////        localStorage.setItem("Login_time", "login");
////        //var log1 = document.getElementById("GetStarttime").rows[1].cells.item(4).innerHTML;
////        localStorage.setItem("log", date_time);
       
////        var login_T = localStorage.getItem("Login_time");
////        var Comment = document.getElementById("Comment").value;
     
////        var checkedInputs = 'Login' + '|' + document.getElementById("Comment").value;
////        var state = 'LOGIN';
////        localStorage.setItem("C_Status", state);
       
////        await fetch(url, {
////            method: 'POST', // or 'PUT'
////            body: JSON.stringify(checkedInputs),
////            headers: {
////                'Accept': 'application/json; charset=utf-8',
////                'Content-Type': 'application/json;charset=UTF-8'
////            }
////        }).then(res => res.json())
////            .then(response => console.log('Success:'))
////            .catch(error => console.error('Error:', error));
////        //window.location = 'https://localhost:44363/Home/Index'
////       window.location = 'https://mytime.in.myatos.net/Home/Index'
        
       
////    }
////    document.getElementById("work").onclick = async function work() {
////        if (document.getElementById("log").value == "") {
////            Swal.fire({
////                title: "Alert",
////                text: "Please Login First!",
////                icon: 'warning',
////                showCancelButton: false,
////                confirmButtonColor: '#3085d6',
////                confirmButtonText: 'Okay!'
////            })
////        }
////        else {
////            var url = 'InsertActivity';
////            var checkedInputs = 'Work' + '|' + document.getElementById("Comment").value;
////            var state = 'WORK';
////            localStorage.setItem("C_Status", state);

////            await fetch(url, {
////                method: 'POST', // or 'PUT'
////                body: JSON.stringify(checkedInputs),
////                headers: {
////                    'Accept': 'application/json; charset=utf-8',
////                    'Content-Type': 'application/json;charset=UTF-8'
////                }
////            }).then(res => res.json())
////                .then(response => console.log('Success:'))
////                .catch(error => console.error('Error:', error));
////            //window.location = 'https://localhost:44363/Activity/Index'
////            window.location = 'https://mytime.in.myatos.net/Home/Index'
////        }
////    }
////    document.getElementById("meeting").onclick = async function meeting() {
////        if (document.getElementById("log").value == "") {
////            Swal.fire({
////                title: "Alert",
////                text: "Please Login First!",
////                icon: 'warning',
////                showCancelButton: false,
////                confirmButtonColor: '#3085d6',
////                confirmButtonText: 'Okay!'
////            })
////        }
////        else {
////            var url = 'InsertActivity';
////            var checkedInputs = 'Meeting' + '|' + document.getElementById("Comment").value;
////            var state = 'MEETING';
////            localStorage.setItem("C_Status", state);


////            await fetch(url, {
////                method: 'POST', // or 'PUT'
////                body: JSON.stringify(checkedInputs),
////                headers: {
////                    'Accept': 'application/json; charset=utf-8',
////                    'Content-Type': 'application/json;charset=UTF-8'
////                }
////            }).then(res => res.json())
////                .then(response => console.log('Success:'))
////                .catch(error => console.error('Error:', error));
////             //window.location = 'https://localhost:44363/Activity/Index'
////            window.location = 'https://mytime.in.myatos.net/Home/Index'
////        }
////    }
////    document.getElementById("training").onclick = async function training() {
////        if (document.getElementById("log").value == "") {
////            Swal.fire({
////                title: "Alert",
////                text: "Please Login First!",
////                icon: 'warning',
////                showCancelButton: false,
////                confirmButtonColor: '#3085d6',
////                confirmButtonText: 'Okay!'
////            })
////        }
////        else {
////            var url = 'InsertActivity';
////            var checkedInputs = 'Training' + '|' + document.getElementById("Comment").value;
////            var state = 'TRAINING';
////            localStorage.setItem("C_Status", state);


////            await fetch(url, {
////                method: 'POST', // or 'PUT'
////                body: JSON.stringify(checkedInputs),
////                headers: {
////                    'Accept': 'application/json; charset=utf-8',
////                    'Content-Type': 'application/json;charset=UTF-8'
////                }
////            }).then(res => res.json())
////                .then(response => console.log('Success:'))
////                .catch(error => console.error('Error:', error));
////            //window.location = 'https://localhost:44363/Activity/Index'
////            window.location = 'https://mytime.in.myatos.net/Home/Index'
////        }
////    }
////    document.getElementById("breaks").onclick = async function breaks() {
////        if (document.getElementById("log").value == "") {
////            Swal.fire({
////                title: "Alert",
////                text: "Please Login First!",
////                icon: 'warning',
////                showCancelButton: false,
////                confirmButtonColor: '#3085d6',
////                confirmButtonText: 'Okay!'
////            })
////        }
////        else {

////            var url = 'InsertActivity';
////            var checkedInputs = 'Break' + '|' + document.getElementById("Comment").value;
////            var state = 'BREAK';
////            localStorage.setItem("C_Status", state);


////            await fetch(url, {
////                method: 'POST', // or 'PUT'
////                body: JSON.stringify(checkedInputs),
////                headers: {
////                    'Accept': 'application/json; charset=utf-8',
////                    'Content-Type': 'application/json;charset=UTF-8'
////                }
////            }).then(res => res.json())
////                .then(response => console.log('Success:'))
////                .catch(error => console.error('Error:', error));
////            //window.location = 'https://localhost:44363/Activity/Index'
////            window.location = 'https://mytime.in.myatos.net/Home/Index'
////        }
////    }
////    document.getElementById("auxiliary").onclick = async function auxiliary() {
////        if (document.getElementById("log").value == "") {
////            Swal.fire({
////                title: "Alert",
////                text: "Please Login First!",
////                icon: 'warning',
////                showCancelButton: false,
////                confirmButtonColor: '#3085d6',
////                confirmButtonText: 'Okay!'
////            })
////        }
////        else {
////            var url = 'InsertActivity';

////            var checkedInputs = 'Auxiliary' + '|' + document.getElementById("Comment").value;
////            var state = 'AUXILIARY';
////            localStorage.setItem("C_Status", state);


////            await fetch(url, {
////                method: 'POST', // or 'PUT'
////                body: JSON.stringify(checkedInputs),
////                headers: {
////                    'Accept': 'application/json; charset=utf-8',
////                    'Content-Type': 'application/json;charset=UTF-8'
////                }
////            }).then(res => res.json())
////                .then(response => console.log('Success:'))
////                .catch(error => console.error('Error:', error));
////            //window.location = 'https://localhost:44363/Activity/Index'
////           window.location = 'https://mytime.in.myatos.net/Home/Index'
////        }
////    }
////    //document.getElementById("btn").onclick =  function btn() {
////    //        var url = 'LogoutActivity';
////    //        localStorage.clear();
////    //        sessionStorage.clear();
////    //         var state = 'LOGOUT';
////    //        localStorage.setItem("C_Status", state);
////    //         fetch(url, {
////    //            method: 'POST', // or 'PUT'
////    //            body: JSON.stringify(),
////    //            headers: {
////    //                'Accept': 'application/json; charset=utf-8',
////    //                'Content-Type': 'application/json;charset=UTF-8'
////    //            }
////    //        }).then(res => res.json())
////    //            .then(response => console.log('Success:'))
////    //            .catch(error => console.error('Error:', error));
////    //        window.location = 'https://localhost:44363/Home/Index'
////    //        //window.location = 'https://mytime.in.myatos.net/Home/Index'
        
////    //}

////    document.getElementById("Logout_BTN").onclick = async function () {
////        var url = 'LogoutActivity';
////        localStorage.clear();
////        sessionStorage.clear();
////        var state = 'LOGOUT';
////        localStorage.setItem("C_Status", state);
////        await fetch(url, {
////            method: 'POST', // or 'PUT'
////            body: JSON.stringify(),
////            headers: {
////                'Accept': 'application/json; charset=utf-8',
////                'Content-Type': 'application/json;charset=UTF-8'
////            }
////        }).then(res => res.json())
////            .then(response => console.log('Success:'))
////            .catch(error => console.error('Error:', error));
////        //window.location.href ='https://localhost:44363/Home/index'
////        window.location = 'https://mytime.in.myatos.net/Home/Index'
////    }
  
////    if (document.getElementById("getloginlogouttotal").rows[1].cells.item(0).innerHTML != " ") {
////        var getlogin = document.getElementById("getloginlogouttotal").rows[1].cells.item(0).innerHTML;
////        document.getElementById("c_Time").value = getlogin;
////        var gettotaltime = document.getElementById("getloginlogouttotal").rows[1].cells.item(2).innerHTML;
////        document.getElementById("Total_txt").value = gettotaltime;
////        var getlogout = document.getElementById("getloginlogouttotal").rows[1].cells.item(1).innerHTML;
////        document.getElementById("getctime").value = getlogout;
////    }
////    //} else {
////    //    document.getElementById("c_Time").value = "";
////    //    document.getElementById("Total_txt").value = "";
////    //    document.getElementById("getctime").value = "";
////    //}
   
   
////}
