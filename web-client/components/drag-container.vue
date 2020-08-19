<template>
  <client-only>
    <vue-draggable-resizable
      class="drag-container"
      :is-conflict-check="true"
      :snap="true"
      :snap-tolerance="40"
      :w="container.w"
      :h="container.h"
      :x="container.x"
      :y="container.y"
      @dragging="onDrag"
      @dragstop="onDragstop"
      @resizing="onResize"
      @resizestop="onResizstop"
      :parent="true"
      :disable-user-select="false"
    >
      <v-btn color="error" class="close" v-if="editMode" @click="deleteContainer">X</v-btn>
      <div class="component-content">
        <component v-bind:is="control" />
      </div>
    </vue-draggable-resizable>
  </client-only>
</template>

<script>
import { mapState, mapActions, mapGetters } from "vuex";
import Weather from "./Weather";
import Financials from "./Financials";
import Search from "./Search";
import News from "./News";

export default {
  props: ["sizeLoc", "control"],
  components: {
    Weather,
    Financials,
    Search,
    News
  },
  mounted() {
    this.container = this.sizeLoc;
    this.container.id = this.uuidv4();
    this.addContainer(this.container);
  },
  data: function () {
    return {
      container: {
        id: "",
        x: 0,
        y: 0,
        w: 100,
        h: 200,
      },
    };
  },
  computed: {
    ...mapGetters("activeContainers", ["resizableContainers"]),
    ...mapGetters(["editMode"]),
  },
  methods: {
    onResize: function (x, y, w, h) {
      // this.container.x = x;
      // this.container.y = y;
      // this.container.w = w;
      // this.container.h = h;
    },
    onResizstop: function (x, y, w, h) {
      var updatedContainer = new Object();
      updatedContainer.id = this.container.id;
      updatedContainer.x = x;
      updatedContainer.y = y;
      updatedContainer.w = w;
      updatedContainer.h = h;

      this.updateContainer(updatedContainer);
    },
    inRange(container, x, y) {
      return !(
        container.x > x + this.container.w ||
        container.x + container.w < x ||
        container.y > y + this.container.h ||
        container.y + container.h < y
      );
    },
    onDrag: function (x, y) {
      // this.container.x = x;
      // this.container.y = y;
      var id = this.container.id;
      var containers = this.resizableContainers.filter(function (container) {
        return container.id !== id;
      });
      for (var i = 0; i < containers.length; i++) {
        var container = containers[i];
        if (this.inRange(container, x, y)) {
          console.dir("Dragged In");
        }
      }
    },
    onDragstop: function (x, y) {
      var updatedContainer = new Object();
      updatedContainer.id = this.container.id;
      updatedContainer.x = x;
      updatedContainer.y = y;
      updatedContainer.w = this.container.w;
      updatedContainer.h = this.container.h;

      this.updateContainer(updatedContainer);
    },
    uuidv4() {
      return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, function (
        c
      ) {
        var r = (Math.random() * 16) | 0,
          v = c == "x" ? r : (r & 0x3) | 0x8;
        return v.toString(16);
      });
    },
    deleteContainer() {
      // destroy the vue listeners, etc
      this.removeContainer(this.id);

      this.$destroy();

      // remove the element from the DOM
      this.$el.parentNode.removeChild(this.$el);
    },
    ...mapActions("activeContainers", ["addContainer"]),
    ...mapActions("activeContainers", ["updateContainer"]),
    ...mapActions("activeContainers", ["removeContainer"]),
  },
};
</script>

<style lang="scss" scoped>
.close {
   position: absolute;
   z-index:10;
   right: 0;
   top: 0;
}
.drag-container {
  border: 1px solid black;
}
.component-content {
  position: relative;
  display: flex;
  overflow: hidden;
  height: 100%;
  width: 100%;
  right: 0px;
  top: 0;
}

</style>
