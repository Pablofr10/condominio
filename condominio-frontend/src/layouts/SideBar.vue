<template>
  <nav class="flex-grow md:block px-4 pb-4 md:pb-0 md:overflow-y-auto">
    <router-link
      v-for="rota in rotasSistema"
      :class="{ 'bg-gray-600': $route.name === rota.name }"
      :key="rota.name"
      class="flex items-center hover:bg-gray-800 duration-200 mt-4 py-2 px-6 text-gray-100"
      :to="rota.rota"
    >
      <v-icon :icon="rota.icon" />
      <span class="mx-4">{{ rota.menuName }}</span>
    </router-link>
  </nav>
</template>

<script>
import { computed } from "vue";
import rotas from "../routers/menus";

export default {
  setup() {
    const rotasSistema = computed(() => rotas);

    return {
      rotasSistema,
    };
  },
};
</script>

<style></style>
