import axios from 'axios'
import type { FormDataInterface, LoginResponse, UserType } from '@/utils/types'
import { jwtDecode, type JwtPayload } from "jwt-decode";
import { store } from '@/stores/store';
class UserServices {
  urlAPI: string
  constructor() {
    this.urlAPI = import.meta.env.VITE_ENV_API_URL
  }
  async createUser(formData: FormDataInterface): Promise<string> {
    try {
      const result = await axios.post(`${this.urlAPI}/create-user`, {
        name: formData.nome,
        email: formData.email,
        password: formData.senha
      })
      return result.data
    } catch (e) {
      console.log(e)
      const err: Error = e as Error
      throw err
    }
  }

  async userUpdate(data: FormDataInterface): Promise<LoginResponse> {
    const state = store()
    const user = state.getUser as UserType
    console.log(user.id, data.name, data.email, data.senha, data.role ?? user.role, data.active ?? user.active)
    try {
      const result = await axios.put(`${this.urlAPI}/update-user`, {
        id: user.id,
        name: data.nome,
        email: data.email,
        password: data.senha,
        role: data.role ?? user.role,
        active: data.active ?? user.active,
      })
      return result.data
    } catch (e) {
      console.log(e)
      const err: Error = e as Error
      throw err
    }
  }

  async userLogin(data: FormDataInterface): Promise<LoginResponse> {
    try {
      const result = await axios.post(`${this.urlAPI}/login`, {
        email: data.email,
        password: data.senha ?? data.password
      })
      return result.data
    } catch (e) {
      console.log(e)
      const err: Error = e as Error
      throw err
    }
  }

  getCredentials(token: string): FormDataInterface | null {
    const { email, password } = jwtDecode<JwtPayload>(token) as FormDataInterface;
    return {email, password};
  }
}

export const userServices = new UserServices()
