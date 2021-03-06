import * as React from 'react';
import { Route } from 'react-router';
import Layout from '@components/Layout';
import Home from '@pages/Home';
import Counter from '@pages/Counter';
import FetchData from '@pages/FetchData';
import FetchCards from '@pages/FetchCards';

import './custom.css'

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
    <Route path='/fetch-cards/:startCardIndex?' component={FetchCards} />
  </Layout>
);