import React from 'react';
import {MemoryRouter} from 'react-router-dom';
import { mount } from 'enzyme'
import Task from './Task';


it('renders without crashing', () => {
  const wrapper = mount(
    <MemoryRouter>
      <Task match={{params: {id: "1"}, isExact: true, path: "/tasks/:id", name: "User details"}}/>
    </MemoryRouter>
  );
  expect(wrapper.containsMatchingElement(<strong>Samppa Nori</strong>)).toEqual(true)
  wrapper.unmount()
});
