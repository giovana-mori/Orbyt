import axios from "axios";

const API = axios.create({ baseURL: 'http://localhost:5113/api', withCredentials: true });
API.interceptors.response.use(
  (response) => response,
  async (error) => {
    const originalRequest = error.config;
    if (error.response.status === 401 && !originalRequest.retry) {
      originalRequest.retry = true;
      try {
        await axios.post('/auth/refresh', null, {
          withCredentials: true,
          headers: {
            'Content-Type': 'application/json',
          },
        });
        return API(originalRequest);
      } catch (refreshError) {
        window.location.href = '/login';
        return Promise.reject(refreshError);
      }
    }
    return Promise.reject(error);
  },
);
export default API;
