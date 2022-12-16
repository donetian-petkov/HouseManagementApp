import * as request from "./requester";

const eventAPI = 'https://localhost:7156/api/Event'

export const getAllEvents = () => request.get(`${eventAPI}/getAllEvents`,'', {});

export const addEvent = (eventToCreate) => {
    
    let jsonObject = eventToCreate.toJSON();
    
    let object = {
        id: jsonObject.id,
        title: jsonObject.title,
        start: jsonObject.start,
        end: jsonObject.end
        
    }

    return request.post(`${eventAPI}/addEvent`, object, {});
}