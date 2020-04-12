import * as React from "react";
import * as CardStore from "../store/Cards";
import ResourceList from "./Resource";
import Condition from "./Condition";

interface ActionProps<T extends CardStore.CardAction> {
  action: T;
}

type AnyActionProps = ActionProps<CardStore.CardAction>;

const CardAction = ({ action }: AnyActionProps) => (
  <React.Fragment>
    {(() => {
      switch (action.type) {
        case 'or':
          return <OrAction action={action as CardStore.OrAction} />;
        case 'and':
          return <AndAction action={action as CardStore.AndAction} />;
        case 'gain':
          return <GainAction action={action as CardStore.GainAction} />;
        case 'lose':
          return <LoseAction action={action as CardStore.LoseAction} />;
        case 'conditional':
          return <ConditionalAction action={action as CardStore.ConditionalAction} />;
        default:
          return <div className="card-action">{action.description}</div>;
      };
    })()}
  </React.Fragment>
);

const OrAction = ({ action }: ActionProps<CardStore.OrAction>) => (
  <div className="or-action">
  </div>
);

const AndAction = ({ action }: ActionProps<CardStore.AndAction>) => (
  <div className="and-action">
    {action.actions.map((a, i) => (
      <CardAction key={i} action={a} />
    ))}
  </div>
);

const GainAction = ({ action }: ActionProps<CardStore.GainAction>) => (
  <div className="gain-action" title={action.description}>
    Gain <ResourceList resources={action.resources}/>
  </div>
);

const LoseAction = ({ action }: ActionProps<CardStore.LoseAction>) => (
  <div className="gain-action" title={action.description}>
    Lose <ResourceList resources={action.resources} />
  </div>
);

const ConditionalAction = ({ action }: ActionProps<CardStore.ConditionalAction>) => (
  <div className="conditional-action">
    <Condition condition={action.condition} />
    <CardAction action={action.action} />
  </div>
);

export default CardAction;