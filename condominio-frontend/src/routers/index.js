import { createRouter, createWebHistory } from 'vue-router'

function lazyLoad (view) {
  return () => import(`../pages/${view}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'login',
    component: lazyLoad('Login'),
    meta: { layout: 'empty' }
  },
  {
    path: '/home',
    name: 'home',
    component: lazyLoad('Home')
  },
  {
    path: '/usuarios',
    name: 'usuarios',
    component: lazyLoad('Usuarios')
  },
  {
    path: '/visitantes',
    name: 'visitantes',
    component: lazyLoad('Visitantes')
  },
  {
    path: '/logistica',
    name: 'logistica',
    component: lazyLoad('Logistica')
  },
  {
    path: '/manutencao',
    name: 'manutencao',
    component: lazyLoad('Manutencao')
  },
  {
    path: '/informacoes',
    name: 'informacoes',
    component: lazyLoad('Informacoes')
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes: routes
})

router.beforeEach((to, from, next) => {
  const token = localStorage.getItem('token')
  debugger
  if (!token) {
    next({ path: '/', query: { redirect: to.fullPath } })
  } else {
    next()
  }
})

export default router
