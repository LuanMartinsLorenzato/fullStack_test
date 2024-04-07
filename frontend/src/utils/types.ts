export type StyleSpan = 'Text' | 'Input'
export type InputType = 'email' | 'text' | 'password' | 'number'
export type MaskTypes = 'phone' | 'cpf' | 'cep'
export interface PropsAtomSpan {
  styleType?: StyleSpan
}
export interface MoleculeCardProps {
  dataCard: FilmsDataType
}

export type StateType = {
  user: UserType | {}
  token: string
}

export type UserType = {
  active: boolean
  email: string
  id: string
  name: string
  password: string
  role: string
}

export interface AtomImgProps {
  src: string
  alt: string
}

export type FilmsDataType = {
  id: string
  runtime: string
  poster: string
  title: string
  released: string
}

export interface MaskObject {
  cpf: string
  cep: string
  phone: string
}

export interface PropsAtomInput {
  mask?: MaskTypes
}

export interface PropsMoleculeInput {
  label: string
  inputType: InputType
  required?: boolean
  mask?: MaskTypes
}

export interface PropsAtomLink {
  route: string
}

export interface FormDataInterface {
  [key: string]: string | number | boolean | undefined
  id?: number
  stats?: boolean
  cep?: string
  password?: string
  cpf?: string
  phone?: string
  name?: string
  lastName?: string
  email?: string
  address?: string
  city?: string
  neighborhood?: string
  uf?: string
}
