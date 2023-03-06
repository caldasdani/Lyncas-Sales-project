import { ApiService } from "../api/api.service.js";

const serviceVenda = {
    getVenda: async (resource) => {
        try {
            const resposta = await ApiService.get(resource);
            return resposta.data;
        }
        catch (error) {
            return error.resposta.data;
        }
    },
    postVenda: async (resource, info) => {
        const resposta = await ApiService.post(resource, info);
        return resposta.data;
    },
    deleteVenda: async (resource, info) => {
        const resposta = await ApiService.delete(resource, info);
        return resposta.data;  
    }
}

export default serviceVenda;