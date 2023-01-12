import { ApiService } from "../api/api.service.js";


export async function editCliente(event){

    //let id = event.target.dataset.editar
    let id = localStorage.getItem("clienteId")
    let nome = document.getElementById("nome").value;
    let email = document.getElementById("email").value;
    let telefone = document.getElementById("tel").value;
    let cpf = document.getElementById("cpf").value;

    event.preventDefault();
    
    let body ={id, nome, email, telefone, cpf}
 
    let resposta = await ApiService.put("Cliente/atualizar", body);
    if(resposta.sucesso){
        alert(resposta.dados.mensagem);
        window.location.href = "http://127.0.0.1:5500/dash_cliente.html"
    }
}

const form = document.getElementById("form")
form.addEventListener('submit', editCliente)