<template>
    <main class="main-container">
        <header_list/>
        <tabela_cliente :clientes="listaClientes" @deleteCliente="deleteCliente"/>
        <div class="paginacao">
            <v-pagination v-model="paginaAtual" :length="totalPaginas" :total-visible="6"/>
        </div>
    </main>
</template>

<script>
    import header_list from './head_lista_cliente.vue'
    import tabela_cliente from './tab_cliente.vue'
    import serviceCliente from '../../common/service/cliente.service'

    export default {
        components: {
            header_list,
            tabela_cliente,
        },
        data() {
            return {
                listaClientesTotal: [],
                listaClientes: [],
                paginaAtual: 1,
                itensPorPagina: 5,
                totalPaginas: 1,
            }
        },
        methods: {
            async listarCliente(paginaAtual){
                const filtro = this.filterBuilder(paginaAtual)
                let resposta = await serviceCliente.getCliente(`Cliente/listar${filtro}`)
                this.listaClientes = resposta.dados;

                let resposta2 = await serviceCliente.getCliente("Cliente/listar")
                this.listaClientesTotal = resposta2.dados;
                
                this.totalPaginas = this.calcularPaginas()
            },
            filterBuilder(paginaAtual) {
                const offset = (paginaAtual - 1) * 5;
                return `?Limit=5&Offset=${offset}`
                //return `?Name=${this.filter.nameFilter}&Email=${this.filter.emailFilter}&PhoneNumber=${this.filter.phoneNumberFilter}&Cpf=${this.filter.cpfFilter}&IsActive=${this.filter.statusValueChecked}&Limit=5&Offset=${offset}`;
            },
            calcularPaginas() {
                return Math.ceil(this.listaClientesTotal.length / this.itensPorPagina);
            },
            async deleteCliente(cliente){
                let body = {id: cliente.id};
                let resposta = await serviceCliente.deleteCliente("Cliente/remover", body);
                
                if(resposta.sucesso === true){
                    alert(resposta.dados.mensagem);
                    await this.listarCliente(this.paginaAtual);                   
                }
            }
        },
        mounted() {        
            this.listarCliente(this.paginaAtual)           
        },
        watch:{
            async paginaAtual(paginaAtual) {
                await this.listarCliente(paginaAtual);               
            }
        }
    }
</script>

<style scoped>
    .paginacao{        
        margin-top: 150px;
    }
</style>
