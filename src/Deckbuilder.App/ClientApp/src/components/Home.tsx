import * as React from "react";
import { connect } from "react-redux";

const Home = () => (
  <div>
    <h1>DeckBuilder.App</h1>
    <p>Eventually our game will have information here.</p>
  </div>
);

export default connect()(Home);
