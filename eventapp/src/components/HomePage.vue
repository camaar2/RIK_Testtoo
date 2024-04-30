<template>
  <main>
    <div class="split-section">
      <div class="blue-background2">
        <p class="blue-text">
          Sed nec elit vestibulum, <span style="font-weight: bold;">tincidunt orci</span> et, sagittis ex. Vestibulum nutrum <span style="font-weight: bold;">neque suscipit</span> ante mattis maximus. Nulla non sapien <span style="font-weight: bold;">viverra, lobortis lorem non</span>, accumsan metus.
        </p>
      </div>
      <img class="image" src="/pilt.jpg" alt="Image">
    </div>
    <div class="split-section-container">
      <div class="split-section">
        <div class="header-box">
          <div class="event-heading">
            <h2>Tulevased üritused</h2>
          </div>
          <div class="issues-container">
            <div v-for="(event, index) in futureEvents" :key="event.eventId" class="event-item">
              <div class="event-info">
                <div class="event-name">{{ index + 1 }}. {{ event.name }} {{ formatDateTime(event.dateTime)}}</div>
                <div class="event-details">
                  <div class="event-actions">
                    <router-link :to="{ name: 'AddParticipant', params: { eventId: event.eventId }}" class="nav-link">OSAVÕTJAD</router-link>

                    <img class="remove-icon" src="/remove.svg" alt="Remove" @click="removeEvent(event.eventId)">
                  </div>
                </div>
              </div>
            </div>
            <div class="add-event-box">
              <router-link :to="'/eventform/'" class="nav-link">LISA ÜRITUS</router-link>
            </div>
          </div>
        </div>
      </div>

      <div class="split-section">
        <div class="header-box2">
          <div class="event-heading2">
            <h21>Toimunud üritused</h21>
          </div>
          <div class="scrollable-container">
            <div v-for="(event, index) in pastEvents" :key="event.eventId" class="event-item">
              <div class="event-info">
                <div class="event-name">{{ index + 1 }}. {{ event.name }} {{ formatDateTime(event.dateTime)}}</div>
                <div class="event-details">
                  <div class="event-actions">
                    <router-link :to="'/participant-addition/' + event.eventId" class="nav-link">OSAVÕTJAD</router-link>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </main>
</template>


<script>
import Participant from '@/views/Participant.vue';
import axios from 'axios';

export default {
  data() {
    return {
      events: [],
      event: {
        name: '',
        datetime: ''
      }
    };
  },
  computed: {
    futureEvents() {
      return this.events.filter(event => new Date(event.dateTime) > new Date());
    },
    pastEvents() {
      return this.events.filter(event => new Date(event.dateTime) <= new Date());
    }
  },
  methods: {
    submitEvent() {
      axios.post('http://localhost:7055/api/Events', this.event)
        .then(response => {
          this.events.push(response.data);
          this.event.name = '';
          this.event.datetime = ''; 
          this.event.location = ''; 
          this.event.additionalInfo = ''; 
        })
        .catch(error => {
          console.error('Error submitting event:', error);
        });
    },
    fetchEvents() {
      axios.get('http://localhost:7055/api/events')
        .then(response => {
          this.events = response.data;
        })
        .catch(error => {
          console.error('Error fetching events:', error);
        });
    },
    fetchParticipant() {
      axios.get('http://localhost:7055/api/Participants/{id}')
        .then(response => {
          this.participant = response.data;
        })
        .catch(error => {
          console.error('Error fetching participants:', error);
        });
    },
    removeEvent(eventId) {
    axios.delete(`http://localhost:7055/api/events/${eventId}`)
      .then(response => {
        const index = this.events.findIndex(event => event.eventId === eventId);
        if (index !== -1) {
          this.events.splice(index, 1);
        }
      })
      .catch(error => {
        console.error('Error removing event:', error);
      });
  },
    formatDateTime(dateTime) {
      const date = new Date(dateTime);
      const hours = date.getHours();
      const minutes = date.getMinutes().toString().padStart(2, '0'); 

      return `${date.getDate()}.${date.getMonth() + 1}.${date.getFullYear()}`;
    },

    formatDate(date) {
      const formattedDate = new Date(date);
      const day = String(formattedDate.getDate()).padStart(2, '0');
      const month = String(formattedDate.getMonth() + 1).padStart(2, '0');
      const year = formattedDate.getFullYear();

      return `${day}.${month}.${year}`;
    },
  },
  mounted() {
    this.fetchEvents();
  }
};

</script>

<style>

.event-list {
  margin-top: 10px;
}
.split-section-container {
  display: flex;
  justify-content: space-between;
}

.event-item {
  margin-bottom: 10px;
}

.event-item button {
  margin-right: 10px;
}
main {
  padding: 20px;
}

.blue-text {
  margin: 0;
  text-align: left;
  font-size: 20px;
  margin-top: 65px;
}

.split-section {
  display: flex;
  justify-content: space-between;
  align-items: flex-start;
  margin-bottom: 20px;
}

.blue-background2 {
  background-color: #005aa1;
  padding: 20px;
  color: white;
  width: 510px;
  margin-left: -20px;
  height: 253px;
}

.image {
  width: 100%;
  height: auto;
  margin-right: 24px;
}

.text {
  flex: 1;
  padding: 20px;
  font-weight: normal;
}

.text h2 {
  margin: 0;
  font-weight: normal;
}
.event-heading h2 {
  font-weight: normal;
}

.text strong {
  font-weight: bold;
}

.image {
  width: 550px;

}
.issues-container {
  height: 250px;
  overflow-y: auto;
  border: 1px solid #ccc;
  padding: 10px;
  text-align: left;
  width: 510px;
  margin-left: -20px;
}
.scrollable-container {
  height: 250px;
  overflow-y: auto;
  border: 1px solid #ccc;
  padding: 10px;
  text-align: left;
  width: 519px;
  margin-left: -19px;
}

.event-heading {
  background-color: #005aa1;
  color: white;
  padding: 10px;
  margin-bottom: 10px;
  font-weight: normal;
  margin-left: -20px;
  max-width: 543px;
}
.event-heading2 {
  background-color: #005aa1;
  color: white;
  height: 35.5px;
  padding: 10px;
  font-weight: normal;
  margin-left: -20px;
  max-width: 543px;
  text-align: center;
  font-size: 23px;
  margin-bottom: 10px;
}


.add-event-text {
  cursor: pointer;
  color: #555;
  font-size: 16px;
  font-weight: bold;
  margin-top: 0px;
}
.add-event-box {
  display: flex;

}
.add-event-text:hover {
  text-decoration: underline;
}
.link-text {
  cursor: pointer;
  color: #555;
  font-size: 16px;
  font-weight: bold;
}
.link-text:hover {
  text-decoration: underline;
}
.remove-icon {
  width: 20px;
  height: 20px;
  cursor: pointer;
}
.event-date {
  margin-right: 10px;
}
.event-heading h2 {
  margin: 0;
}

.event-name,
.event-date,
.event-actions {
  flex: 1;
}
.event-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 10px;
}
.event-info {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
}
.event-name {
  margin-right: 10px;
}
.header-box {
  flex: 1;
  
  width: 510px;

}
.header-box2 {
  flex: 1;
  margin-right: 27px;
  width: 520px;

}
.event-actions {
  display: flex; 
  align-items: center; 
}

.event-actions .nav-link {
  margin-right: 10px; 
}


</style>