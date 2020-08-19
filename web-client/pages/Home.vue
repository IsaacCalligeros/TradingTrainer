<template>
  <div id="Home">
    <div id="dragContainer" class="draggable-container">
      <template v-for="item in draggableContainers">
        <drag-container :key="item.control" :sizeLoc="item.sizeLoc" :control="item.control"></drag-container>
      </template>
    </div>
  </div>
</template>

<script>
import { mapState, mapActions, mapGetters } from "vuex";

export default {
  data: function () {
    return {
      draggableContainers: [
        {
          control: "Weather",
          sizeLoc: {
            x: 200,
            y: 200,
            w: 300,
            h: 200,
          },
        },
        {
          control: "Financials",
          sizeLoc: {
            x: 500,
            y: 500,
            w: 300,
            h: 200,
          },
        },
      ],
    };
  },
  computed: {
    ...mapGetters("activeContainers", ["resizableContainers"]),
  },
  methods: {},
};
</script>

<style lang="scss" scoped>
.draggable-container {
  position: absolute;
  top: 0px;
  bottom: 0px;
  width: 100%;
  left: 0px;
}
</style>
