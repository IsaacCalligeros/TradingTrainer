<template>
  <div>
    <!--     
    <v-icon id="sunny" size="35">mdi-weather-sunny</v-icon>
    <v-icon size="35">mdi-weather-cloudy</v-icon>
    <v-icon size="35">mdi-weather-partly-cloudy</v-icon>
    <v-icon size="35">mdi-weather-night-partly-cloudy</v-icon>
    <v-icon size="35">mdi-weather-windy-variant</v-icon>
    <v-icon size="35">mdi-weather-windy</v-icon>-->
    <div v-if="!editMode">
      <p>{{city}} - {{Time}}</p>
      <div v-if="weatherDetails !== null">
        Temperature: {{weatherDetails.currentWeather.dayTempDetail.temp}}
        Max: {{weatherDetails.currentWeather.dayTempDetail.tempMax}}
        Min: {{weatherDetails.currentWeather.dayTempDetail.tempMin}}
        <v-icon id="sunny" size="35">mdi-weather-sunset-up</v-icon>
        <div>{{sunRiseTime}}</div>
        <v-icon size="35">mdi-weather-sunset-down</v-icon>
        <div>{{sunSetTime}}</div>
      </div>
    </div>

    <div v-if="editMode">
      <v-text-field label="City" v-model="city"></v-text-field>
      <button @click="getWeather">BUTTON</button>
    </div>
  </div>
</template>
<script>
import { mapState, mapActions, mapGetters } from "vuex";

export default {
  data: function () {
    return {
      city: "Adelaide",
      weatherDetails: null,
      celcius: true,
    };
  },
  created() {
    this.getWeather();
  },
  computed: {
    ...mapGetters(["editMode"]),
    sunRiseTime: function () {
      if (this.weatherDetails !== null) {
        return this.$helpers.getTime(
          this.weatherDetails.currentWeather.dayDetail.sunriseDate
        );
      }
      return undefined;
    },
    sunSetTime: function () {
      if (this.weatherDetails !== null) {
        return this.$helpers.getTime(
          this.weatherDetails.currentWeather.dayDetail.sunsetDate
        );
      }
      return undefined;
    },
    Time: function() {
      return this.$helpers.getTime(new Date());
    }
  },
  methods: {
    async getWeather() {
      const message = await this.$axios.$get(
        "http://localhost:5000/api/weather/GetWeather?city=" + this.city
      );
      this.weatherDetails = message;
      console.dir(this.weatherDetails);
    },
  },
};
</script>

<style lang="scss" scoped>
#sunny {
  color: yellow;
}
</style>