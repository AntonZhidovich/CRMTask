function OnBtnCreate() {
    document.getElementById("modalTitle").textContent = "New contact";
    const createForm = document.getElementById("ModalForm");
    createForm.action = "/Home/Create";
    ShowModal();
}

async function OnBtnEdit(id) {
    let contact = await (await fetch('/home/update/' + id, {
        method: 'get',
    })).json();
    const createForm = document.getElementById("ModalForm");
    document.getElementById("modalTitle").textContent = "Edit contact";
    createForm.action = "/Home/Update";
    document.getElementById("idIn").value = contact.id;
    document.getElementById("nameIn").value = contact.name;
    document.getElementById("phoneIn").value = contact.mobilePhone;
    document.getElementById("jobIn").value = contact.jobTitle;
    document.getElementById("birthIn").value = contact.birthDate.slice(0, -9); 
    ShowModal();
}

function ShowModal() {
    const overlay = document.getElementById("overlayElem");
    const modal = document.getElementById("CreateModal");
    overlay.classList.remove("hidden");
    modal.style.display = "block";
}

function HideModal() {
    const overlay = document.getElementById("overlayElem");
    const modal = document.getElementById("CreateModal");
    overlay.classList.add("hidden");
    modal.style.display = "none";
    phoneIn.style.borderColor = "lightgrey";
    document.getElementById("phoneError").style.display = "none";
    birthIn.style.borderColor = "lightgrey";
    document.getElementById("birthError").style.display = "none";
}

function confirmDelete() {
    return confirm("Are you sure you want to delete the contact?");
}

function isValid() {
    let res = true;
    const phoneIn = document.getElementById("phoneIn");
    let phonePattern = /^\+375[0-9]{9}$/;
    if (!phonePattern.test(phoneIn.value)) {
        phoneIn.style.borderColor = "red";
        document.getElementById("phoneError").style.display = "block";
        res = false;
    }
    const birthIn = document.getElementById("birthIn");
    let dateNow = new Date();
    let userDate = new Date(birthIn.value);
    if (userDate > dateNow) {
        birthIn.style.borderColor = "red";
        document.getElementById("birthError").style.display = "block";
        res = false;
    }
    return res;
}