<template>
  <section class="ContainerHeader">
    <nav class="NavHeader">
      <AtomLink route="movies">Filmes</AtomLink>
      <AtomLink route="manager" v-if="user.role == 'manager'">Administrador</AtomLink>
      <MoleculeButton @action="handleUserConfig">
        <template #span>Configurações</template>
      </MoleculeButton>
    </nav>
    <OrganismUserConfig v-if="isActiveUserConfig" @action="handleUserConfig"/>
  </section>
</template>

<script setup lang="ts">
import { store } from '@/stores/store'
import AtomLink from '../atoms/AtomLink.vue'
import type { UserType } from '@/utils/types'
import { ref } from 'vue'
import MoleculeButton from '../molecules/MoleculeButton.vue'
import OrganismUserConfig from './OrganismUserConfig.vue'
const state = store()
const user = ref<UserType>(state.getUser as UserType)
const isActiveUserConfig = ref<boolean>(false)

const handleUserConfig = () => {
  isActiveUserConfig.value = !isActiveUserConfig.value;
}

</script>

<style scoped>
.ContainerHeader {
  @apply bg-gray-300/55 w-full h-16 md:h-24 flex justify-center transition-all ease-linear;
}

.NavHeader {
  @apply w-4/5 h-full flex items-center max-w-screen-lg justify-center relative;
}
</style>
