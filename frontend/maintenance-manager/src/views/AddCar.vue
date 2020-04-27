<template>
  <container class="fill-height" fluid>
    <v-row align="center" justify="center">
      <v-col cols="12" sm="8" md="6">
        <v-card class="elevation-12">
          <v-toolbar color="secondary">
            <v-toolbar-title>Choose your car</v-toolbar-title>
          </v-toolbar>
          <v-card-text>
            <v-form>
              <v-select
              v-show="makes"
              :items="makes"
              :item-text="makes.Make_Name"
              ></v-select>
            </v-form>
          </v-card-text>
          <v-card-actions>
            <v-spacer />
            <v-btn color="primary">Login</v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </container>
</template>

<script>
export default {
  data() {
    return {
      makes: []
    };
  },
  created() {
    //retrieve list of makes from API
    fetch("https://vpic.nhtsa.dot.gov/api/vehicles/getallmanufacturers?ManufacturerType=complete&format=json")
      .then(response => {
        return response.json();
      })
      .then(x => {
        this.makes = x.results;
      })
      .catch(err => console.error(err));
  }
};
</script>

<style>
</style>