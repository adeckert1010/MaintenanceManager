<template>
  <v-container class="fill-height" fluid>
    <v-row class="mx-auto" justify="center">
        <v-col cols="4" align-self="start" class="vehicle">
            <v-card>
                <v-toolbar color="secondary">
            <v-toolbar-title>{{car.year}} {{car.make}} {{car.name}}</v-toolbar-title>
          </v-toolbar>
                <v-img  v-show="car.imgSrc" id="carImage" :src="car.imgSrc"></v-img>
            </v-card>
        </v-col>
      <v-col cols="8">
      
      <div v-for="(repair, i) in repairs" :key="i">
      <v-card class="elevation-12 my-4">
         <v-card-title class="secondary">
            
                {{repair.desc}}
             </v-card-title>
             <v-card-text>
                 <br/>
                <p> Mileage: {{repair.due_mileage}}</p>
                <p v-if="repair.parts">Parts: </p>
                <p v-for="(part, i) in repair.parts" :key="i"> {{part.desc}} ${{part.price}} </p>
                <p v-if="repair.repair.total_cost">Total cost with labor: ${{repair.repair.total_cost}}</p>
             </v-card-text>
      </v-card>
      </div>
      </v-col>
       </v-row>
  </v-container>
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
        .then(this.getPicture())
        .catch(err => console.error(err));
    },
    methods: {
        getPicture() {
      const oReq = new XMLHttpRequest();
      let self = this;
      self.imgSrc="@/assets/Transpo_G70_TA-518126.jpg"
      oReq.onreadystatechange = function() {
        if (oReq.readyState == 4 && oReq.status == 200) {
          self.setImgSrc(oReq);
        }
      };
      oReq.open(
        "GET",
        `http://www.carimagery.com/api.asmx/GetImageUrl?searchTerm=${this.car.year}+${this.car.make}+${this.car.name}`,
        true
      );
      oReq.send();
    },
    setImgSrc: function(xml) {
      let self = this;
      const xmlDoc = xml.responseXML;
      const x = xmlDoc.getElementsByTagName("string");
      console.log(x[0].firstChild.data);
      self.car.imgSrc = x[0].firstChild.data;
    },
    }
    
}
</script>

<style>
</style>