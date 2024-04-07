<template>
  <span :class="props.styleType">
    <slot></slot>
  </span>
</template>

<script setup lang="ts">
import type { PropsAtomSpan } from '@/utils/types'
const props = withDefaults(defineProps<PropsAtomSpan>(), {
  styleType: 'Input'
})
</script>

<style scoped>
.Input,
.Text {
  @apply w-fit h-fit;
}

.Input {
  @apply font-semibold;
}
.Input::after {
  content: ':';
}

.Text {
  @apply font-medium;
}
</style>
