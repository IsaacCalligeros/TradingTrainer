import Vue from "vue";

export function getTime(dateText) {
    var date = new Date(dateText);
    var minutes = date.getMinutes();
    var hours = date.getHours();
    if(minutes < 10) { 
      minutes = '0' + minutes;
    }
    if(hours < 10)
    {
        hours = '0' + hours;
    }
    var timeText = hours + ':' + minutes;
    return tConvert(timeText);
}

function tConvert (time) {
    console.dir(time);
    // Check correct time format and split into components
    time = time.toString ().match (/^([01]\d|2[0-3])(:)([0-5]\d)(:[0-5]\d)?$/) || [time];
  
    if (time.length > 1) { // If time format correct
      time = time.slice (1);  // Remove full string match value
      time[5] = +time[0] < 12 ? ' AM' : ' PM'; // Set AM/PM
      time[0] = +time[0] % 12 || 12; // Adjust hours
    }
    return time.join (''); // return adjusted time or original string
  }

const helpers = { getTime }

export default helpers;

Vue.prototype.$helpers = helpers;