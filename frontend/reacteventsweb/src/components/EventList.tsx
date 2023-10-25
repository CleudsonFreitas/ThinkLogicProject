import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import { useFetchEvents } from "../hooks/EventsHooks";
import { Event } from "../types/event";

const EventList = () => {
    const nav = useNavigate();
    const { data, status, isSuccess } = useFetchEvents();
    console.log(data);
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
            {data &&
                data.map((e: Event) => (
                <tr key={e.id} onClick={() => nav(`/event/${e.id}`)}>
                    <td>{e.title}</td>
                    <td>{e.startDate}</td>
                    <td>{e.endDate}</td>
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
