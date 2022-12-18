import React, { Component } from 'react';
import Calendar from '../calendar/Calendar'
import ToDoListComponent from "../todolist/ToDoListComponent";

export class Home extends Component {
  static displayName = Home.name;

  render () {
      return (
          <ToDoListComponent/>
    );
  }
}
