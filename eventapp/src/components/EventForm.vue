<template>
  <div id="app">
    <header class="header2"></header>
    <main>
      <section class="libled-section">
        <div class="blue-background">
          <h2>Ürituse lisamine</h2>
        </div>
        <img class="libled-image" src="/lible.jpg" alt="Libled Image">
      </section>

      <div class="white-box-section">
        <div class="form-container">
          <h3 class="form-heading">Ürituse lisamine</h3>
          <form class="event-form" @submit.prevent="submitEvent">
            <div class="form-group">
              <label for="eventName">Ürituse nimi:</label>
              <input type="text" id="eventName" name="eventName" v-model="formData.name">
            </div>
            <div class="form-group">
              <label for="eventTime">Toimumisaeg:</label>
              <input type="text" id="eventTime" name="eventTime" placeholder="pp.kk.aaaa hh:mm" v-model="formData.dateTime">
            </div>
            <div class="form-group">
              <label for="eventLocation">Koht:</label>
              <input type="text" id="eventLocation" name="eventLocation" v-model="formData.location">
            </div>
            <div class="form-group">
              <label for="eventInfo">Lisainfo:</label>
              <textarea id="eventInfo" name="eventInfo" rows="4" v-model="formData.additionalInfo"></textarea>
            </div>
            <div class="button-container">
              <button class="back-button">Tagasi</button>
              <button type="submit" class="submit-button">Lisa</button>
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
  data() {
    return {
      formData: {
        name: '', 
        dateTime: '',
        location: '',
        additionalInfo: ''
      }
    };
  },
  methods: {
    submitEvent() {
      const eventData = {
        event: {
          name: this.formData.name,
          dateTime: this.formData.dateTime,
          location: this.formData.location,
          additionalInfo: this.formData.additionalInfo
        }
      };

      axios.post('http://localhost:7055/api/Events', formData)
        .then(response => {
          console.log('Event saved:', response.data);
          this.clearForm();
        })
        .catch(error => {
          console.error('Error submitting event:', error);
        });
    },
    clearForm() {
      this.formData.name = '';
      this.formData.dateTime = '';
      this.formData.location = '';
      this.formData.additionalInfo = '';
    }
  }
};
</script>

<style>

.blue-box-section {
  margin-left: -52px;
  align-items: center;
  margin-top: -55px;
  font-weight: normal;
}
.blue-background h2 {
  font-weight: normal !important;
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

.libled-section {
  display: flex;
  align-items: center;
  height: 100px;
  width: 100%;
  margin-top: -30px;

}

.libled-image {
  width: 850px;
  height: 100px;
}

.white-box-section {
  background-color: white;
  margin-top: -20px;
  padding: 20px;
  margin-left: -50px;
}

.form-heading {
  color: #005aa1;
  font-family: 'Open Sans', sans-serif;
  margin-left: -380px;
  font-weight: normal;
  font-size: 26px;
}

.form-group {
  display: flex;

  margin-bottom: 20px;
  width: 600px;
  margin-left: 250px;
}

.form-group label {
  width: 180px;
  margin-right: -40px;
  text-align: left;
}

.form-group input,
.form-group textarea {
  flex: 1;
  padding: 8px;
  border: 1px solid #606060;
  border-radius: 4px;
}

.form-group textarea {
  height: 100px;
}

.button-container {
  text-align: center;
  margin-top: 10px;
}

.back-button {
  font-family: 'Open Sans', sans-serif;
  font-size: 20px;
  background-color: #ccc;
  color: rgb(0, 0, 0);
  padding: 10px 20px;
  border: none;
  cursor: pointer;
  margin-left: -350px;
  width: 100px;
  height: 40px;
}

.submit-button {
  background-color: #005aa1;
  font-family: 'Open Sans', sans-serif;
  font-size: 20px;
  color: white;
  padding: 10px 20px;
  border: none;
  cursor: pointer;
  margin-left: 10px;
  width: 100px;
  height: 40px;
}
</style>
