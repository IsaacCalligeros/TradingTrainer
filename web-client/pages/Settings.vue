<template>
  <div>
    <v-switch v-model="$vuetify.theme.dark" :label="colorMode"></v-switch>
  </div>
</template>

<script>
import Axios from "axios";
import { mapState, mapActions, mapMutations } from "vuex";

export default {
  components: {},
  data: () => ({
    //message: ""
    colorMode: "colorMode"
  }),
  computed: mapState({
    message: (state) => state.message,
  }),
  methods: {
  ...mapActions("Settings", [""]),
  ...mapMutations(["reset"])
  },
  created() {},
};
</script>
