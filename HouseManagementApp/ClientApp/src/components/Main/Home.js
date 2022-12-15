import React, { Component } from 'react';
import CalendarComponent from '../Calendar/CalendarComponentClass'

export class Home extends Component {
  static displayName = Home.name;

  render () {
      return (
          <CalendarComponent/>
    );
  }
}
