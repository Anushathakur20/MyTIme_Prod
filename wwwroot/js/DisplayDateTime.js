function startDate() {
    var d = new Date();
    window.setInterval(ut, 1000);
    function ut() {
        var dt = new Date();
        var days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
        var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        document.getElementById("date").innerHTML = days[d.getDay()] + " | " + d.getDate() + " " + months[d.getMonth()] + " " + d.getFullYear()  + " | " +  dt.toLocaleTimeString();
    }
}
startDate();