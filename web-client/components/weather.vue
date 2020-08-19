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
      <Loading v-if="isLoading"></Loading>
      <div v-if="!isLoading">
        <h3>{{city}} - {{Time}}</h3>
        <div v-if="weatherDetails !== null">
          {{weatherDetails.currentWeather.weather[0].description}}
          <div class="temperature-details">
            <v-row>
              <v-col
                cols="7"
                class="mp-0"
              >Temperature: {{weatherDetails.currentWeather.dayTempDetail.temp}}</v-col>
              <v-col cols="5" class="mp-0">
                <div class="mp-0">High: {{weatherDetails.currentWeather.dayTempDetail.tempMax}}</div>
                <div class="mp-0">Low: {{weatherDetails.currentWeather.dayTempDetail.tempMin}}</div>
              </v-col>
            </v-row>
          </div>
          <v-icon id="sunny" size="35">mdi-weather-sunset-up</v-icon>
          <div>{{sunRiseTime}}</div>
          <v-icon size="35">mdi-weather-sunset-down</v-icon>
          <div>{{sunSetTime}}</div>
        </div>
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
      isLoading: true,
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
    Time: function () {
      return this.$helpers.getTime(new Date());
    },
  },
  methods: {
    async getWeather() {
      const message = await this.$axios.$get(
        "http://localhost:5000/api/weather/GetWeather?city=" + this.city
      );
      this.weatherDetails = message;
      this.isLoading = false;
    },
  },
};
</script>

<style lang="scss" scoped>
#sunny {
  color: yellow;
}
.temperature-details {
  color: #878787 !important;
}
</style>