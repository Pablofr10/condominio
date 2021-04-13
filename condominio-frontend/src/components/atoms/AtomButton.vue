<template>
{{tipo}}
  <button
    class="w-full p-3 mt-4 bg-indigo-600 text-white rounded shadow"
    :type="tipo"
  >
    <slot></slot>
  </button>
</template>

<script setup>
import { defineProps, toRefs } from "vue";

const props = defineProps({ tipo: String });

const { tipo } = toRefs(props);
</script>