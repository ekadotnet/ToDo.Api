import React from 'react';
import logo from './logo.svg';
import './App.css';
import {BrowserRouter as Router,Route, Switch } from 'react-router-dom';
import NavbarComponent from './components/navbarComponent/index';
import TasksComponent from './components/tasksComponent/index';

function App() {
  return (
    <div className="App">
    <NavbarComponent/>
     <Router>
       <Switch>
        <Route path="/" component={TasksComponent}/>
       </Switch>
     </Router>
    </div>
  );
}

export default App;
