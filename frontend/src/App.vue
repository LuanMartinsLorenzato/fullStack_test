<template>
  <RouterView />
</template>

<script setup lang="ts">
import { onMounted } from 'vue';
import { RouterView } from 'vue-router'
import { store } from './stores/store';

const state = store();
onMounted(() => state.userAutoLogin())
</script>
