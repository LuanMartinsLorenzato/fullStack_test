<template>
  <form @submit.prevent="emitAction" class="ContainerForm">
    <div class="WrapInputs">
      <slot name="inputs"></slot>
    </div>
    <div class="WrapButtons">
      <slot name="buttons"></slot>
    </div>
  </form>
</template>

<script setup lang="ts">
const emit = defineEmits(['action'])
const emitAction = () => emit('action')
</script>

<style scoped>
.ContainerForm {
  @apply w-4/5 max-w-lg
    h-2/4 min-h-96
    px-4
    py-8
    drop-shadow-2xl 
    bg-gray-300/55 
    rounded-3xl
    flex
    flex-col
    items-center;
}

.WrapInputs {
  @apply w-11/12 sm:w-4/5 h-fit flex flex-col items-center gap-5 transition-all ease-linear duration-300;
}

.WrapButtons {
  @apply w-11/12 sm:w-4/5 h-10 mt-auto flex justify-between transition-all ease-linear duration-300;
}
</style>
