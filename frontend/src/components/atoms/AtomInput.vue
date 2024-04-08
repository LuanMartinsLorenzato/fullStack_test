<template>
 <MaskInput
    :mask="maskString"
    class="Input"
    v-model="inputValue"
    @keyup="setValue"
    v-if="withMask"
  />
  <input class="Input" @keyup="setValue" v-model="inputValue" v-else/>
</template>

<script setup lang="ts">
import type { MaskTypes, PropsAtomInput } from '@/utils/types'
import { MaskInput } from 'vue-3-mask'
import { MASKS } from '@/utils/constants'
import { onMounted, ref } from 'vue'
const emit = defineEmits(['action']);

const inputValue = ref<string>('')
const withMask = ref<boolean>(true)
const props = defineProps<PropsAtomInput>()
const maskString = ref<string>('');

const checkInput = () => {
  if (!props.mask) return (withMask.value = false)
  setMask();
}

const setMask = () => maskString.value = MASKS[props.mask as MaskTypes];
const setValue = () => emit('action', inputValue.value)

onMounted(() => checkInput())
</script>

<style scoped>
.Input {
  @apply w-full h-9 bg-white/20 rounded-md px-3 font-medium shadow-md focus:outline-none;
}
</style>
