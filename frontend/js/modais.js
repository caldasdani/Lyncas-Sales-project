
// Modal para mostrar detalhes dos clientes no Mobile

// const openModalDetails =  document.querySelector('.open_details')

// const closeModalDetails = document.querySelector('#close_details')
// const modal = document.querySelector('#modal')
// const fade = document.querySelector('#fade')

// const toggleModal = () => {
//     modal.classList.toggle("hide")
//     fade.classList.toggle("hide")
// }

// [openModalDetails, closeModalDetails, fade].forEach(element => {
//     element.addEventListener("click", () => toggleModal())
// });


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

