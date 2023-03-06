<template>
    <main class="container">
        <div class="azul">
            <img id="logo" src="../assets/logo-lyncas-branco.png" width="245px">
            <p id="intro">Bem-vindo ao Lyncas Sales, uma aplicação simples para gerenciar vendas e clientes.</p>
        </div>
        <div class="branco">
            <span id="entrar">Entrar</span>
            <form @submit.prevent="validarUsuario" id="form_login">
                <input type="text" id="email" placeholder="E-mail" v-model="form.login">
                <input type="text" id="senha" placeholder="Senha" v-model="form.senha">
                <button id="login" type="submit" @click="validarUsuario">Entrar</button>
            </form>
            
        </div>
    </main>
</template>

<script>
    import serviceUsuario from '../common/service/usuario.service'

    export default {
        data() {
            return {
                form: {
                    login: '',
                    senha: '',
                }
            }
        },
        methods: {
            async validarUsuario() {
                const body = {
                    login: this.form.login,
                    senha: this.form.senha
                }
                try {
                    let resposta = await serviceUsuario.postUsuario("Usuario/autenticar", body);
                    if (resposta.sucesso == true) {
                        localStorage.setItem("token", resposta.dados.token);
                        window.location.href = "http://localhost:5173/dashboard"
                    }
                }
                catch (error) {
                    alert(error.response.data.notificacoes[0].message)
                }
            }
        }
    }
</script>

<style>
.container{
    display: flex;
    flex-direction: row;
    height: 100vh;
}
.azul{
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    width: 50%;   
    background: #1C3B85;
}
.branco{
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    background: #F8F8F8;
    width: 50%;
}
#intro{
    font-family: 'Jost';
    margin-top: 65px;
    width: 447px;
    font-style: normal;
    font-weight: 500;
    font-size: 24px;
    line-height: 35px;
    text-align: center;
    color: #D9D9D9;
}
#entrar{
    font-family: 'Jost';
    font-style: normal;
    font-weight: 500;
    font-size: 40px;
    line-height: 58px;
    text-align: center;
    color: #26324B;
}
#login{
    background: #03C874;
    border-radius: 4px;
    cursor: pointer;
    width: 100%;
    height: 39px;
    font-family: 'Jost';
    font-style: normal;
    font-weight: 700;
    font-size: 20px;
    line-height: 29px;
    color: #FFFFFF;
    margin-top: 24px;
    border: none;
}
#form_login{
    width: 60%;
}
#form_login input{
    background: #FFFFFF;
    border: 1px solid #E5EBF1;
    border-radius: 4px;
    width: 60%;
    height: 45px;
    margin-top: 11px;
    padding-left: 18px;
    width: 100%;
}
</style>