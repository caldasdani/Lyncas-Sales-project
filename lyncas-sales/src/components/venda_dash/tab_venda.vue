<template>
    <div class="table">
        <table>
            <thead class="thead">
                <tr>
                    <td>Cliente</td> 
                    <td>Qtd. itens</td>
                    <td>Data da venda</td>
                    <td>Data Faturamento</td>
                    <td>Valor total</td>
                    <td id="action">Ações</td>
                </tr>
            </thead>
            <tbody id="table_sale" class="tbody">
                <tr v-for="venda in vendas" :key="venda.id">

                    <td> {{ venda.clienteNome }} </td>
                    <td> {{ venda.quantidadeItens }} </td>                   
                    <td> {{ formattingDate(venda.dataVenda) }} </td>                    
                    <td> {{ formattingDate(venda.dataFaturamento) }} </td>                                   
                    <td> {{ formattingCurrency(venda.valorTotal) }} </td>
                    <td>
                        <div>
                            <button class="edit_btn" :id="venda.id">editar</button>
                            <button class="del_btn" :id="venda.id" @click="deleteVenda(venda)">deletar</button>
                        </div>  
                    </td>
                </tr>
            </tbody>       
        </table>
    </div>
</template>

<script>
    import serviceVenda from '../../common/service/venda.service';
    import { formattingDate, formattingCurrency } from '../../common/teste'

    export default{
        data(){
            return{
                formattingDate,
                formattingCurrency
            }           
        },
        props:{
            vendas:{type: Object},
        },
        methods:{
            async deleteVenda(venda){
                let body = {id: venda.id};
                let resposta = await serviceVenda.deleteVenda("Venda/remover", body);
                
                if(resposta.sucesso === true){
                    alert(resposta.dados.mensagem);
                    window.location.reload();
                }
            }
        }
    }
</script>

<style>
.table{
    width: 100%;
    height: 260px;
}
.table table{
    border-spacing: 0 20px;
    width: 100%;
}
.thead{
    margin-top: 10px;
    font-style: normal;
    font-weight: 400;
    font-size: 16px;
    line-height: 23px;
    color: #7B828D;
}
.tbody{
    height: 220px;
    border-spacing: 0px 10px;
}
.tbody tr{
    background: #FFFFFF;
    font-style: normal;
    font-weight: 500;
    font-size: 14px;
    color: #26324B;
    height: 50px;
}
.tbody tr td:first-child{
    padding-left: 10px;
    border-top-left-radius: 5px; 
    border-bottom-left-radius: 5px;
}
.tbody tr td:last-child{
    border-top-right-radius: 5px; 
    border-bottom-right-radius: 5px;
}
#action{
    display: flex;
    margin-left: 70px;
}
.del_btn{
    font-family: 'Jost', sans-serif;
    font-weight: 500;
    font-size: 0.875em;
    color: #C27476;
    cursor: pointer;
    width: 6.290625vw;
    height: 5.8236272878535775vh;
    background-color: #FDF6F6;
    border: 1px solid #F7EEEE;
    border-radius: 5px;
    margin-right: 0.625vw;
    margin-left: 10px;
}
.edit_btn{
    font-family: 'Jost', sans-serif;
    font-weight: 500;
    font-size: 0.875em;
    color: #5B89C7;
    cursor: pointer;
    width: 5.90078125vw;
    height: 5.8236272878535775vh;
    background-color: #F6FAFD;
    border: 1px solid #EEF1F7;
    border-radius: 5px;
}
</style>