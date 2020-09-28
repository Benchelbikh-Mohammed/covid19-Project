<template>
    <v-container>
        <v-row>
            <v-col
                cols="12"
                sm="6"
                md="4"
                v-for="event in event.events"
                :key="event.id"
            >
                <Card :url="randomImage" :event="event" />
            </v-col>
        </v-row>
    </v-container>
</template>

<script>
import Card from '@/components/Card.vue';
import { mapState } from 'vuex';

export default {
    components: {
        Card,
    },

    created() {
        this.$store.dispatch('fetchEvents').then(() => {
            console.log('fetched');
        });
    },

    computed: mapState(['event']),

    methods: {
        randomImage() {
            return `https://picsum.photos/id/${(Math.random() * 100) | 0}/500`;
        },
    },
};
</script>

<style></style>
