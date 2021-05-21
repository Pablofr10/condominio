import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import icones from "./styles/fontawesome";
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

import DefaultLayout from "./components/layouts/DefaultLayout.vue";

library.add({ ...icones });

const app = createApp(App);

app.component("default-layout", DefaultLayout);
app.component("fa", FontAwesomeIcon);

app.use(store);
app.use(router);

app.mount("#app");
