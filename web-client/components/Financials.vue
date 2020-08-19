<template>
  <div>
    {{editMode}}
  </div>
</template>
<script>
import { mapState, mapActions, mapGetters } from "vuex";

export default {
  data: function () {
    return {
        watchList: ''
    };
  },
  created() {

  },
  mounted () {

  },
  computed: {
    ...mapGetters(["editMode"]),
  },
  methods: {
    async getStockData() {

    },
  },
};
</script>

<style lang="scss" scoped>

</style>