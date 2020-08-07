<template>
  <div id="Home">
    <div class="draggable-container">
      <drag-container :sizeLoc=sizeLoc :control=Stocks></drag-container>
      <drag-container :sizeLoc=sizeLoc2 :control=Weather></drag-container>
      
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
        w: 300,
        h: 200
      },
      sizeLoc2: {
        x: 500,
        y: 500,
        w: 300,
        h: 200
      },
      Weather: "Weather",
      Stocks: "Stocks"
    };
  },
  computed: {},
  methods: {}
};
</script>

<style lang="scss" scoped>
.draggable-container {
  position: absolute;
top: 0px;
bottom: 0px;
width: 100%;
  border: 1px solid red;
}
</style>
