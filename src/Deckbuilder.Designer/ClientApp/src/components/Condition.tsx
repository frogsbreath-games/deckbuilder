import * as React from "react";
import * as CardStore from "../store/Cards";

type ConditionProps = {
  condition: CardStore.BoardCondition;
}

const Condition = ({ condition }: ConditionProps) => (
  <React.Fragment>
    <span className="condition" title={condition.description}>?</span>
  </React.Fragment>
);

export default Condition;

