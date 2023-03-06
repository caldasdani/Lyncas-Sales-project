<template>
    <main class="main-container">
        <header_list/>
        <tabela_venda :vendas="listaVendas"/>
        <div class="paginacao">
            <v-pagination v-model="paginaAtual" :length="totalPaginas" :total-visible="6"/>
        </div>
    </main>
</template>

<script>
    import header_list from './head_lista_venda.vue'
    import tabela_venda from './tab_venda.vue'
    import serviceVenda from '../../common/service/venda.service'

    export default {
        components: {
            header_list,
            tabela_venda           
        },
        data(){
            return {
                listaVendas: [],
                listaVendasTotal: [],
                paginaAtual: 1,
                itensPorPagina: 5,
                totalPaginas: 1,
            }
        },
        methods: {
            async listarVendas(paginaAtual){
                const filtro = this.filterBuilder(paginaAtual)
                let resposta = await serviceVenda.getVenda(`Venda/listar${filtro}`)
                this.listaVendas = resposta.dados;

                let resposta2 = await serviceVenda.getVenda("Venda/listar")
                this.listaVendasTotal = resposta2.dados;
                
                this.totalPaginas = this.calcularPaginas()
            },
            filterBuilder(paginaAtual) {
                const offset = (paginaAtual - 1) * 5;
                return `?Limit=5&Offset=${offset}`
                //return `?Name=${this.filter.nameFilter}&Email=${this.filter.emailFilter}&PhoneNumber=${this.filter.phoneNumberFilter}&Cpf=${this.filter.cpfFilter}&IsActive=${this.filter.statusValueChecked}&Limit=5&Offset=${offset}`;
            },
            calcularPaginas() {
                return Math.ceil(this.listaVendasTotal.length / this.itensPorPagina);
            },
        },
        mounted(){
            this.listarVendas(this.paginaAtual)
        },
        watch:{
            async paginaAtual(paginaAtual) {
                await this.listarVendas(paginaAtual);               
            }
        }

    }
</script>

<style scoped>
.paginacao{        
    margin-top: 150px;
}
</style>
