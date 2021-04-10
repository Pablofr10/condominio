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
            <svg fill="currentColor" viewBox="0 0 20 20" class="w-6 h-6">
              <path
                v-if="!open"
                d="M3 5a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM3 10a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM9 15a1 1 0 011-1h6a1 1 0 110 2h-6a1 1 0 01-1-1z"
              ></path>
              <path
                v-if="open"
                d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
              ></path>
            </svg>
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
