const uri = 'https://localhost:5001/api/factura';

let addProductButton = document.getElementById("addProductButton"); 
let productsTableBody = document.getElementById("productsTableBody");
let errorMessageProductsForm = document.getElementById("errorMessageProductsForm");
let cancelFacturaButton = document.getElementById("cancelFacturaButton");
let createFacturaButton = document.getElementById("createFacturaButton"); 

const numeProdusCell = 0;
const cantitateCell = 1;
const pretUnitarCell = 2;
const valoareCell = 3;



function checkParameters() {
    let params = window.location.search.slice(1).split("&");
    let idFactura = params[0].split("=")[1];


    if (idFactura != undefined) {

        fetch(uri + "/" + idFactura)
            .then(response => response.json())
            .then(data => addValuesToInputs(data))
            .catch(error => console.error('Unable to get items.', error));

    }
}

function prepareFacturaForSubmit() {

    const productsTable = document.getElementById("productsTable");

    if (productsTable.rows.length == 1) {
        return false;
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
    console.log(factura.idFactura);
    const productsTable = document.getElementById("productsTable");

    let idFactura = document.getElementById("idFactura");
    idFactura.value = factura.idFactura;

    for (let i = 0; i < numberOfProducts; i++) {


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


    document.getElementById("createFactura").setAttribute('onclick', 'updateItem( " ' + factura.idFactura+ ' " )');

}


function addItem() {

    let factura = prepareFacturaForSubmit();


    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(factura)
    })
        .then(response => response.json())
        .then(data =>  window.location.href="index.html")
        .catch(error => console.error('Unable to add item.', error));

}

function updateItem() {

    let factura = prepareFacturaForSubmit()

    console.log(factura);

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(factura),
        success: function () {
            successmessage = 'Data was succesfully captured';
        },
    })
        .then(res => res.text())          // convert to plain text
        .then(text => console.log(text))
        .then(data => window.location.href = "index.html")
        .catch(error => console.error('Unable to add item.', error));

}


addProductButton.addEventListener("click", function () {

    let numeProdus = document.getElementById('numeProdus').value;
    let cantitate = document.getElementById('cantitate').value;
    let pretUnitar = document.getElementById('pretUnitar').value;
    let valoare = document.getElementById('valoare').value;
    

    if (numeProdus == null || numeProdus == "", cantitate == null || cantitate == "",
        pretUnitar == null || pretUnitar == "", valoare == null || valoare == "") {
        errorMessageProductsForm.classList.remove("d-none");
        errorMessageProductsForm.style.visibility = true
        return false;
    }

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
    let textNode4 = document.createTextNode(valoare);
    td4.appendChild(textNode4);
    document.getElementById('valoare').value = "";

});


function addProducts() {

    let cantitate = document.getElementById("cantitate");

    let td2 = tr.insertCell(0);
    let textNode2 = document.createTextNode(cantitate.nodeValue);
    td2.appendChild(textNode2);

}

function goPrev() {
    window.history.back();
}