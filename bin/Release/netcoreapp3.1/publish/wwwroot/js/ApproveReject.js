window.onload = function () {
   
    //document.getElementById("approve").onclick = async function approve() {
    //    var url = 'Approve';
    //    /*var username = 'example'*/

    //    var checkedInputs = [];
    //    var inputs = document.querySelectorAll('input[type=checkbox]')
    //    inputs = Array.from(inputs)
    //    if (document.getElementById('select-all').checked) {
    //        inputs.shift();
    //    }
    //    inputs.forEach(item => {
    //        if (item.checked)
    //            checkedInputs.push(item.getAttribute('data-id'))
    //    })
    //    await fetch(url, {
    //        method: 'POST', // or 'PUT'
    //        body: JSON.stringify(checkedInputs),
    //        headers: {
    //            'Accept': 'application/json; charset=utf-8',
    //            'Content-Type': 'application/json;charset=UTF-8'
    //        }
    //    }).then(res => res.json())
    //        .then(response => console.log('Success:'))
    //        .catch(error => console.error('Error:', error));
    //    //window.location = 'http://192.168.103.112:82/RM_SCREEN/Index'
    //    window.location = 'https://mytime-uat.in.myatos.net/RM_SCREEN/Index'
    //}
    //document.getElementById("reject").onclick = async function reject() {
    //    var url = 'Reject';
    //    /*var username = 'example'*/
    //    var checkedInputs = []
    //    var inputs = document.querySelectorAll('input[type=checkbox]')
    //    inputs = Array.from(inputs)
    //    if (document.getElementById('select-all').checked) {
    //        inputs.shift();
    //    }
    //    inputs.forEach(item => {
    //        if (item.checked)
    //            checkedInputs.push(item.getAttribute('data-id'))
    //    })
    //    await fetch(url, {
    //        method: 'POST', // or 'PUT'
    //        body: JSON.stringify(checkedInputs),
    //        headers: {
    //            'Accept': 'application/json; charset=utf-8',
    //            'Content-Type': 'application/json;charset=UTF-8'
    //        }
    //    }).then(res => res.json())
    //        .then(response => console.log('Success:'))
    //        .catch(error => console.error('Error:', error));
    //    //window.location = 'http://192.168.103.112:82/RM_SCREEN/Index'
    //    window.location = 'https://mytime-uat.in.myatos.net/RM_SCREEN/Index'
    //}

    //document.getElementById("select-all").onclick = function selectAll() {
    //    var checkAll = document.getElementById('select-all');
    //    var inputs = document.querySelectorAll('input[type=checkbox]');
    //    if (checkAll.checked) {
    //        inputs.forEach(item => {
    //            item.checked = true;
    //        })
    //    } else {
    //        inputs.forEach(item => {
    //            item.checked = false;
    //        })
    //    }
    //}
    //function selectAct(selectValue) {
    //    var x = selectValue.value;
    //}
    document.getElementById("block_time").onclick = async function block_time() {
        window.location = 'https://mytime-uat.in.myatos.net/BLOCK_TIME'
    }

    //document.getElementById("reconcile").onclick = async function reconcile() {
    //    var url = 'GoToReconcile';
    //    var checkedInputs = []
    //    var inputs = document.querySelectorAll('input[type=checkbox')
    //    inputs = Array.from(inputs)
    //    if (document.getElementById('select-all').checked) {
    //        inputs.shift();
    //    }
    //    inputs.forEach(item => {
    //        if (item.checked)
    //            checkedInputs.push(item.getAttribute('data-id'))
    //    })
    //    await fetch(url, {
    //        method: 'Post',
    //        body: JSON.stringify(checkedInputs),
    //        headers: {
    //            'Accept': 'application/json; charset=utf-8',
    //            'Content-Type': 'application/json;charset=UTF-8'
    //        }
    //    }).then(response => {
    //        var redirectURL = "";
    //        for (let i = 0; i < checkedInputs.length; i++) {
    //            if (i < checkedInputs.length - 1) {
    //                redirectURL += "checkedInputs=" + checkedInputs[i] + "&";
    //            }
    //            else {
    //                redirectURL += "checkedInputs=" + checkedInputs[i];
    //            }
    //        }
    //        //window.location.href = 'http://192.168.103.112:82/RM_SCREEN/Reconcile?' + redirectURL;
    //        window.location.href = 'https://mytime-uat.in.myatos.net/RM_SCREEN/Reconcile?' + redirectURL;
    //    })
    //        .catch(error => console.log('Error:', error));
    //    /*window.location.href ='http://localhost:10001/RMscreen/Reconcile'*/
    //}


    //var getColor = function (text) {
    //    if (text === "Approved by RM") return 'green';
    //    if (text === "Approved by SM") return 'green';
    //    /* if (text >= "00:00:00") return 'green';*/
    //    if (text === "Approved by VH") return 'green';
    //    if (text === "Awaiting RM Approval") return 'orange';
    //    if (text === "Awaiting SM Approval") return 'orange';
    //    if (text === "Awaiting VH Approval") return 'orange';
    //    if (text === "Rejected by RM") return 'red';
    //    if (text === "Rejected by SM") return 'red';
    //    if (text === "Rejected by VH") return 'red';
    //    return "";
    //};

    //$('td').each(function (i, td) {
    //    var color = getColor($(td).html());
    //    $(td).css({
    //        "color": color

    //    });
    //});

}
