<template>
  <v-container class="fill-height" fluid>
    <v-row align="center" justify="center">
      <v-col cols="12" sm="8" md="6">
        <v-card class="elevation-12">
          <v-toolbar color="secondary">
            <v-toolbar-title>Choose your car</v-toolbar-title>
          </v-toolbar>
          <v-img id="carImage" v-show="name" :src="imgSrc" transition :lazy-src="require('@/assets/Transpo_G70_TA-518126.jpg')">
          <template v-slot:placeholder>
        <v-row
          class="fill-height ma-0"
          align="center"
          justify="center"
        >
          <v-progress-circular v-if="name" indeterminate color="grey lighten-5"></v-progress-circular>
        </v-row>
          </template>
</v-img>
          <v-card-text>
            <p>{{year}} {{make}} {{name}}</p>
            <v-form>
              <v-select
                :items="years"
                v-model="year"
                label="Select A Year"
                @change="getMakesByYear(); clearMake(); clearName();"
              ></v-select>
              <v-select
                v-if="year"
                v-model="make"
                label="Select A Make"
                :items="makes"
                :loading="!makes"
                :disabled="!makes"
                @change="getModelsByYearAndMake(); clearName();"
              ></v-select>
              <v-select
                v-if="make"
                v-model="name"
                label="Select A Model"
                :items="models"
                :loading="!models"
                :disabled="!models"
                @change="getPicture()"
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
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      models: null,
      makes: null,
      years: [
        "2020",
        "2019",
        "2018",
        "2017",
        "2016",
        "2015",
        "2014",
        "2013",
        "2012",
        "2011",
        "2010",
        "2009",
        "2008",
        "2007",
        "2006",
        "2005",
        "2004",
        "2003",
        "2002",
        "2001",
        "2000",
        "1999",
        "1998",
        "1997",
        "1996"
      ],
      year: null,
      make: "",
      name: "",
      imgSrc: ""
    };
  },
  created() {},
  methods: {
    getMakesByYear() {
      //retrieve list of makes from API
      const headers = new Headers();
      headers.append(
        "Authorization",
        "Basic NzhhZTlkY2YtYzY5YS00NmMzLTg1NjAtY2YzMDBiNDI0ZWQy"
      );
      headers.append("partner-token", "ae89a034867a458cb665133a5ad4e8a7");
      fetch(`https://api.carmd.com/v3.0/make?year=${this.year}`, {
        method: "GET",
        headers: headers
      })
        .then(response => {
          if (response.ok) {
            return response.json();
          }
        })
        .then(x => {
          this.makes = x.data;
        })
        .catch(err => console.error(err));
    },

    getModelsByYearAndMake() {
      //retrieve list of models from API
      const headers = new Headers();
      headers.append(
        "Authorization",
        "Basic NzhhZTlkY2YtYzY5YS00NmMzLTg1NjAtY2YzMDBiNDI0ZWQy"
      );
      headers.append("partner-token", "ae89a034867a458cb665133a5ad4e8a7");
      fetch(
        `https://api.carmd.com/v3.0//model?year=${this.year}&make=${this.make}`,
        {
          method: "GET",
          headers: headers
        }
      )
        .then(response => {
          if (response.ok) {
            return response.json();
          }
        })
        .then(x => {
          this.models = x.data;
        })
        .catch(err => console.error(err));
    },
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
        `http://www.carimagery.com/api.asmx/GetImageUrl?searchTerm=${this.year}+${this.make}+${this.name}`,
        true
      );
      oReq.send();
    },
    setImgSrc: function(xml) {
      let self = this;
      const xmlDoc = xml.responseXML;
      const x = xmlDoc.getElementsByTagName("string");
      console.log(x[0].firstChild.data);
      self.imgSrc = x[0].firstChild.data;
    },
    clearName() {
      this.name = "";
    },
    clearMake() {
      this.make = "";
    }
  }
  // computed: {
  //   loadingState() {
  //     if(this.makes!==0){
  //       return false
  //     }
  //     else {
  //       return true
  //     }
  //   }
  // }
};
</script>

<style>
</style>