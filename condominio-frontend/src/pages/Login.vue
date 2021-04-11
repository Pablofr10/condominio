<template>
  <template-login></template-login>
</template>
<script setup>
import { reactive } from "vue";

import { TemplateLogin } from '../components/templates'

const loginUsuario = reactive({
  usuario: "",
  senha: "",
});

const login = () => {
  alert("teste");
};
</script>