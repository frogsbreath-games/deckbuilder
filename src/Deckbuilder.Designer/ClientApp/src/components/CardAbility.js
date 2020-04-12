"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var CardAction_1 = require("./CardAction");
var Resource_1 = require("./Resource");
var CardAbility = function (_a) {
    var ability = _a.ability;
    return (React.createElement("div", { className: "card-ability", title: ability.description },
        ability.unlimited && (ability.description),
        !ability.unlimited && (React.createElement("div", { className: "ability-details" },
            ability.cost && (React.createElement(React.Fragment, null,
                "You may pay ",
                React.createElement(Resource_1.default, { resources: ability.cost }),
                " then")),
            React.createElement(CardAction_1.default, { action: ability.action })))));
};
exports.default = CardAbility;
//# sourceMappingURL=CardAbility.js.map