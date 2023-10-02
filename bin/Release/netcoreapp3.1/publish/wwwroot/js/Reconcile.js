window.onload = function () {
    document.getElementById("reconcile").onclick = async function reconcile() {
        var url = 'GoToReconcile';
        var checkedInputs = []
        var inputs = document.querySelectorAll('input[type=checkbox')
        inputs = Array.from(inputs)
        if (document.getElementById('select-all').checked) {
            inputs.shift();
        }
        inputs.forEach(item => {
            if (item.checked)
                checkedInputs.push(item.getAttribute('data-id'))
        })
        await fetch(url, {
            method: 'Post',
            body: JSON.stringify(checkedInputs),
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            }
        }).then(response => {
            var redirectURL = "";
            for (let i = 0; i < checkedInputs.length; i++) {
                if (i < checkedInputs.length - 1) {
                    redirectURL += "checkedInputs=" + checkedInputs[i] + "&";
                }
                else {
                    redirectURL += "checkedInputs=" + checkedInputs[i];
                }
            }
            //window.location.href = 'http://192.168.103.112:82/RM_SCREEN/Reconcile?' + redirectURL;
            window.location.href = 'https://mytime-uat.in.myatos.net/RM_SCREEN/Reconcile?' + redirectURL;
        })
            .catch(error => console.log('Error:', error));
        /*window.location.href ='http://localhost:10001/RMscreen/Reconcile'*/
    }

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