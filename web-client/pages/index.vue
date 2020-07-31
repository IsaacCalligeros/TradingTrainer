<template>
  <v-layout column justify-center align-center>
    <v-flex xs12 sm8 md6>
      Hello
    </v-flex>
  </v-layout>
</template>

<script>
import Axios from "axios";
import { mapState, mapActions, mapMutations } from "vuex";

export default {
  components: {

  },
  data: () => ({
    //message: ""
  }),
  computed: mapState({
    message: state => state.message
  }),
  methods: mapMutations(["reset"]),
  // async fetch (){
  //   await this.$store.dispatch('fetchMessage');
  //  },
  // asyncData(payload) {
  //   //Server side function in nuxt
  //   return Axios.get("http://localhost:5000/api/home")
  //   .then(({data}) => {
  //     return { message: data }
  //   })
  // },
  created() {}
};
</script>
