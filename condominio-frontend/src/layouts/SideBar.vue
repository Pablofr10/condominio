<template>
  <nav class="flex-grow md:block px-4 pb-4 md:pb-0 md:overflow-y-auto">
    <router-link
      v-for="rota in rotas"
      :class="{'bg-gray-600': $route.name === rota.name}"
      :key="rota.name"
      class="flex items-center hover:bg-gray-800 duration-200 mt-4 py-2 px-6 text-gray-100"
      :to="rota.rota"
    >
      <v-icon :icon="rota.icon" />
      <span class="mx-4">{{ rota.menuName }}</span>
    </router-link>
  </nav>
</template>

<script setup>
import { useRoute } from "vue-router";

const rotas = [
  { menuName: "Home", name: "home", rota: "/home", icon: "home" },
  { menuName: "Usuários", name: "usuarios", rota: "/usuarios", icon: "user" },
  { menuName: "Visitantes", name: "visitantes", rota: "/visitantes", icon: "user-tie" },
  { menuName: "Logistica", name: "logistica", rota: "/logistica", icon: "dolly" },
  { menuName: "Manutenção", name: "manutencao", rota: "/manutencao", icon: "tools" },
  { menuName: "Informações", name: "informações", rota: "/informacoes", icon: "info" },
  { menuName: "Sair", name: "sair", rota: "/sair", icon: "sign-out-alt" },
];


const route = useRoute();
</script>

<style></style>
