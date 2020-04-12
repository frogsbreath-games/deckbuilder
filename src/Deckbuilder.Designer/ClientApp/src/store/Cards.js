"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).
exports.actionCreators = {
    requestCards: function (startCardIndex) { return function (dispatch, getState) {
        // Only load data if it's something we don't already have (and are not already loading)
        var appState = getState();
        if (appState && appState.cards && startCardIndex !== appState.cards.startCardIndex) {
            fetch("card")
                .then(function (response) { return response.json(); })
                .then(function (data) {
                dispatch({ type: 'RECEIVE_CARDS', startCardIndex: startCardIndex, cards: data });
            });
            dispatch({ type: 'REQUEST_CARDS', startCardIndex: startCardIndex });
        }
    }; }
};
// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.
var unloadedState = { cards: [], isLoading: false };
exports.reducer = function (state, incomingAction) {
    if (state === undefined) {
        return unloadedState;
    }
    var action = incomingAction;
    switch (action.type) {
        case 'REQUEST_CARDS':
            return {
                startCardIndex: action.startCardIndex,
                cards: state.cards,
                isLoading: true
            };
        case 'RECEIVE_CARDS':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            if (action.startCardIndex === state.startCardIndex) {
                return {
                    startCardIndex: action.startCardIndex,
                    cards: action.cards,
                    isLoading: false
                };
            }
            break;
    }
    return state;
};
//# sourceMappingURL=Cards.js.map