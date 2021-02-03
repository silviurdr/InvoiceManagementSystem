const uri = 'https://localhost:5001/api/factura';

let addProductButton = document.getElementById("addProductButton"); 
let productsTableBody = document.getElementById("productsTableBody");
let errorMessageProductsForm = document.getElementById("errorMessageProductsForm");


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