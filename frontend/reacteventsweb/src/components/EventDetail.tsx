import { Link, useParams } from "react-router-dom";
import { useFetchEvent } from "../hooks/EventsHooks";

const EventDetail = () => {
  const { id } = useParams();
  if (!id) throw Error("Event id not found");
  const eventId = parseInt(id);

  const { data, status, isSuccess } = useFetchEvent(eventId);

  if (!data) return <div>Event not found.</div>;

  return (
    <div className="row">
      <div className="col-8">
        <div className="row">
            <div className="row mt-2">
            <h3>{data.title}</h3>
            </div>
            <div className="row">
            <h5>{data.location}</h5>
            </div>
            <div className="row">
            <h5>{data.description}</h5>
            </div>
            <div className="row">
            <div>Start date: {new Intl.DateTimeFormat('en-US', {dateStyle: 'medium', timeStyle: 'medium'}).format(new Date(data.startDate))}</div>
            </div>
            <div className="row">
            <div>End date: {new Intl.DateTimeFormat('en-US', {dateStyle: 'medium', timeStyle: 'medium'}).format(new Date(data.endDate))}</div>
            </div>
        </div>
        <div className="row mt-4">
          <div className="col-1">
            <Link
              className="btn btn-primary"
              to={`/event/edit/${data.id}`}
            >
              Edit
            </Link>
          </div>
          <div className="col-3">
            <Link
              className="btn btn-warning"
              to={"/"}
            >
              Back to event list
            </Link>
          </div>
          <div className="col-6">
          </div>
        </div>
      </div>
    </div>
  );
};

export default EventDetail;
