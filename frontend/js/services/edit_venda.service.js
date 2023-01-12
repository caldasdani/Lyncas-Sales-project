import { ApiService } from "../api/api.service.js";

let clienteId = localStorage.getItem("clienteId")
idCliente.value = `${clienteId}`

export async function editVenda(event){
    event.preventDefault();
    let id = localStorage.getItem("vendaId")
    let clienteId = localStorage.getItem("clienteId")
    let dataFaturamento = document.getElementById("data").value;    
    let itens = {
        descricaoItem: document.getElementById("desc").value,
        valorUnitario: document.getElementById("unit").value,
        quantidade: document.getElementById("quant").value,
        valorTotal: document.getElementById("total").value
    }
    let itensArray = [];
    itensArray.push(itens);
     
    let body = {
            id: id, 
            clienteId: clienteId, 
            dataFaturamento: dataFaturamento, 
            itens: itensArray
    }
 
    let resposta = await ApiService.put("Venda/atualizar", body);
    if(resposta.sucesso){
        alert(resposta.dados.mensagem);
        window.location.href = "http://127.0.0.1:5500/dash_venda.html"
    }
}

const form = document.getElementById("form")
form.addEventListener('submit', editVenda)

// {
//     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     "clienteId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//     "dataFaturamento": "2023-01-11T17:41:55.832Z",
//     "itens": [
//       {
//         "descricaoItem": "string", document.getElementById("desc").value;
//         "valorUnitario": 0,        document.getElementById("unit").value;
//         "quantidade": 0,           document.getElementById("quant").value;
//         "valorTotal": 0            document.getElementById("total").value;
//       }
//     ]
//   }