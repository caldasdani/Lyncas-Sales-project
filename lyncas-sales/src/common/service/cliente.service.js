import { ApiService } from "../api/api.service.js";

const serviceCliente = {
    getCliente: async (resource) => {
        try {
            const resposta = await ApiService.get(resource);
            return resposta.data;
        }
        catch (error) {
            return error.resposta.data;
        }
    },
    postCliente: async (resource, info) => {
        const resposta = await ApiService.post(resource, info);
        return resposta.data;
    },
    putCliente: async (resource, info) => {
        try {
            const resposta = await ApiService.put(resource, info);
            return resposta.data;
        }
        catch (error) {
            return error.resposta.data;
        }       
    },
    deleteCliente: async (resource, info) => {      
        const resposta = await ApiService.delete(resource, info);
        return resposta.data;  
    }
}

export default serviceCliente;