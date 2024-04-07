<template>
  <div class="Link">
    <a :href="`/${props.route}`">
      <slot></slot>
    </a>
  </div>
</template>

<script setup lang="ts">
import type { PropsAtomLink } from '@/utils/types'

const props = withDefaults(defineProps<PropsAtomLink>(), {
  route: 'movies',
})
</script>

<style scoped>
.Link {
  @apply w-full font-medium h-fit flex justify-center cursor-pointer;
}
</style>
