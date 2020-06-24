<template>
  <v-content>
    <v-row class="mx-auto" align="center" justify="center">
      <v-col cols="12">
      {{car.year}} {{car.make}} {{car.name}} {{car.miles}} miles
      <div v-for="(repair, i) in repairs" :key="i">
      <v-card>
         <v-toolbar class="secondary">
             <v-toolbar-title>
                {{repair.desc}}
             </v-toolbar-title>
             <v-card-text>
                Mileage: {{repair.due_mileage}}
                <p v-if="repair.parts">Parts: </p>
                <p v-for="(part, i) in repair.parts" :key="i"> {{part.desc}} ${{part.price}} </p>
                <p>Total cost with labor: {{part.price + repair.labor_cost}}</p>
             </v-card-text>
         </v-toolbar>
      </v-card>
      </div>
      </v-col>
       </v-row>
  </v-content>
</template>

<script>
export default {
    data() {
        return {
        car: {},
        repairs: [{}]
        }

    },
    created() {
        this.car.year = this.$route.params.year;
        this.car.make = this.$route.params.make;
        this.car.name = this.$route.params.name;
        this.car.miles = this.$route.params.miles;

        const headers = new Headers();
      headers.append(
        "Authorization",
        "Basic NzhhZTlkY2YtYzY5YS00NmMzLTg1NjAtY2YzMDBiNDI0ZWQy"
      );
      headers.append("partner-token", "ae89a034867a458cb665133a5ad4e8a7");
      fetch(`http://api.carmd.com/v3.0/maint?year=${this.car.year}&make=${this.car.make}&model=${this.car.name}&mileage=${this.car.miles}`, {
        method: "GET",
        headers: headers
      })
        .then(response => {
          if (response.ok) {
            return response.json();
          }
        })
        .then(x => {
          this.repairs = x.data;
        })
        .catch(err => console.error(err));
    },
    
}
</script>

<style>

</style>