import Vue from 'vue'
import HelloWorld from '@/components/HelloWorld.vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        {
            path: '/',
            name: 'home',
            component: HelloWorld
        },
        {
            path: '/login',
            name: 'login'
        },
        {
            path: '/cars',
            name: 'cars'
        }
    ]
})