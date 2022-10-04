// Modal de adicionar itens de venda no Mobile

const openAddItem =  document.querySelector('#more_itens')
const closeAddItem = document.querySelector('#close_modal')
const modalAddItem = document.querySelector('#modal_add')
const fadeAddItem = document.querySelector('#fade_add')

const toggleModalAddItem = () => {
    modalAddItem.classList.toggle("hide")
    fadeAddItem.classList.toggle("hide")
}

[openAddItem, closeAddItem, fadeAddItem].forEach(element => {
    element.addEventListener("click", () => toggleModalAddItem())
});
