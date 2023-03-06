<template>
    <main class="main-container-add-venda">
        <div>
            <p id="title-add-venda">Adicionar venda</p>
        </div>
        <form_venda @save="addVenda"/>
    </main>
</template>

<script>
    import form_venda from './add_venda_form.vue'
    import serviceVenda from '../../common/service/venda.service'
    
    export default {
        components: {
            form_venda
        },
        data() {
            return {
                form: {
                    clienteId: '',
                    dataFaturamento: '',
                    itens: [],
                }
            };
        },
        methods: { 
            async addVenda(params) {
                console.log(params);

                let venda = {
                    clienteId: params.venda.clienteId,
                    dataFaturamento: params.venda.dataFaturamento,
                    itens: params.venda.itens
                }
                let resposta = await serviceVenda.postVenda("Venda/adicionar", venda);
                if (resposta.sucesso == true) {
                    alert(resposta.dados.mensagem);
                    console.log(resposta); 
                    window.location.href = "http://localhost:5173/dash_venda"
                }
                console.log(resposta);
            }
        }
    }
</script>

<style>
.main-container-add-venda{
    display: flex;
    flex-direction: column;
    box-sizing: border-box;
    background: #FFFFFF;
    border: 1px solid #E5EBF1;
    border-radius: 5px;
    margin-top: 30px;
    height: 360px;
    overflow-y: auto;
}
#title-add-venda{
    font-family: 'Jost';
    font-style: normal;
    font-weight: 700;
    font-size: 20px;
    line-height: 29px;
    color: #26324B;
    padding-left: 40px;
    padding-top: 30px;
    padding-bottom: 20px;
}
</style>