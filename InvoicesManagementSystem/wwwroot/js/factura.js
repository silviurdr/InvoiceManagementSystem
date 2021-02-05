const uri = 'api/';

let addProductButton = document.getElementById("addProductButton");
let productsTableBody = document.getElementById("productsTableBody");
let errorMessageProductsForm = document.getElementById("errorMessageProductsForm");
let cancelFacturaButton = document.getElementById("cancelFacturaButton");
let createFacturaButton = document.getElementById("createFacturaButton");
let locatiiCount;

const numeProdusCell = 0;
const cantitateCell = 1;
const pretUnitarCell = 2;
const valoareCell = 3;


function checkParameters() {
    let params = window.location.search.slice(1).split("&");
    let idFactura = params[0].split("=")[1];
    if (idFactura != undefined) {

        fetch(uri + "factura/" + idFactura)
            .then(response => response.json())
            .then(data => addValuesToInputs(data))
            .catch(error => console.error('Unable to get items.', error));
    }
}

function prepareFacturaForSubmit() {

    const productsTable = document.getElementById("productsTable");

    let numarFactura = document.getElementById("numarFactura").value;

    if (!numarFactura) {
        return
    }

    let errorMessageProductsMissing = document.getElementById("errorMessageProductsMissing");

    if (productsTable.rows.length == 1) {
        errorMessageProductsMissing.style.visibility = false;
        errorMessageProductsMissing.classList.remove("d-none");
        return false;
    } else {
        errorMessageProductsMissing.style.visibility = true;
        errorMessageProductsMissing.classList.add("d-none");
    }

    const oldIdFactura = document.getElementById('idFactura').value;
    const newIdLocatie = document.getElementById('idLocatie').value;
    const newNumarFactura = document.getElementById('numarFactura').value;
    const newNumeClient = document.getElementById('numeClient').value;
    const newDataFactura = document.getElementById('dataFactura').value;

    const newProducts = [];

    let productsNumber = productsTable.rows.length - 1;

    for (let i = 1; i < productsNumber + 1; i++) {
        let product = {
            idLocatie: document.getElementById('idLocatie').value,
            numeProdus: productsTable.rows[i].cells[numeProdusCell].innerText,
            cantitate: productsTable.rows[i].cells[cantitateCell].innerText,
            pretUnitar: productsTable.rows[i].cells[pretUnitarCell].innerText,
            valoare: productsTable.rows[i].cells[valoareCell].innerText,
            idFactura: 44
        }
        newProducts.push(product);
    }

    const factura = {
        idFactura: oldIdFactura,
        idLocatie: newIdLocatie,
        numarFactura: newNumarFactura,
        numeClient: newNumeClient,
        dataFactura: newDataFactura,
        detaliiFactura: newProducts
    };
    return factura;
}

function addValuesToInputs(factura) {

    let facturaProducts = factura.detaliiFactura;
    let numberOfProducts = facturaProducts.length;
    const productsTable = document.getElementById("productsTable");

    let idFactura = document.getElementById("idFactura");
    idFactura.value = factura.idFactura;

    const deleteButtonTemplate = document.createElement('i');
    deleteButtonTemplate.classList.add("fas", "fa-trash-alt");
    deleteButtonTemplate.style.color = "#FF4E50";
    deleteButtonTemplate.style.cursor = "pointer";

    for (let i = 0; i < numberOfProducts; i++) {

        let deleteButton = deleteButtonTemplate.cloneNode(false);
        deleteButton.setAttribute('onclick', "deleteProduct(this)");
        deleteButton.setAttribute('id', "product" + factura.detaliiFactura[i].idDetaliiFactura);

        let tr = productsTable.insertRow();

        let td1 = tr.insertCell(0);
        let textNode1 = document.createTextNode(facturaProducts[i]['numeProdus']);
        td1.appendChild(textNode1);

        let td2 = tr.insertCell(1);
        let textNode2 = document.createTextNode(facturaProducts[i]['cantitate']);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(2);
        let textNode3 = document.createTextNode(facturaProducts[i]['pretUnitar']);
        td3.appendChild(textNode3);

        let td4 = tr.insertCell(3);
        let textNode4 = document.createTextNode(facturaProducts[i]['valoare']);
        td4.appendChild(textNode4);

        let td5 = tr.insertCell(4);
        td5.appendChild(deleteButton);
        td5.style.verticalAlign = "middle";
        td5.style.textAlign = "center";
    }

    let numarFactura = document.getElementById("numarFactura");
    numarFactura.value = factura.numarFactura;

    let numeClient = document.getElementById("numeClient");
    numeClient.value = factura.numeClient;

    let dataFactura = document.getElementById("dataFactura");
    let dataFacturaFromDB = factura.dataFactura.slice(0, 10);
    dataFactura.value = dataFacturaFromDB;

    let idLocatie = document.getElementById("idLocatie");
    idLocatie.value = factura.idLocatie;

    document.getElementById("createFactura").setAttribute('onclick', 'updateItem( " ' + factura.idFactura + ' " )');
}

function toggleErrorMessage(facturaProperty, errorMessage) {
    if (!facturaProperty.value) {
        errorMessage.style.visibility = true;
        errorMessage.classList.remove("d-none");
    } else {
        errorMessage.style.visibility = false;
        errorMessage.classList.add("d-none");
    }
}

function addItem() {

    let factura = prepareFacturaForSubmit();

    let errorMessageNumarFactura = document.getElementById("errorMessageNumarFactura");
    let errorMessageDataFactura = document.getElementById("errorMessageDataFactura");
    let errorMessageNumeClient = document.getElementById("errorMessageNumeClient");
    let errorMessageIdLocatie = document.getElementById("errorMessageIdLocatie");

    let productsTable = document.getElementById("productsTable");
    
    let numarFactura = document.getElementById("numarFactura");
    let dataFactura = document.getElementById("dataFactura");
    let numeClient = document.getElementById("numeClient");
    let idLocatie = document.getElementById("idLocatie");

    toggleErrorMessage(numarFactura, errorMessageNumarFactura);
    toggleErrorMessage(dataFactura, errorMessageDataFactura);
    toggleErrorMessage(numeClient, errorMessageNumeClient);

    if (idLocatie.value == "Alege un Id de locatie") {
        errorMessageIdLocatie.style.visibility = true;
        errorMessageIdLocatie.classList.remove("d-none");
    } else {
        errorMessageIdLocatie.style.visibility = false;
        errorMessageIdLocatie.classList.add("d-none");
    }

    if (!factura) return;

    if (!factura.numarFactura || !factura.dataFactura || !factura.numeClient || factura.idLocatie === "Alege un Id de locatie") return;
    else if (productsTable.rows.length == 1)
    {

    };

    fetch(uri + "factura", {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(factura)
    })
        .then(response => response.json())
        .then(data => window.location.replace("index.html"))
        .catch(error => console.error('Unable to add item.', error));
}

function updateItem() {

    let factura = prepareFacturaForSubmit()

    if (!factura) return;

    if (!factura.numarFactura || !factura.dataFactura || !factura.numeClient || factura.idLocatie === "Alege un Id de locatie") return;

    fetch(uri + "factura", {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(factura),
    })
        .then(res => res.text())          // convert to plain text
        .then(text => console.log(text))
        .then(data => window.location.replace("index.html"))
        .catch(error => console.error('Unable to add item.', error));
}

addProductButton.addEventListener("click", function () {

    let numeProdus = document.getElementById('numeProdus').value;
    let cantitate = document.getElementById('cantitate').value;
    let pretUnitar = document.getElementById('pretUnitar').value;
    let valoare = document.getElementById('valoare').value;

    const deleteButtonTemplate = document.createElement('i');
    deleteButtonTemplate.classList.add("fas", "fa-trash-alt");
    deleteButtonTemplate.style.color = "#FF4E50";
    deleteButtonTemplate.style.cursor = "pointer";

    let deleteButton = deleteButtonTemplate.cloneNode(false);
    deleteButton.setAttribute('onclick', "deleteProduct(this)");


    if (!numeProdus || !cantitate || !pretUnitar) {
        errorMessageProductsForm.classList.remove("d-none");
        errorMessageProductsForm.style.visibility = true;
        return false;
    }

    let errorMessageProductsMissing = document.getElementById("errorMessageProductsMissing");
    errorMessageProductsMissing.style.visibility = false;
    errorMessageProductsMissing.classList.add("d-none");

    errorMessageProductsForm.classList.add("d-none");

    let tr = productsTableBody.insertRow();
    let td1 = tr.insertCell(0);
    let textNode1 = document.createTextNode(numeProdus);
    td1.appendChild(textNode1);
    document.getElementById('numeProdus').value = "";

    let td2 = tr.insertCell(1);
    let textNode2 = document.createTextNode(cantitate);
    td2.appendChild(textNode2);
    document.getElementById('cantitate').value = "";

    let td3 = tr.insertCell(2);
    let textNode3 = document.createTextNode(pretUnitar);
    td3.appendChild(textNode3);
    document.getElementById('pretUnitar').value = "";

    let td4 = tr.insertCell(3);
    let textNode4 = document.createTextNode((parseFloat(cantitate) * parseFloat(pretUnitar)).toFixed(2));
    td4.appendChild(textNode4);
    document.getElementById('valoare').value = "";

    let td5 = tr.insertCell(4);
    td5.appendChild(deleteButton);
    td5.style.verticalAlign = "middle";
    td5.style.textAlign = "center";

});

function deleteProduct(x) {
    
    if (confirm("Are you sure you want to delete this product?")) {
        let idProductToDelete = x.id;

        document.getElementById("productsTable").deleteRow(x.parentElement.parentElement.rowIndex);
        if (idProductToDelete) {
            let numberIdProductToDelete = idProductToDelete.match(/\d+/)[0];
            fetch(`${uri}detaliifactura/${numberIdProductToDelete}`, {
                method: "DELETE",
            })
                .catch(error => console.error('Unable to add item.', error));       
        }  
    };
}

function addProducts() {

    let cantitate = document.getElementById("cantitate");

    let td2 = tr.insertCell(0);
    let textNode2 = document.createTextNode(cantitate.nodeValue);
    td2.appendChild(textNode2);

}

function goPrev() {
    event.preventDefault()
    window.location.replace("index.html");
}