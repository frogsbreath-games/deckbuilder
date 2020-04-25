"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var Faction_1 = require("./Faction");
var CardAbility_1 = require("./CardAbility");
var CardAction_1 = require("./CardAction");
var Resource = require("./Resource");
var StoreCardCost = function (_a) {
    var card = _a.card;
    return (React.createElement("div", { className: "card-cost" },
        React.createElement(Resource.ResourceList, { resources: card.store.cost })));
};
var CardHeader = function (_a) {
    var card = _a.card;
    return (React.createElement("div", { className: "game-card-header" },
        React.createElement("div", { className: "left-icon-container" },
            React.createElement(Faction_1.default, { faction: card.faction })),
        React.createElement("div", { className: "name-container" }, card.name),
        React.createElement("div", { className: "right-icon-container" }, card.store && (React.createElement(StoreCardCost, { card: card })))));
};
var CardArt = function (_a) {
    var card = _a.card;
    return (React.createElement("div", { className: "card-art" }, "ART"));
};
var StoreCardBody = function (_a) {
    var card = _a.card;
    return (React.createElement(React.Fragment, null, card.store.bounty !== undefined && (React.createElement("div", { className: "monster-bounty" },
        React.createElement(CardAction_1.default, { action: card.store.bounty })))));
};
var BoardCardBody = function (_a) {
    var card = _a.card;
    return (React.createElement(React.Fragment, null,
        card.board.effect !== undefined && (React.createElement("div", { className: "board-effect" },
            React.createElement(CardAction_1.default, { action: card.board.effect }))),
        card.board.abilities !== undefined &&
            card.board.abilities.length > 0 && (React.createElement("div", { className: "board-abilities" }, card.board.abilities.map(function (a, i) { return (React.createElement(CardAbility_1.default, { key: i, ability: a })); })))));
};
var CardBody = function (_a) {
    var card = _a.card;
    return (React.createElement("div", { className: "game-card-body" },
        card.store && (React.createElement(StoreCardBody, { card: card })),
        card.board && (React.createElement(BoardCardBody, { card: card }))));
};
var CardDescription = function (_a) {
    var card = _a.card;
    return (React.createElement("div", { className: "game-card-description" },
        React.createElement("div", { className: "card-type-name" }, Object.keys(card.keywords).join(' ') + ' ' + card.type),
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