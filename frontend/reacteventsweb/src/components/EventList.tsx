import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import { useFetchEvents } from "../hooks/EventsHooks";
import { Event } from "../types/event";

type Args = {
    date: string;
  };

const EventList = ({date}:Args) => {
    const nav = useNavigate();
    const { data, status, isSuccess } = useFetchEvents();
    let eventsFiltered: Event[] = [];
    
    if(data)
       eventsFiltered = date ? data.filter((e) => new Date(e.startDate).toISOString().split("T")[0] === date) : data
    
    return (
        <div>
        <table className="table table-hover">
            <thead>
            <tr>
                <th>Title</th>
                <th>Start Date</th>
                <th>End Date</th>
            </tr>
            </thead>
            <tbody>
            {eventsFiltered.map((e: Event) => (
                <tr key={e.id} onClick={() => nav(`/event/${e.id}`)}>
                    <td>{e.title}</td>
                    <td>{new Intl.DateTimeFormat('en-US', {dateStyle: 'medium', timeStyle: 'medium'}).format(new Date(e.startDate))}</td>
                    <td>{new Intl.DateTimeFormat('en-US', {dateStyle: 'medium', timeStyle: 'medium'}).format(new Date(e.endDate))}</td>
                </tr>
                ))}
            </tbody>
        </table>
        <Link className="btn btn-primary" to="/event/add">
            Add
        </Link>
        </div>
    );
};

export default EventList;
