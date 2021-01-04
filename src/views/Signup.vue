<template>
    <v-container>
        <v-form ref="form" v-model="valid" @submit.prevent="submit">
            <v-stepper v-model="e1" vertical>
                <v-stepper-step :complete="e1 > 1" step="1">
                    Select an app
                    <small>Summarize if needed</small>
                </v-stepper-step>

                <v-stepper-content step="1">
                    <v-row>
                        <v-col cols="12" md="4">
                            <v-text-field
                                v-model="cin"
                                :rules="cinRules"
                                label="Cin"
                                required
                            ></v-text-field>
                        </v-col>

                        <v-col cols="12" md="4">
                            <v-text-field
                                v-model="firstname"
                                :rules="nameRules"
                                :counter="20"
                                label="First name"
                                required
                            ></v-text-field>
                        </v-col>

                        <v-col cols="12" md="4">
                            <v-text-field
                                v-model="lastname"
                                :rules="nameRules"
                                :counter="20"
                                label="Last name"
                                required
                            ></v-text-field>
                        </v-col>
                    </v-row>

                    <v-row>
                        <v-col cols="12" md="4">
                            <v-text-field
                                v-model="email"
                                :rules="emailRules"
                                label="E-mail"
                                required
                            ></v-text-field>
                        </v-col>
                        <v-col cols="12" md="4">
                            <v-menu
                                ref="menu"
                                v-model="menu"
                                :close-on-content-click="false"
                                transition="scale-transition"
                                offset-y
                                min-width="290px"
                            >
                                <template v-slot:activator="{ on, attrs }">
                                    <v-text-field
                                        v-model="date"
                                        label="Birthday date"
                                        prepend-icon="mdi-calendar"
                                        readonly
                                        v-bind="attrs"
                                        v-on="on"
                                    ></v-text-field>
                                </template>
                                <v-date-picker
                                    ref="picker"
                                    v-model="date"
                                    :max="
                                        new Date().toISOString().substr(0, 10)
                                    "
                                    min="1950-01-01"
                                    @change="save"
                                ></v-date-picker>
                            </v-menu>
                        </v-col>
                        <v-col cols="12" md="4">
                            <v-textarea
                                label="adress"
                                auto-grow
                                rows="3"
                                row-height="10"
                                shaped
                                v-model="adress"
                            ></v-textarea>
                        </v-col>
                    </v-row>

                    <v-row>
                        <v-checkbox
                            v-model="checkbox"
                            :rules="[v => !!v || 'You must agree to continue!']"
                            label="Do you agree?"
                            required
                        ></v-checkbox>
                    </v-row>
                    <v-row>
                        <v-btn
                            type="submit"
                            color="success"
                            class="mr-4"
                            @click="validate"
                        >
                            Validate
                        </v-btn>
                        <v-btn color="error" class="mr-4" @click="reset">
                            Reset Form
                        </v-btn>

                        <v-btn color="warning" @click="resetValidation">
                            Reset Validation
                        </v-btn>
                    </v-row>

                    <v-btn color="primary" @click="e1 = 2">
                        Continue
                    </v-btn>
                    <v-btn text>
                        Cancel
                    </v-btn>
                </v-stepper-content>

                <v-stepper-step :complete="e1 > 2" step="2">
                    Configure analytics for this app
                </v-stepper-step>

                <v-stepper-content step="2">
                    <v-card
                        color="grey lighten-1"
                        class="mb-12"
                        height="200px"
                    ></v-card>
                    <v-btn color="primary" @click="e1 = 1">
                        Continue
                    </v-btn>
                    <v-btn text>
                        Cancel
                    </v-btn>
                </v-stepper-content>
            </v-stepper>
        </v-form>
    </v-container>
</template>

<script>
export default {
    name: 'Signup',
    data: () => ({
        e1: 1,
        valid: false,
        adress: '',
        menu: false,
        cin: '',
        cinRules: [
            v => !!v || 'Cin obligatoire',
            v => /^[A-Za-z]{1,2}[0-9]{6}$/.test(v) || 'cin doit etre valide',
        ],
        firstname: '',
        lastname: '',
        date: '',
        nameRules: [
            v => !!v || 'Name est obligatoire',
            v =>
                (v && v.length <= 20) ||
                'Nom doit etre inferieur a 20 caracters',
        ],
        email: '',
        emailRules: [
            v => !!v || 'E-mail est obligatoire',
            v => /.+@.+/.test(v) || 'E-mail doit etre valide',
        ],
        checkbox: false,
    }),

    watch: {
        menu(val) {
            val && setTimeout(() => (this.$refs.picker.activePicker = 'YEAR'));
        },
    },

    methods: {
        save(date) {
            this.$refs.menu.save(date);
        },
        validate() {
            this.$refs.form.validate();
        },

        submit() {
            console.log('submitted');
        },
        reset() {
            this.$refs.form.reset();
        },
        resetValidation() {
            this.$refs.form.resetValidation();
        },
    },
};
</script>

<style>
.slide-fade-enter-active {
    transition: all 0.3s ease;
}
.slide-fade-leave-active {
    transition: all 0.8s cubic-bezier(1, 0.5, 0.8, 1);
}
.slide-fade-enter,
.slide-fade-leave-to {
    transform: translateX(10px);
    opacity: 0;
}
</style>
