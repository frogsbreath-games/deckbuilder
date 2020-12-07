import * as React from "react";
import * as CardStore from "@store/Cards";
import CardAction from "@components/CardAction";
import ResourceList from "@components/Resource";

type AbilityProps = {
  ability: CardStore.CardAbility;
}

const CardAbility = ({ ability }: AbilityProps) => (
  <div className="card-ability" title={ability.description}>
    {ability.unlimited && (ability.description)}
    {!ability.unlimited && (
      <div className="ability-details">
        {ability.cost && (
          <React.Fragment>
            You may pay <ResourceList resources={ability.cost} /> then
          </React.Fragment>
        )}
        <CardAction action={ability.action} />
      </div>
    )}
  </div>
);

export default CardAbility;