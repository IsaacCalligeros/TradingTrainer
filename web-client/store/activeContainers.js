const initState = () => ({
  resizableContainers: []
});

export const state = initState;

export const getters = {
  resizableContainers: state => state.resizableContainers
};

//mutations are functions, synchronous
export const mutations = {
  addContainer(state, container) {
    state.resizableContainers.push(container);
  },
  //Can't mutate state in the component itself and also need consistent sizings for all other components
  updateContainer(state, container) {
    for (var i in state.resizableContainers) {
      if (state.resizableContainers[i].id === container.id) {
        const w = state.resizableContainers[i].w;
        const h = state.resizableContainers[i].h;
        state.resizableContainers[i] = container;
        //This is so bizzare, the Dragstop event doesn't seem to pull back the h/w values for some reason.
        if (container.w === undefined) {
          state.resizableContainers[i].w = w;
        }
        if (container.h === undefined) {
          state.resizableContainers[i].h = h;
        }
      }
    }
  },
  removeContainer(state, id) {
    for (var i in state.resizableContainers) {
      if (state.resizableContainers[i].id === id) {
        state.resizableContainers = state.resizableContainers.splice(index, i);
      }
    }
  },
  reset(state) {
    Object.assign(state, initState());
  }
};

export const actions = {
  async addContainer({ commit }, container) {
    commit("addContainer", container);
  },
  async updateContainer({ commit }, container) {
    commit("updateContainer", container);
  },
  async removeContainer({ commit }, id) {
    commit("removeContainer", id);
  }
};
