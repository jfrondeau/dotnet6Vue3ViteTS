<template>
  <h3>Orodateur</h3>

  <h3>Date du jour: {{ dateLabel }}</h3>

  <table>
    <template v-for="entry in entries" :key="entry.id">
      <Entry :entry="entry"></Entry>
    </template>
  </table>

  <button type="button" @click="punchIn">Punch in!</button>
</template>

<script setup lang="ts">

import IOroStamp from '@/models/IOroStamp';
import { computed, ref, onMounted } from 'vue';
import Entry from './Entry.vue';
import axios from 'axios';
import OroStamp from '@/models/Orostamp';

const API_URL = `api/entries`;

const props = defineProps<{
  date: Date
}>()

const entries = ref<IOroStamp[]>([]);

const dateLabel = computed(() => {
  return props.date.toLocaleDateString()
})

onMounted(async () => {
  try {
    var response: any = await axios.get(API_URL);
    debugger;
    if (response.headers['content-type'].toString().includes('json') === true) {
      console.log("response is ok");
      entries.value = response.data;
      return;
    }

    console.log("response is not ok ", response);
  }
  catch (error) {
    console.log("Error: ", error)
  }
})

async function punchIn() {
  const stamp = new OroStamp();
  stamp.userId = 1;
  try {
    let response = await axios.post(API_URL, stamp);

    console.log("Post response: ", response);
  }
  catch (error) {
    console.log("Error: ", error)
  }
}

</script>