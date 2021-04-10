<template>
  <!-- This example requires Tailwind CSS v2.0+ -->

  <atom-table>
    <template #cabecalho>
      <tr>
        <th
          scope="col"
          class="px-6 py-3 text-center text-xs font-medium text-gray-500 uppercase tracking-wider"
        >
          Name
        </th>
        <th
          scope="col"
          class="px-6 py-3 text-center text-xs font-medium text-gray-500 uppercase tracking-wider"
        >
          Title
        </th>
        <th
          scope="col"
          class="px-6 py-3 text-center text-xs font-medium text-gray-500 uppercase tracking-wider"
        >
          Status
        </th>
        <th
          scope="col"
          class="px-6 py-3 text-center text-xs font-medium text-gray-500 uppercase tracking-wider"
        >
          Role
        </th>
        <th scope="col" class="relative px-6 py-3">
          <span class="sr-only">Acoes</span>
        </th>
      </tr>
    </template>

    <template #corpo>
      <tr v-for="(n, index) in 15" :key="index">
        <td class="px-6 py-4 whitespace-nowrap">
          <div class="flex items-center">
            <div class="flex-shrink-0 h-10 w-10">
              <img
                class="h-10 w-10 rounded-full"
                src="https://images.unsplash.com/photo-1494790108377-be9c29b29330?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=4&w=256&h=256&q=60"
                alt=""
              />
            </div>
            <div class="ml-2">
              <div class="text-sm font-medium text-gray-900">Jane Cooper</div>
              <div class="text-sm text-gray-500">jane.cooper@example.com</div>
            </div>
          </div>
        </td>
        <td class="px-2 py-4 whitespace-nowrap">
          <div class="text-sm text-gray-900">Regional Paradigm Technician</div>
          <div class="text-sm text-gray-500">Optimization</div>
        </td>
        <td class="px-6 py-4 whitespace-nowrap">
          <span
            class="px-2 inline-flex text-xs leading-5 font-semibold rounded-full bg-green-100 text-green-800"
          >
            Active
          </span>
        </td>
        <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500">Admin</td>
        <td class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
          <a href="#" class="text-indigo-600 hover:text-indigo-900">Edit</a>
          <a href="#" class="text-indigo-600 hover:text-indigo-900">Edit</a>
        </td>
      </tr>
    </template>
  </atom-table>
</template>

<script setup >
import { AtomTable } from "../atoms";
</script>

<style scoped>
</style>