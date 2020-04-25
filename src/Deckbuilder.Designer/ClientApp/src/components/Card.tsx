import * as React from "react";
import * as CardStore from "../store/Cards";
import FactionIcon from "./Faction";
import CardAbility from "./CardAbility";
import CardAction from "./CardAction";
import * as Resource from "./Resource";

interface CardProps<T extends CardStore.Card> {
  card: T;
}

type AnyCardProps = CardProps<CardStore.Card>;

const StoreCardCost = ({ card }: CardProps<CardStore.StoreCard>) => (
  <div className="card-cost">
    <Resource.ResourceList resources={card.store.cost} />
  </div>
);

const CardHeader = ({ card }: AnyCardProps) => (
  <div className="game-card-header">
    <div className="left-icon-container">
      <FactionIcon faction={card.faction}/>
    </div>
    <div className="name-container">
      {card.name}
    </div>
    <div className="right-icon-container">
      {card.store && (
        <StoreCardCost card={card as CardStore.StoreCard} />
      )}
    </div>
  </div>
);

const CardArt = ({ card }: AnyCardProps) => (
  <div className="card-art">
    ART
  </div>
);

const StoreCardBody = ({ card }: CardProps<CardStore.StoreCard>) => (
  <React.Fragment>
    {card.store.bounty !== undefined && (
      <div className="monster-bounty">
        <CardAction action={card.store.bounty} />
      </div>
    )}
  </React.Fragment>
);

const BoardCardBody = ({ card }: CardProps<CardStore.BoardCard>) => (
  <React.Fragment>
    {card.board.effect !== undefined && (
      <div className="board-effect">
        <CardAction action={card.board.effect} />
      </div>
    )}
    {card.board.abilities !== undefined &&
      card.board.abilities.length > 0 && (
      <div className="board-abilities">
        {card.board.abilities.map((a, i) => (
          <CardAbility key={i} ability={a}/>
        ))}
      </div>
    )}
  </React.Fragment>
);

const CardBody = ({ card }: AnyCardProps) => (
  <div className="game-card-body">
    {card.store && (
      <StoreCardBody card={card as CardStore.StoreCard} />
    )}
    {card.board && (
      <BoardCardBody card={card as CardStore.BoardCard} />
    )}
  </div>
);

const CardDescription = ({ card }: AnyCardProps) => (
  <div className="game-card-description">
    <div className="card-type-name">{Object.keys(card.keywords).join(' ') + ' ' + card.type}</div>
    <div className="card-id">{card.id}</div>
  </div>
);

const Card = ({ card }: AnyCardProps) => (
  <div className={"game-card " + card.type + " " + card.faction}>
    <div className="game-card-inner">
      <CardHeader card={card} />
      <CardArt card={card} />
      <CardDescription card={card} />
      <CardBody card={card} />
    </div>
  </div>
);

export default Card;