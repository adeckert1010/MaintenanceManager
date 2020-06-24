import Vue from 'vue'
import Home from '@/views/Home'
import Router from 'vue-router'
import AddCar from '@/views/AddCar'
import Results from '@/views/Results'

Vue.use(Router)

export default new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        {
            path: '/',
            name: 'home',
            component: Home
        },
        {
            path: '/login',
            name: 'login'
        },
        {
            path: '/addcar',
            name: 'addcar',
            component: AddCar
        },
        {
            path: '/results/:year/:make/:name/:miles',
            name: 'results',
            component: Results
        }
    ]
})