<template>
  <h3>Orodateur</h3>

  <h3>Date: {{ dateLabel }}</h3>

  <table>
    <template v-for="entry in data">
      <Entry :oroStamp="entry"></Entry>
    </template>
  </table>
</template>

<script setup lang="ts">

import IOroStamp from '@/models/IOroStamp';
import OroStamp from '@/models/Orostamp';
import { computed, ref, onMounted } from 'vue';
import Entry from './Entry.vue';

const API_URL = `api/entries`;

const props = defineProps<{
  date: Date
}>()

const data = ref<OroStamp[]>([]);

const dateLabel = computed(() => {
  return props.date.toLocaleDateString()
})

onMounted(async () => {
  data.value = await (await fetch(API_URL)).json().then(json => {
    console.log("data: ", json);
    const entries = json.map((e: IOroStamp) => new OroStamp(e));

    console.log("entries: ", entries);
    return entries;
  })
})


</script>