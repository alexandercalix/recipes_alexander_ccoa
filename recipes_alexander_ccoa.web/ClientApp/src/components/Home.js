import React, { Component } from 'react';
import { MaintenancePage } from '../pages/maintenance/MaintenancePage';

export class Home extends Component {
  static displayName = Home.name;

  render() {


   
    return (
      <div>
        <MaintenancePage />
      </div>
    );
  }
}
