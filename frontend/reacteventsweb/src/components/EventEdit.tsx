import { useParams } from "react-router-dom";
import { useFetchEvent, useUpdateEvent } from "../hooks/EventsHooks";
import EventForm from "./EventForm";

const EventEdit = () => {
  const { id } = useParams();
  if (!id) throw Error("Need a event id");
  const eventId = parseInt(id);

  const { data, status, isSuccess } = useFetchEvent(eventId);
  const updateEventMutation = useUpdateEvent();

  if (!isSuccess) throw Error("Event not found");

  return (
    <>
      <h3>Edit Event</h3>
      <EventForm
        event={data}
        submitted={(event) => {
            updateEventMutation.mutate(event);
        }}/>
    </>
  );
};

export default EventEdit;
