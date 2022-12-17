import * as request from "./requester";

const eventAPI = 'https://localhost:7156/api/Event'

export const getAll = () => request.get(`${eventAPI}/getAll`,'', {});

export const add = (eventToCreate) => {
    
    let jsonObject = eventToCreate.toJSON();
    
    let object = {
        id: jsonObject.id,
        title: jsonObject.title,
        start: jsonObject.start,
        end: jsonObject.end
        
    }

    return request.post(`${eventAPI}/add`, object, {});
}

export const deleteById = (id) => request.del(`${eventAPI}/deleteById?eventId=${id}`);