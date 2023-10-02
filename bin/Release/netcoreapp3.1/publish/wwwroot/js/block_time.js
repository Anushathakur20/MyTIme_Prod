//endTime ,activity
window.onload = function () {
     function SetName() {
        $("Employee_Name").val($("#employee_Name option:selected").text());
    }

    document.getElementById("endTime").onchange = async function total() {
       
            var sTime = document.getElementById('startTime').value;
            var eTime = document.getElementById('endTime').value;

            console.log(sTime);
            console.log(eTime);

            var startTime = moment(sTime, 'HH:mm');
            var endTime = moment(eTime, 'HH:mm');

            console.log(startTime);
            console.log(endTime);

            var duration = moment.duration(endTime.diff(startTime));
            var hours = parseInt(duration.asHours());
            var minutes = parseInt(duration.asMinutes()) % 60;

            console.log(duration);
            console.log(hours);
            console.log(minutes);

            if (minutes < 10) minutes = '0' + minutes;
            if (hours < 10) hours = '0' + hours;

            var result = hours + ':' + minutes;

            document.getElementById('totalTime').value = result;

        

    }

    $(function () {
        $('#employee_Name').multiselect({
            includeSelectAllOption: true
        });
    });

    document.getElementById("activity").onclick = function selectAct(selectValue) {
        var x = selectValue.value;
    }
}