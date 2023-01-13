import { ApiService } from "../api/api.service.js";

export async function addVenda(event){
    event.preventDefault();

    let select = document.getElementById("name")
    let clienteId = select.options[select.selectedIndex].dataset.cliente;
    console.log(clienteId)

    let dataFaturamento = document.getElementById("data").value;    
    let itens = {
        descricaoItem: document.getElementById("desc").value,
        valorUnitario: document.getElementById("unit").value,
        quantidade: document.getElementById("quant").value,
        valorTotal: document.getElementById("total").value
    }
    let itensArray = [];
    itensArray.push(itens);

    let body ={
        clienteId: clienteId, 
        dataFaturamento: dataFaturamento, 
        itens: itensArray
    }
 
    let resposta = await ApiService.post("Venda/adicionar", body);
    if(resposta.sucesso){
        alert(resposta.dados.mensagem);
        window.location.href = "http://127.0.0.1:5500/dash_venda.html"
    }
    else{
        //alert(resposta.notificacoes[0].message);
        return;
    }
    console.log(resposta);
}


export async function selectCliente(){
    let listaClientes = await ApiService.get("Cliente/listar");
    console.log(listaClientes) 

    let select = document.getElementById("name")

    listaClientes.dados.forEach(cliente => {
        let option = document.createElement('option')
        option.setAttribute("data-cliente", cliente.id)
        option.innerHTML = cliente.nome

        select.appendChild(option)
    });  
}
selectCliente();


const form = document.getElementById("form")
form.addEventListener('submit', addVenda)