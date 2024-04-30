import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import HomePage from '../views/Home.vue';
import EventForm from '../views/AddEvent.vue';
import AddParticipant from '../views/AddParticipant.vue';
import Participant from '../views/Participant.vue';
import ParticipantDetailsPage from '../views/ParticipantDetailsPage.vue';



const routes: Array<RouteRecordRaw> = [
    {
        path: '/',
        name: 'HomePage',
        component: HomePage,
    },
    {
        path: '/eventform',
        name: 'EventForm',
        component: EventForm,
    },
    {
        path: '/participants',
        name: 'Participants',
        component: Participant,
    },
    {
        path: '/participant-addition/:eventId',
        name: 'AddParticipant',
        component: AddParticipant,
    },
   
    {
        path: '/participant-details',
        name: 'ParticipantDetails',
        component: ParticipantDetailsPage,
        props: true,
    },
    {
        path: '/participant-details/:participantId',
        name: 'participant-details',
        component: ParticipantDetailsPage,
        props: true,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
