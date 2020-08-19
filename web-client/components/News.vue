<template>
  <div>
    <div v-if="editMode">
      <v-row>
        <v-col cols="6">
          Select your news Source:
          <v-list>
            <v-row align="center" justify="center" class="my-0">
              <v-col class="py-0" cols="4">
                <v-subheader>Sources:</v-subheader>
              </v-col>
              <v-col cols="8" class="py-0">
                <v-text-field v-model="selectedSource" rounded label="filter"></v-text-field>
              </v-col>
            </v-row>
            <div class="news-sources">
              <v-list-item-group color="primary">
                <v-list-item
                  v-for="(item, i) in allSources"
                  :key="i"
                  @click="selectedSource = item.name"
                >
                  <v-list-item-content>
                    <v-list-item-title v-html="item.name"></v-list-item-title>
                  </v-list-item-content>
                </v-list-item>
              </v-list-item-group>
            </div>
          </v-list>
        </v-col>

        <v-col cols="6">
          <v-list v-if="selectedSource === allSources.newsApi.name">
            <v-row align="center" justify="center" class="my-0">
              <v-col class="py-0" cols="4">
                <v-subheader>Sources:</v-subheader>
              </v-col>
              <v-col cols="8" class="py-0">
                <v-text-field v-model="allSources.newsApi.sourcesFilter" rounded label="filter"></v-text-field>
              </v-col>
            </v-row>
            <div class="news-sources">
              <v-list-item-group color="primary">
                <v-list-item
                  v-for="(item, i) in filteredSources"
                  :key="i"
                  @click="selectSource(item)"
                >
                  <v-list-item-content>
                    <v-list-item-title v-html="item.name"></v-list-item-title>
                    <v-list-item-subtitle v-html="item.country"></v-list-item-subtitle>
                  </v-list-item-content>
                </v-list-item>
              </v-list-item-group>
            </div>
          </v-list>
        </v-col>
      </v-row>
    </div>
    <v-flex v-else>
      <!-- General News - News Api -->

      <div class="ml-2 mt-2" v-if="selectedSource === allSources.newsApi.name">
        <v-text-field
          v-model="allSources.newsApi.searchQuery"
          solo
          rounded
          label="Search"
          v-on:keyup.enter="getNews"
          class="search"
        ></v-text-field>
        <div class="news-stories">
          <v-list two-line>
            <v-list-item-group>
              <template v-for="(item, index) in allSources.newsApi.newsStories">
                <v-list-item :key="index" @click="newsStorySelected(item)">
                  <v-list-item-content>
                    <v-list-item-title v-text="item.title + ' - ' + item.source.name"></v-list-item-title>
                    <v-list-item-subtitle class="text--primary" v-text="getHeadlineDisplay(item)"></v-list-item-subtitle>
                  </v-list-item-content>
                </v-list-item>

                <v-divider v-if="index + 1 < allSources.newsApi.length" :key="'divider' + index"></v-divider>
              </template>
            </v-list-item-group>
          </v-list>
        </div>
      </div>

      <!-- Hacker News -->

      <div v-if="selectedSource === allSources.hackerNews.name">
        <v-btn @click="getHackerNewsStories">YeetHacker</v-btn>
        <v-row align="center">
          <v-col cols="12">
            <div class="ml-2 mt-2">
              <div class="news-stories">
                <v-list two-line>
                  <v-list-item-group>
                    <template v-for="(item, index) in allSources.hackerNews.stories">
                      <v-list-item :key="index" @click="newsStorySelected(item)">
                        <v-list-item-content>
                          <v-list-item-title v-text="item.title"></v-list-item-title>
                        </v-list-item-content>
                      </v-list-item>

                      <v-divider
                        v-if="index + 1 < allSources.hackerNews.length"
                        :key="'divider' + index"
                      ></v-divider>
                    </template>
                  </v-list-item-group>
                </v-list>
              </div>
            </div>
          </v-col>
        </v-row>
      </div>
    </v-flex>
  </div>
</template>
<script>
import { mapState, mapActions, mapGetters } from "vuex";

export default {
  data: function () {
    return {
      selectedSource: "Hacker News",
      allSources: {
        newsApi: {
          name: "General news",
          country: "",
          category: "",
          sources: undefined,
          searchQuery: "",
          selectedSources: [],
          sourcesFilter: "",
          newsStories: undefined,
        },
        hackerNews: {
          name: "Hacker News",
          currentPage: 0,
          pageSize: 5,
          stories: undefined,
        },
      },
    };
  },
  created() {
    this.getSources();
  },
  mounted() {},
  computed: {
    ...mapGetters(["editMode"]),
    filteredSources() {
      if (this.allSources.newsApi.sources !== undefined) {
        return this.allSources.newsApi.sources.filter((i) => {
          if (this.searchQuery === "") {
            return true;
          }
          return i.name
            .toLowerCase()
            .includes(this.allSources.newsApi.sourcesFilter.toLowerCase());
        });
      }
      return undefined;
    },
  },
  methods: {
    async getSources() {
      const data = await this.$axios.$get(
        "https://newsapi.org/v2/sources?apiKey="
      );
      console.dir(data);
      this.allSources.newsApi.sources = data.sources;
    },
    async getNews() {
      const newsStories = await this.$axios.$get(
        "https://newsapi.org/v2/top-headlines?q=" +
          this.allSources.newsApi.searchQuery +
          "&apiKey="
      );
      this.allSources.newsApi.newsStories = newsStories.articles;
    },
    selectSource(item) {
      this.allSources.newsApi.selectedSources.push(item);
    },
    getHeadlineDisplay(item) {
      var returnString = "";

      if (
        item.author === null ||
        item.source.name.toLowerCase() !== item.author.toLowerCase()
      ) {
        returnString += item.source.name;
      }
      if (item.url !== "") {
        if (returnString !== "") {
          returnString += " - ";
        }
        returnString += item.url.split("/")[2];
      }
      return returnString;
    },
    newsStorySelected(item) {
      var win = window.open(item.url, "_blank");
      win.focus();
    },
    async getHackerNewsStories() {
      const topStories = await this.$axios.$get(
        "https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty"
      );
      console.dir(topStories);
      var stories = [];
      for (
        var i =
          this.allSources.hackerNews.currentPage *
          this.allSources.hackerNews.pageSize;
        i <
        this.allSources.hackerNews.currentPage *
          this.allSources.hackerNews.pageSize +
          5;
        i++
      ) {
        stories.push(await this.getHackerNewsStoryById(topStories[i]));
      }
      console.dir(stories);
      this.allSources.hackerNews.currentPage += 1;
    },
    async getHackerNewsStoryById(id) {
      const story = await this.$axios.$get(
        "https://hacker-news.firebaseio.com/v0/item/" +
          id +
          ".json?print=pretty"
      );
      return story;
    },
  },
};
</script>

<style lang="scss" scoped>
.search {
  max-width: 70%;
}
.news-sources {
  overflow-y: scroll;
  height: 150px;
  width: 200px;
  border: 1px solid black;
  margin-left: 10px;
  overflow: auto;
}
.news-stories {
  overflow-y: auto;
  max-height: 300px;
}
</style>
