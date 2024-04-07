import axios from 'axios'
import type { FormDataInterface } from '@/utils/types'

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
      console.log(result.data)
      return result.data
    } catch (e) {
      console.log(e)
      const err: Error = e as Error
      throw err
    }
  }

}

export const userServices = new UserServices()
