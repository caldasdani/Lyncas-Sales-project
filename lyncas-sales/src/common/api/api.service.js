import { API_URL } from "../config/config.js";
import axios from "axios";

export const ApiService = {
    init() {
        axios.defaults.baseURL = API_URL;
        axios.defaults.headers = {Authorization: `Bearer ${localStorage.getItem('token')}`};
    },
    get(resource){
        this.init();
        return axios.get(`/${resource}`);   
    },

    post(resource, info){
        this.init();
        return axios.post(`/${resource}`, info);
    },

    put(resource, info){
        this.init();
        return axios.put(`/${resource}`, info);      
    },

    delete(resource, info){
        this.init();
        return axios.delete(`/${resource}`, { data: info });        
    }
}