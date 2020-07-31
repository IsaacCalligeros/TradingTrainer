<template>
    <client-only>
      <vue-draggable-resizable 
        :w="sizes.width"
        :h="sizes.height"
        @dragging="onDrag"
        @resizing="onResize"
        :parent="true"
      >
        <p>
          {{sizeLoc}} Hello! I'm a flexible component. You can drag me around and you can
          resize me.<br />
          X: {{ sizes.x }} / Y: {{ sizes.y }} - Width: {{ sizes.width }} / Height: {{ sizes.height }}
        </p>
      </vue-draggable-resizable>
      
    </div>    
    </client-only>

</template>

<script>


export default {
  props: {
  	sizeLoc: {
      type: Object,
  	},
  },
  created() {
    console.dir(this.sizeLoc);

  },
  data: function () {
    return {
      sizes: {
        x: 0,
        y: 0,
        width: 100,
        height: 200,
      }
    }
  },
  computed: {
  },
  methods: {
    onResize: function (x, y, width, height) {
      this.x = x
      this.y = y
      this.width = width
      this.height = height
    },
    onDrag: function (x, y) {
      this.x = x
      this.y = y
    }
  }
}
</script>


