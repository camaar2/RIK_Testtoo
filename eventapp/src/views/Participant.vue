<template>
  <div>
    <h2>Participant List</h2>
    <ul>
      <li v-for="participant in participants" :key="participant.id">
        <span>{{ participant.firstName }} {{ participant.lastName }}</span>
        <span>{{ participant.idNumber }}</span>
        <button @click="deleteParticipant(participant.id)">Delete</button>
      </li>
    </ul>
    <router-link to="/">Back to Homepage</router-link>
  </div>
</template>

<script>
export default {
  data() {
    return {
      participants: []
    };
  },
  methods: {
    deleteParticipant(participantId) {

    }
  }
}
</script>