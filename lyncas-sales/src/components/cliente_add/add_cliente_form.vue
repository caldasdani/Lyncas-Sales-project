<template>
    <form @submit.prevent="save" id="form">
        <div class="input1">
            <div class="input_container_add">
                <label for="nome">Nome</label>
                <input v-model="cliente.nome" id="nome" name="nome" required type="text">
            </div>
            <div class="input_container_add">
                <label for="e-mail">E-mail</label>
                <input v-model="cliente.email" id="email" name="e-mail" required type="email">
            </div>
        </div>
        <div class="input1">
            <div class="input_container_add">
                <label for="telefone">Telefone</label>
                <input v-model="cliente.tel" id="tel" name="telefone" required type="text" maxlength="15" pattern="\(?[0-9]{2}\)?[0-9]{5}-?[0-9]{4}">
            </div>
            <div class="input_container_add">
                <label for="cpf">CPF</label>
                <input v-model="cliente.cpf" id="cpf" name="cpf" required type="text" maxlength="14" pattern="\d{3}\.\d{3}\.\d{3}-\d{2}">
            </div>
        </div>
        <div class="btt">
            <button type="submit" id="save">Salvar</button>
        </div>
    </form>
</template>

<script>
    export default {
        emits:['save'],
        data() {
            return {
                cliente: {
                    nome: '',
                    email: '',
                    tel: '',
                    cpf: ''
                }
            };
        },
        methods: {
            save() {
                this.$emit('save', {cliente: this.cliente});
            }
        }
    };
</script>

<style>
    .input_container_add{
        display: flex;
        flex-direction: column;
        width: 100%;
        
    }
    .btt{
        display: flex;
        align-self: end;
        width: 50%;
        padding-top: 20px;
    }
    #save{
        width: 150px;
        background: #03C874;
        color: #FFFFFF;
        border-radius: 4px;
        font-family: 'Jost';
        font-style: normal;
        font-size: 16px;
        border: none;
        cursor: pointer;
        width: 100%; 
        height: 38px;
        margin-left: 10px;
    }
    form{
        display: flex;
        flex-direction: column;
    }
    .input1{
        display: flex;
        justify-content: space-between;
        padding-bottom: 10px;
        gap: 20px;
    }
    .input1 input{
        border: 1px solid #E5EBF1;
        border-radius: 4px;
        height: 38px;
        padding-left: 15px;
    }
    label{
        font-family: 'Jost';
        font-style: normal;
        font-weight: 400;
        font-size: 16px;
        line-height: 23px;
        color: #7B828D;
    }
</style>