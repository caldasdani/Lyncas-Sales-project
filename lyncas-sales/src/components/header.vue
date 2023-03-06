
<template>
    <div class="head-container">
      <div class="profile">
          <div>
              <img id="profile_pic" src="../assets/profile_pic.jpeg">
          </div>
          <div class="head-itens-container">   
              <span id="hello">Olá Caldas</span>
              <a @click="logout" id="logout">Sair</a>
          </div>
      </div>
      <div>
        <span v-if="addClienteBtt"><btt value="Adicionar" :classe="'bttAdicionar'" @click="handleAddCliente"></btt></span>
        <span v-if="addVendaBtt"><btt value="Adicionar" :classe="'bttAdicionar'" @click="handleAddVenda"></btt></span>
        <span v-if="voltarDashBtt"><btt value="Voltar" :classe="'bttVoltar'" @click="handleDashboard"></btt></span>   
      </div>
    </div>
  </template>
  
  <script>
    import btt from './btt.vue'
  
    export default{
      data(){
       return {
        addClienteBtt: false,
        addVendaBtt: false,
        voltarDashBtt: false,
       }    
      },
      components:{
          btt
      },
      methods:{
        handleAddCliente(){
            this.$emit('button:Add')
            this.$router.push('/add_cliente')
        },
        handleAddVenda(){
            this.$emit('button:Add')
            this.$router.push('/add_venda')
        },
        handleDashboard(){
            this.$emit('button:Add')
            this.$router.push('/dashboard')
        },
        logout(){
            this.$emit('button:Logout')
            this.$router.push('/login')
            window.localStorage.removeItem('token');
        },
        verificaUrl(){
          if(this.$route.path === '/dashboard'){
            this.addClienteBtt = false
            this.addVendaBtt = false
            this.voltarDashBtt = false
          }       
          else if(this.$route.path === '/dash_cliente'){
            this.addClienteBtt = true
            this.addVendaBtt = false
            this.voltarDashBtt = false
          }
          else if(this.$route.path === '/dash_venda'){
            this.addVendaBtt = true
            this.addClienteBtt = false
            this.voltarDashBtt = false
          }
          else if(this.$route.path === '/add_cliente' || this.$route.path === '/add_venda'){
            this.voltarDashBtt = true
            this.addClienteBtt = false
            this.addVendaBtt = false
          }
        }
      },
      watch:{
        $route(){
          this.verificaUrl()
        },
      },
      mounted(){
          this.verificaUrl()        
      }   
    }

  </script>
  
  <style scoped>
  .head-container{
    display: flex;
    width: 100%;
    margin-top: 50px;
    align-items: center;
    border-bottom: 2px solid #E5EBF1;
    padding-bottom: 26px;
    margin-left: 3em;
    margin-right: 3em;
    justify-content: space-between;
  }
  .head-itens-container{
    display: flex;
    flex-direction: column;   
  }
  .profile{
    display: flex;
  }
  #profile_pic{
    object-fit: cover;
    border-radius: 5px ;
    height: 50px;
    width: 50px;
  }
  #hello{
    cursor: default;
    margin-left: 20px;
    font-family: 'Jost';
    font-style: normal;
    font-weight: 700;
    font-size: 15px;
  }
  #logout{
    cursor: pointer;
    font-family: 'Jost';
    font-style: normal;
    font-weight: 500;
    margin-left: 20px;
    font-size: 14px;
    color: rgba(117, 127, 152, 1);
    text-decoration: none;
  }
  
  </style>
  