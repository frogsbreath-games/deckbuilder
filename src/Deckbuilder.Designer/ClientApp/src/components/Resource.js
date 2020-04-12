"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
exports.GoldResource = function (_a) {
    var count = _a.count;
    return React.createElement("span", { className: "resource gold" }, count);
};
exports.GloryResource = function (_a) {
    var count = _a.count;
    return React.createElement("span", { className: "resource glory" }, count);
};
exports.DamageResource = function (_a) {
    var count = _a.count;
    return React.createElement("span", { className: "resource damage" }, count);
};
exports.HealthResource = function (_a) {
    var count = _a.count;
    return React.createElement("span", { className: "resource health" }, count);
};
var ResourceList = function (_a) {
    var resources = _a.resources;
    return (React.createElement(React.Fragment, null,
        resources.gold && React.createElement(exports.GoldResource, { count: resources.gold }),
        resources.damage && React.createElement(exports.DamageResource, { count: resources.damage }),
        resources.health && React.createElement(exports.HealthResource, { count: resources.health }),
        resources.glory && React.createElement(exports.GloryResource, { count: resources.glory })));
};
exports.default = ResourceList;
//# sourceMappingURL=Resource.js.map