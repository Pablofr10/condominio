<template>
  <span class="text-red-500 text-xs">{{ mensagemErro }}</span>
  <form class="mt-4" @submit.prevent="login()">
    <label class="block">
      <span class="text-gray-700 text-sm">Usuário</span>
      <input
        type="usuario"
        placeholder="Digite seu usuário"
        class="mt-1 block w-full rounded-md focus:border-indigo-600"
        v-model="usuario"
      />
    </label>

    <label class="block mt-3">
      <span class="text-gray-700 text-sm">Senha</span>
      <input
        type="senha"
        placeholder="Digite sua senha"
        class="mt-1 block w-full rounded-md focus:border-indigo-600"
        v-model="senha"
      />
    </label>

    <div class="flex justify-between items-center mt-4">
      <div>
        <label class="inline-flex items-center">
          <input type="checkbox" class="form-checkbox text-indigo-600" />
          <span class="mx-2 text-gray-600 text-sm">Lembrar-me</span>
        </label>
      </div>

      <div>
        <a
          class="block text-sm fontme text-indigo-700 hover:underline"
          href="#"
        >
          Forgot your password?
        </a>
      </div>
    </div>

    <div class="mt-6">
      <button
        type="submit"
        class="py-2 px-4 text-center bg-indigo-600 rounded-md w-full text-white text-sm hover:bg-indigo-500"
      >
        Entrar
      </button>
    </div>
  </form>
</template>

<script>
import { ref } from "vue";
import services from "../services";
import { useRouter } from "vue-router";

export default {
  props: ["usuario", "senha"],

  setup(props) {
    const mensagemErro = ref("");

    const router = useRouter();

    async function login() {
      try {
        const { data } = await services.post("auth/login", {
          userName: props.usuario,
          password: props.senha,
        });
        console.log(data);
        const { token, userName } = data;
        window.localStorage.setItem("token", token);
        router.push("/home");
      } catch (error) {
        console.log(error);
      }
    }

    return {
      login,
      mensagemErro,
    };
  },
};
</script>
