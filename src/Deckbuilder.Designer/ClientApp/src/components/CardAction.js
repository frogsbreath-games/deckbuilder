"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var Resource_1 = require("./Resource");
var Condition_1 = require("./Condition");
var CardAction = function (_a) {
    var action = _a.action;
    return (React.createElement(React.Fragment, null, (function () {
        switch (action.type) {
            case 'or':
                return React.createElement(OrAction, { action: action });
            case 'and':
                return React.createElement(AndAction, { action: action });
            case 'gain':
                return React.createElement(GainAction, { action: action });
            case 'lose':
                return React.createElement(LoseAction, { action: action });
            case 'conditional':
                return React.createElement(ConditionalAction, { action: action });
            default:
                return React.createElement("div", { className: "card-action" }, action.description);
        }
        ;
    })()));
};
var OrAction = function (_a) {
    var action = _a.action;
    return (React.createElement("div", { className: "or-action" }));
};
var AndAction = function (_a) {
    var action = _a.action;
    return (React.createElement("div", { className: "and-action" }, action.actions.map(function (a, i) { return (React.createElement(CardAction, { key: i, action: a })); })));
};
var GainAction = function (_a) {
    var action = _a.action;
    return (React.createElement("div", { className: "gain-action", title: action.description },
        "Gain ",
        React.createElement(Resource_1.default, { resources: action.resources })));
};
var LoseAction = function (_a) {
    var action = _a.action;
    return (React.createElement("div", { className: "gain-action", title: action.description },
        "Lose ",
        React.createElement(Resource_1.default, { resources: action.resources })));
};
var ConditionalAction = function (_a) {
    var action = _a.action;
    return (React.createElement("div", { className: "conditional-action" },
        React.createElement(Condition_1.default, { condition: action.condition }),
        React.createElement(CardAction, { action: action.action })));
};
exports.default = CardAction;
//# sourceMappingURL=CardAction.js.map