<template>
  <div>
    <v-list id="components-list">
      <v-list-item v-for="item in ComponentsList" :key="item.componentName">
        <div class="col-6">{{ item.componentName }}</div>
        <div class="2">
          <v-btn color="success" @click="addComponent(item)">
            <v-icon id="sunny" size="35">mdi-plus</v-icon>
          </v-btn>
        </div>
      </v-list-item>
    </v-list>
  </div>
</template>

<script>
import { mapState, mapActions, mapGetters } from "vuex";

import Financials from "./Financials";
import Weather from "./Weather";
import Search from "./Search";
import News from "./News";

import dragContainer from "./drag-container";
import Vue from "vue";
import idMixin from "../mixins/idMixin";
import dynamicSort from "../mixins/dynamicSort";
import findRectangleSpace from "../mixins/findRectangleSpace";

export default {
  data: function () {
    return {
      defaultContainer: {
        x: 0,
        y: 0,
        w: 300,
        h: 200,
      },
      ComponentsList: [
        { componentName: "Financials", componentType: Financials },
        { componentName: "Weather", componentType: Weather },
        { componentName: "Search", componentType: Search },
        { componentName: "News", componentType: News }
      ],
    };
  },
  mixins: [idMixin, dynamicSort],
  created() {},
  computed: {
    ...mapGetters("activeContainers", ["resizableContainers"]),
    ...mapGetters(["editMode"]),
  },
  methods: {
    async getStockData() {},
    async addComponent(componentsItem) {
      var ComponentClass = Vue.component("newFinancials", dragContainer);
      var homeScreen = document.getElementById("dragContainer");

      var screenSize = {
        height: homeScreen.clientHeight,
        width: homeScreen.clientWidth,
      };

      var containersClone = JSON.parse(
        JSON.stringify(this.resizableContainers)
      );

      // var freeSpace = findRectangleSpace.methods.start(
      //   screenSize,
      //   containersClone
      // );
      // this.defaultContainer.x = freeSpace[0];
      // this.defaultContainer.y = freeSpace[1];
      // console.dir(freeSpace);

      var instance = new ComponentClass({
        parent: this,
        propsData: {
          sizeLoc: this.defaultContainer,
          control: componentsItem.componentName,
        },
      });

      var componentContainer = document.getElementById("dragContainer");
      var dummyElement = document.createElement("newComponent");
      dummyElement.setAttribute("id", "newComponent");
      componentContainer.appendChild(dummyElement);
      instance.$mount("#newComponent");
    },
  },
};
</script>

