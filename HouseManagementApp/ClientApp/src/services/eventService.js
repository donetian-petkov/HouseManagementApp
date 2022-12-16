import * as request from "./requester";

const eventAPI = 'https://localhost:7156/api/Event'

export const getAllEvents = () => request.get(`${eventAPI}/`,'', {});