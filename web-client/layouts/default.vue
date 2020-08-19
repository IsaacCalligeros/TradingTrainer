<template>
  <v-app :style="{background: $vuetify.theme.themes[isDark].background}">
    <v-app-bar :clipped-left="clipped" fixed app>
      <v-spacer />
      <div class="col-2">
        <nuxt-link class="mx-3" to="/settings">settings</nuxt-link>
        <nuxt-link to="/home">Home</nuxt-link>
      </div>
      <div class="col-2 float-right">
        <v-btn icon v-if="$nuxt.$route.name === 'Home'" @click="edit = !edit">
          <v-icon @click.stop="flipEdit">mdi-puzzle-edit-outline</v-icon>
        </v-btn>
        <v-btn icon v-if="$nuxt.$route.name === 'Home'" @click.stop="rightDrawer = !rightDrawer">
          <v-icon>mdi-menu</v-icon>
        </v-btn>
      </div>
    </v-app-bar>
    <v-content>
      <v-container>
        <nuxt />
      </v-container>
    </v-content>
    <v-navigation-drawer v-model="rightDrawer" :right="right" temporary fixed>
      <v-list>
        <v-list-item @click.native="right = !right">
          <v-list-item-action>
            <v-icon light>mdi-repeat</v-icon>
          </v-list-item-action>
          <v-list-item-title>Controls</v-list-item-title>
        </v-list-item>
      </v-list>
      <div>
        <components-list></components-list>
      </div>
    </v-navigation-drawer>
    <v-footer :absolute="!fixed" app>
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
import { mapState, mapActions, mapGetters } from "vuex";

export default {
  data() {
    return {
      fixed: false,
      clipped: false,
      right: true,
      rightDrawer: false,
      edit: false,
      title: "Vuetify.js",
    };
  },
  computed: {
    ...mapGetters(["editMode"]),
    isDark() {
      return this.$vuetify.theme.dark ? "dark" : "light";
    },
  },
  methods: {
    ...mapActions(["flipEditMode"]),
    flipEdit() {
      this.flipEditMode();
    },
  },
};
</script>
