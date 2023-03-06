<template>
    <div id="teste">
        <h3>Lista de atividades</h3>
        <input id="insert" placeholder="insira uma nova atividade" type="text" @change="addToList" v-model="text">
        <ul>
            <li id="tarefa" v-for="(item, index) in list" :key="index">
                <span @click="toggle(item)">
                    <input type="checkbox" :checked="item.done">
                    {{item.label}}
                </span>
                <button id="deleteBtn" @click="deleteFromList">Deletar</button>
            </li>     
        </ul>
    </div>
    
</template>

<script>
    export default{
        props:{
            item: String,
        },
        data(){
            return{
                list: [],
                text: ''
            }
        },
        created(){
            this.list = JSON.parse(localStorage.getItem('list')) || [];
        },
        methods:{
            addToList(){
                this.list.unshift({label:this.text, done:false});
                this.updateLocalStorage();
                this.text = '';
            },
            deleteFromList(){
                this.list.splice(this.list.index, 1)
                this.updateLocalStorage();
            },
            updateLocalStorage(){
                localStorage.setItem('list', JSON.stringify(this.list));
            },
            toggle(item){
                item.done = !item.done;
                this.updateLocalStorage();
            }
        }
    }
</script>

<style>
    #teste{
        display: flex;
        flex-direction: column;
        margin-left: 100px;
        margin-top: 50px;
        gap: 20px;
        width: 50%;
    }
    #insert{
        width: 100%;
        height: 25px;
        padding-left: 10px;
    }
    #tarefa{
        display: flex;
        justify-content: space-between;
        margin-bottom: 5px;
    }
    #deleteBtn{
        display: flex;
        align-items: center;
        background-color: rgb(225, 130, 150);
        height: 30px;
    }
</style>