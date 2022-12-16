import dayGridPlugin from "@fullcalendar/daygrid";
import timeGridPlugin from "@fullcalendar/timegrid";
import interactionPlugin from "@fullcalendar/interaction";
import {createEventId, INITIAL_EVENTS} from "./event-utils";
import FullCalendar from "@fullcalendar/react";
import React, {useEffect, useState} from "react";
import * as eventService from '../../services/eventService';



const Calendar = () => {

   const [events, setEvents] = useState([]);

   useEffect(() => {

       eventService.getAllEvents()
           .then(events => setEvents(events));

   },[])



   const handleEvents = (events) => {

       setEvents(events);

    }

    const handleDateSelect = (selectInfo) => {
        let title = prompt('Please enter a new title for your event')
        let calendarApi = selectInfo.view.calendar

        calendarApi.unselect() // clear date selection

        if (title) {
            calendarApi.addEvent({
                id: createEventId(),
                title,
                start: selectInfo.startStr,
                end: selectInfo.endStr,
                AllDay: true
            })
        }
    }

    const handleEventClick = (clickInfo) => {
        if (window.confirm(`Are you sure you want to delete the event '${clickInfo.event.title}'`)) {
            clickInfo.event.remove()
        }
    }

    function renderEventContent(eventInfo) {
        return (
            <>
                <b>{eventInfo.timeText}</b>
                <i>{eventInfo.event.title}</i>
            </>
        )
    }

    const eventAddHandler = (eventToBeCreated) => {

       eventService.addEvent(eventToBeCreated["event"])
           .then(result => {
               console.log(result);
           })
           .catch((error) => {
               console.log(error);
           });


    }

    return (
        <FullCalendar
            plugins={[dayGridPlugin, timeGridPlugin, interactionPlugin]}
            headerToolbar={{
                left: 'prev,next today',
                center: 'title',
                right: 'dayGridMonth,timeGridWeek,timeGridDay'
            }}
            initialView='dayGridMonth'
            height={900}
            editable={true}
            selectable={true}
            selectMirror={true}
            dayMaxEvents={true}
            weekends={true}
            initialEvents={events} // alternatively, use the `events` setting to fetch from a feed
            select={handleDateSelect}
            eventContent={renderEventContent} // custom render function
            eventClick={handleEventClick}
            eventsSet={handleEvents} // called after events are initialized/added/changed/removed
            eventAdd={eventAddHandler}
            /* you can update a remote database when these fire:

            eventChange={function(){}}
            eventRemove={function(){}}
            */
        />
    )

}

export default Calendar;