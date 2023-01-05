
// MASCARAS PARA OS INPUTS

const input = document.querySelector('#cpf')
input.addEventListener('keypress', () => {
    let inputLength = input.value.length

    if (inputLength == 3 || inputLength == 7) {
        input.value += '.'
    }else if (inputLength == 11) {
        input.value += '-'
    }
})

const input2 = document.querySelector('#tel')
input2.addEventListener('keypress', () => {
  let input2Length = input2.value.length

  if (input2Length == 0) {
      input2.value += '('
  }else if (input2Length == 3) {
      input2.value += ')'
  }
})

// const input_valor = document.querySelector('#unit')
// input_valor.addEventListener('keypress', () => {
//   let input_valorLength = input_valor.value.length

//   if (input_valorLength == 2){
//     input_valor.value += ','
//   }
// })

//--------------------------------------------------------

// FUNÇOES DE VALIDAÇÃO 

  function validarCPF() {
    const cpf = document.getElementById("cpf");
    const valorCpf = cpf.value;
    const re = /([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})/g;
    const cpfPassou = re.test(valorCpf);

    console.log("cpf passou? " + cpfPassou);
    return cpfPassou  
  };


  function validarTel() {
    const telefone = document.getElementById("tel");
    const valorTelefone = telefone.value;
    const re = /^\(?[0-9]{2}\)?[0-9]{5}-?[0-9]{4}/g;
    const telefonePassou = re.test(valorTelefone);
    
    console.log("telefone passou? " + telefonePassou);
    return telefonePassou     
  };
  

  function validarNome() {
    const nome = document.getElementById("nome");
    const valorNome = nome.value;
    const re = /^[a-zA-ZéúíóáÉÚÍÓÁèùìòàçÇÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄ\-\ \s]+$/;
    const nomePassou = re.test(valorNome);
   
    console.log("nome passou? " + nomePassou);
    return nomePassou
  };
  

  function validarEmail() {
    const email = document.getElementById("email");
    const valorEmail = email.value;
    const re = /^[a-z0-9!#$%&'*.+/=?^-`{|}~-]{1,}@{1,1}[a-zA-Z]{1,}.[a-zA-Z]{2,}$/i;
    const emailPassou = re.test(valorEmail);

    console.log("email passou? " + emailPassou);
    return emailPassou; 
  };

  
  function validarTudo(event) {
      event.preventDefault();

       const nomePassouNaRegra = validarNome()
       const emailPassouNaRegra = validarEmail()
       const telefonePassouNaRegra = validarTel()
       const cpfPassouNaRegra = validarCPF()

        const inputsPassaramNasRegras = 
        nomePassouNaRegra && 
        emailPassouNaRegra && 
        telefonePassouNaRegra && 
        cpfPassouNaRegra

        return inputsPassaramNasRegras

        // if(inputsPassaramNasRegras){
        //     alert("Cliente Cadastrado")
        //     window.location.href = "dash_cliente.html"
        // }        
    }



//-----------------------------------------------------
// FUNCIONALIDADE DO BOTÃO MAIS ITENS

    // let orderBox = document.querySelector('.form_itens2');
    // let clonedItem = document.querySelector('.cloned_form')
    // let moreItensButton = document.querySelector('#more_items');
    
    // //Clona o elemento com o método cloneNode e o insere em uma variável
    // let clonedBox = () => {
    //     return orderBox.cloneNode(true);
    // }
    // //Criar  função que insere o elemento ao final da página com o appendChild ao clicar no botão Mais Itens
    // let useClone = () => clonedItem.insertAdjacentElement("beforeend", clonedBox())
        
    
    // moreItensButton.addEventListener('click', useClone);

    export default {
      validarCPF, validarEmail, validarNome, validarTel
    }