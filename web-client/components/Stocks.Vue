<template>
  <div>
    <p>Stocks yooooot</p>
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