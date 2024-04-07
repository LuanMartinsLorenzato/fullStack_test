<template>
  <img :src="props.src" :alt="props.alt" />
</template>

<script setup lang="ts">
import type { AtomImgProps } from '@/utils/types'

const props = defineProps<AtomImgProps>()
</script>

<style scoped>
img {
  @apply object-cover;
}
</style>
