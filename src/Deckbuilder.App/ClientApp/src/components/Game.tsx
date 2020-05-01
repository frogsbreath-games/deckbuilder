import * as React from "react";
import { connect } from "react-redux";
import { ApplicationState } from "../store";
import * as GameStore from "../store/Game";
import styles from "./Game.module.css";

// At runtime, Redux will merge together...
type GameProps = GameStore.GameState & // ... state we've requested from the Redux store
  typeof GameStore.actionCreators;

class FetchData extends React.PureComponent<GameProps> {
  // This method is called when the component is first added to the document
  public componentDidMount() {
    this.fetchBoard();
  }

  public render() {
    return (
      <React.Fragment>
        <div className={styles.board}>
          <div className={styles.opponentSection}>
            <div className={styles.permanentArea}>Permanent Area</div>
            <div className={styles.playArea}>Play Area</div>
            <div className={styles.heroArea}>Hero Area</div>
            <div className={styles.handArea}>Hand Area</div>
            <div className={styles.deckArea}>Deck Area</div>
            <div className={styles.counterArea}>Counter Area</div>
          </div>
          <div className={styles.neutralSection}>
            <div className={styles.storeArea}>
              {this.props.boardState.storeObjects &&
                this.props.boardState.storeObjects.map(
                  (boardObject: GameStore.BoardObject) => (
                    <div className={styles.card} key={boardObject.card.number}>
                      {boardObject.card.number}
                    </div>
                  )
                )}
            </div>
            <div className={styles.utilityArea}>Utility Area</div>
          </div>
          <div className={styles.playerSection}>
            <div className={styles.permanentArea}>Permanent Area</div>
            <div className={styles.playArea}>Play Area</div>
            <div className={styles.heroArea}>Hero Area</div>
            <div className={styles.handArea}>Hand Area</div>
            <div className={styles.deckArea}>Deck Area</div>
            <div className={styles.counterArea}>Counter Area</div>
          </div>
        </div>
      </React.Fragment>
    );
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
