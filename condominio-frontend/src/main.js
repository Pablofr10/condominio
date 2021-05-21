import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

import DefaultLayout from "./components/layouts/DefaultLayout.vue";

const app = createApp(App);

app.component("default-layout", DefaultLayout);

app.use(store);
app.use(router);

app.mount("#app");
