////console.log("Hello Logout");

////document.getElementById("btn").onclick = function () {
////    console.log("Hello Logout");
////    var date = new Date();
////    var current_date = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
////    var current_time = date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
////    var date_time = current_date + " " + current_time;
////    document.getElementById("EndTime_txt").value = current_time;
////    document.getElementById("getctime").value = date_time;
////    getovertime();
////    //var auxiliary_tm = time_el.innerText
////    //document.getElementById("auxiliary_txt").value = auxiliary_tm;
////    reset();
////    stop();
////    document.getElementById('GetNow').disabled = false;
////    document.getElementById('btn').disabled = true;
////    document.getElementById('work').disabled = true;
////    document.getElementById('training').disabled = true;
////    document.getElementById('meeting').disabled = true;
////    document.getElementById('breaks').disabled = true;
////    document.getElementById('auxiliary').disabled = true;
////    if (document.getElementById("EndTime_txt").value != 0) {
////        const hours = (startTime, finishTime) => {
////            const [startHours, startMinutes] = startTime.split(':');
////            const [finishHours, finishMinutes] = finishTime.split(':');
////            const startTimeinMinutes = (parseInt(startHours) * 60) + parseInt(startMinutes);
////            const finishTimeinMinutes = (parseInt(finishHours) * 60) + parseInt(finishMinutes);
////            const totalMinutes = finishTimeinMinutes - startTimeinMinutes;
////            const minutes = totalMinutes % 60;
////            const hours = (totalMinutes - minutes) / 60;

////            return `${hours < 10 ? '0' : ''}${hours}:${minutes < 10 ? '0' : ''}${minutes}`;
////        };

////        var login = document.getElementById("StartTime_txt").value;
////        var logout = document.getElementById("EndTime_txt").value;
////        var overtime = hours(login, logout);
////        document.getElementById("OverTM_txt").value = overtime;
////        console.log(hours(login, logout));
////    }


////}

document.getElementById("btn").onclick = async function Logout() {
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
    //window.location = 'https://localhost:44363/Activity/Index'
    window.location = 'https://mytime-uat.in.myatos.net/Home/Index'
}