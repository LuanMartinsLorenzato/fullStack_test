import type { FormDataInterface, LoginResponse } from '@/utils/types'
import { defineStore } from 'pinia'
import { state } from './state'
import { userServices } from '@/services/UserServices'
import route from '../router/index'
import { filmsServices } from '@/services/FilmsServices'

export const store = defineStore('user', {
  state: () => state,
  getters: {
    getUser: (state) => {
      console.log(state.user)
      return state.user
    },
    getToken: (state) => state.token
  },
  actions: {
    async userLogin(data: FormDataInterface): Promise<void> {
      const resultdata = await userServices.userLogin(data) as LoginResponse
      localStorage.setItem('Token', resultdata.token)
      this.user = resultdata.user
      this.token = resultdata.token
      await filmsServices.populateDB();
    },

    async userAutoLogin(): Promise<void> {
      const token = localStorage.getItem('Token')
      if (!token) return;
      await filmsServices.populateDB();
      const credentials = userServices.getCredentials(token);
      if (!credentials) return;
      const resultdata = await userServices.userLogin(credentials) as LoginResponse;
      if (!resultdata) return;
      localStorage.setItem('Token', resultdata.token)
      this.user = resultdata.user
      this.token = resultdata.token
      route.push('/movies');
    }
  }
})
