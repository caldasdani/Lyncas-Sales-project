<template>
    <button :class="classe" class="bttPadrao"> {{ value }} </button>
</template>

<script>
     export default{
        name: 'btt',
        props:{
            classe: {type: String, default: 'bttPadrao'},
            value: String
        }
     }
</script>

<style>
    .bttPadrao{
        font-family: 'Jost';
        width: 150px;
        height: 40px;
        color: #FFFFFF;
        border-radius: 4px;
        font-style: normal;
        font-weight: 700;
        font-size: 16px;
        border: none;
        cursor: pointer;
    }
    .bttVoltar{
        background: #BFBFBF;
        width: 120px;
    }
    .bttAdicionar{
        background: #03C874;
    }
    
</style>
