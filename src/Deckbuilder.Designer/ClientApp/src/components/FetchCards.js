"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_redux_1 = require("react-redux");
var CardsStore = require("../store/Cards");
var Card_1 = require("./Card");
var FetchCards = /** @class */ (function (_super) {
    __extends(FetchCards, _super);
    function FetchCards() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    // This method is called when the component is first added to the document
    FetchCards.prototype.componentDidMount = function () {
        this.ensureDataFetched();
    };
    // This method is called when the route parameters change
    FetchCards.prototype.componentDidUpdate = function () {
        this.ensureDataFetched();
    };
    FetchCards.prototype.render = function () {
        return (React.createElement(React.Fragment, null,
            React.createElement("h1", { id: "tabelLabel" }, "Cards"),
            this.renderCardsTable()));
    };
    FetchCards.prototype.ensureDataFetched = function () {
        var startCardIndex = parseInt(this.props.match.params.startCardIndex, 10) || 0;
        this.props.requestCards(startCardIndex);
    };
    FetchCards.prototype.renderCardsTable = function () {
        return (React.createElement("div", null,
            React.createElement("div", { className: "game-card-list" }, this.props.cards.map(function (card) {
                return React.createElement(Card_1.default, { key: card.id, card: card });
            }))));
    };
    return FetchCards;
}(React.PureComponent));
exports.default = react_redux_1.connect(function (state) { return state.cards; }, // Selects which state properties are merged into the component's props
CardsStore.actionCreators // Selects which action creators are merged into the component's props
)(FetchCards);
//# sourceMappingURL=FetchCards.js.map