import * as request from "./requester";

const eventAPI = 'https://localhost:7156/api/Event'

export const getAllEvents = () => request.get(`${eventAPI}/getAllEvents`,'', {});

export const addEvent = (eventToCreate) => {

    return request.post(`${eventAPI}/addEvent`, eventToCreate, {});
}