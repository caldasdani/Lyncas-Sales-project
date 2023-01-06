import { ApiService } from "../api/api.service.js";

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
    del_btn.innerHTML = "Deletar"
    del_btn.classList.add("del_btn")

    const edit_btn = document.createElement("button");
    edit_btn.innerHTML = "Editar"
    edit_btn.classList.add("edit_btn")

    tr.appendChild(tdCliente);
    tr.appendChild(tdQt_itens);
    tr.appendChild(tdData_venda);
    tr.appendChild(tdData_fat);
    tr.appendChild(tdValor_total);

    tdBotao.appendChild(del_btn);
    tdBotao.appendChild(edit_btn);
    tr.appendChild(tdBotao);

    return tr;
}