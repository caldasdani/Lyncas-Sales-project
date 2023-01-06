import { ApiService } from "../api/api.service.js";
import { criarLinhaTabelaCliente } from "./listar_cliente.service.js";

//----------------------------------------------------------------------------------------

export async function obterCliente(){
    let id = document.getElementById("input").value
    let cliente = await ApiService.get(`Cliente/obter/${id}`);
    
    const tbody = document.getElementById("table_client");
    tbody.innerHTML = "";

    const tr = criarLinhaTabelaCliente(cliente.dados)
    tbody.appendChild(tr);

    console.log(cliente)
}