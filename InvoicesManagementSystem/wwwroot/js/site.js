const uri = 'https://localhost:5001/api/factura';
let invoices = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}


function deleteItem(id) {

    if (confirm("Are you sure you want to delete this factura?")) {
        fetch(`${uri}/${id}`, {
            method: 'DELETE'
        })
            .then(() => getItems())
            .catch(error => console.error('Unable to delete item.', error));
    }
}


function goToEditFactura(idFactura) {

    console.log(idFactura);
    window.location.href = "factura.html?idFactura=" + idFactura;
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

function _displayItems(data) {
    const tBody = document.getElementById('invoices');
    tBody.innerHTML = '';

    let tableInvoices = document.getElementById("apiTable");
    tableInvoices.style.borderCollapse = "separate";
    tableInvoices.style.borderSpacing = "0 0.5em";

    let invoicesContainer = document.getElementById("invoicesContainer");
    invoicesContainer.style.backgroundColor = "white";
    invoicesContainer.style.cursor = "pointer";

 /*   const infoButtonTemplate = document.createElement('i');
    infoButtonTemplate.classList.add("fas", "fa-info", "text-info");*/

    const deleteButtonTemplate = document.createElement('i');
    deleteButtonTemplate.classList.add("fas", "fa-trash-alt");
    deleteButtonTemplate.style.color = "#FF4E50";

    const editButtonTemplate = document.createElement('i');
    editButtonTemplate.classList.add("fas", "fa-edit", "text-dark");

    document.getElementsByTagName("body")[0].style.backgroundColor = "white";

    data.forEach(item => {

        item.id = item.idFactura;

        let editButton = editButtonTemplate.cloneNode(false);
        editButton.setAttribute('onclick', `goToEditFactura(${item.id})`);

        let deleteButton = deleteButtonTemplate.cloneNode(false);
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

        /*let infoButton = infoButtonTemplate.cloneNode(false);*/


        let tr = tBody.insertRow();

        tBody.style.backgroundColor = "whitesmoke";

        var date = new Date(item.dataFactura);

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
        td3.style.paddingLeft = "20px";
        td3.style.verticalAlign = "middle";

        let td4 = tr.insertCell(2);
        let textNode3 = document.createTextNode(item.numarFactura);
        td4.appendChild(textNode3);
        td4.style.verticalAlign = "middle";

        let td5 = tr.insertCell(3);
        let textNode4 = document.createTextNode(date.toUTCString());
        td5.appendChild(textNode4);
        td5.style.verticalAlign = "middle";

/*        let td6 = tr.insertCell(4);
        td6.appendChild(infoButton);
        td6.style.verticalAlign = "middle";
        td6.style.textAlign = "center";
        td6.style.width = "100px";*/

        let td7 = tr.insertCell(4);
        td7.appendChild(editButton);
        td7.style.verticalAlign = "middle";
        td7.style.textAlign = "center";
        td7.style.width = "100px";

        let td8 = tr.insertCell(5);
        td8.appendChild(deleteButton);
        td8.style.verticalAlign = "middle";
        td8.style.borderBottomRightRadius = "6px";
        td8.style.borderTopRightRadius = "6px";
        td8.style.textAlign = "center";
        td8.style.width = "100px";


    });

    let allTr = document.getElementsByTagName("tr");

/*    $("#invoices tr ").hover(function () {
        $(this).css("background", "khaki");
    },
        function () {
            $(this).css("background", "white");
        });
*/


    for (tableRow of allTr) {

        tableRow.style.height = "70px";
    };

   invoices = data;
}