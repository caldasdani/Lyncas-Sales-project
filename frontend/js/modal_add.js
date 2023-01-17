// Modal de adicionar itens de venda no Mobile

const openAddItem =  document.querySelector('#more_itens')
const closeAddItem = document.querySelector('#close_modal')
const modalAddItem = document.querySelector('#modal_add')
const fadeAddItem = document.querySelector('#fade_add')
const btt_modal = document.querySelector('#button_modal')

const toggleModalAddItem = () => {
    modalAddItem.classList.toggle("hide")
    fadeAddItem.classList.toggle("hide")
}

[openAddItem, closeAddItem, fadeAddItem, btt_modal].forEach(element => {
    element.addEventListener("click", () => toggleModalAddItem())
});
