import * as React from "react";
import * as CardStore from "../store/Cards";

type FactionIconProps = {
  faction?: CardStore.Faction;
}

const FactionIcon = ({ faction }: FactionIconProps) => (
  faction !== undefined ? (
    <div className={"faction " + faction} title={faction + " faction"}></div>
  ) : (
      <div className="faction none" title="neutral"></div>
    )
);

export default FactionIcon;