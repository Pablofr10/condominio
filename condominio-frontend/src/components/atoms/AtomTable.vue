<template>
  <div class="flex flex-col">
    <div class="-my-2 overflow-x-auto sm:-mx-2 lg:-mx-2">
      <div class="py-2 align-middle inline-block min-w-full sm:px-6 lg:px-8">
        <div
          class="shadow overflow-hidden border-b border-gray-200 sm:rounded-lg"
        >
          <table class="min-w-full divide-y divide-gray-200">
            <thead class="bg-gray-50">
              <slot name="cabecalho"></slot>
            </thead>
            <tbody class="bg-white divide-y divide-gray-200">
              <slot name="corpo"></slot>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
</script>

<style scoped>
</style>