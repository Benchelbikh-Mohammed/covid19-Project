<template>
    <v-container fluid>
        <v-row justify="space-around">
            <v-col cols="12" md="6">
                <v-text-field
                    id="input"
                    v-model="location.adresse"
                    label="Entrer une location"
                    required
                ></v-text-field>
            </v-col>
        </v-row>

        <Map />
    </v-container>
</template>

<script>
import Map from '@/components/Map.vue';
import eventBus from '@/event-bus.js';

export default {
    name: 'Location',
    components: {
        Map,
    },

    data: () => ({
        location: {
            adresse: '',
            cityState: '',
        },
    }),

    mounted() {
        // targets for emitted events
        eventBus.$on('googleInit', () => {
            this.initMapAutocomplete();
        });

        eventBus.$on('mapAddress', payload => {
            this.updateAddressFromMap(payload);
        });
    },

    methods: {
        initMapAutocomplete() {
            // eslint-disable-next-line no-undef
            this.geocoder = new google.maps.Geocoder();

            const input = document.getElementById('input');
            // eslint-disable-next-line no-undef
            const autocomplete = new google.maps.places.Autocomplete(input);
            // eslint-disable-next-line no-undef
            google.maps.event.addListener(autocomplete, 'place_changed', () => {
                const place = autocomplete.getPlace();

                // we need to update the map
                eventBus.$emit('newTextAddress', place);
            });
        },

        updateAddressFromMap(payload) {
            // TODO: error checking...
            const firstAddress = payload[0].formatted_address;

            this.location.adresse = firstAddress;
            // if we have something here, it makes the 'get city' button visible

            // parse the address to get city and state
            this.location.cityState = this.getCityState(payload);
        },

        getCityState(address) {
            let cs = '';

            address.map(curAddress => {
                if (curAddress.types[0] === 'locality') {
                    cs = this.cityStateHelper(curAddress.formatted_address);
                }
            });
            return cs;
        },

        cityStateHelper(str) {
            let city = '';
            let state = '';

            if (!str) return '';

            const addressParts = str.split(',');
            city = addressParts[0];
            // just the first two characters...
            state = addressParts[1].trim().substring(0, 2);
            return `${city},${state}`;
        },
    },
};
</script>

<style></style>
