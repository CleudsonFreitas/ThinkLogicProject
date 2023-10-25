import { useAddEvent } from "../hooks/EventsHooks";
import { Event } from "../types/event";
import EventForm from "./EventForm";

const EventAdd = () => {
  const addEventMutation = useAddEvent();

  const event: Event = {
    title: "",
    location: "",
    description: "",
    id: 0,
    endDate: "",
    startDate: ""   
  };

  return (
    <>
        <h3>Add Event</h3>
      <EventForm
        event={event}
        submitted={(event) => addEventMutation.mutate(event)}
      />
    </>
  );
};

export default EventAdd;
