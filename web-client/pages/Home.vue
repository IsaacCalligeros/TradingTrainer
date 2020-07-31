<template>
  <div id="Home">
    Home
    <div class="draggable-container">
      <drag-container :sizeLoc=sizeLoc></drag-container>
      <drag-container></drag-container>
    </div>
  </div>
</template>

<script>
export default {
  data: function() {
    return {
      sizeLoc: {
        x: 200,
        y: 200,
        width: 300,
        height: 200
      }
    };
  },
  computed: {},
  methods: {}
};
</script>

<style lang="scss" scoped>
.draggable-container {
  height: 1000px;
  width: 1000px;
  border: 1px solid red;
}
</style>
