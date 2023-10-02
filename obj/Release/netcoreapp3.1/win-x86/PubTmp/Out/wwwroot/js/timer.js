//Declare Variable
const time_el = document.querySelector('.watch .stopwatch');
const star_btn = document.getElementById('start');
const stop_btn = document.getElementById('stop');
const reset_btn = document.getElementById('reset');
//const work_btn = document.getElementById('work');
//const meeting_btn = document.getElementById('meeting');
//const training_btn = document.getElementById('training');
//const breaks_btn = document.getElementById('breaks');
//const auxiliary_btn = document.getElementById('auxiliary');

let seconds = 0;
let interval = null;

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

function work_remember_btn() {
    //localStorage.setItem("clickedButton", work);
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
function Meeting_remember_btn() {
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
function training_remember_btn() {
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
function break_remember_btn(){
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
function auxiliary_remember_btn() {
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
function Common_Activity(current_activity) {
    var localvar_Time;
    var timerVal = time_el.innerHTML;
    var previous_status = localStorage.getItem("currentstatus");
    console.log(previous_status);
        if (typeof window !== 'undefined') {
            localStorage.setItem('currentstatus', current_activity );   
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
    else if (previous_status == "auxiliary")
    {
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
    else if (statusType == "auxiliary")
    {
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

    if (secs < 10) secs = '0' + secs;
    if (mins < 10) mins = '0' + mins;
    if (hrs  < 10) hrs = '0' + hrs;

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

//function sumTime() {
//    var time_work = document.getElementById("work_txt").value;
//    var time_meeting = document.getElementById("meeting_txt").value;
//    var time_training = document.getElementById("training_txt").value;
//    var time_break = document.getElementById("break_txt").value;
//    var time_auxiliary = document.getElementById("auxiliary_txt").value;
//    var total_time = document.getElementById("Total_txt").value
//    var hour = 00;
//    var minute = 00;
//    var second = 00;
//    if (total_time == 0) {
//        total_time='0:0:0'
//    }
//    var split_Time_work = time_work.split(':');
//    var splitTime_time_meeting = time_meeting.split(':');
//    var splitTime_time_training = time_training.split(':');
//    var splitTime_time_break = time_break.split(':');
//    var splitTime_time_auxiliary = time_auxiliary.split(':');
//    var splittotal_time = total_time.split(':');
    
//    if (time_work != 0) {
//        hour = parseInt(split_Time_work[0]) + parseInt(splittotal_time[0]);
//        minute = parseInt(split_Time_work[1]) + parseInt(splittotal_time[1]);
//        second = parseInt(split_Time_work[2]) + parseInt(splittotal_time[2]);
//        if (minute > 59) {
//            minute = Math.abs(60 - minute);
//            hour += 1;
//        }
//        if (second > 59) {
//            second = Math.abs(60 - second);
//            minute += 1;
//        }
//        if (second < 10) second = '0' + second;
//        if (minute < 10) minute = '0' + minute;
//        if (hour < 10) hour = '0' + hour;
//        var rest = hour + ":" + minute + ":" + second;
//        document.getElementById("Total_txt").value = rest
//    }
//    else if (time_work == 0) {
//        document.getElementById("Total_txt").value = time_work;
//    } else if (time_meeting != 0) {
//        hour = parseInt(splitTime_time_meeting[0]) + parseInt(splittotal_time[0]);
//        minute = parseInt(splitTime_time_meeting[1]) + parseInt(splittotal_time[1]);
//        second = parseInt(splitTime_time_meeting[2]) + parseInt(splittotal_time[2]);
//        if (minute > 59) {
//            minute = Math.abs(60 - minute);
//            hour += 1;
//        }
//        if (second > 59) {
//            second = Math.abs(60 - second);
//            minute += 1;
//        }
//        if (second < 10) second = '0' + second;
//        if (minute < 10) minute = '0' + minute;
//        if (hour < 10) hour = '0' + hour;
//        var rest = hour + ":" + minute + ":" + second;
//        document.getElementById("Total_txt").value = rest
//    } else if (time_meeting == 0) {
//        document.getElementById("Total_txt").value = time_meeting;
//    } else if (time_training != 0) {
//        hour = parseInt(splitTime_time_training[0]) + parseInt(splittotal_time[0]);
//        minute = parseInt(splitTime_time_training[1]) + parseInt(splittotal_time[1]);
//        second = parseInt(splitTime_time_training[2]) + parseInt(splittotal_time[2]);
//        if (minute > 59) {
//            minute = Math.abs(60 - minute);
//            hour += 1;
//        }
//        if (second > 59) {
//            second = Math.abs(60 - second);
//            minute += 1;
//        }
//        if (second < 10) second = '0' + second;
//        if (minute < 10) minute = '0' + minute;
//        if (hour < 10) hour = '0' + hour;
//        var rest = hour + ":" + minute + ":" + second;
//        document.getElementById("Total_txt").value = rest
//    } else if (time_training == 0) {
//        document.getElementById("Total_txt").value = time_training;
//    } else if (time_break != 0) {
//        hour = parseInt(splitTime_time_training[0]) + parseInt(splittotal_time[0]);
//        minute = parseInt(splitTime_time_training[1]) + parseInt(splittotal_time[1]);
//        second = parseInt(splitTime_time_training[2]) + parseInt(splittotal_time[2]);
//        if (minute > 59) {
//            minute = Math.abs(60 - minute);
//            hour += 1;
//        }
//        if (second > 59) {
//            second = Math.abs(60 - second);
//            minute += 1;
//        }
//        if (second < 10) second = '0' + second;
//        if (minute < 10) minute = '0' + minute;
//        if (hour < 10) hour = '0' + hour;
//        var rest = hour + ":" + minute + ":" + second;
//        document.getElementById("Total_txt").value = rest
//    } else if (time_break == 0) {
//        document.getElementById("Total_txt").value = time_break;
//    }
//}
