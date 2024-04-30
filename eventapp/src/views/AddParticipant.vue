<template>
  <div id="app">
    <header class="header2"></header>
    <main>
      <section class="blue-background-section">
        <div class="blue-background">
          <h2>Osavõtjad</h2>
        </div>
        <img class="sible-pic" src="/lible.jpg" alt="Sible Pic">
      </section>
      <div class="white-box-section">
        <div class="form-container">
          <h3 class="header3">Osavõtjad</h3>
          <div v-if="event" class="event-info-container">
            <!-- Display event information -->
            <div class="event-info">
              <strong class="label">Ürituse nimi:</strong>
              <div class="event-name">{{ event.name }}</div>
            </div>
            <div class="event-info">
              <strong class="label">Toimumisaeg:</strong>
              <div class="event-date">{{ formatDateTime(event.dateTime) }}</div>
            </div>
            <div class="event-info">
              <strong class="label">Koht:</strong>
              <div class="event-location">{{ event.location }}</div>
            </div>
          </div>
          <!-- Display participants -->
          <div v-if="participants.length > 0">
            <strong class="label">Osavõtjad:</strong>
            <div class="event-participants">
              <div v-for="(participant, index) in participants" :key="participant.id" class="participant-item">
                <div class="participant-info">
                  <span>{{ index + 1 }}. {{ participant.firstName }} {{ participant.lastName }} - {{ participant.personalCode }}</span>
                  <span>{{ participant.companyName }} - {{ participant.companyRegistrationCode }}</span>
                  <div class="participant-actions">
                    <router-link :to="'/participant-details/' + participant.participantId" class="nav-link">VAATA</router-link>
                    <div class="delete-text" @click="deleteParticipant(participant.id)">KUSTUTA</div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="white-box-section">
        <div class="form-container">
          <h3 class="form-heading">Osavõtjate lisamine</h3>
          <form class="participant-form">
            <div class="participant-type">
              <label>
                <input type="radio" v-model="participantType" value="individual"> Eraisik
              </label>
              <label>
                <input type="radio" v-model="participantType" value="company"> Ettevõte
              </label>
            </div>

            <div v-if="participantType === 'individual'">
              <div class="form-group">
                <label for="firstName">Eesnimi:</label>
                <input id="firstName" v-model="firstName" type="text" placeholder="">
              </div>
              <div class="form-group">
                <label for="lastName">Perekonnanimi:</label>
                <input id="lastName" v-model="lastName" type="text" placeholder="">
              </div>
              <div class="form-group">
                <label for="idNumber">Isikukood:</label>
                <input id="idNumber" v-model="idNumber" type="text" placeholder="">
              </div>
            </div>

            <div v-if="participantType === 'company'">
              <div class="form-group">
                <label for="companyName">Ettevõtte juriidiline nimi:</label>
                <input id="companyName" v-model="companyName" type="text" placeholder="">
              </div>
              <div class="form-group">
                <label for="companyRegCode">Ettevõtte registrikood:</label>
                <input id="companyRegCode" v-model="companyRegCode" type="text" placeholder="">
              </div>
              <div class="form-group">
                <label for="numParticipants">Ettevõttest tulevate osavõtjate arv:</label>
                <input id="numParticipants" v-model="numParticipants" type="number" placeholder="">
              </div>
            </div>

            <div class="form-group">
              <label for="paymentMethod">Osavõtumaksu maksmise viis:</label>
              <select id="paymentMethod" v-model="paymentMethod">
                <option value="bankTransfer">Pangaülekanne</option>
                <option value="cash">Sularaha</option>
              </select>
            </div>
            <div class="form-group">
              <label for="additionalInfo">Lisainfo:</label>
              <textarea id="additionalInfo" v-model="additionalInfo" placeholder=""></textarea>
            </div>
            <div class="button-container">
              <button class="back-button">Tagasi</button>
              <button type="submit" class="submit-button">Salvesta</button>
            </div>
          </form>
        </div>
      </div>
    </main>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  name: 'Osavõtjad',
  data() {
    return {
      event: {},
      participants: [],
      participantType: 'individual',
      firstName: '',
      lastName: '',
      idNumber: '',
      companyName: '',
      companyRegCode: '',
      numParticipants: '',
      paymentMethod: 'bankTransfer',
      additionalInfo: ''
    };
  },
  mounted() {
    const eventId = this.$route.params.eventId;
    console.log("Event ID:", eventId);
    this.fetchEvent(eventId);
    this.fetchParticipantsByEventId(eventId);
  },
  methods:{
    submitParticipant() {
      const data = {
        eventId: this.event.id,
        firstName: this.firstName,
        lastName: this.lastName,
        idNumber: this.idNumber,
        companyName: this.companyName,
        companyRegCode: this.companyRegCode,
        numParticipants: this.numParticipants,
        paymentMethod: this.paymentMethod,
        additionalInfo: this.additionalInfo
      };
    },
  fetchEvent(eventId) {
      axios.get(`http://localhost:7055/api/Events/${eventId}`)
        .then(response => {
          this.event = response.data;
        })
        .catch(error => {
          console.error('Error fetching event:', error);
        });
    },
    fetchParticipantsByEventId(eventId) {
  axios.get(`http://localhost:7055/api/participants/event/${eventId}`)
    .then(response => {
      this.participants = response.data;
      console.log("Participants:", this.participants); 
    })
    .catch(error => {
      console.error('Error fetching participants:', error);
    });
  },
  postParticipant(){
  axios.post('http://localhost:7055/api/Participants', data)
    .then(response => {
      console.log('Participant saved:', response.data);
    })
    .catch(error => {
      console.error('Error saving participant:', error);
    });
  },

    filterParticipants() {
      this.filteredParticipants = this.participants.filter(participant => participant.eventId === eventId);
    },
    formatDateTime(dateTime) {
      const date = new Date(dateTime);
      const hours = date.getHours();
      const minutes = date.getMinutes().toString().padStart(2, '0'); 

      return `${date.getDate()}.${date.getMonth() + 1}.${date.getFullYear()}`;
    },
  }
}

</script>

<style scoped>
.header2 {
  font-weight: normal;
}
.header3 {
  color: #005aa1;
  font-family: 'Open Sans', sans-serif;
  margin-left: 115px;
  font-weight: normal;
  font-size: 25px;
}

.blue-background-section {
  display: flex;
  align-items: center;
  height: 100px;
  margin-top: -30px;
  font-weight: normal;
}

.blue-background {
  background-color: #005aa1;
  font-family: 'Open Sans', sans-serif;
  font-size: 18px;
  color: white;
  text-align: center;
  height: 100px;
  width: 250px;
  margin-left: -50px;
  font-weight: normal !important;
}

.sible-pic {
  width: 850px;
  height: 100px;
}

.white-box-section {
  background-color: white;
  padding: 20px;
  margin-top: -20px;
}

.form-container {
  max-width: 500px;
  margin-left: 0px;
}

.form-heading {
  color: #005aa1;
  font-family: 'Open Sans', sans-serif;
  margin-left: 220px;
  font-weight: normal;
}

.participant-type {
  display: flex;

  margin-bottom: 15px;
  margin-left: 550px;
}

.participant-type label {
  margin: 0 10px;
}

label {
  display: block;
  margin-bottom: 5px;
  
}

input[type="text"],
select,
textarea {
  width: 100%;
  padding: 8px;
  margin-bottom: 15px;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}
.form-group {
  display: flex;

  margin-bottom: 15px;
}

.form-group label {
  width: 180px;
  margin-right: 10px;
}

.form-group input[type="text"],
.form-group select,
.form-group textarea {
  flex: 1;
}


button {
  padding: 10px 15px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  width: 100px;
}

.back-button {
  background-color: #ccc;
  color: black;
  margin-left: 250px;
}

.submit-button {
  background-color: #005aa1;
  color: white;
  margin-right: 300px;
}

.button-container {
  display: flex;
  justify-content: space-between;
}
.event-info {
  display: flex;
  margin-left: 250px;
  
}

.event-participants {
  margin-left: 350px;
  margin-top: 20px;
  text-align: left;
}

.event-info {
  display: flex;
  margin-bottom: 10px;
  text-align: left;
}

.label {
  font-weight: bold;
  color: #333;
  width: 120px; 
  
}

.event-name,
.event-date,
.event-location {
  color: #666;
  flex: 1; 
}

.participant-info {
  margin-bottom: 5px;
}

.participant-actions {
  display: flex;
  align-items: left;
}
.participant-item {
  display: flex;
  align-items: left;
  justify-content: space-between;
  margin-bottom: 10px;
}
.delete-text{
  margin-top: -20px;
  margin-left: 0px;
}
.nav-link{
  margin-left: 300px;
  margin-top: -20px;
}

</style>