import { createRouter, createWebHistory } from 'vue-router'

import MainView from '../views/MainView.vue'
import LoginView from '../views/LoginView.vue'
////////////////////////////////////////////////////////////////////////
import dashboard from '../components/dashboard/dashboard.vue'
import dash_venda from '../components/venda_dash/dash_venda.vue'
import dash_cliente from '../components/cliente_dash/dash_cliente.vue'
import add_cliente from '../components/cliente_add/add_cliente.vue'
import add_venda from '../components/venda_add/add_venda.vue'
////////////////////////////////////////////////////////////////////////

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
      {
        path: '/acesso',
        component: MainView,
        name: 'MainView',
        children: [
          { path: '/dashboard', name: 'dashboard', component: dashboard },
          { path: '/dash_cliente', name: 'dash_cliente', component: dash_cliente },
          { path: '/dash_venda', name: 'dash_venda', component: dash_venda },
          { path: '/add_cliente', name: 'add_cliente', component: add_cliente },
          { path: '/add_venda', name: 'add_venda', component: add_venda },
        ]
      },
      {
        path: '/',
        component: LoginView,
        name: 'LoginView',
        children: [
          { path: '/login', name: 'login', component: LoginView },
        ]
      }
  ]
})

export default router
