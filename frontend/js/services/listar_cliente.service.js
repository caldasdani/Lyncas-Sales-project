import { ApiService } from "../api/api.service.js";
import { removerCliente } from "./remover_cliente.service.js";


//----------------------------------------------------------------------------------------


export async function listarCliente(){
    let listaClientes = await ApiService.get("Cliente/listar");
    let pagAtual = 1;

    const tbody = document.getElementById("table_client");
    const voltar = document.getElementById("previous")
    const passar = document.getElementById("next")

    function mostraPag(pagNum) {
        const startIndex = (pagNum - 1) * 5;
        const endIndex = startIndex + 5;
        
        const pagCliente = listaClientes.dados.slice(startIndex, endIndex);
        
        pagCliente.forEach(cliente => {
            const tr = criarLinhaTabelaCliente(cliente)
            tbody.appendChild(tr);
        });
        pagAtual = pagNum;
        
        console.log(pagCliente)
    }
    mostraPag(1);

    let pagina = document.getElementById("pagNumber")

    voltar.addEventListener('click', ()=>{
        tbody.innerHTML = "";
        const prevPage = pagAtual -1

        pagina.innerHTML = `Pagina ${prevPage}`

        if(prevPage >= 1) {
            mostraPag(prevPage);
        }
        voltar.disabled = prevPage <= 1;
        passar.disabled = prevPage >= listaClientes.dados.length/5;
        
    })
    
    passar.addEventListener('click', ()=>{
        tbody.innerHTML = "";
        const nextPage = pagAtual + 1;

        pagina.innerHTML = `Pagina ${nextPage}`

        mostraPag(nextPage);
        
        voltar.disabled = nextPage <= 1;
        passar.disabled = nextPage >= listaClientes.dados.length/5;
    })  
}
listarCliente();

export async function listarClienteSelect(){
    let tipo_busca = search.value
    let valor_busca = input.value
    let listaClientes = await ApiService.get(`Cliente/listar?${tipo_busca}=${valor_busca}`);

    const tbody = document.getElementById("table_client");
    tbody.innerHTML = "";

    listaClientes.dados.forEach(cliente => {
        const tr = criarLinhaTabelaCliente(cliente)
        tbody.appendChild(tr);
    });
}

export function criarLinhaTabelaCliente(cliente){
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
    del_btn.setAttribute("data-deletar",`${cliente.id}`)
    del_btn.innerHTML = "Deletar"
    del_btn.classList.add("del_btn")

    const edit_btn = document.createElement("button");
    edit_btn.setAttribute("data-editar",`${cliente.id}`)
    edit_btn.innerHTML = "Editar"
    edit_btn.classList.add("edit_btn")
    
    tr.appendChild(tdNome);
    tr.appendChild(tdEmail);
    tr.appendChild(tdTelefone);
    tr.appendChild(tdCpf);

    tdBotao.appendChild(del_btn);
    tdBotao.appendChild(edit_btn);
    tr.appendChild(tdBotao);

    del_btn.addEventListener('click', removerCliente)

    edit_btn.onclick = function(){
        localStorage.setItem("clienteId", cliente.id), 
        window.location.href = "http://127.0.0.1:5500/edit_cliente.html"
    }
    return tr;
}

//-------------------------------------------------------------------------
export async function listarClienteResp(){
    let listaClientes = await ApiService.get("Cliente/listar");
    let pagAtual = 1;

    const tbody = document.getElementById("table_client_responsive");
    const voltar = document.getElementById("previous2")
    const passar = document.getElementById("next2")

    function mostraPag(pagNum) {
        const startIndex = (pagNum - 1) * 5;
        const endIndex = startIndex + 5;
        
        const pagCliente = listaClientes.dados.slice(startIndex, endIndex);
        
        pagCliente.forEach(cliente => {
            const tr = criarLinhaTabelaClienteResp(cliente)
            tbody.appendChild(tr);
        });
        pagAtual = pagNum;
        
        console.log(pagCliente)
    }
    mostraPag(1);

    let pagina = document.getElementById("pagNumber")

    voltar.addEventListener('click', ()=>{
        tbody.innerHTML = "";
        const prevPage = pagAtual -1

        pagina.innerHTML = `Pagina ${prevPage}`

        if(prevPage >= 1) {
            mostraPag(prevPage);
        }
        voltar.disabled = prevPage <= 1;
        passar.disabled = prevPage >= listaClientes.dados.length/5;
        
    })
    
    passar.addEventListener('click', ()=>{
        tbody.innerHTML = "";
        const nextPage = pagAtual + 1;

        pagina.innerHTML = `Pagina ${nextPage}`

        mostraPag(nextPage);
        
        voltar.disabled = nextPage <= 1;
        passar.disabled = nextPage >= listaClientes.dados.length/5;
    })  
}
listarClienteResp();

export async function listarClienteSelectResp(){
    let tipo_busca = search2.value
    let valor_busca = input2.value
    let listaClientes = await ApiService.get(`Cliente/listar?${tipo_busca}=${valor_busca}`);

    const tbody = document.getElementById("table_client_responsive");
    tbody.innerHTML = "";

    listaClientes.dados.forEach(cliente => {
        const tr = criarLinhaTabelaClienteResp(cliente)
        tbody.appendChild(tr);
    });
    console.log(listaClientes)
}

export function criarLinhaTabelaClienteResp(cliente){
    const tr = document.createElement("tr")

    const tdNome = document.createElement("td")
    tdNome.innerHTML = cliente.nome;

    const tdCpf = document.createElement("td")
    tdCpf.innerHTML = cliente.cpf;
    tdCpf.classList.add("cpf")

    const tdDetalhes = document.createElement("button")
    tdDetalhes.classList.add("open_details")

    tr.appendChild(tdNome);
    tr.appendChild(tdCpf);
    tr.appendChild(tdDetalhes)

    return tr;
}
