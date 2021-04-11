import axios from 'axios';

const axiosInstance = axios.create({
    baseURL: 'http://localhost:5000/api/'
});

const api = {
    get (endpoint) {
        return axiosInstance.get(endpoint);
    },
    post (endpoint, body) {
        return axiosInstance.post(endpoint, body);
    },
    delete (endpoint) {
        return axiosInstance.delete(endpoint);
    },
    get (endpoint, body) {
        return axiosInstance.put(endpoint, body);
    }
}

export default api;