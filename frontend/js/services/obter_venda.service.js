import { ApiService } from "../api/api.service.js";
import { criarLinhaTabelaVenda } from "./listar_venda.service.js";

export async function obterVenda(){
    let id = document.getElementById("input").value
    let venda = await ApiService.get(`Venda/obter/${id}`);
    
    const tbody = document.getElementById("table_sale");
    tbody.innerHTML = "";

    const tr = criarLinhaTabelaVenda(venda.dados)
    tbody.appendChild(tr);

    console.log(venda)
}