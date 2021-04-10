import { createRouter, createWebHistory } from "vue-router";

import { Home, Login } from './views';

const routes = [
    {
        path: "/",
        name: "login",
        component: Login,
        meta: { layout: "empty" },
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes: routes,
});

export default router;