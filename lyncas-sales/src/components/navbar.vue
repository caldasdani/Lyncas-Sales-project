<template>
    <nav class="navbar-container">
        <div class="logo-container">
            <img id="logo" src="../assets/logo-lyncas.svg" width="100">
        </div>
        <div class="navitens-container">
            <button @click="handleDash"><img class="minilogo" src="../assets/dash_img.png">Dashboard</button>
            <router-link to="/dash_cliente"><button><img class="minilogo" src="../assets/cliente_img.svg">Clientes</button></router-link>
            <router-link to="/dash_venda"><button><img class="minilogo" src="../assets/venda_img.svg">Vendas</button></router-link>
        </div>
    </nav>
</template>
    
<script>
    export default {
        
        methods: {
            handleDash(){
                this.$router.push('/dashboard')
            }
        }
    }
</script>

<style>
.navbar-container {
    display:flex;
    flex-direction: column;
    width: 200px;
    height: 100vh;
    background: #274A9D;
    align-items: center;
}
.logo-container{
    margin-top: 50%;
}
.navitens-container{
    display: flex;
    flex-direction: column;
    margin-top: 130px;
    gap: 21px;
}
.navitens-container button{
    display: flex;
    align-items: center;
    padding-left: 13px;
    font-family: 'Jost';
    border: 1px solid #1C3B85;
    width: 136px;
    height: 36px;
    font-size: 16px;
    border-radius: 4px;
    background: none ;
    color: white;
    cursor: pointer;  
    gap: 10px;
}
.navitens-container a{
    text-decoration: none;
}
</style>