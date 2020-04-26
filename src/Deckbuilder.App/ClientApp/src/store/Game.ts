import { Action, Reducer } from "redux";
import { AppThunkAction } from "./";

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface GameState {
  boardState: BoardState;
  isLoading: boolean;
}

export interface BoardState {
  storeDeck?: any;
  storeObjects?: any;
  players?: any;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestBoardState {
  type: "REQUEST_BOARD_STATE";
}

interface RecieveBoardState {
  type: "RECIEVE_BOARD_STATE";
  boardState: BoardState;
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestBoardState | RecieveBoardState;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
  requestBoardState: (): AppThunkAction<KnownAction> => (
    dispatch,
    getState
  ) => {
    // Only load data if it's something we don't already have (and are not already loading)
    const appState = getState();

    fetch(`board/random`)
      .then((response) => response.json() as Promise<BoardState>)
      .then((data) => {
        console.log(data);
        dispatch({
          type: "RECIEVE_BOARD_STATE",
          boardState: data,
        });
      });

    dispatch({
      type: "REQUEST_BOARD_STATE",
    });
  },
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: GameState = {
  boardState: {},
  isLoading: false,
};

export const reducer: Reducer<GameState> = (
  state: GameState | undefined,
  incomingAction: Action
): GameState => {
  if (state === undefined) {
    return unloadedState;
  }

  const action = incomingAction as KnownAction;
  switch (action.type) {
    case "REQUEST_BOARD_STATE":
      return {
        boardState: state.boardState,
        isLoading: true,
      };
    case "RECIEVE_BOARD_STATE":
      return {
        boardState: action.boardState,
        isLoading: false,
      };
      break;
  }

  return state;
};
