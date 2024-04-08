<template>
  <button class="ContainerButton" @click="action">
    <AtomSpan styleType="Text">
      <slot name="span">
      </slot>
    </AtomSpan>
  </button>
</template>

<script setup lang="ts">
import AtomSpan from '@/components/atoms/AtomSpan.vue'
const emit = defineEmits(['action'])
const action = () => emit('action')
</script>

<style scoped>
.ContainerButton {
  @apply w-fit px-6 py-2 shadow-md focus:shadow-sm bg-white/20 hover:bg-white/35 h-fit rounded-xl focus:outline-none focus:ring-transparent focus:bg-white/20;
}
</style>
