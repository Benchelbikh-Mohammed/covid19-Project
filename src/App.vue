<template>
    <v-app>
        <v-app-bar v-if="$vuetify.breakpoint.smAndUp" app color="primary" dark>
            <v-toolbar-title>Real vue app</v-toolbar-title>
            <v-spacer></v-spacer>
            <v-btn
                v-for="(link, index) in links"
                :key="index"
                v-show="!link.requireAuth || loggedIn"
                color="white"
                text
                rounded
                class="my-2 mx-1"
                :to="{ name: link.name }"
                exact
            >
                {{ link.label }}
            </v-btn>
            <template v-if="!loggedIn">
                <v-btn
                    color="white"
                    text
                    rounded
                    class="my-2 mx-1"
                    :to="{ name: 'login' }"
                    exact
                    >Login</v-btn
                >
                <v-btn
                    color="white"
                    text
                    rounded
                    class="my-2 mx-1"
                    :to="{ name: 'signup' }"
                    exact
                    >Signup</v-btn
                >
            </template>
            <v-btn
                color="indigo darken-4"
                v-if="loggedIn"
                @click="logout"
                rounded
            >
                Logout
            </v-btn>
        </v-app-bar>
        <v-main class="grey lighten-4">
            <router-view></router-view>
        </v-main>
        <v-footer color="primary lighten-1" padless>
            <v-bottom-navigation v-model="bottomNav">
                <v-btn
                    color="white"
                    text
                    rounded
                    class="my-2 mx-1"
                    :to="{ name: 'login' }"
                    exact
                    value="login"
                    ><span>login</span> <v-icon>mdi-heart</v-icon></v-btn
                >
                <v-btn
                    color="white"
                    text
                    rounded
                    class="my-2 mx-1"
                    :to="{ name: 'signup' }"
                    exact
                    value="signup"
                >
                    <span>Signup</span>
                    <v-icon>mdi-history</v-icon>
                </v-btn>

                <v-btn
                    v-for="(link, index) in links"
                    :key="index"
                    color="white"
                    text
                    rounded
                    v-show="!link.requireAuth || loggedIn"
                    :value="link.value"
                    class="my-2"
                    :to="{ name: link.name }"
                    exact
                >
                    <span>{{ link.label }}</span>
                    <v-icon>{{ link.icon }}</v-icon>
                </v-btn>
            </v-bottom-navigation>
            <v-layout justify-center wrap>
                <v-flex primary lighten-2 py-4 text-center white--text xs12>
                    {{ new Date().getFullYear() }} —
                    <strong>Vuetify Dashboard</strong>
                </v-flex>
            </v-layout>
        </v-footer>
    </v-app>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
    name: 'App',
    data() {
        return {
            links: [
                {
                    label: 'Home',
                    name: 'home',
                    requireAuth: true,
                    value: 'home',
                    icon: 'mdi-home',
                },
                {
                    label: 'Dashboard',
                    name: 'dashboard',
                    requireAuth: true,
                    value: 'dashbord',
                    icon: 'mdi-dashboard',
                },
            ],
            bottomNav: '',
        };
    },
    methods: {
        logout() {
            this.$store.dispatch('logout');
        },
    },

    computed: mapGetters(['loggedIn']),
};
</script>

<style lang="scss">
@import '@/sass/variables.scss';

body {
    font-family: $body-font-family;
}
</style>
