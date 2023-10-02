$('table').on('scroll', function () {
    $("table > *").width($("table").width() + $("table").scrollLeft());
});

var getColor = function (text) {
    if (text === "Approved by RM") return 'green' ;
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
var coll = document.getElementsByClassName("collapsible");
var i;

for (i = 0; i < coll.length; i++) {
    coll[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var content = this.nextElementSibling;
        if (content.style.maxHeight) {
            content.style.maxHeight = null;
        } else {
            content.style.maxHeight = content.scrollHeight + "px";
        }

    });
}
//document.getElementById("homelink").onclick = function () {
//    if (document.getElementById("currentTime").value != "") {
//        Swal.fire({
//            title: "Alert",
//            text: "Please Logout First!",
//            icon: 'warning',
//            showCancelButton: false,
//            confirmButtonColor: '#3085d6',
//            confirmButtonText: 'Okay!'
//        })
//        return false;
//    } else {
//        window.location = 'https://mytime-uat.in.myatos.net/Home/Index'
//    }
//}

//document.getElementById("rmlink").onclick = function () {
//    if (document.getElementById("currentTime").value != "") {
//        Swal.fire({
//            title: "Alert",
//            text: "Please Logout First!",
//            icon: 'warning',
//            showCancelButton: false,
//            confirmButtonColor: '#3085d6',
//            confirmButtonText: 'Okay!'
//        })
//        return false;
//    } else {
//        window.location = 'https://mytime-uat.in.myatos.net/RM_SCREEN/Index'
//    }
//}
//document.getElementById("Activitylink").onclick = function () {
//    if (document.getElementById("currentTime").value != "") {
//        Swal.fire({
//            title: "Alert",
//            text: "Please Logout First!",
//            icon: 'warning',
//            showCancelButton: false,
//            confirmButtonColor: '#3085d6',
//            confirmButtonText: 'Okay!'
//        })
//        return false;
//    } else {
//        window.location = 'https://mytime-uat.in.myatos.net/Activity/Index'
//    }
//}

//document.getElementById("smlink").onclick = function () {
//    if (document.getElementById("currentTime").value != "") {
//        Swal.fire({
//            title: "Alert",
//            text: "Please Logout First!",
//            icon: 'warning',
//            showCancelButton: false,
//            confirmButtonColor: '#3085d6',
//            confirmButtonText: 'Okay!'
//        })
//        return false;
//    } else {
//        window.location = 'https://mytime-uat.in.myatos.net/SM_SCREEN/Index'
//    }
//}
//document.getElementById("VHLink1").onclick = function () {
//    if (document.getElementById("currentTime").value != "") {
//        Swal.fire({
//            title: "Alert",
//            text: "Please Logout First!",
//            icon: 'warning',
//            showCancelButton: false,
//            confirmButtonColor: '#3085d6',
//            confirmButtonText: 'Okay!'
//        })
//        return false;
//    } else {
//        window.location = 'https://mytime-uat.in.myatos.net/VH_SCREEN/Index'
//    }
    //document.getElementById("VHLink2").onclick = function () {
    //    if (document.getElementById("currentTime").value != "") {
    //        Swal.fire({
    //            title: "Alert",
    //            text: "Please Logout First!",
    //            icon: 'warning',
    //            showCancelButton: false,
    //            confirmButtonColor: '#3085d6',
    //            confirmButtonText: 'Okay!'
    //        })
    //        return false;
    //    } else {
    //        window.location = 'https://mytime-uat.in.myatos.net/VH_SCREEN/Index'
    //    }
    //}
/*}*/


