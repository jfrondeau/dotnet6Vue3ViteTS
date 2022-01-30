<template>
    <tr>
        <td>{{ oroStamp.punchAt }}</td>
        <td>{{ oroStamp.isIn }}</td>
    </tr>
</template>

<script setup lang="ts">
import OroStamp from '@/models/Orostamp';

const props = defineProps<{
    oroStamp: OroStamp
}>()
</script>