<template>
  <nav>
    <button
      class="btn"
      @click="abrir = !abrir"
      style="font-size: 30px; color: white"
    >
      <fa v-if="abrir" icon="bars" />
      <fa v-if="!abrir" icon="times" />
    </button>

    <label class="logo">Meu condominio</label>
    <ul>
      <li><a href="#" class="active">Home</a></li>
      <li><a href="#">About</a></li>
      <li><a href="#">Services</a></li>
      <li><a href="#">Feedback</a></li>
    </ul>
  </nav>
</template>

<script>
import { ref } from "vue";
export default {
  setup() {
    const abrir = ref(false);
    return {
      abrir,
    };
  },
};
</script>

<style scoped>
nav {
  background: #0082e6;
  height: 80px;
  width: 100%;
}
label.logo {
  color: white;
  font-size: 35px;
  line-height: 80px;
  padding: 0 100px;
  font-weight: bold;
}
nav ul {
  float: right;
  margin-right: 20px;
}
nav ul li {
  display: inline-block;
  line-height: 80px;
  margin: 0 5px;
}
nav ul li a {
  color: white;
  font-size: 17px;
  text-transform: uppercase;
  text-decoration: none;
}
a.active,
a:hover {
  background: #1b9bff;
  transition: 0.5s;
}
</style>