import { ApiService } from "../api/api.service.js";

const serviceUsuario = {
    postUsuario: async (resource, info) => {
        const resposta = await ApiService.post(resource, info);
        return resposta.data;      
    }
}

export default serviceUsuario;