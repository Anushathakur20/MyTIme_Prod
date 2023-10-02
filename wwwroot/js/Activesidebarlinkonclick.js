    document.getElementById("homelink").onclick = function () {
        window.location = 'https://mytime-uat.in.myatos.net/Activity/Index'

    }
    document.getElementById("rmlink").onclick = function () {
        window.location = 'https://mytime-uat.in.myatos.net/RM_SCREEN/Index'
    }
    document.getElementById("Activitylink").onclick = function () {
        window.location = 'https://mytime-uat.in.myatos.net/Activity/Index'
    }

    document.getElementById("smlink").onclick = function () {
        window.location = 'https://mytime-uat.in.myatos.net/SM_SCREEN/Index'
    }
    //document.getElementById("VHLink1").onclick = function () {
    //    window.location = 'https://mytime-uat.in.myatos.net/VH_SCREEN/Index'
    //}
    document.getElementById("VHLink2").onclick = function () {
        window.location = 'https://mytime-uat.in.myatos.net/VH_SCREEN/Index'

}

var getColor = function (text) {
    if (text === "Approved by RM") return 'green';
    if (text === "Approved by SM") return 'green';
    /* if (text >= "00:00:00") return 'green';*/
    if (text === "Approved by VH") return 'green';
    if (text === "Awaiting RM Approval") return 'orange';
    if (text === "Awaiting SM Approval") return 'orange';
    if (text === "Awaiting VH Approval") return 'orange';
    if (text === "Rejected by RM") return 'red';
    if (text === "Reject by SM") return 'red';
    if (text === "Rejected by VH") return 'red';

    return "";
};

$('td').each(function (i, td) {
    var color = getColor($(td).html());
    $(td).css({
        "color": color

    });
});