<template>
  <section class="ContainerHeader">
    <nav class="NavHeader">
      <AtomLink route="movies">Filmes</AtomLink>
      <MoleculeButton>
        <template #icon>
          Favoritos
        </template>
      </MoleculeButton>
      <AtomLink route="manager" v-if="user.role == 'manager'">Administradores</AtomLink>
    </nav>
  </section>
</template>

<script setup lang="ts">
import { store } from '@/stores/store';
import AtomLink from '../atoms/AtomLink.vue'
import type { UserType } from '@/utils/types';
import { ref } from 'vue';
import MoleculeButton from '../molecules/MoleculeButton.vue';

const state = store();
const user = ref<UserType>(state.getUser as UserType);
console.log(user.value)
</script>

<style scoped>
.ContainerHeader {
  @apply bg-gray-300/55 w-full h-16 md:h-24 flex justify-center transition-all ease-linear;
}

.NavHeader {
  @apply w-4/5 h-full flex items-center max-w-screen-lg
}
</style>
