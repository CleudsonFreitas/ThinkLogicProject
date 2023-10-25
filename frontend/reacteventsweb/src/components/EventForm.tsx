import React, { useState } from "react";
import { Event } from "../types/event";
import { Link } from "react-router-dom";

type Args = {
  event: Event;
  submitted: (event: Event) => void;
};

const EventForm = ({ event, submitted }: Args) => {
  const [eventState, setEventState] = useState({ ...event });

  const onSubmit: React.MouseEventHandler<HTMLButtonElement> = async (e) => {
    e.preventDefault();
    submitted(eventState);
  };

  return (
    <form className="mt-2">
      <div className="form-group">
        <label htmlFor="title">Title</label>
        <input
          type="text"
          className="form-control"
          placeholder="Title"
          value={eventState.title}
          onChange={(e) =>
            setEventState({ ...eventState, title: e.target.value })
          }
        />
      </div>
      <div className="form-group mt-2">
        <label htmlFor="location">Location</label>
        <input
          type="text"
          className="form-control"
          placeholder="Location"
          value={eventState.location}
          onChange={(e) =>
            setEventState({ ...eventState, location: e.target.value })
          }
        />
      </div>
      <div className="form-group mt-2">
        <label htmlFor="description">Description</label>
        <textarea
          className="form-control"
          placeholder="Description"
          value={eventState.description}
          onChange={(e) =>
            setEventState({ ...eventState, description: e.target.value })
          }
        />
      </div>
      <div className="form-group mt-2">
        <label htmlFor="startDate">Start Date</label>
        <input
          type="text"
          className="form-control"
          placeholder="Start Date"
          value={eventState.startDate}
          onChange={(e) =>
            setEventState({ ...eventState, startDate: e.target.value })
          }
        />
      </div>
      <div className="form-group mt-2">
        <label htmlFor="endDate">End Date</label>
        <input
          type="text"
          className="form-control"
          placeholder="End Date"
          value={eventState.endDate}
          onChange={(e) =>
            setEventState({ ...eventState, endDate: e.target.value })
          }
        />
      </div>
      <div className="row">
        <div className="col-1">
            <button
                className="btn btn-primary mt-3"
                disabled={!eventState.startDate || !eventState.endDate}
                onClick={onSubmit}
            >
                Submit
            </button>
        </div>
        <div className="col-1">
            <Link
            className="btn btn-warning mt-3"
            to={"/"}>
            Cancel
            </Link>
        </div>
      </div>
    </form>
  );
};

export default EventForm;
