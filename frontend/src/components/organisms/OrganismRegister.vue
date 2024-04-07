<template>
  <OrganismForm @action="submitForm">
    <template #inputs>
      <MoleculeInput label="Nome" inputType="text" @action="updateFormData" required />
      <MoleculeInput label="Email" inputType="text" @action="updateFormData" required />
      <MoleculeInput label="Senha" inputType="password" @action="updateFormData" required />
    </template>
    <template #buttons>
      <MoleculeButton @action="handleRegister">Voltar</MoleculeButton>
      <MoleculeButton type="submit">Salvar</MoleculeButton>
    </template>
  </OrganismForm>
</template>

<script setup lang="ts">
import MoleculeInput from '../molecules/MoleculeInput.vue'
import MoleculeButton from '../molecules/MoleculeButton.vue'
import OrganismForm from './OrganismForm.vue'
import type { FormDataInterface } from '@/utils/types'
import { userServices } from '@/services/UserServices'
import { ref } from 'vue'
const emit = defineEmits(['action']);

const formData = ref<FormDataInterface>({})

const updateFormData = ([value, key]: string) => {
  formData.value[key.toLocaleLowerCase()] = value
}
const handleRegister = () => {
  emit('action');
}

const submitForm = () => {
  userServices.createUser(formData.value)
  .then(() => {console.log('Mensagem de sucesso'); handleRegister()})
  .catch(error => {console.log('Mensagem de erro' + error)});
}
</script>
