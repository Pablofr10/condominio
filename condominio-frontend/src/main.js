import { createApp } from "vue";
import App from "./App.vue";
import "virtual:windi.css";
import router from "./router";

import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

import { DefaultLayout, EmptyLayout } from './layouts'
import { library } from "@fortawesome/fontawesome-svg-core";
import icons from './fontawesome';

library.add({ ...icons });

const app = createApp(App);

app.component('default-layout', DefaultLayout);
app.component('empty-layout', EmptyLayout);
app.component("font-awesome-icon", FontAwesomeIcon);

app.use(router);
app.mount("#app");
