<template>
    <v-container>
        <v-form ref="form" v-model="valid" @submit.prevent="submit">
            <v-row>
                <v-col cols="12" md="4">
                    <v-text-field
                        v-model="firstname"
                        :rules="nameRules"
                        :counter="10"
                        label="First name"
                        required
                    ></v-text-field>
                </v-col>

                <v-col cols="12" md="4">
                    <v-text-field
                        v-model="lastname"
                        :rules="nameRules"
                        :counter="10"
                        label="Last name"
                        required
                    ></v-text-field>
                </v-col>

                <v-col cols="12" md="4">
                    <v-text-field
                        v-model="email"
                        :rules="emailRules"
                        label="E-mail"
                        required
                    ></v-text-field>
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
        </v-form>
    </v-container>
</template>

<script>
export default {
    name: 'Signup',
    data: () => ({
        valid: false,
        firstname: '',
        lastname: '',
        nameRules: [
            v => !!v || 'Name is required',
            v => v.length <= 10 || 'Name must be less than 10 characters',
        ],
        email: '',
        emailRules: [
            v => !!v || 'E-mail is required',
            v => /.+@.+/.test(v) || 'E-mail must be valid',
        ],
        checkbox: false,
    }),

    methods: {
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

<style></style>
