import React, {Component, useState} from 'react';

import './custom.css'
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import NavBar from "./components/main/NavBar";
import Home from "./components/main/Home";
import Calendar from "./components/calendar/Calendar";
import ToDoListComponent from "./components/todolist/ToDoListComponent";
import Reminder from "./components/reminder/Reminder";
import Notes from "./components/note/Notes";
import {UserContext} from './contexts/userContext';
import {PageNotFound} from "./components/PageNotFound";
import {useLocalStorage} from "./hooks/userLocalStorage";
import {ProtectedRoute} from "./components/auth/ProtectedRoute";
import {AuthComponent} from "./components/auth/AuthComponent";
import {Logout} from "./components/auth/Logout";


function App() {

    const [auth, setAuth] = useLocalStorage('auth', {});
    const [username, setUsername] = useLocalStorage('username', '');


    const userLogin = (userData) => {
        console.log(userData.Username);
        setAuth(userData.Token);
        setUsername(userData.Username)
    };

    const userLogout = () => {
        setAuth({});
        setUsername('');
    };


    const getIsLoggedIn = () => {

        return Object.keys(auth).length !== 0;

    };

    return (
        <UserContext.Provider value={{user: username, userLogin, userLogout, getIsLoggedIn}}>
            <NavBar/>
            <Routes>
                <Route path='/' exact element={<Home/>}/>
                <Route path='/login' element={<AuthComponent/>}/>
                <Route element={<ProtectedRoute user={auth}/>}>
                    <Route path='/calendar' element={<Calendar/>}/>
                    <Route path='/todolist' element={<ToDoListComponent/>}/>
                    <Route path='/reminder' element={<Reminder/>}/>
                    <Route path='/notes' element={<Notes/>}/>
                    <Route path='/logout' element={<Logout/>}/>
                </Route>
                <Route path="*" element={PageNotFound} />
            </Routes>
        </UserContext.Provider>
    );
}

export default App;
