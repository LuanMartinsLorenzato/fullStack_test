<template>
  <OrganismForm @action="submitForm">
    <template #inputs>
      <MoleculeInput label="Email" inputType="email" @action="updateFormData" required />
      <MoleculeInput label="Senha" inputType="password" @action="updateFormData" required />
      <!--Não foi implementado na API 
      <AtomLink>Forgot password</AtomLink> -->
    </template>
    <template #buttons>
      <MoleculeButton @action="registerForm">
        <template #span>Cadastre-se</template>
      </MoleculeButton>
      <MoleculeButton type="submit">
        <template #span>Entrar</template>
      </MoleculeButton>
    </template>
  </OrganismForm>
</template>

<script setup lang="ts">
import MoleculeInput from '../molecules/MoleculeInput.vue'
import MoleculeButton from '../molecules/MoleculeButton.vue'
import OrganismForm from './OrganismForm.vue'
// import AtomLink from '../atoms/AtomLink.vue'
import type { FormDataInterface } from '@/utils/types'
import { ref } from 'vue'
import { store } from '@/stores/store'
const state = store()
const formData = ref<FormDataInterface>({})

const updateFormData = ([value, key]: string) => {
  formData.value[key.toLocaleLowerCase()] = value
}
const emit = defineEmits(['action', 'login'])

const registerForm = () => emit('action')

const submitForm = () => {
  state
    .userLogin(formData.value)
    .then(() => {
      emit('login')
    })
    .catch((error) => console.log(error))
}
</script>
