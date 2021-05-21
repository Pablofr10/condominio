<template>
  <component :is="'default-layout'">
    <router-view></router-view>
  </component>
  <router-view />
</template>


<style>
@import "./styles/global.css";
</style>
