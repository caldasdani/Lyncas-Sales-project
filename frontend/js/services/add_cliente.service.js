import { ApiService } from "../api/api.service.js";
import inputs from "../inputs.js"


export async function addCliente(event){
    let nome = document.getElementById("nome").value;
    let email = document.getElementById("email").value;
    let telefone = document.getElementById("tel").value;
    let cpf = document.getElementById("cpf").value;

    event.preventDefault();
    
    inputs.validarNome()
    inputs.validarEmail()
    inputs.validarTel()
    inputs.validarCPF()

    let body ={nome, email, telefone, cpf}
 
    let resposta = await ApiService.post("Cliente/adicionar", body);
    if(resposta.sucesso){
        alert(resposta.dados.mensagem);
        window.location.href = "http://127.0.0.1:5500/dash_cliente.html"
    }
    else{
        alert(resposta.notificacoes[0].message);
        return;
    }
    console.log(resposta);
}

const form = document.getElementById("form")
form.addEventListener('submit', addCliente)