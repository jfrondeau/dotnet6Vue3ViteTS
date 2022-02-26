<template>
    <tr>
        <td>{{ entry.punchAt }}</td>
        <td>{{ entry.isIn ? "In" : "Out" }}</td>
    </tr>
</template>

<script setup lang="ts">

import { onMounted } from 'vue';

interface IOroStamp {
    entry: {
        id: number
        userId: number
        punchAt: Date
        isIn: Boolean
    }
}

const props = defineProps<IOroStamp>()

onMounted(() => {
    console.log("Date = ", props.entry.punchAt);
    console.log("Date = ", typeof (props.entry.punchAt));
});

function formatDate(d: Date) {
    console.log("Type de d:", typeof (d))
    return d?.toString().replace(/T|Z/g, ' ');
}
</script>