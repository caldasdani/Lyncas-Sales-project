<template>
    <main class="main-container-add-cliente">
        <div>
            <p id="title-add-cliente">Adicionar cliente</p>
        </div>
        <form_cliente @save="addCliente"/>
    </main>
</template>

<script>
    import form_cliente from './add_cliente_form.vue'
    import serviceCliente from '../../common/service/cliente.service'

    export default {
        components: {
            form_cliente,
        },
        data() {
            return {
                form: {
                    nome: '',
                    email: '',
                    telefone: '',
                    cpf: ''
                }
            }
        },
        methods: { 
            async addCliente(params) {
                let cliente = {
                    nome: params.cliente.nome,
                    email: params.cliente.email,
                    telefone: params.cliente.tel,
                    cpf: params.cliente.cpf
                }
                try{
                    let resposta = await serviceCliente.postCliente("Cliente/adicionar", cliente);
                    if (resposta.sucesso == true) {
                        alert(resposta.dados.mensagem);
                        console.log(resposta); 
                        window.location.href = "http://localhost:5173/dash_cliente"
                    }
                }
                catch(erro) {
                    alert(erro.response.data.notificacoes[0].message);                  
                }         
            }
        }
        // methods: {
        //     save() {
        //         this.$store.dispatch('add_client', this.form)
        //     }
        // }
    }
</script>


<style>

.main-container-add-cliente{
    display: flex;
    flex-direction: column;
    box-sizing: border-box;
    background: #FFFFFF;
    border: 1px solid #E5EBF1;
    border-radius: 5px;
    margin-top: 50px;
    height: 350px;
    padding-left: 40px;
    padding-right: 40px;
}
#title-add-cliente{
    font-family: 'Jost';
    font-style: normal;
    font-weight: 700;
    font-size: 20px;
    line-height: 29px;
    color: #26324B;
    padding-left: 40px;
    padding-top: 30px;
    padding-bottom: 50px;
}



</style>