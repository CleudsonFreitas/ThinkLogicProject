import { useState } from "react";
import EventList from "./EventList";

const EventCalendar = () => {
    const [filterDate, setFilterDate] = useState("");

    return ( 
        <div className="row mt-3">
            <div className="col-4 mb-3">
            <label htmlFor="filterDate">Select start date:</label>
            <input
                type="date"
                className="form-control"
                value={filterDate}
                onChange={(e) => setFilterDate(e.target.value)}
                id="filterDate"
            />
            </div>
            <EventList date={filterDate}/>
        </div>
    );
}
 
export default EventCalendar;