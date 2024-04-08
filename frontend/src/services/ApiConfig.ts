import axios from 'axios'
import { store } from '@/stores/store'

export const api = () => {
  const state = store()
  let token = state.getToken
  if (!token) token = localStorage.getItem('Token') as string;
  axios.defaults.baseURL = import.meta.env.VITE_ENV_API_URL
  axios.defaults.headers.common = { Authorization: `Bearer ${token}` }
  return axios
}
