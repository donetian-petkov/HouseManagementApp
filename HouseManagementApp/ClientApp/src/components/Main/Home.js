import React, { Component } from 'react';
import CalendarComponent from '../Calendar/CalendarComponent'

export class Home extends Component {
  static displayName = Home.name;

  render () {
      return (
          <CalendarComponent/>
    );
  }
}
