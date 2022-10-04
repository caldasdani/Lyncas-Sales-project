
// Modal para mostrar detalhes dos clientes no Mobile

const openModalDetails =  document.querySelector('#open_details')
const closeModalDetails = document.querySelector('#close_details')
const modal = document.querySelector('#modal')
const fade = document.querySelector('#fade')

const toggleModal = () => {
    modal.classList.toggle("hide")
    fade.classList.toggle("hide")
}

[openModalDetails, closeModalDetails, fade].forEach(element => {
    element.addEventListener("click", () => toggleModal())
});


//----------------------------------------------------------------------
