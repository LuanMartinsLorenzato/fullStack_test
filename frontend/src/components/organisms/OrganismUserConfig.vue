<template>
  <section class="ContainerUserConfig">
    <AtomImg :src="closeIcon" :alt="'Logo'" class="close" @click="closeConfig" />
    <OrganismForm @action="submitForm" class="form">
      <template #inputs>
        <MoleculeInput label="Nome" inputType="text" @action="updateFormData" />
        <MoleculeInput label="Email" inputType="email" @action="updateFormData" />
        <MoleculeInput label="Senha" inputType="password" @action="updateFormData" />
      </template>
      <template #buttons>
        <MoleculeButton type="submit" class="btn">
          <template #span>Atualizar</template>
        </MoleculeButton>
      </template>
    </OrganismForm>
  </section>
</template>

<script setup lang="ts">
import MoleculeInput from '../molecules/MoleculeInput.vue'
import MoleculeButton from '../molecules/MoleculeButton.vue'
import { userServices } from '@/services/UserServices'
import OrganismForm from './OrganismForm.vue'
import type { FormDataInterface } from '@/utils/types'
import { ref } from 'vue'
import AtomImg from '../atoms/AtomImg.vue'
import closeIcon from '@/assets/closeIcon.svg'

const formData = ref<FormDataInterface>({})
const updateFormData = ([value, key]: string) => {
  console.log(value, key)
  formData.value[key.toLocaleLowerCase()] = value
}

const submitForm = () => {
  userServices
    .userUpdate(formData.value)
    .then(() => {
      emit('action')
    })
    .catch((error: Error) => console.log(error))
}

const emit = defineEmits(['action'])
const closeConfig = () => emit('action')
</script>

<style scoped>
.ContainerUserConfig {
  @apply absolute bg-white/95 top-0 w-full h-full z-10 flex flex-col justify-center items-center;
}

.form {
  @apply bg-gray-300;
}

.close {
  @apply absolute w-7 h-7 top-6 right-6;
}
</style>
