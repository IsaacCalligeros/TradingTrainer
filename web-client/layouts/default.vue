<template>
  <v-app dark>
    <v-app-bar :clipped-left="clipped" fixed app>
      <v-spacer />
      <v-btn icon @click="edit = !edit">
        <v-icon>mdi-puzzle-edit-outline</v-icon>
      </v-btn>
      <v-btn icon @click.stop="rightDrawer = !rightDrawer">
        <v-icon>mdi-menu</v-icon>
      </v-btn>
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
            <v-icon light>
              mdi-repeat
            </v-icon>
          </v-list-item-action>
          <v-list-item-title></v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-footer :absolute="!fixed" app>
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      fixed: false,
      clipped: false,
      right: true,
      rightDrawer: false,
      edit: false,
      title: "Vuetify.js"
    };
  }
};
</script>
