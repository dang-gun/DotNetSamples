//import { createApp } from "https://unpkg.com/vue@3.2.31/dist/vue.esm-browser.js";
//import createApp from "https://unpkg.com/vue@3.2.31/dist/vue.esm-browser.prod.js";
//import Vue from 'https://cdn.jsdelivr.net/npm/vue@2.6.12/dist/vue.esm.browser.js'
//import { createRouter } from "https://unpkg.com/vue-router@4.0.14/dist/vue-router.global.js";


const Home = { template: '<div>Home</div>' };
const About = { template: '<div>About</div>' };

const routes = [
    { path: '/', component: Home },
    { path: '/about', component: About },
    { path: '/dashboard', component: { template: "<div>dashboard</div>" } },
    { path: '/dashboard2', component: () => import('/TestView.js') },
];


export default function Startup()
{
    //전역 스코프에 개체 저장
    window.app = Vue.createApp({});
    let divMain = document.querySelector("#divMain");

    app.divMain = $(divMain);

    window.app.router
     = VueRouter.createRouter({
        // 4. Provide the history implementation to use. We are using the hash history for simplicity here.
        history: VueRouter.createWebHashHistory(),
        routes, // short for `routes: routes`
    });

    window.app.use(app.router);

    app.mount(divMain);
}