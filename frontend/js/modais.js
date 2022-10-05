
// Modal para mostrar detalhes dos clientes no Mobile

const openModalDetails =  document.querySelector('#open_details')
const openModalDetails2 =  document.querySelector('#open_details2')
const openModalDetails3 =  document.querySelector('#open_details3')
const openModalDetails4 =  document.querySelector('#open_details4')
const openModalDetails5 =  document.querySelector('#open_details5')

const closeModalDetails = document.querySelector('#close_details')
const modal = document.querySelector('#modal')
const fade = document.querySelector('#fade')

const toggleModal = () => {
    modal.classList.toggle("hide")
    fade.classList.toggle("hide")
}

[openModalDetails, openModalDetails2, openModalDetails3, openModalDetails4, openModalDetails5, closeModalDetails, fade].forEach(element => {
    element.addEventListener("click", () => toggleModal())
});


//----------------------------------------------------------------------
//-----------------------------------------------------------------------------------

// MODAL DE EDITAR O CLIENTE

const openEdit = document.querySelector('#open_edit')
const modalEdit = document.querySelector('#modal_edit')
const fadeEdit = document.querySelector('#fade_edit')
const openModalEdit = () => {
    modalEdit.classList.toggle("hide")
    fadeEdit.classList.toggle("hide")
}

[openEdit, fadeEdit].forEach(element => {
    element.addEventListener("click", () => openModalEdit())
});

