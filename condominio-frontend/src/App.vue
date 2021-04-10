<template>
  <component :is="'default-layout'">
    <router-view />
  </component>
</template>

<script setup>
import { defineComponent, ref, computed } from "vue";
import { useRouter } from "vue-router";

const defaultLayout = "default";

const { currentRoute } = useRouter();

console.log(currentRoute.value.meta.layout);

const layout = computed(
  () => `${route.currentRoute.value.meta.layout || defaultLayout}-layout`
);
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>
