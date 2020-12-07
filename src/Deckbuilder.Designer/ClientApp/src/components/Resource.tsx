import * as React from "react";
import * as CardStore from "@store/Cards";

type ResourceListProps = {
  resources: CardStore.ResourceList;
}

type ResourceProps = {
  count: number;
}

export const GoldResource = ({ count }: ResourceProps) =>
  <span className="resource gold">{count}</span>;

export const GloryResource = ({ count }: ResourceProps) =>
  <span className="resource glory">{count}</span>;

export const DamageResource = ({ count }: ResourceProps) =>
  <span className="resource damage">{count}</span>;

export const HealthResource = ({ count }: ResourceProps) =>
  <span className="resource health">{count}</span>;

export const ResourceList = ({ resources }: ResourceListProps) => (
  <React.Fragment>
    {resources.gold && <GoldResource count={resources.gold} />}
    {resources.damage && <DamageResource count={resources.damage} />}
    {resources.health && <HealthResource count={resources.health} />}
    {resources.glory && <GloryResource count={resources.glory} />}
  </React.Fragment>
);

export default ResourceList;

