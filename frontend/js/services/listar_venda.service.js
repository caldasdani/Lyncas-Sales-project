import { ApiService } from "../api/api.service.js";
import { removerVenda } from "./remover_venda.service.js";

//----------------------------------------------------------------------------------------

export async function listarVenda(){
    let listaVendas = await ApiService.get("Venda/listar");
    console.log(listaVendas);

    const tbody = document.getElementById("table_sale");

    listaVendas.dados.forEach(venda => {
        const tr = criarLinhaTabelaVenda(venda)
        tbody.appendChild(tr);
    });
}
listarVenda();

export function criarLinhaTabelaVenda(venda){
    const tr = document.createElement("tr")

    const tdCliente = document.createElement("td")
    tdCliente.innerHTML = venda.clienteNome;
    
    const tdQt_itens = document.createElement("td")
    if(venda.itens){
        tdQt_itens.innerHTML = venda.itens.length;
    }
    else{
        tdQt_itens.innerHTML = venda.quantidadeItens;
    }
    
    const tdData_venda = document.createElement("td")
    if(venda.itens){
        tdData_venda.innerHTML = new Date(venda.dataFaturamento).toLocaleDateString();
    }
    else{
        tdData_venda.innerHTML = new Date(venda.dataVenda).toLocaleDateString();
    }
    
    
    const tdData_fat = document.createElement("td")
    tdData_fat.innerHTML = new Date(venda.dataFaturamento).toLocaleDateString();

    const tdValor_total = document.createElement("td")
    if(venda.itens){
        tdValor_total.innerHTML = venda.itens[0].valorTotal;
    }
    else{
        tdValor_total.innerHTML = venda.valorTotal;
    }
    
    const tdBotao = document.createElement("td");

    const del_btn = document.createElement("button");
    del_btn.setAttribute("data-deletar",`${venda.id}`)
    del_btn.innerHTML = "Deletar"
    del_btn.classList.add("del_btn")

    const edit_btn = document.createElement("button");
    edit_btn.setAttribute("data-editar",`${venda.id}`)
    edit_btn.innerHTML = "Editar"
    edit_btn.classList.add("edit_btn")
    edit_btn.onclick = function(){
        localStorage.setItem("vendaId", venda.id)
        localStorage.setItem("clienteId", venda.clienteId)
        window.location.href = "http://127.0.0.1:5500/edit_venda.html"
    }
    
    tr.appendChild(tdCliente);
    tr.appendChild(tdQt_itens);
    tr.appendChild(tdData_venda);
    tr.appendChild(tdData_fat);
    tr.appendChild(tdValor_total);

    tdBotao.appendChild(del_btn);
    tdBotao.appendChild(edit_btn);
    tr.appendChild(tdBotao);

    del_btn.addEventListener('click', removerVenda);

    //edit_btn.onclick
    return tr;
}