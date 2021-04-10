<template>
  <div class="bg-gray-200 h-screen font-sans text-gray-700">
    <div class="container mx-auto p-8 flex">
      <div class="max-w-md w-full mx-auto">
        <h1 class="text-4xl text-center mb-12 font-thin">Condominio</h1>

        <div class="bg-white rounded-lg overflow-hidden shadow-2xl">
          <div class="p-8">
            <form method="POST" class="" action="#" onsubmit="return false;">
              <div class="mb-5">
                <label
                  for="user"
                  class="block mb-2 text-sm font-medium text-gray-600"
                >
                  Usuário
                </label>

                <input
                  type="text"
                  name="user"
                  v-model="loginUsuario.usuario"
                  class="block w-full p-3 rounded bg-gray-200 border border-transparent focus:outline-none"
                />
              </div>

              <div class="mb-5">
                <label
                  for="senha"
                  class="block mb-2 text-sm font-medium text-gray-600"
                  >Senha</label
                >

                <input
                  type="password"
                  name="senha"
                  v-model="loginUsuario.senha"
                  class="block w-full p-3 rounded bg-gray-200 border border-transparent focus:outline-none"
                />
              </div>

              <button
                class="w-full p-3 mt-4 bg-indigo-600 text-white rounded shadow"
                type="submit"
                @click.prevent="login()"
              >
                Entrar
              </button>
            </form>
          </div>

          <div
            class="flex justify-between p-8 text-sm border-t border-gray-300 bg-gray-100"
          >
            <button href="#" class="font-medium text-indigo-500">
              Criar novo cadastro {{ loginUsuario.senha }}
            </button>

            <a href="#" class="text-gray-600">Esqueci a senha?</a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script setup>
import { reactive } from "vue";

const loginUsuario = reactive({
  usuario: "",
  senha: "",
});

const login = () => {
  alert("teste");
};
</script>