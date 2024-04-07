import { createRouter, createWebHistory } from 'vue-router'
import TemplateApp from '@/pages/TemplateApp.vue'
import TemplateLogin from '@/pages/TemplateLogin.vue'
import TemplateDashboard from '@/pages/TemplateDashboard.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'login',
      component: TemplateLogin
    },
    {
      path: '/movies',
      name: 'movies',
      component: TemplateApp
    },
    {
      path: '/manager',
      name: 'manager',
      component: TemplateDashboard
    },
  ]
})

export default router
