import VueRouter from "https://unpkg.com/vue-router@4.0.5/dist/vue-router.global.js";

const Home = { template: '<div>Home</div>' };
const About = { template: '<div>About</div>' };
const routes = [
    { path: '/', component: Home },
    { path: '/about', component: About },
];




export default function VueRouterTest()
{
        //전역 스코프에 개체 저장
    window.app = Vue.createApp({});

    const router = VueRouter.createRouter({
        // 4. Provide the history implementation to use. We are using the hash history for simplicity here.
        history: VueRouter.createWebHashHistory(),
        routes, // short for `routes: routes`
    });

    window.app.use(router);

    window.app.mount("#divMain");
}