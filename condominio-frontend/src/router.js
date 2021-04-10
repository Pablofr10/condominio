import { createRouter, createWebHistory } from "vue-router";

import { Home, Login, Usuarios, Visitantes, Logistica, Manutencao, Informacoes } from './views';

function lazyLoad (view) {
    return () => import(`./views/${view}.vue`)
}

const routes = [
    {
        path: "/",
        name: "login",
        component: lazyLoad('Login'),
        meta: { layout: "empty" },
    },
    {
        path: "/home",
        name: "home",
        component: lazyLoad('Home')
    },
    {
        path: "/usuarios",
        name: "usuarios",
        component: lazyLoad('Usuarios')
    },
    {
        path: "/visitantes",
        name: "visitantes",
        component: lazyLoad('Visitantes')
    },
    {
        path: "/logistica",
        name: "logistica",
        component: lazyLoad('Logistica')
    },
    {
        path: "/manutencao",
        name: "manutencao",
        component: lazyLoad('Manutencao')
    },
    {
        path: "/informacoes",
        name: "informacoes",
        component: lazyLoad('Informacoes')
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes: routes,
});

export default router;