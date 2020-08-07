<template>
  <client-only>
    <vue-draggable-resizable
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
      <p>
        <component v-bind:is=control />
      </p>
    </vue-draggable-resizable>
  </client-only>
</template>

<script>
import { mapState, mapActions, mapGetters } from "vuex";
import Weather from "./Weather";
import Stocks from "./Stocks";

export default {
  props: ["sizeLoc", "control"],
  components: {
    Weather,
    Stocks
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
          console.dir("hello");
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
    ...mapActions("activeContainers", ["addContainer"]),
    ...mapActions("activeContainers", ["updateContainer"]),
  },
};
</script>
