<template>
    <div class="table">
        <table>
            <thead class="thead">
                <tr>
                    <td>Nome</td> 
                    <td>E-mail</td>
                    <td>Telefone</td>
                    <td>CPF</td>
                    <td id="action">Ações</td>
                </tr>
            </thead>
            <tbody id="table_client" class="tbody">
                <tr v-for="cliente in clientes" :key="cliente.id">
                    <td>{{ cliente.nome }}</td>                      
                    <td>{{ cliente.email }}</td>           
                    <td>{{ cliente.telefone }}</td>
                    <td>{{ cliente.cpf }}</td>                      
                    <td>
                        <div>
                            <button class="edit_btn" :id="cliente.id">editar</button>                              
                            <button class="del_btn" :id="cliente.id" @click="deleteCliente(cliente)">deletar</button>
                        </div>                          
                    </td>
                </tr>
            </tbody>          
        </table>
    </div>
</template>

<script>   
    export default {
        emits: ['deleteCliente'],
        props:{
            clientes:{type: Object},
        },
        methods:{
            deleteCliente(cliente){
                this.$emit('deleteCliente', cliente);
            }
        }
    }
</script>

<style>
</style>