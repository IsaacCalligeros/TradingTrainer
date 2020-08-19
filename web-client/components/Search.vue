<template>
  <div>
    <div v-if="editMode">
      <v-radio-group v-model="selectedEngine">
        <v-radio v-for="n in engine" :key="n" :label="`${n}`" :value="n"></v-radio>
      </v-radio-group>
    </div>
    <v-flex v-else>
      <v-form ref="searchForm">
        <div class="center">
          <v-text-field  v-model="searchTerm" solo rounded label="Search"></v-text-field>
          <v-btn color="primary" @click="search">Search</v-btn>
        </div>
      </v-form>
    </v-flex>
  </div>
</template>
<script>
import { mapState, mapActions, mapGetters } from "vuex";

export default {
  data: function () {
    return {
      selectedEngine: "Google",

      engine: {
        GOOGLE: "Google",
        DUCKDUCKGO: "DuckDuckGo",
        BING: "Bing",
      },
      google: "https://www.google.com/search?q=",
      duckduckgo: "https://duckduckgo.com/?q=",
      bing: "https://www.bing.com/search?q",
      searchTerm: "",
    };
  },
  created() {},
  mounted() {},
  computed: {
    ...mapGetters(["editMode"]),
  },
  methods: {
    search() {
      this.$refs.searchForm.validate();
      console.dir(this.selectedEngine);
      switch (this.selectedEngine) {
        case this.engine.GOOGLE:
          window.location.replace(this.googleBase + this.searchTerm);
        case this.engine.BING:
          window.location.replace(this.bing + this.searchTerm);
        case this.engine.DUCKDUCKGO:
          window.location.replace(this.duckduckgo + this.searchTerm);
      }
    },
  },
};
</script>

<style lang="scss" scoped>
.center {
  position: absolute;
  top: 50%;
  left: 50%;
  width: 80%;
  transform: translate(-50%, -50%);
}

</style>
