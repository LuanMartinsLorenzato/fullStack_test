<template>
  <div class="TemplateLogin">
    <OrganismLogin @action="handleOrganism" @login="goToApp" v-if="!isActiveRegister"/>
    <OrganismRegister @action="handleOrganism" v-else/>
  </div>
</template>
<script setup lang="ts">
import OrganismLogin from '@/components/organisms/OrganismLogin.vue';
import OrganismRegister from '@/components/organisms/OrganismRegister.vue';
import { ref } from 'vue';
import router from '../router/index'
const isActiveRegister = ref<boolean>(false);
const goToApp = () => router.replace('/movies');
const handleOrganism = () => isActiveRegister.value = !isActiveRegister.value;
</script>

<style scoped>
.TemplateLogin {
  @apply w-full h-full flex justify-center items-center bg-gray-50
}
</style>
