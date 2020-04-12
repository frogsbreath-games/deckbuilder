"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var FactionIcon = function (_a) {
    var faction = _a.faction;
    return (faction !== undefined ? (React.createElement("div", { className: "faction " + faction, title: faction + " faction" })) : (React.createElement("div", { className: "faction none", title: "neutral" })));
};
exports.default = FactionIcon;
//# sourceMappingURL=Faction.js.map