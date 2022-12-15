import React, { Component } from 'react';
import { Home } from './Home';
import NavBar from './NavBar'

export const Layout = () => {
    return (
        <div>
            <NavBar />
            <Home />
        </div>
    );
}
