import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import { ApplicationState } from '../store';
import * as CardsStore from '../store/Cards';
import Card from './Card';

// At runtime, Redux will merge together...
type CardProps =
  CardsStore.CardsState // ... state we've requested from the Redux store
  & typeof CardsStore.actionCreators // ... plus action creators we've requested
  & RouteComponentProps<{ startCardIndex: string }>; // ... plus incoming routing parameters


class FetchCards extends React.PureComponent<CardProps> {
  // This method is called when the component is first added to the document
  public componentDidMount() {
    this.ensureDataFetched();
  }

  // This method is called when the route parameters change
  public componentDidUpdate() {
    this.ensureDataFetched();
  }

  public render() {
    return (
      <React.Fragment>
        <h1 id="tabelLabel">Cards</h1>
        {this.renderCardsTable()}
      </React.Fragment>
    );
  }

  private ensureDataFetched() {
    const startCardIndex = parseInt(this.props.match.params.startCardIndex, 10) || 0;
    this.props.requestCards(startCardIndex);
  }

  private renderCardsTable() {
    return (
      <div>
        <div className="game-card-list">
          {this.props.cards.map((card: CardsStore.Card) =>
            <Card
              key={card.id}
              card={card}
            />
          )}
        </div>
      </div>
    );
  }
}

export default connect(
  (state: ApplicationState) => state.cards, // Selects which state properties are merged into the component's props
  CardsStore.actionCreators // Selects which action creators are merged into the component's props
)(FetchCards as any);
