import * as React from "react";
import { connect } from "react-redux";
import { RouteComponentProps } from "react-router";
import { Link } from "react-router-dom";
import { ApplicationState } from "../store";
import * as GameStore from "../store/Game";

// At runtime, Redux will merge together...
type GameProps = GameStore.GameState & // ... state we've requested from the Redux store
  typeof GameStore.actionCreators;

class FetchData extends React.PureComponent<GameProps> {
  // This method is called when the component is first added to the document
  public componentDidMount() {
    this.fetchBoard();
  }

  public render() {
    return <React.Fragment></React.Fragment>;
  }

  private fetchBoard() {
    this.props.requestBoardState();
    console.log("Board Fetched");
  }
}

export default connect(
  (state: ApplicationState) => state.game, // Selects which state properties are merged into the component's props
  GameStore.actionCreators // Selects which action creators are merged into the component's props
)(FetchData as any);
