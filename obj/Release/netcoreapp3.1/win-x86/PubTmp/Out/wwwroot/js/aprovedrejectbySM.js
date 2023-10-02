

 async function approveSM()  {
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
     window.location = 'https://localhost:44363/SM_SCREEN/Index'
}

 async function rejectSM() {
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
     window.location = 'https://localhost:44363/SM_SCREEN/Index'
}

function selectAll() {
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


