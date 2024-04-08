<template>
  <main class="TemplateApp">
    <OrganismHeader />
    <OrganismFilms />
  </main>
</template>

<script setup lang="ts">
import OrganismHeader from '@/components/organisms/OrganismHeader.vue';
import OrganismFilms from '@/components/organisms/OrganismFilms.vue';

  
</script>

<style scoped>
  .TemplateApp {
    @apply bg-gray-50 flex flex-col items-center;
  }
</style>
