<template>
  <label :for="referencia" class="block mb-2 text-sm font-medium text-gray-600">
    {{ nome }}
  </label>
</template>

<script setup>
import { defineProps, toRefs } from "vue";

const props = defineProps({ nome: String, referencia: String });

const { nome, referencia } = toRefs(props);

const teste = async () => {
  console.log(props.nome);
};
</script>