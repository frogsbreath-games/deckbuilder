"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var Faction_1 = require("./Faction");
var CardAbility_1 = require("./CardAbility");
var CardAction_1 = require("./CardAction");
var Resource = require("./Resource");
var CardPrice = function (_a) {
    var count = _a.count;
    return (React.createElement("div", { className: "card-price" },
        React.createElement(Resource.GoldResource, { count: count })));
};
var CardPower = function (_a) {
    var count = _a.count;
    return (React.createElement("div", { className: "card-power" },
        React.createElement(Resource.DamageResource, { count: count })));
};
var CardHeader = function (_a) {
    var card = _a.card;
    return (React.createElement("div", { className: "game-card-header" },
        React.createElement("div", { className: "left-icon-container" },
            React.createElement(Faction_1.default, { faction: card.faction })),
        React.createElement("div", { className: "name-container" }, card.name),
        React.createElement("div", { className: "right-icon-container" },
            card.type === "monster" && React.createElement(CardPower, { count: card.monsterPower }),
            card.type === "spell" && React.createElement(CardPrice, { count: card.purchasePrice }),
            card.type === "fortification" && React.createElement(CardPrice, { count: card.purchasePrice }),
            card.type === "outpost" && React.createElement(CardPrice, { count: card.purchasePrice }))));
};
var CardArt = function (_a) {
    var card = _a.card;
    return (React.createElement("div", { className: "card-art" }, "ART"));
};
var MonsterBounty = function (_a) {
    var card = _a.card;
    return (React.createElement("div", { className: "monster-bounty" },
        React.createElement(CardAction_1.default, { action: card.bounty })));
};
var PlayableCardBody = function (_a) {
    var card = _a.card;
    return (React.createElement(React.Fragment, null,
        card.boardEffect !== undefined && (React.createElement("div", { className: "board-effect" },
            React.createElement(CardAction_1.default, { action: card.boardEffect }))),
        card.boardAbilities !== undefined &&
            card.boardAbilities.length > 0 && (React.createElement("div", { className: "board-abilities" }, card.boardAbilities.map(function (a, i) { return (React.createElement(CardAbility_1.default, { key: i, ability: a })); })))));
};
var CardBody = function (_a) {
    var card = _a.card;
    return (React.createElement("div", { className: "game-card-body" },
        card.type === "monster" && (React.createElement(MonsterBounty, { card: card })),
        ((card.type === "spell") || (card.type === "hero") || (card.type === "fortification") || (card.type === "outpost")) && (React.createElement(PlayableCardBody, { card: card }))));
};
var CardDescription = function (_a) {
    var card = _a.card;
    return (React.createElement("div", { className: "game-card-description" },
        React.createElement("div", { className: "card-type-name" }, card.keywords.join(' ') + ' ' + card.type),
        React.createElement("div", { className: "card-id" }, card.id)));
};
var Card = function (_a) {
    var card = _a.card;
    return (React.createElement("div", { className: "game-card " + card.type + " " + card.faction },
        React.createElement("div", { className: "game-card-inner" },
            React.createElement(CardHeader, { card: card }),
            React.createElement(CardArt, { card: card }),
            React.createElement(CardDescription, { card: card }),
            React.createElement(CardBody, { card: card }))));
};
exports.default = Card;
//# sourceMappingURL=Card.js.map