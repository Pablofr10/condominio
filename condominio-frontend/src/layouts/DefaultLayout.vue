<template>
  <div
    class="fixed md:w-auto w-screen overflow-hidden flex items-center justify-center"
    style="background: #edf2f7"
  >
    <div class="md:flex flex-col md:flex-row md:min-h-screen w-full">
      <div class="flex flex-col w-full md:w-64 text-gray-700 bg-gray-900">
        <div
          class="flex-shrink-0 px-8 py-4 flex flex-row items-center justify-between"
        >
          <a
            href="#"
            class="text-lg font-semibold tracking-widest text-green-50 uppercase rounded-lg focus:outline-none focus:shadow-outline"
          >
            Condominio
          </a>
          <button
            class="rounded-lg md:hidden rounded-lg focus:outline-none focus:shadow-outline"
            @click="open = !open"
          >
            <font-awesome-icon class="text-3xl" v-if="!open" icon="bars" />
            <font-awesome-icon class="text-3xl" v-if="open" icon="times" />
          </button>
        </div>
        <SideBar />
      </div>
    </div>
  </div>
  <div class="lg:pt-5 pt-15 md:pl-50">
    <slot></slot>
  </div>
</template>

<script setup>
import SideBar from "./SideBar.vue";

import { ref } from "vue";
const open = ref(false);
</script>

<style></style>
