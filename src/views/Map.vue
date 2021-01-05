<template>
    <v-container fluid>
        <div id="map"></div>
    </v-container>
</template>

<script>
import $Scriptjs from 'scriptjs';
import { eventBus } from '@/event-bus.js';

export default {
    data: () => ({
        map: null,
        geocoder: null,

        DEFAULT_LAT: 31,
        DEFAULT_LNG: -7,
    }),

    mounted() {
        $Scriptjs(
            'https://maps.googleapis.com/maps/api/js?key=AIzaSyDi6aRqF_ORhlgQ2Hun3g6TYcDGqS81-iQ&libraries=geometry,places',
            () => {
                this.initMap();
            },
        );
    },

    methods: {
        initMap() {
            // eslint-disable-next-line no-undef
            this.geocoder = new google.maps.Geocoder();
            // eslint-disable-next-line no-undef
            this.map = new google.maps.Map(document.getElementById('map'), {
                // eslint-disable-next-line no-undef
                center: new google.maps.LatLng(
                    this.DEFAULT_LAT,
                    this.DEFAULT_LNG,
                ),
                zoom: 3,
                gestureHandling: 'greedy',
            });

            // eslint-disable-next-line no-undef
            this.placesService = new google.maps.places.PlacesService(this.map);

            // google.maps.event.addListener(this.map, 'click', event => {
            //     this.lastLat = event.latLng.lat();
            //     this.lastLng = event.latLng.lng();

            //     this.updateMarker(event.latLng);

            //     this.geocoder.geocode(
            //         { location: event.latLng },
            //         (results, status) => {
            //             if (results) {
            //                 eventBus.$emit('mapAddress', results);
            //             }
            //         },
            //     );
            // });

            // this.map.data.loadGeoJson('https://d2ad6b4ur7yvpq.cloudfront.net/naturalearth-3.3.0/ne_50m_populated_places.geojson')
            // this.map.data.loadGeoJson('https://d2ad6b4ur7yvpq.cloudfront.net/naturalearth-3.3.0/ne_50m_land.geojson');
            this.map.data.loadGeoJson(
                'https://d2ad6b4ur7yvpq.cloudfront.net/naturalearth-3.3.0/ne_50m_admin_0_countries.geojson',
            );

            // now we can init other things that depend on Google being loaded
            // tell the event bus
            eventBus.$emit('googleInit', {});
        },
    },
};
</script>

<style>
#map {
    width: 95vw;
    height: 80vh;
}
</style>
