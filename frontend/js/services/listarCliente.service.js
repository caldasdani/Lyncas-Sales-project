import { ApiService } from "../api/api.service.js";
import inputs from "../inputs.js"


//----------------------------------------------------------------------------------------

export async function listarCliente(){
    let listaClientes = await ApiService.get("Cliente/listar");
    
    console.log(listaClientes)

    const tbody = document.getElementById("table_client");

    listaClientes.dados.forEach(cliente => {
        const tr = criarLinhaTabela(cliente)
        tbody.appendChild(tr);
    });
}
listarCliente();


function criarLinhaTabela(cliente){
    const tr = document.createElement("tr")

    const tdNome = document.createElement("td")
    tdNome.innerHTML = cliente.nome;

    const tdEmail = document.createElement("td")
    tdEmail.innerHTML = cliente.email;

    const tdTelefone = document.createElement("td")
    tdTelefone.innerHTML = cliente.telefone;

    const tdCpf = document.createElement("td")
    tdCpf.innerHTML = cliente.cpf;

    const tdBotao = document.createElement("td");
    const del_btn = document.createElement("button");
    del_btn.innerHTML = "Deletar"
    del_btn.classList.add("del_btn")

    const edit_btn = document.createElement("button");
    edit_btn.innerHTML = "Editar"
    edit_btn.classList.add("edit_btn")

    tr.appendChild(tdNome);
    tr.appendChild(tdEmail);
    tr.appendChild(tdTelefone);
    tr.appendChild(tdCpf);

    tdBotao.appendChild(del_btn);
    tdBotao.appendChild(edit_btn);
    tr.appendChild(tdBotao);
    console.log(tr)
    return tr;
}



