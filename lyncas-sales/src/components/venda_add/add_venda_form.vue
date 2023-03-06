<template>
    <form id="form" @submit.prevent="save">
        <div class="form_itens1">
            <div class="input1-add-venda">
                <div class="input_container1">
                    <label for="nome">Cliente</label>
                    <select id="name" required type="text" v-model="venda.clienteId">
                        <option value="Selecionar" selected disabled>Selecione o Cliente</option>
                        <option :value="cliente.id" v-for="cliente in clientes" :key="cliente.id"> {{ cliente.nome }}</option>
                    </select>
                </div>
                <div class="input_container2">
                    <label for="data">Data do faturamento</label>
                    <input id="data" required type="date" v-model="venda.dataFaturamento">
                </div>
            </div>
        </div>
        <div>
            <p id="title2">Itens do pedido</p>
        </div>
        <div class="form_itens2" v-for="(item, index) in venda.itens" :key="index">
            <div class="input2-add-venda">
                <div class="input_container1">
                    <label for="description">Descrição do item</label>
                    <input id="desc" required type="text" @input="atualizarInputs(index, 'descricaoItem', $event.target.value)">
                </div>
                <div class="input_container2">
                    <label for="unit">Valor Unitário</label>
                    <input id="unit" required type="number" pattern="([0-9]{1,3}\.)?[0-9]{1,3},[0-9]{2}$" @input="atualizarInputs(index, 'valorUnitario', $event.target.value)">
                </div>
            </div>
            <div class="input2-add-venda">
                <div class="input_container1">
                    <label for="quantity">Quantidade</label>
                    <input id="quant" required type="number" @input="atualizarInputs(index, 'quantidade', $event.target.value)">
                </div>
                <div class="input_container2">
                    <label for="total">Valor total</label>
                    <input id="total" required type="number" @input="atualizarInputs(index, 'valorTotal', $event.target.value)">
                </div>
            </div>
        </div>
        <div class="more_itens_div">
            <button id="more_itens" type="button" @click="maisItens">+ Mais itens</button>
        </div>
        <div class="baseline">
            <div id="total">
                <p>Total: {{ total }}</p>
            </div>
            <div id="btt">
                <button type="submit" id="save">Salvar</button>
            </div>
        </div>
    </form>
    <!-- <div id="fade_add" class="hide"></div>
    <div id="modal_add" class="hide">
        <div id="modal_x">
            <a href="./add_venda.html" id="close_modal"><img src="./img/x.png"></a>
        </div>
        <div id="header_modal">
            <p>Adicionar item</p>
        </div>
        <div id="inputs_modal" >
            <label for="description">Descrição do item</label>
            <input id="descMore" required type="text"> 

            <label for="unit">Valor Unitário</label>
            <input id="unitMore" required type="number" pattern="([0-9]{1,3}\.)?[0-9]{1,3},[0-9]{2}$">

            <label for="quantity">Quantidade</label>
            <input id="quantMore" required type="number">

            <label for="total">Valor total</label>
            <input id="totalMore" required type="number">
        </div>
        <div id="button_modal">
            <button>Adicionar</button>
        </div>
    </div> -->
</template>

<script>
    import serviceCliente from '../../common/service/cliente.service'

    export default {

        emits:['save'],
        data() {
            return {
                clientes:[],
                venda: {
                    clienteId: '',
                    dataFaturamento: '',
                    itens: []
                }
            };
        },
        methods: {
            save() {
                this.$emit('save', {venda: this.venda});
            },
            maisItens(){
                this.venda.itens.push({               
                "descricaoItem": '',
                "valorUnitario": '',
                "quantidade": '',
                "valorTotal": ''              
                });    
            },
            atualizarInputs(index, campo, valor){
                this.venda.itens[index][campo] = valor;
                console.log(this.venda.itens);
            },
        },
        // created() {
        //     this.soma()
        // },
        computed: {
            soma(){
                return 
            }
        },
        async mounted() {
            const response = await serviceCliente.getCliente("Cliente/listar");
            this.clientes = response.dados;

            this.venda.itens.push({               
                "descricaoItem": '',
                "valorUnitario": '',
                "quantidade": '',
                "valorTotal": ''              
            });
        }
    };
</script>

<style>
#title_responsive{
    display: none;
}
#title2{
    font-family: 'Jost';
    font-style: normal;
    font-weight: 500;
    font-size: 18px;
    line-height: 26px;
    color: #26324B;
    padding-left: 40px;
    padding-top: 15px;
    padding-bottom: 15px;
}
form{
    display: flex;
    flex-direction: column;
}
label{
    font-family: 'Jost';
    font-style: normal;
    font-weight: 400;
    font-size: 16px;
    line-height: 23px;
    color: #7B828D;
}
.input_container1{
    display: flex;
    flex-direction: column;
    width: 100%;   
}
.input_container2{
    display: flex;
    flex-direction: column;
    width: 100%;  
}
.form_itens1{
    padding-left: 40px;
    padding-right: 40px;
}
.input1-add-venda{
    display: flex;
    justify-content: space-between;
    padding-bottom: 20px;
    border-bottom: 2px dashed rgba(229, 235, 241, 1);
    gap: 20px;
}
.input1-add-venda select{
    background: #FFFFFF;
    border: 1px solid #E5EBF1;
    border-radius: 4px;
    width: 100%;
    height: 38px;
    padding-left: 10px;
}
.input1-add-venda input{
    background: #FFFFFF;
    border: 1px solid #E5EBF1;
    border-radius: 4px;
    height: 38px;
    padding-left: 15px;
}
.form_itens2{ 
    display: flex;
    flex-direction: column;
    padding-left: 40px;
    padding-right: 40px;
}
.input2-add-venda{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    padding-bottom: 20px;
    gap:20px;
}
.input2-add-venda input{
    background: #FFFFFF;
    border: 1px solid #E5EBF1;
    border-radius: 4px;
    height: 38px;
    padding-left: 15px; 
}
.more_itens_div{
    display: flex;
    width: 50%;
    align-self: end;
    padding-bottom: 20px;
    padding-right: 40px;
}
#more_itens{
    display: flex;
    align-items: center;
    justify-content: center;
    height: 40px;
    width: 100%;
    border-radius: 4px;
    border: 2px solid rgba(39, 74, 157, 1);
    font-family: 'Jost';
    font-weight: 700;
    font-size: 20px;
    line-height: 29px;
    color: #274A9D;
    cursor: pointer;
    margin-left: 10px;
}
.baseline{
    display: flex;
    margin-left: 40px;
    margin-right: 40px;
    padding-top: 20px;
    padding-bottom: 20px;
    border-top: 2px dashed rgba(229, 235, 241, 1);
}
.baseline div{
    width: 100%;
    align-items: flex-end;
    justify-content: space-between;
}
.baseline button{
    height: 39px;
    background: #03C874;
    border: none;
    width: 100%;
    border-radius: 4px;
    font-family: 'Jost';
    font-style: normal;
    font-weight: 700;
    font-size: 20px;
    color: #FFFFFF;
    cursor: pointer;
}
.baseline p{
    font-family: 'Jost';
    font-style: normal;
    font-weight: 700;
    font-size: 24px;
    line-height: 35px;
    color: #26324B;
}
#fade_add{
    display: flex;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.6);
    z-index: 5;
}
#modal_add{
    display: flex;
    flex-direction: column;
    position: fixed;
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
    z-index: 10;
    padding: 50px;
    position: absolute;
    width: 389px;
    height: 476px;  
    background: #F8F8F8;
    border-radius: 10px;
}
#modal_add, #fade_add{
    transition: 0.5s;
    opacity: 1;
    pointer-events: all;
}
#modal_add.hide, #fade_add.hide{
    opacity: 0;
    pointer-events: none;
}
#header_modal{
    display: flex;
    justify-content: center;
    height: 50px;
    align-items: center;
    margin-bottom: 30px;
}
#header_modal p{
    font-family: 'Jost';
    font-style: normal;
    font-weight: 500;
    font-size: 24px;
    line-height: 35px;
    color: #26324B;
}
#modal_x{
    display: flex;
    justify-content: end;
}
#inputs_modal{
    display: flex;
    flex-direction: column;
}
#modal.hide{
    top: 0;
}
label{
    font-family: 'Jost';
    font-style: normal;
    font-weight: 400;
    font-size: 16px;
    line-height: 23px;
    color: #7B828D;
}  
#button_modal button{
    margin-top: 20px;
    width: 100%;
    background: #03C874;
    border-radius: 4px;
    height: 38px;
    border: none;
    font-family: 'Jost';
    font-style: normal;
    font-weight: 700;
    font-size: 20px;
    line-height: 29px;
    color: #FFFFFF;
    cursor: pointer;
}
</style>