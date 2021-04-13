<template>
  <div class="bg-white rounded-lg overflow-hidden shadow-2xl">
    <div class="p-8">
      <form method="POST" class="" action="#" onsubmit="return false;">
        <molecula-input-login></molecula-input-login>

        <atom-button :tipo="'text'">Entrar</atom-button>
      </form>
    </div>

    <div
      class="flex justify-between p-8 text-sm border-t border-gray-300 bg-gray-100"
    >
      <atom-button :tipo="'text'">Criar novo cadastro</atom-button>

      <a href="#" class="text-gray-600">Esqueci a senha?</a>
    </div>
  </div>
</template>

<script setup>
import { MoleculeInputLogin } from "../molecules";
import { AtomButton } from "../atoms";
</script>
