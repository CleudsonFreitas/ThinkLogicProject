import React from 'react';
import './App.css';
import Header from './Header';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import EventCalendar from './EventCalendar';
import EventDetail from './EventDetail';
import EventAdd from './EventAdd';
import EventEdit from './EventEdit';


function App() {
  return (
    <BrowserRouter>
        <Header />
        <div className="container mt-5">
        <Routes>
          <Route path="/" element={<EventCalendar/>}></Route>
          <Route path="/event/:id" element={<EventDetail />}></Route>
          <Route path="/event/add" element={<EventAdd />}></Route>
          <Route path="/event/edit/:id" element={<EventEdit />}></Route>
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
