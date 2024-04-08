<template>
  <section class="ContainerFilms">
    <div class="WrapCards"> 
      <MoleculeCard v-for="films in filmsList" :key="films.id" :dataCard="films" />
    </div>
  </section>
</template>

<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import MoleculeCard from '../molecules/MoleculeCard.vue'
import { filmsServices } from '@/services/FilmsServices'
import type { FilmsDataType } from '@/utils/types'

const searchString = ref<string>('Batman') 
let filmsList = ref<FilmsDataType[]>([])

const getListFilms = async () => {
  filmsList.value = await filmsServices.filmsList() as FilmsDataType[]
}

watch(searchString, (newValue) => {
  if(newValue == '') return searchString.value = 'Batman';
  getListFilms()
})

onMounted(() => getListFilms())
</script>

<style scoped>
.ContainerFilms {
  @apply flex flex-col items-center w-full overflow-hidden h-full;
}

.WrapCards {
  @apply flex flex-wrap my-2 justify-center gap-5 w-4/5 h-fit max-w-screen-lg overflow-y-scroll;
}
</style>
