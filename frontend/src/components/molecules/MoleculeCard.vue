<template>
  <div class="ContainerCard">
    <AtomLink route="/new-locate">
      <AtomImg :src="data.Poster" :alt="data.Title" />
    </AtomLink>
  </div>
</template>

<script setup lang="ts">
import { reactive } from 'vue'
import type { MoleculeCardProps, FilmsDataType } from '@/utils/types'
import AtomLink from '../atoms/AtomLink.vue'
import AtomImg from '../atoms/AtomImg.vue'
const props = defineProps<MoleculeCardProps>()
const data = reactive<FilmsDataType>(props.dataCard)
</script>

<style scoped>
.ContainerCard {
  @apply flex flex-col relative overflow-hidden w-36 h-48 md:w-44 md:h-56 lg:w-52 lg:h-64;
}
</style>
