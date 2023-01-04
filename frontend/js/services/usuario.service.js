import { ApiService } from "../api/api.service.js";

export async function autenticar(){
    let login = document.getElementById("email").value;
    let senha = document.getElementById("senha").value;
    let body = {login,senha};

    let retorno = await ApiService.post("Usuario/autenticar", body);
    if(retorno.sucesso){
        window.location = "./dashboard.html"
    }
    else{
        alert(retorno.notificacoes[0].message);
        return;
    }

    localStorage.setItem("token", retorno.dados.token);
    console.log(retorno);
}