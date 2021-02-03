const uri = 'https://localhost:5001/api/factura/';
let invoices = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function addItem() {
    const addNameTextbox = document.getElementById('add-name');

    const item = {
        name: addNameTextbox.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
    const item = todos.find(item => item.id === id);

    document.getElementById('edit-name').value = item.name;
    document.getElementById('edit-id').value = item.id;
    document.getElementById('edit-isComplete').checked = item.isComplete;
    document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
    const itemId = document.getElementById('edit-id').value;
    const item = {
        id: parseInt(itemId, 10),
        isComplete: document.getElementById('edit-isComplete').checked,
        name: document.getElementById('edit-name').value.trim()
    };

    fetch(`${uri}/${itemId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to update item.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayItems(data) {
    const tBody = document.getElementById('invoices');
    tBody.innerHTML = '';

    let tableInvoices = document.getElementById("apiTable");
    tableInvoices.style.borderCollapse = "separate";
    tableInvoices.style.borderSpacing = "0 0.5em";

    let invoicesContainer = document.getElementById("invoicesContainer");
    invoicesContainer.style.backgroundColor = "whitesmoke";
    invoicesContainer.style.cursor = "pointer";

 

    const button = document.createElement('button');

    document.getElementsByTagName("body")[0].style.backgroundColor = "whitesmoke";

    data.forEach(item => {


        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);


        let tr = tBody.insertRow();

        tBody.style.backgroundColor = "white";

        let td2 = tr.insertCell(0);
        let textNode = document.createTextNode(item.idFactura);
        td2.appendChild(textNode);
        td2.style.verticalAlign = "middle";
        td2.style.textAlign = "center";
        td2.style.borderTopLeftRadius = "6px";
        td2.style.borderBottomLeftRadius = "6px";
 

        let td3 = tr.insertCell(1);
        let textNode2 = document.createTextNode(item.idLocatie);
        td3.appendChild(textNode2);
        td3.style.verticalAlign = "middle";

        let td4 = tr.insertCell(2);
        let textNode3 = document.createTextNode(item.numarFactura);
        td4.appendChild(textNode3);
        td4.style.verticalAlign = "middle";

        let td5 = tr.insertCell(3);
        let textNode4 = document.createTextNode(item.dataFactura);
        td5.appendChild(textNode4);
        td5.style.verticalAlign = "middle";

        let td6 = tr.insertCell(4);
        td6.appendChild(editButton);
        td6.style.verticalAlign = "middle";

        let td7 = tr.insertCell(5);
        td7.appendChild(deleteButton);
        td7.style.verticalAlign = "middle";
        td7.style.borderBottomRightRadius = "6px";
        td7.style.borderTopRightRadius = "6px";


    });

    let allInvoices = tBody.children;

    $("#invoicesTableHeader").css("background", "khaki");

    let allTr = document.getElementsByTagName("tr");

    $("#invoices tr ").hover(function () {
        $(this).css("background", "khaki");
    },
        function () {
            $(this).css("background", "white");
        });

    console.log(allTr);


    for (tableRow of allTr) {

        console.log(tableRow);
        tableRow.style.height = "70px";
    };

   invoices = data;
}