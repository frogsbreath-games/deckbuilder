import * as React from "react";
import * as CardStore from "../store/Cards";
import FactionIcon from "./Faction";
import CardAbility from "./CardAbility";
import CardAction from "./CardAction";
import * as Resource from "./Resource";

interface CardProps<T extends CardStore.Card> {
  card: T;
}

type CountProps = {
  count: number;
}

type AnyCardProps = CardProps<CardStore.Card>;

const CardPrice = ({ count }: CountProps) => (
  <div className="card-price">
    <Resource.GoldResource count={count} />
  </div>
);

const CardPower = ({ count }: CountProps) => (
  <div className="card-power">
    <Resource.DamageResource count={count} />
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
      {card.type === "monster" && <CardPower count={(card as CardStore.Monster).monsterPower} />}
      {card.type === "spell" && <CardPrice count={(card as CardStore.Spell).purchasePrice} />}
      {card.type === "fortification" && <CardPrice count={(card as CardStore.Fortification).purchasePrice} />}
      {card.type === "outpost" && <CardPrice count={(card as CardStore.Outpost).purchasePrice} />}
    </div>
  </div>
);

const CardArt = ({ card }: AnyCardProps) => (
  <div className="card-art">
    ART
  </div>
);

const MonsterBounty = ({ card }: CardProps<CardStore.Monster>) => (
  <div className="monster-bounty">
    <CardAction action={card.bounty}/>
  </div>
);

const PlayableCardBody = ({ card }: CardProps<CardStore.PlayableCard>) => (
  <React.Fragment>
    {card.boardEffect !== undefined && (
      <div className="board-effect">
        <CardAction action={card.boardEffect} />
      </div>
    )}
    {card.boardAbilities !== undefined &&
      card.boardAbilities.length > 0 && (
      <div className="board-abilities">
        {card.boardAbilities.map((a, i) => (
          <CardAbility key={i} ability={a}/>
        ))}
      </div>
    )}
  </React.Fragment>
);

const CardBody = ({ card }: AnyCardProps) => (
  <div className="game-card-body">
    {card.type === "monster" && (
      <MonsterBounty card={card as CardStore.Monster} />
    )}
    {((card.type === "spell") || (card.type === "hero") || (card.type === "fortification") || (card.type === "outpost")) && (
      <PlayableCardBody card={card as CardStore.PlayableCard}/>
    )}
  </div>
);

const CardDescription = ({ card }: AnyCardProps) => (
  <div className="game-card-description">
    <div className="card-type-name">{card.keywords.join(' ') + ' ' + card.type}</div>
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