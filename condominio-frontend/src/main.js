import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import PrimeVue from "primevue/config";

const app = createApp(App);

app.use(store);
app.use(PrimeVue);
app.use(router);
app.mount("#app");
