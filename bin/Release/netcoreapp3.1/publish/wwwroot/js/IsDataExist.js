window.onload = function () {
 
    time_el = document.querySelector('.watch .stopwatch');
    star_btn = document.getElementById('start');
    stop_btn = document.getElementById('stop');
    reset_btn = document.getElementById('reset');
    const work_btn = document.getElementById('work');
    const meeting_btn = document.getElementById('meeting');
    const training_btn = document.getElementById('training');
    const breaks_btn = document.getElementById('breaks');
    const auxiliary_btn = document.getElementById('auxiliary');

    seconds = 0;
    interval = null;

    //Event Listener

    //star_btn.addEventListener('click', start);
    //stop_btn.addEventListener('click', stop);
    //reset_btn.addEventListener('click', reset); 
    //work_btn.addEventListener('click', work); 
    //meeting_btn.addEventListener('click', meeting);
    //training_btn.addEventListener('click', training);
    //breaks_btn.addEventListener('click', breaks); 
    //auxiliary_btn.addEventListener('click', auxiliary);



    //for (let elem of document.querySelectorAll('button'))
    //{
    //    elem.addEventListener("click", e => console.log("Capturing:", elem.tagName), true);
    //}

    document.getElementById("work").onclick = function () {
        //localStorage.setItem("clickedButton", work);
        if (document.getElementById("currentTime").value == "") {
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

            document.getElementById("work").style.backgroundColor = "blue";

            //console.log(localStorage.getItem("clickedButton"));
            stop();
            Common_Activity("work");
            reset();
            start();
            localStorage.setItem("currentstatus", "work");
            console.log(localStorage.getItem("currentstatus"));
            console.log(localStorage.getItem("work"));
            console.log(localStorage.getItem("training"));
            console.log(localStorage.getItem("meeting"));
            console.log(localStorage.getItem("breaks"));
            console.log(localStorage.getItem("auxiliary"));
        }
    }
    document.getElementById("meeting").onclick = function () {
        if (document.getElementById("currentTime").value == "") {
            Swal.fire({
                title: "Alert",
                text: "Please Login First!",
                icon: 'warning',
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Okay!'
            })
        } else {
            document.getElementById("meeting").style.backgroundColor = "blue";
            stop();
            Common_Activity("meeting");
            reset();
            start();
            localStorage.setItem("currentstatus", "meeting");
            console.log(localStorage.getItem("currentstatus"));
            console.log(localStorage.getItem("work"));
            console.log(localStorage.getItem("training"));
            console.log(localStorage.getItem("meeting"));
            console.log(localStorage.getItem("breaks"));
            console.log(localStorage.getItem("auxiliary"));
        }
    }
    document.getElementById("training").onclick = function () {
        if (document.getElementById("currentTime").value == "") {
            Swal.fire({
                title: "Alert",
                text: "Please Login First!",
                icon: 'warning',
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Okay!'
            })
        } else {
            document.getElementById("training").style.backgroundColor = "blue";
            stop();
            Common_Activity("training");
            reset();
            start();
            localStorage.setItem("currentstatus", "training");

            console.log(localStorage.getItem("currentstatus"));
            console.log(localStorage.getItem("work"));
            console.log(localStorage.getItem("training"));
            console.log(localStorage.getItem("meeting"));
            console.log(localStorage.getItem("breaks"));
            console.log(localStorage.getItem("auxiliary"));
        }
    }
    document.getElementById("breaks").onclick = function () {
        if (document.getElementById("currentTime").value == "") {
            Swal.fire({
                title: "Alert",
                text: "Please Login First!",
                icon: 'warning',
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Okay!'
            })
        } else {
            document.getElementById("breaks").style.backgroundColor = "blue";
            stop();
            Common_Activity("breaks");
            reset();
            start();
            localStorage.setItem("currentstatus", "breaks");
            console.log(localStorage.getItem("currentstatus"));
            console.log(localStorage.getItem("work"));
            console.log(localStorage.getItem("training"));
            console.log(localStorage.getItem("meeting"));
            console.log(localStorage.getItem("breaks"));
            console.log(localStorage.getItem("auxiliary"));
        }
    }
    document.getElementById("auxiliary").onclick = function () {
        if (document.getElementById("currentTime").value == "") {
            Swal.fire({
                title: "Alert",
                text: "Please Login First!",
                icon: 'warning',
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Okay!'
            })
        } else {
            document.getElementById("auxiliary").style.backgroundColor = "blue";
            stop();
            Common_Activity("auxiliary");
            reset();
            start();
            localStorage.setItem("currentstatus", "auxiliary");
            console.log(localStorage.getItem("currentstatus"));
            console.log(localStorage.getItem("work"));
            console.log(localStorage.getItem("training"));
            console.log(localStorage.getItem("meeting"));
            console.log(localStorage.getItem("breaks"));
            console.log(localStorage.getItem("auxiliary"));
        }
    }
    function Common_Activity(current_activity) {
        var localvar_Time;
        var timerVal = time_el.innerHTML;
        var previous_status = localStorage.getItem("currentstatus");
        console.log(previous_status);
        if (typeof window !== 'undefined') {
            localStorage.setItem('currentstatus', current_activity);
        }
        var previous_time = get_previous_Time(previous_status);
        var a = previous_time;
        var b = timerVal;
        var splita = a.split(':');
        var splitb = b.split(':');
        var hour = 00;
        var minute = 00;
        var second = 00;
        hour = parseInt(splita[0]) + parseInt(splitb[0]);
        minute = parseInt(splita[1]) + parseInt(splitb[1]);
        second = parseInt(splita[2]) + parseInt(splitb[2]);
        if (minute > 59) {
            minute = Math.abs(60 - minute);
            hour += 1;
           
        }
        if (second > 59) {
            second = Math.abs(60 - second);
            minute += 1;
        }
        if (second < 10) second = '0' + second;
        if (minute < 10) minute = '0' + minute;
        if (hour < 10) hour = '0' + hour;
        var res = hour + ":" + minute + ":" + second;
        if (previous_status == "work") {
            localStorage.setItem("work", res);
            document.getElementById("work_txt").value = res;
            if (document.getElementById("Total_txt").value != 0) {
                var a = timerVal;
                var b = document.getElementById("Total_txt").value;
                var splita = a.split(':');
                var splitb = b.split(':');
                var hour = 00;
                var minute = 00;
                var second = 00;
                hour = parseInt(splita[0]) + parseInt(splitb[0]);
                minute = parseInt(splita[1]) + parseInt(splitb[1]);
                second = parseInt(splita[2]) + parseInt(splitb[2]);
                if (minute > 59) {
                    minute = Math.abs(60 - minute);
                    hour += 1;
                }
                if (second > 59) {
                    second = Math.abs(60 - second);
                    minute += 1;
                }
                if (second < 10) second = '0' + second;
                if (minute < 10) minute = '0' + minute;
                if (hour < 10) hour = '0' + hour;
                var rest = hour + ":" + minute + ":" + second;
                document.getElementById("Total_txt").value = rest
            } else {
                document.getElementById("Total_txt").value = res;
            }

        }
        else if (previous_status == "meeting") {
            localStorage.setItem("meeting", res);
            document.getElementById("meeting_txt").value = res;
            if (document.getElementById("Total_txt").value != 0) {
                var a = timerVal;
                var b = document.getElementById("Total_txt").value;
                var splita = a.split(':');
                var splitb = b.split(':');
                var hour = 00;
                var minute = 00;
                var second = 00;
                hour = parseInt(splita[0]) + parseInt(splitb[0]);
                minute = parseInt(splita[1]) + parseInt(splitb[1]);
                second = parseInt(splita[2]) + parseInt(splitb[2]);
                if (minute > 59) {
                    minute = Math.abs(60 - minute);
                    hour += 1;
                }
                if (second > 59) {
                    second = Math.abs(60 - second);
                    minute += 1;
                }
                if (second < 10) second = '0' + second;
                if (minute < 10) minute = '0' + minute;
                if (hour < 10) hour = '0' + hour;
                var rest = hour + ":" + minute + ":" + second;
                document.getElementById("Total_txt").value = rest
            } else {
                document.getElementById("Total_txt").value = res;
            }

        }
        else if (previous_status == "training") {
            localStorage.setItem("training", res);
            document.getElementById("training_txt").value = res;
            if (document.getElementById("Total_txt").value != 0) {
                var a = timerVal;
                var b = document.getElementById("Total_txt").value;
                var splita = a.split(':');
                var splitb = b.split(':');
                var hour = 00;
                var minute = 00;
                var second = 00;
                hour = parseInt(splita[0]) + parseInt(splitb[0]);
                minute = parseInt(splita[1]) + parseInt(splitb[1]);
                second = parseInt(splita[2]) + parseInt(splitb[2]);
                if (minute > 59) {
                    minute = Math.abs(60 - minute);
                    hour += 1;
                }
                if (second > 59) {
                    second = Math.abs(60 - second);
                    minute += 1;
                }
                if (second < 10) second = '0' + second;
                if (minute < 10) minute = '0' + minute;
                if (hour < 10) hour = '0' + hour;
                var rest = hour + ":" + minute + ":" + second;
                document.getElementById("Total_txt").value = rest
            } else {
                document.getElementById("Total_txt").value = res;
            }
        }
        else if (previous_status == "breaks") {
            localStorage.setItem("breaks", res);
            document.getElementById("break_txt").value = res;
            if (document.getElementById("Total_txt").value != 0) {
                var a = timerVal;
                var b = document.getElementById("Total_txt").value;
                var splita = a.split(':');
                var splitb = b.split(':');
                var hour = 00;
                var minute = 00;
                var second = 00;
                hour = parseInt(splita[0]) + parseInt(splitb[0]);
                minute = parseInt(splita[1]) + parseInt(splitb[1]);
                second = parseInt(splita[2]) + parseInt(splitb[2]);
                if (minute > 59) {
                    minute = Math.abs(60 - minute);
                    hour += 1;
                }
                if (second > 59) {
                    second = Math.abs(60 - second);
                    minute += 1;
                }
                if (second < 10) second = '0' + second;
                if (minute < 10) minute = '0' + minute;
                if (hour < 10) hour = '0' + hour;
                var rest = hour + ":" + minute + ":" + second;
                document.getElementById("Total_txt").value = rest
            } else {
                document.getElementById("Total_txt").value = res;
            }
        }
        else if (previous_status == "auxiliary") {
            localStorage.setItem("auxiliary", res);
            document.getElementById("auxiliary_txt").value = res;
            if (document.getElementById("Total_txt").value != 0) {
                var a = timerVal;
                var b = document.getElementById("Total_txt").value;
                var splita = a.split(':');
                var splitb = b.split(':');
                var hour = 00;
                var minute = 00;
                var second = 00;
                hour = parseInt(splita[0]) + parseInt(splitb[0]);
                minute = parseInt(splita[1]) + parseInt(splitb[1]);
                second = parseInt(splita[2]) + parseInt(splitb[2]);
                if (minute > 59) {
                    minute = Math.abs(60 - minute);
                    hour += 1;
                }
                if (second > 59) {
                    second = Math.abs(60 - second);
                    minute += 1;
                }
                if (second < 10) second = '0' + second;
                if (minute < 10) minute = '0' + minute;
                if (hour < 10) hour = '0' + hour;
                var rest = hour + ":" + minute + ":" + second;
                document.getElementById("Total_txt").value = rest
            } else {
                document.getElementById("Total_txt").value = res;
            }
        }
        // return res;    
    }

    function get_previous_Time(statusType) {
        var pre_time;

        if (statusType == "work") {
            pre_time = localStorage.getItem("work");

        }
        else if (statusType == "meeting") {
            pre_time = localStorage.getItem("meeting");
        }
        else if (statusType == "training") {
            pre_time = localStorage.getItem("training");
        }
        else if (statusType == "breaks") {
            pre_time = localStorage.getItem("breaks");
        }
        else if (statusType == "auxiliary") {
            pre_time = localStorage.getItem("auxiliary");
        }
        if (pre_time == 0) {

            return "00:00:00";
        } else if (typeof pre_time == 'undefined') {
            return "00:00:00";
        } else if (typeof pre_time == null) {
            return "00:00:00";
        }
        else { return pre_time; }

    }

    function Timer() {

        seconds++;

        //Format the Time
        let hrs = Math.floor(seconds / 3600);
        console.log(hrs);
        let mins = Math.floor(seconds / 60);
        console.log(mins);
        let secs = seconds % 60;
        console.log(secs);
        //if (mins > 59) mins = '0';
        if (secs < 10) secs = '0' + secs;
        if (mins < 10) mins = '0' + mins;
        if (hrs < 10) hrs = '0' + hrs;

        time_el.innerHTML = `${hrs}:${mins}:${secs}`;

        console.log(time_el);
    }
    Timer();
    function start() {
        if (interval) {
            return
        }
        interval = setInterval(Timer, 1000);

    }
    function stop() {
        clearInterval(interval);
        interval = null;
    }
    function reset() {
        stop();
        seconds = 0;
        time_el.innerText = '00:00:00';
    }
   
  
    function sumofTime() {

        var time_work = document.getElementById("work_txt").value;
        var time_meeting = document.getElementById("meeting_txt").value;
        var time_training = document.getElementById("training_txt").value;
        var time_break = document.getElementById("break_txt").value;
        var time_auxiliary = document.getElementById("auxiliary_txt").value;

        var hour = 00;
        var minute = 00;
        var second = 00;

        var split_Time_work = time_work.split(':');
        var splitTime_time_meeting = time_meeting.split(':');
        var splitTime_time_training = time_training.split(':');
        var splitTime_time_break = time_break.split(':');
        var splitTime_time_auxiliary = time_auxiliary.split(':');

        hour = parseInt(split_Time_work[0]) + parseInt(splitTime_time_meeting[0]) + parseInt(splitTime_time_training[0]) + parseInt(splitTime_time_break[0]) + parseInt(splitTime_time_auxiliary[0]);
        minute = parseInt(split_Time_work[1]) + parseInt(splitTime_time_meeting[1]) + parseInt(splitTime_time_training[1]) + parseInt(splitTime_time_break[1]) + parseInt(splitTime_time_auxiliary[1]);
        second = parseInt(split_Time_work[2]) + parseInt(splitTime_time_meeting[2]) + parseInt(splitTime_time_training[2]) + parseInt(splitTime_time_break[2]) + parseInt(splitTime_time_auxiliary[2]);
        if (minute > 59) {
            minute = Math.abs(60 - minute);
            hour += 1;
        }
        if (second > 59) {
            second = Math.abs(60 - second);
            minute += 1;
        }
        if (second < 10) second = '0' + second;
        if (minute < 10) minute = '0' + minute;
        if (hour < 10) hour = '0' + hour;

        document.getElementById("Total_txt").value = hour + ':' + minute + ':' + second
    }


    

    //Confirmbox.js start
    document.getElementById("GetNow").onclick = function () {
        //disabledlogin();
        document.getElementById('GetNow').disabled = true;
        element = document.getElementById('datafound').value;
        console.log(element);
        if (element != null) {
            if (document.getElementById("datafound").value == "found records") {
                Swal.fire({
                    title: "You're already login",
                    text: "Are you Sure! Do you want to edit your existing record??",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes, Edit it!',
                    cancelButtonText: "No, don't Edit It!"
                }).then((result) => {
                    if (result.isConfirmed) {
                        localStorage.setItem("currentstatus", "0");
                        document.getElementById('GetNow').disabled = true;
                        document.getElementById('btn').disabled = false;
                        //document.getElementById('work').disabled = false;
                        //document.getElementById('training').disabled = false;
                        //document.getElementById('meeting').disabled = false;
                        //document.getElementById('breaks').disabled = false;
                        //document.getElementById('auxiliary').disabled = false;
                        disabledlogin();
                       
                        var getDate = document.getElementById("getTableRow").rows[1].cells.item(12).innerHTML;
                        document.getElementById("currentDate").value = getDate;
                        var getLogin = document.getElementById("getTableRow").rows[1].cells.item(13).innerHTML;
                        document.getElementById("currentTime").value = getLogin;
                        var getLogout = document.getElementById("getTableRow").rows[1].cells.item(14).innerHTML;
                        document.getElementById("getctime").value = getLogout;
                        var getTotal = document.getElementById("getTableRow").rows[1].cells.item(15).innerHTML;
                        document.getElementById("Total_txt").value = getTotal;
                        var getOverTime = document.getElementById("getTableRow").rows[1].cells.item(16).innerHTML;
                        document.getElementById("OverTM_txt").value = getOverTime;
                        var getWork = document.getElementById("getTableRow").rows[1].cells.item(17).innerHTML;
                        document.getElementById("work_txt").value = getWork;
                        localStorage.setItem("work", getWork);
                        var getMeeting = document.getElementById("getTableRow").rows[1].cells.item(18).innerHTML;
                        document.getElementById("meeting_txt").value = getMeeting;
                        localStorage.setItem("meeting", getMeeting);
                        var getTraining = document.getElementById("getTableRow").rows[1].cells.item(19).innerHTML;
                        document.getElementById("training_txt").value = getTraining;
                        localStorage.setItem("training", getTraining);
                        var getBreak = document.getElementById("getTableRow").rows[1].cells.item(20).innerHTML;
                        document.getElementById("break_txt").value = getBreak;
                        localStorage.setItem("breaks", getBreak);
                        var getauxiliary = document.getElementById("getTableRow").rows[1].cells.item(21).innerHTML;
                        document.getElementById("auxiliary_txt").value = getauxiliary;
                        localStorage.setItem("auxiliary", getauxiliary);
                        var getComment = document.getElementById("getTableRow").rows[1].cells.item(22).innerHTML;
                        document.getElementById("Comment").value = getComment;
                        Swal.fire(
                            'Confirmed!',
                            'Now you can edit your record!',
                            'success'
                        )
                    } else {
                        x = "You pressed Cancel!";
                        document.getElementById('GetNow').disabled = true;
                        document.getElementById('btn').disabled = false;
                        //document.getElementById('work').disabled = false;
                        //document.getElementById('training').disabled = false;
                        //document.getElementById('meeting').disabled = false;
                        //document.getElementById('breaks').disabled = false;
                        //document.getElementById('auxiliary').disabled = false;
                        //document.getElementById("btncolapse").hidden = false;
                        disabledlogin();
                        //var getDate = document.getElementById("getTableRow").rows[1].cells.item(12).innerHTML;
                        //document.getElementById("currentDate").value = getDate;
                        //var getLogin = document.getElementById("getTableRow").rows[1].cells.item(13).innerHTML;
                        //document.getElementById("currentTime").value = getLogin;
                        var date = new Date();
                        var current_date = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
                        var current_time = date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
                        var date_time = current_date + " " + current_time;

                        document.getElementById("currentDate").value = current_date;
                        document.getElementById("currentTime").value = date_time;

                        localStorage.setItem("work", "0");
                        localStorage.setItem("meeting", "0");
                        localStorage.setItem("training", "0");
                        localStorage.setItem("breaks", "0");
                        localStorage.setItem("auxiliary", "0");
                        localStorage.setItem("currentstatus", "0");
                        Swal.fire(
                            'Cancelled!',
                            'Now you can add new record!',
                            'error'
                        )
                    }

                })

            } else if (document.getElementById("datafound").value == "No records") {
                    var date = new Date();
                    var current_date = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
                    var current_time = date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
                    var date_time = current_date + " " + current_time;

                    document.getElementById("currentDate").value = current_date;
                    document.getElementById("currentTime").value = date_time;
                    document.getElementById("StartTime_txt").value = current_time;
                    document.getElementById('GetNow').disabled = true;
                    document.getElementById('btn').disabled = false;
                    disabledlogin();
                    localStorage.setItem("work", "0");
                    localStorage.setItem("meeting", "0");
                    localStorage.setItem("training", "0");
                    localStorage.setItem("breaks", "0");
                    localStorage.setItem("auxiliary", "0");
                    localStorage.setItem("currentstatus", "0");
            }
            
        }

    }

    // //Confirmbox.js End
    ////collapsible.js start
    //var coll = document.getElementsByClassName("collapsible");
    //var i;

    //for (i = 0; i < coll.length; i++) {
    //    coll[i].addEventListener("click", function () {
    //        this.classList.toggle("active");
    //        var content = this.nextElementSibling;
    //        if (content.style.maxHeight) {
    //            content.style.maxHeight = null;
    //        } else {
    //            content.style.maxHeight = content.scrollHeight + "px";
    //        }
    //    });
    //}
    // //collapsible.js End
    //Logout.js start
    document.getElementById("btn").onclick = function () {
        //console.log("Hello Logout");
        var previous_status = localStorage.getItem("currentstatus");
        //Common_Activity(current_activity);
        document.getElementById('GetNow').disabled = false;
        if (previous_status == "work") {
            stop();
            Common_Activity("work");
            localStorage.setItem("currentstatus", "work");
            console.log(localStorage.getItem("currentstatus"));
            console.log(localStorage.getItem("work"));
            console.log(localStorage.getItem("training"));
            console.log(localStorage.getItem("meeting"));
            console.log(localStorage.getItem("breaks"));
            console.log(localStorage.getItem("auxiliary"));
        }
        else if (previous_status == "training") {
            stop();
            Common_Activity("training");
            localStorage.setItem("currentstatus", "training");
            console.log(localStorage.getItem("currentstatus"));
            console.log(localStorage.getItem("work"));
            console.log(localStorage.getItem("training"));
            console.log(localStorage.getItem("meeting"));
            console.log(localStorage.getItem("breaks"));
            console.log(localStorage.getItem("auxiliary"));
        }
        else if (previous_status == "meeting") {
            stop();
            Common_Activity("meeting");
            localStorage.setItem("currentstatus", "meeting");
            console.log(localStorage.getItem("currentstatus"));
            console.log(localStorage.getItem("work"));
            console.log(localStorage.getItem("training"));
            console.log(localStorage.getItem("meeting"));
            console.log(localStorage.getItem("breaks"));
            console.log(localStorage.getItem("auxiliary"));
        }
        else if (previous_status == "breaks") {
            stop();
            Common_Activity("breaks");
            localStorage.setItem("currentstatus", "breaks");
            console.log(localStorage.getItem("currentstatus"));
            console.log(localStorage.getItem("work"));
            console.log(localStorage.getItem("training"));
            console.log(localStorage.getItem("meeting"));
            console.log(localStorage.getItem("breaks"));
            console.log(localStorage.getItem("auxiliary"));
        }
        else if (previous_status == "auxiliary") {
            stop();
            Common_Activity("auxiliary");
            localStorage.setItem("currentstatus", "auxiliary");
            console.log(localStorage.getItem("currentstatus"));
            console.log(localStorage.getItem("work"));
            console.log(localStorage.getItem("training"));
            console.log(localStorage.getItem("meeting"));
            console.log(localStorage.getItem("breaks"));
            console.log(localStorage.getItem("auxiliary"));
        }

        
        var date = new Date();
        var current_date = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
        var current_time = date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
        var date_time = current_date + " " + current_time;
        document.getElementById("EndTime_txt").value = current_time;
        document.getElementById("getctime").value = date_time;
        if (document.getElementById("Comment").value == "") {
            document.getElementById("Comment").value = ".";
        }
        document.getElementById('GetNow').disabled = false;
        Swal.fire(
            'Good job!',
            'You Added Data Successfully!',
            'success'
        )
        //swal({
        //    title: 'Good job!',
        //    text: 'You Added Data Successfully!',
        //    type: 'success',
        //    allowOutsideClick: true,
        //    html: true
        //},
        //    function () {
        //        window.location.href = 
        //    });
        //if (document.getElementById("EndTime_txt").value != 0) {
        //    const hours = (startTime, finishTime) => {
        //        const [startHours, startMinutes] = startTime.split(':');
        //        const [finishHours, finishMinutes] = finishTime.split(':');
        //        const startTimeinMinutes = (parseInt(startHours) * 60) + parseInt(startMinutes);
        //        const finishTimeinMinutes = (parseInt(finishHours) * 60) + parseInt(finishMinutes);
        //        const totalMinutes = finishTimeinMinutes - startTimeinMinutes;
        //        const minutes = totalMinutes % 60;
        //        const hours = (totalMinutes - minutes) / 60;

        //        return `${hours < 10 ? '0' : ''}${hours}:${minutes < 10 ? '0' : ''}${minutes}`;
        //    };

        //    var login = document.getElementById("StartTime_txt").value;
        //    var logout = document.getElementById("EndTime_txt").value;
        //    var overtime = hours(login, logout);
        //    document.getElementById("OverTM_txt").value = overtime;
           
        //    //console.log(hours(login, logout));
        //    //if (document.getElementById('btn').disabled = true) {
        //    //    document.getElementById('GetNow').disabled = false;
        //    //}
         
        //}   
        

        var sTime = "08:00";
        var eTime = document.getElementById('Total_txt').value;
        var brk_Time = document.getElementById('break_txt').value;
            console.log(sTime);
            console.log(eTime);
            
            var startTime = moment(sTime, 'HH:mm');
            var endTime = moment(eTime, 'HH:mm');
            var brkTime = moment(brk_Time, 'HH:mm');
            console.log(startTime);
            console.log(endTime);
            console.log(brkTime);
        var duration = moment.duration(endTime.diff(brkTime));
        
            var hours = parseInt(duration.asHours());
        var minutes = parseInt(duration.asMinutes()) % 60;

       
            if (minutes < 10) minutes = '0' + minutes;
            if (hours < 10) hours = '0' + hours;
           
        var result = hours + ':' + minutes;
        var resultot = moment(result, 'HH:mm');
        var dur = moment.duration(resultot.diff(startTime));
            if (dur < 0) {
                document.getElementById("OverTM_txt").value = "00:00:00";
            } else {
            var hr = parseInt(dur.asHours());
            var mins = parseInt(dur.asMinutes()) % 60;
            if (mins < 10) mins = '0' + mins;
            if (hr < 10) hr = '0' + hr;
            var res = hr + ':' + mins;
            document.getElementById('OverTM_txt').value = res;
        }
       

        
        
    }

    function disabledlogin() {
        console.log("Hello Login")
        if (document.getElementById('GetNow').disabled = false) {
            document.getElementById('btn').disabled = true;
            document.getElementById('work').disabled = true;
            document.getElementById('training').disabled = true;
            document.getElementById('meeting').disabled = true;
            document.getElementById('breaks').disabled = true;
            document.getElementById('auxiliary').disabled = true;
        } else if (document.getElementById('GetNow').disabled = true) {
            document.getElementById('GetNow').disabled = true;
            document.getElementById('work').disabled = false;
            document.getElementById('training').disabled = false;
            document.getElementById('meeting').disabled = false;
            document.getElementById('breaks').disabled = false;
            document.getElementById('auxiliary').disabled = false;
        }   
    }
    function disabledlogout() {
        if (document.getElementById('btn').disabled = true) {
            document.getElementById('GetNow').disabled = false;
            document.getElementById('work').disabled = true;
            document.getElementById('training').disabled = true;
            document.getElementById('meeting').disabled = true;
            document.getElementById('breaks').disabled = true;
            document.getElementById('auxiliary').disabled = true;
           
        }
        else if (document.getElementById('btn').disabled = false) {
            document.getElementById('GetNow').disabled = true;
            document.getElementById('work').disabled = false;
            document.getElementById('training').disabled = false;
            document.getElementById('meeting').disabled = false;
            document.getElementById('breaks').disabled = false;
            document.getElementById('auxiliary').disabled = false;
           
        }
    }
    ////Logout.js End
    ////Timer.js Start
    // //Timer.js End
}

