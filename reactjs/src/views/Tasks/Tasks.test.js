import React from 'react';
import ReactDOM from 'react-dom';
import { MemoryRouter } from 'react-router-dom';
import Tasks from './Tasks';

it('renders without crashing', () => {
  const div = document.createElement('div');
  ReactDOM.render(<MemoryRouter><Tasks /></MemoryRouter>, div);
  ReactDOM.unmountComponentAtNode(div);
});
