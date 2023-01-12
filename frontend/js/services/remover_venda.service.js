import { ApiService } from "../api/api.service.js";

export async function removerVenda(event){
    let body = {id: event.target.dataset.deletar}
    let resposta = await ApiService.delete("Venda/remover", body);
  
    if(resposta.sucesso == true){
        alert(resposta.dados.mensagem);
        window.location.href = "http://127.0.0.1:5500/dash_venda.html"
    }
}
