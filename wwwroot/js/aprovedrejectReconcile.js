window.onload = function () {
    document.getElementById("approveRC").onclick = async function approve() {
        var url = 'Approve';
        /*var username = 'example'*/

        var checkedInputs = [];
        var inputs = document.querySelectorAll('input[type=checkbox]')
        inputs = Array.from(inputs)
        if (document.getElementById('select-all').checked) {
            inputs.shift();
        }
        inputs.forEach(item => {
            if (item.checked)
                checkedInputs.push(item.getAttribute('data-id'))
        })
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
       // window.location = 'http://192.168.103.112:82/RM_SCREEN/Index'
        window.location = 'https://mytime.in.myatos.net/RM_SCREEN/Index'
    }

    document.getElementById("rejectRC").onclick = async function reject() {
        var url = 'Reject';
        /*var username = 'example'*/
        var checkedInputs = []
        var inputs = document.querySelectorAll('input[type=checkbox]')
        inputs = Array.from(inputs)
        if (document.getElementById('select-all').checked) {
            inputs.shift();
        }
        inputs.forEach(item => {
            if (item.checked)
                checkedInputs.push(item.getAttribute('data-id'))
        })
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
        //window.location = 'http://192.168.103.112:82/RM_SCREEN/Index'
    window.location = 'https://mytime.in.myatos.net/RM_SCREEN/Index'
}

    //select - all
    document.getElementById("select-all").onclick = function selectAll() {
        var checkAll = document.getElementById('select-all');
        var inputs = document.querySelectorAll('input[type=checkbox]');
        if (checkAll.checked) {
            inputs.forEach(item => {
                item.checked = true;
            })
        } else {
            inputs.forEach(item => {
                item.checked = false;
            })
        }
    }

}
