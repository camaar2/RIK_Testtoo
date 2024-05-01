<template>
  <div id="app">
    <header class="header2">
    </header>
    <main>
      <section class="blue-background-section">
        <div class="blue-background">
          <h2>Osavõtja info</h2>
        </div>
        <img class="sible-pic" src="/lible.jpg" alt="Sible Pic">
      </section>

      <div class="white-box-section">
        <div class="form-container">
          <h3 class="form-heading">Osavõtja info</h3>
          <form class="participant-form">
            <div class="form-group">
          <label for="firstName">Eesnimi:</label>
              <input id="firstName" v-model="participant.firstName" type="text" placeholder="">
          </div>
            <div class="form-group">
              <label for="lastNameOrCompanyName">Perenimi / Ettevõtte nimi:</label>
              <input id="lastNameOrCompanyName" v-model="participant.lastName" type="text" placeholder="">
            </div>
            <div class="form-group">
              <label for="idNumberOrRegCode">Isikukood / Registrikood:</label>
              <input id="idNumberOrRegCode" v-model="participant.personalCode" type="text" placeholder="">
            </div>
            <div class="form-group">
              <label for="paymentMethod">Maksmisviis:</label>
              <select id="paymentMethod" v-model="participant.paymentMethod">
                <option value="bankTransfer">Pangaülekanne</option>
                <option value="cash">Sularaha</option>
              </select>
            </div>
            <div class="form-group">
              <label for="additionalInfo">Lisainfo:</label>
              <textarea id="additionalInfo" v-model="participant.additionalInfo" placeholder=""></textarea>
            </div>
            <div class="button-container">
              <button class="back-button" @click="goBack">Tagasi</button>
              <button class="submit-button" @click="saveParticipant">Salvesta</button>
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
  name: '',
  data() {
    return {
      participant: {
        participantId: null,
        firstName: '',
        lastName: '',
        personalCode: '',
        paymentMethod: '',
        additionalInfo: '',
        companyName: '',
        companyRegistrationCode: '',
        numberOfParticipantsFromCompany: null,
        eventId: null,
        event: null
      }
    };
  },
  mounted() {
    const participantId = this.$route.params.participantId;
    console.log("Participant ID:", participantId);
    this.fetchParticipant(participantId);
  },
  methods: {
    fetchParticipant(participantId) {
      axios.get(`http://localhost:7055/api/Participants/${participantId}`)
          .then(response => {
            console.log('Response Data:', response.data);
            this.participant = response.data;
          })
          .catch(error => {
            console.error('Error fetching participant:', error);
          });
    },
    saveParticipant() {
      const participantId = this.participant.participantId;
      console.log("Participant ID:", participantId); // Log participantId
      console.log("Participant data:", this.participant); // Log participant data
      axios.put(`http://localhost:7055/api/Participants/${participantId}`, this.participant)
          .then(response => {
            console.log('Response Data:', response.data);
            this.participant = response.data;
            this.$router.push({ name: 'AddParticipant', params: { eventId }});
          })
          .catch(error => {
            console.error('Error updating participant:', error);
          });
    },
    goBack() {
      this.router.go(-4); 
    }
  }
};
</script>

<style scoped>
.header2 {
  font-weight: normal;
}

.blue-background-section {
  display: flex;
  align-items: center;
  height: 100px;
  margin-top: -30px;
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
  margin-left: 108px;
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
</style>