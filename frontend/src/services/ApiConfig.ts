import axios from 'axios'
import { store } from '@/stores/store'

export const api = () => {
  const state = store()
  console.log(state.getToken)
  const token = state.getToken

  axios.defaults.baseURL = import.meta.env.VITE_ENV_API_URL
  axios.defaults.headers.common = { Authorization: `Bearer ${token}` }
  return axios
}
