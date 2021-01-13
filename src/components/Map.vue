<template>
    <v-container fluid>
        <div id="map"></div>
    </v-container>
</template>

<script>
import $Scriptjs from 'scriptjs';
import eventBus from '@/event-bus.js';
import axios from 'axios';

export default {
    data: () => ({
        map: null,
        geocoder: null,
        markers: null,
        marker: null,

        lastLat: null,
        lastLng: null,

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

        eventBus.$on('newTextAddress', payload => {
            this.updateFromTextAddress(payload);
        });
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
                zoom: 7,
                styles: [
                    {
                        elementType: 'geometry',
                        stylers: [{ color: '#242f3e' }],
                    },
                    {
                        elementType: 'labels.text.stroke',
                        stylers: [{ color: '#242f3e' }],
                    },
                    {
                        elementType: 'labels.text.fill',
                        stylers: [{ color: '#746855' }],
                    },
                    {
                        featureType: 'administrative.locality',
                        elementType: 'labels.text.fill',
                        stylers: [{ color: '#d59563' }],
                    },
                    {
                        featureType: 'poi',
                        elementType: 'labels.text.fill',
                        stylers: [{ color: '#d59563' }],
                    },
                    {
                        featureType: 'poi.park',
                        elementType: 'geometry',
                        stylers: [{ color: '#263c3f' }],
                    },
                    {
                        featureType: 'poi.park',
                        elementType: 'labels.text.fill',
                        stylers: [{ color: '#6b9a76' }],
                    },
                    {
                        featureType: 'road',
                        elementType: 'geometry',
                        stylers: [{ color: '#38414e' }],
                    },
                    {
                        featureType: 'road',
                        elementType: 'geometry.stroke',
                        stylers: [{ color: '#212a37' }],
                    },
                    {
                        featureType: 'road',
                        elementType: 'labels.text.fill',
                        stylers: [{ color: '#9ca5b3' }],
                    },
                    {
                        featureType: 'road.highway',
                        elementType: 'geometry',
                        stylers: [{ color: '#746855' }],
                    },
                    {
                        featureType: 'road.highway',
                        elementType: 'geometry.stroke',
                        stylers: [{ color: '#1f2835' }],
                    },
                    {
                        featureType: 'road.highway',
                        elementType: 'labels.text.fill',
                        stylers: [{ color: '#f3d19c' }],
                    },
                    {
                        featureType: 'transit',
                        elementType: 'geometry',
                        stylers: [{ color: '#2f3948' }],
                    },
                    {
                        featureType: 'transit.station',
                        elementType: 'labels.text.fill',
                        stylers: [{ color: '#d59563' }],
                    },
                    {
                        featureType: 'water',
                        elementType: 'geometry',
                        stylers: [{ color: '#17263c' }],
                    },
                    {
                        featureType: 'water',
                        elementType: 'labels.text.fill',
                        stylers: [{ color: '#515c6d' }],
                    },
                    {
                        featureType: 'water',
                        elementType: 'labels.text.stroke',
                        stylers: [{ color: '#17263c' }],
                    },
                ],
                gestureHandling: 'greedy',
            });

            // // eslint-disable-next-line no-undef
            // this.placesService = new google.maps.places.PlacesService(this.map);

            // eslint-disable-next-line no-undef
            google.maps.event.addListener(this.map, 'click', event => {
                this.lastLat = event.latLng.lat();
                this.lastLng = event.latLng.lng();

                this.updateMarker(event.latLng);

                this.geocoder.geocode({ location: event.latLng }, results => {
                    if (results) {
                        eventBus.$emit('mapAddress', results);
                    }
                });

                this.$store.dispatch('setLatLng', {
                    lat: this.lastLat,
                    lng: this.lastLng,
                });
            });

            // this.map.data.loadGeoJson('https://d2ad6b4ur7yvpq.cloudfront.net/naturalearth-3.3.0/ne_50m_populated_places.geojson')
            // this.map.data.loadGeoJson('https://d2ad6b4ur7yvpq.cloudfront.net/naturalearth-3.3.0/ne_50m_land.geojson');
            // this.map.data.loadGeoJson(
            //     'https://d2ad6b4ur7yvpq.cloudfront.net/naturalearth-3.3.0/ne_50m_admin_0_countries.geojson',
            // );

            const apiCall = async () => {
                const d = await axios.get('http://localhost:5000/api/location');

                const markerCollection = this.map.data.addGeoJson(d.data);
                for (var i = 0; i < markerCollection.length; i++) {
                    var feature = markerCollection[i];
                    if (feature.getProperty('icon')) {
                        this.map.data.setStyle(feature => ({
                            icon: {
                                url: feature.getProperty('icon'),
                                // this marker is 765.9 pixels wide by 666 pixels high.
                                // eslint-disable-next-line no-undef
                                scaledSize: new google.maps.Size(14, 12),
                                // The anchor for this image is the base (0, 12).
                                // eslint-disable-next-line no-undef
                                anchor: new google.maps.Point(7, 12),
                            },
                        }));
                    }
                }
            };

            apiCall();

            // now we can init other things that depend on Google being loaded
            // tell the event bus
            eventBus.$emit('googleInit', {});
        },

        updateMarker(latLng) {
            if (!this.marker) {
                // eslint-disable-next-line no-undef
                this.marker = new google.maps.Marker({
                    map: this.map,
                });
            }

            this.marker.setPosition(latLng);
        },

        updateFromTextAddress(payload) {
            this.map.setCenter(payload.geometry.location);
            this.updateMarker(payload.geometry.location);

            eventBus.$emit('mapAddress', payload);
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
