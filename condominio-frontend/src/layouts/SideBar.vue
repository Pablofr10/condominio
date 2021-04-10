<template>
  <nav class="flex-grow md:block px-4 pb-4 md:pb-0 md:overflow-y-auto">
    <router-link
      v-for="rota in rotas"
      :class="[$route.name === rota.name ? 'bg-gray-800' : '']"
      :key="rota.name"
      class="flex items-center duration-200 mt-4 py-2 px-6 text-gray-100"
      :to="rota.rota"
    >
      <font-awesome-icon :icon="rota.icon" />
      <span class="mx-4">{{ rota.menuName }}</span>
    </router-link>
  </nav>
</template>

<script setup>
import { useRoute } from "vue-router";

const rotas = [
  { menuName: "Home", name: "home", rota: "/", icon: "home" },
  { menuName: "Sobre", name: "sobre", rota: "/sobre", icon: "phone" },
];

const route = useRoute();
</script>

<style></style>
