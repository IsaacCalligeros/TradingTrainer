const initState = () => ({
    message: "initial"
})

export const state = initState

//mutations are functions, synchronous
export const mutations = {
    setMessage(state, message) {
        state.message = message;
    },
    reset(state){
        Object.assign(state, initState())
    }
}

//async operations 
//nuxtServerInit on only initial pre render
//use fetch and map actions if needed everytime landing on page.
export const actions = {
    async nuxtServerInit({commit}){
        const message = (await this.$axios.$get("http://localhost:5000/api/home"));
        console.log(message);
        commit("setMessage", message)
    }
}