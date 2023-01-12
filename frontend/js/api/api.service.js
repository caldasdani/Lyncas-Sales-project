import { API_URL } from "../config/config.js";

export const ApiService = {        // criei esse objeto com metodos pra usar em outros arquivos

    get(resource){
        return fetch(`${API_URL}/${resource}`, {  //retorna a url da api + o parametro ex: /Cliente/listar
            headers: {
                'Content-Type': 'application/json',
                Authorization: `Bearer ${localStorage.getItem("token")}`
            }
        })  .then((data)=> {
                return data.json();          // se tiver ok retorna os dados
            })
            .catch((error) => {              // senão retorna o erro
                console.log(error);
            })
    },

    post(resource, info){                                  // info é o corpo do body
        return fetch(`${API_URL}/${resource}`,{
            method: "POST",           //preciso setar o metodo pois o fetch por padrão seta um get
            headers: {
                'Content-Type': 'application/json',     //tipo do conteúdo, geralmente esse é o padrão
                Authorization: `Bearer ${localStorage.getItem("token")}`
            },
            body: JSON.stringify(info)
        }) 
            .then((data)=> {
                return data.json();
            })
            .catch((error) => {
                console.log(error);
            })
    },

    put(resource, info){
        return fetch(`${API_URL}/${resource}`,{
            method: "PUT",
            headers: {
                'Content-Type': 'application/json',
                Authorization: `Bearer ${localStorage.getItem("token")}`
            },
            body: JSON.stringify(info)
        }) 
            .then((data)=> {
                return data.json();
            })
            .catch((error) => {
                console.log(error);
            })
    },

    delete(resource, info){
        return fetch(`${API_URL}/${resource}`,{
            method: "DELETE",
            headers: {
                'Content-Type': 'application/json',
                Authorization: `Bearer ${localStorage.getItem("token")}`         
            },
            body: JSON.stringify(info)
        }) 
            .then((data)=> {
                return data.json();
            })
            .catch((error) => {
                console.error(error);
            })
    }
}
