<script setup lang="ts">
import { onMounted, ref } from "vue"

const API_URL = `weatherforecast`;

defineProps<{
  msg: string
}>()

const data = ref(null)

onMounted(async () => {
  data.value = await (await fetch(API_URL)).json()

  console.log("Component created")
  console.log("data fetched: ", data.value)
});
</script>

<template>
  <div class="greetings">
    <h1 class="green">{{ msg }}</h1>
    <h3>
      You’ve successfully created a project with
      <a target="_blank" href="https://vitejs.dev/">Vite</a> +
      <a target="_blank" href="https://v3.vuejs.org/">Vue 3</a>. What's next?
    </h3>
  </div>
</template>

<style scoped>
h1 {
  font-weight: 500;
  font-size: 2.6rem;
  top: -10px;
}

h3 {
  font-size: 1.2rem;
}

.greetings h1,
.greetings h3 {
  text-align: center;
}

@media (min-width: 1024px) {
  .greetings h1,
  .greetings h3 {
    text-align: left;
  }
}
</style>
