import { createRouter, createWebHistory } from "vue-router";

import Home from './views/Home.vue';

const routes = [
    {
        path: "/",
        name: "home",
        component: Home,
        meta: { layout: "empty" },
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes: routes,
});

export default router;