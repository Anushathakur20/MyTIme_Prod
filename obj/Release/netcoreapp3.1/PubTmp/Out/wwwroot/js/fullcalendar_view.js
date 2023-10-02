
jQuery(document).ready(function ($) {
    var actionurl = '/Home/CalendarData';
    $.getJSON(actionurl, function (response) {
        console.log(response);
        //var events = response;
       
    $('#calendar').fullCalendar({
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        initialDate: '2021-04-25',
        navLinks: true, // can click day/week names to navigate views
        selectable: true,
        selectMirror: true,
        displayEventTime: false,
       
        //events: location.href ='@Url.RouteUrl(new{ action= "CalendarData", controller="Home"})',
        //events: '/Home/CalendarData',
        //$.getJSON(events, function (response) {
           
        //}),
        //events: '@Url.RouteUrl(new{ action= "CalendarData", controller="Home"})',
        events: response,
        eventClick: function (event) {
            console.log(event.color);
            localStorage.setItem("color", event.color);
            $('#successModal').modal('show');

            //$('.modal-body h2').text("Total Time " + event.title);
            var array = event.description.split(','),
                status = array[0], work = array[1], meeting = array[2], Training = array[3], Break = array[4], Auxiliary = array[5], date = array[6], login = array[7], logout = array[8], overtime = array[9], id = array[10];
            //$('.modal-body h3').text(event.description);
            $('.modal-body .id').text(id);
            $('.modal-body .date').text("Date: " + date);
            $('.modal-body .login').text(login);
            $('.modal-body .logout').text(logout);
            $('.modal-body .overtime').text(overtime);
            $('.modal-body .total').text(event.title);
            $('.modal-body .work').text(work);
            $('.modal-body .meeting').text(meeting);
            $('.modal-body .training').text(Training);
            $('.modal-body .break').text(Break);
            $('.modal-body .auxiliary').text(Auxiliary);
            $('.modal-body .status').text(" Status: " + status);
            localStorage.setItem("ID", id);
        },
        color: localStorage.getItem("color"),
    });
    });
});
