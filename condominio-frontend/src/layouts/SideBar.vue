<template>
  <nav class="flex-grow md:block px-4 pb-4 md:pb-0 md:overflow-y-auto">
    <nav class="mt-10">
      <router-link class="flex items-center duration-200 mt-4 py-2 px-6" to="/">
        <font-awesome-icon style="color: white" icon="home" />

        <span class="mx-4">Home</span>
      </router-link>
      <router-link class="flex items-center duration-200 mt-4 py-2 px-6" to="/">
        <font-awesome-icon icon="archive" />

        <span class="mx-4">Painel</span>
      </router-link>
    </nav>
  </nav>
</template>

<script setup>
import { ref } from "vue";
const open = ref(false);
</script>

<style></style>
