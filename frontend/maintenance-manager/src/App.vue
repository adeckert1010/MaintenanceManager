<template>
  <v-app id="inspire">
    <v-navigation-drawer v-model="drawer" app dark mini-variant expand-on-hover class="secondary">
      <v-list dense>
        <v-list-item link :to="'/'">
          <v-list-item-action>
            <v-icon>mdi-home</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link :to="'addcar'">
          <v-list-item-action>
            <v-icon>mdi-car</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Add A Car</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar app class="secondary" dark>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title v-cloak>Maintenance Manager</v-toolbar-title>
    </v-app-bar>

    <v-content class="primary">
      <router-view />
    </v-content>
    <v-footer color="secondary" app>
      <span class="white--text">&copy; {{new Date().getFullYear()}} Allen Deckert</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  props: {
    source: String
  },
  data() {
    return {
      drawer: null,
      initialDark: this.$vuetify.theme.dark
    };
  }
};
</script>