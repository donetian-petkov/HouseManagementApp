import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Main/Layout';
import { Home } from './components/Main/Home';

import './custom.css'

function App() {
    return (
        <Layout>
            <h1>Hello from react</h1>
        </Layout>
    );
}

export default App;
