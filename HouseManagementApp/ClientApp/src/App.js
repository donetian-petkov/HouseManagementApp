import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/main/Layout';

import './custom.css'

function App() {
    return (
        <Layout>
            <h1>Hello from react</h1>
        </Layout>
    );
}

export default App;
