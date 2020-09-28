<template>
    <v-card max-width="344" class="mx-auto">
        <v-list-item>
            <v-list-item-avatar color="grey"></v-list-item-avatar>
            <v-list-item-content>
                <v-list-item-title class="headline">{{
                    event.sujet
                }}</v-list-item-title>
                <v-list-item-subtitle
                    >by {{ event.organisateur }}</v-list-item-subtitle
                >
            </v-list-item-content>
        </v-list-item>

        <v-img :src="Url" lazy-src="@/assets/808080.png" height="194"
            ><template v-slot:placeholder>
                <v-row class="fill-height ma-0" align="center" justify="center">
                    <v-progress-circular
                        indeterminate
                        color="grey lighten-5"
                    ></v-progress-circular>
                </v-row>
            </template>
        </v-img>

        <v-card-text>
            {{ event.description }}
        </v-card-text>

        <v-card-actions>
            <v-btn text color="deep-purple accent-4">
                participate
            </v-btn>
            <v-btn
                text
                color="deep-purple accent-4"
                :to="{ name: 'event-show' }"
            >
                more details
            </v-btn>
        </v-card-actions>
    </v-card>
</template>

<script>
export default {
    name: 'CardEvent',
    props: {
        event: {
            type: Object,
            required: true,
        },
        url: {
            type: Function,
            required: true,
        },
    },

    data() {
        return {
            Url: '',
        };
    },

    created() {
        this.Url = this.url();
    },
};
</script>

<style></style>
