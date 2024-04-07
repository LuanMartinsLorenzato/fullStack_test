import { api } from './ApiConfig'
import type { FilmsDataType } from '@/utils/types'

class FilmsServices {
  dataList: FilmsDataType[]

  constructor() {
    this.dataList = [];
  }

  async filmsList(): Promise<FilmsDataType[]> {
    try {
      const result = await api().get("/get-movies");
      this.dataList = result.data as FilmsDataType[];
      return this.dataList;
    } catch (e) {
      console.log(e);
      const err: Error = e as Error;
      throw err;
    };
  }
}

export const filmsServices = new FilmsServices()
