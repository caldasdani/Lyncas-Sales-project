<script setup>
import head_page from '../components/header.vue'
import navbar from '../components/navbar.vue'
</script>

<template>  
  
  <div id="page">

    <div>
      <navbar/>
    </div>

    <div id="section">
      <div id="header">
        <head_page/>
      </div>
      <div id="main">
        <router-view></router-view>
      </div>     
    </div>
    
  </div>
</template>

<style scoped>
  #page{
    display: flex;
    font-family: 'Jost';
  }
  #section{
    display: flex;
    flex-direction: column;
    width: 100%;
    background-color: rgba(248, 248, 248, 1);
  }
  #header{
    display: flex;
    justify-content: space-between;
  }
  #main{
    height: 100%;
    margin-left: 3em;
    margin-right: 3em;
  }
</style>