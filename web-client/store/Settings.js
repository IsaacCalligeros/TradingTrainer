const initState = () => ({
  colorMode: "Dark"
});

export const state = initState;

export const getters = {
  colorMode: state => state.colorMode
};

//mutations are functions, synchronous
export const mutations = {
  reset(state) {
    Object.assign(state, initState());
  }
};

//async operations
//nuxtServerInit on only initial pre render
//use fetch and map actions if needed everytime landing on page.
export const actions = {};
