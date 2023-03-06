<template>
    <div class="search_list">
        <p id="title">Lista de clientes</p>
        <div class="input_container">
            <p>Procurar cliente por:</p>
            <select id="search">
                <option value="Nome" selected>Nome</option>
                <option value="Email">E-mail</option>
                <option value="Telefone">Telefone</option>
                <option value="cpf">CPF</option>
                </select>                            
            <input type="text" id="input" placeholder="Buscar cliente...">
            <button onclick="listarClienteSelect()"><img src="../../assets/lupinha.svg"></button>                                     
        </div>               
    </div>
</template>

<style>
.search_list{
    display: flex;
    justify-content: space-between;
    margin-top: 35px;
    padding-bottom: 15px;
}
#title{
    font-style: normal;
    font-weight: 500;
    font-size: 25px;
    color: #26324B;
}
.input_container{
    display: flex;
    position: relative;
    align-items: center;
}
.input_container button{
    position: absolute;
    right: 10px;
    background: none;
    border: none;
    cursor: pointer;
    top: calc(50% - 15px);
}
.input_container select{
    border: 1px solid #E5EBF1;
    border-radius: 5px;
    background: #FFFFFF;
    width: 90px;
    height: 30px;
    margin-left: 5px;
    margin-right: 15px;
    padding-left: 10px;
    font-style: normal;
    font-weight: 400;
    font-size: 14px;
}
.input_container p{
    font-style: normal;
    font-weight: 400;
    font-size: 18px;
}
#input{
    border: 1px solid #E5EBF1;
    border-radius: 5px;
    background: #FFFFFF;
    width: 300px;
    height: 30px;
    padding-left: 19px;
    font-style: normal;
    font-weight: 400;
    font-size: 14px;
}
</style>