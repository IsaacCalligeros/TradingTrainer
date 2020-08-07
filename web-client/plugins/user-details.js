import Vue from "vue";

export function getLocale() {
  var language;
  if (window.navigator.languages) {
    language = window.navigator.languages[0];
  } else {
    language = window.navigator.userLanguage || window.navigator.language;
  }
  return language;
}

const userDetails = { getLocale }

export default userDetails;

Vue.use(userDetails);

Vue.prototype.$userDetails = userDetails;