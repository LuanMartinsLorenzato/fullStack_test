import type { FormDataInterface } from '@/utils/types';
import { defineStore } from 'pinia'
import { state } from './state';
import axios from 'axios';

export const store = defineStore('user', {
  state: () => (state),
  getters: {
    getUser: (state) => {
      console.log(state.user)
      return state.user
    },
    getToken: (state) => state.token,
  },
  actions: {
    async userLogin(data: FormDataInterface): Promise<void> {
      const urlApi = import.meta.env.VITE_ENV_API_URL;
      try {
        const result = await axios.post(`${urlApi}/login`, {
          email: data.email,
          password: data.senha
        })
        this.user = result.data.user;
        this.token = result.data.token;
      } catch (e) {
        console.log(e)
        const err: Error = e as Error
        throw err
      }
    },
  },
})
