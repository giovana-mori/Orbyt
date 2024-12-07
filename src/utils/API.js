import axios from "axios";

const API = axios.create({ baseURL: 'http://localhost:5113/api' });

export default API;
