<template>
  <div id="app">
    <header class="header">
      <div class="section" @click="setActive('/')">
        <img class="logo" src="/logo.svg" alt="Logo">
      </div>
      <div :class="{ 'active-section': activeRoute === '/' }" class="section" @click="setActive('/')">
        <router-link to="/" class="nav-link">AVALEHT</router-link>
      </div>
      <div :class="{ 'active-section': activeRoute === '/event-form' }" class="section" @click="setActive('/event-form')">
        <router-link to="/eventform" class="nav-link">ÜRITUSE LISAMINE</router-link>
      </div>
      <div class="section">
        <img class="symbol" src="/symbol.svg" alt="Symbol">
      </div>
    </header>
    <router-view></router-view>
    <footer class="footer">
      <div class="footer-section">
        <h3>Curabitur</h3>
        <p>Emauris</p>
        <p>Kfringilla</p>
        <p>Oin Magna sem</p>
        <p>Kelementum</p>
      </div>
      <div class="footer-section">
        <h3>Fusce</h3>
        <p>Econsectetur</p>
        <p>Ksollicitudin</p>
        <p>Omvulputate</p>
        <p>nunc fringilla tellu</p>
      </div>
      <div class="footer-section">
        <h3>Kontakt</h3>
        <p>peakontor: Tallinnas</p>
        <p>Väike-Ameerika 1, 11415 Tallinn</p>
        <p>Telefon: 6054450</p>
        <p>Faks: 6053186</p>
      </div>
      <div class="footer-section">
        <p>Harukontor: Võrus</p>
        <p>Oja tn 7 (külastusaadress)</p>
        <p>Telefon: 605 3330</p>
        <p>Faks: 605 3155</p>
      </div>
    </footer>
  </div>
</template>


<script>
export default {
  name: 'App',
  data() {
    return {
      activeRoute: null
    };
  },
  methods: {
    setActive(route) {
      this.activeRoute = route;
    }
  }
}
</script>

<style>

body {
  background-color: #eff2f4;
  margin: 0;
  font-family: 'Open Sans', sans-serif;
}
.active-link {
  background-color: #ffffff;
  color: white;
}
.active-section {
  background-color: #005aa1;
  color: white;
  height: 100px;
  display: flex;
  align-items: center;
  justify-content: center;

}
.section {
  flex: 1;
  text-align: center; 
  transition: background-color 0.3s, color 0.3s; 
}
.active-section .nav-link {
  font-weight: bold; 
  color: white; 
}

.header {
  background-color: white;
  padding: 0px;
  display: flex;

  align-items: center;
  width: 1100px;
  height: 100px;
}


.logo {
  max-width: 350px;
}

.symbol {
  max-width: 250px;
}

.nav-links {
  display: flex;
}

.nav-link {
  margin-right: 20px;
  color: black;
  font-family: 'Bebas Neue', sans-serif;
  font-size: 15px;
  display: flex;
  transition: background-color 0.3s;
  align-items: center;
  justify-content: center;
}

footer {
  background-color: #373737;
  color: #e0e0e0;
  padding: 15px;
  display: flex;
  justify-content: space-around;
  margin-top: -35px;
  width: 1072px;
}

.footer-section {
  flex: 1;
}

.footer-section h3 {
  color: white;
  font-size: 1.2rem;
  margin-bottom: 15px;
}

.footer-section p {
  margin: 0;
  line-height: 1.6;
}
</style>
