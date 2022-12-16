import React, { Component } from 'react';
import Calendar from '../calendar/Calendar'

export class Home extends Component {
  static displayName = Home.name;

  render () {
      return (
          <Calendar/>
    );
  }
}
