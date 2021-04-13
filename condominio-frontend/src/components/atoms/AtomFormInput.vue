<template>
  {{ tipo }}
  <input
    :type="tipo"
    v-model="model"
    :id="idReferencia"
    @change="change($event)"
    class="block w-full p-3 rounded bg-gray-200 border border-transparent focus:outline-none"
  />
</template>

<script setup>
import { defineProps, toRefs } from "vue";

const props = defineProps({
  tipo: String,
  model: String,
  idReferencia: String,
});

const { tipo, model, idReferencia } = toRefs(props);


</script>

<style scoped>
</style>