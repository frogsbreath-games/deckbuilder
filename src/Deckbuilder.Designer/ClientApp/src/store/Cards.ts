﻿import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface CardsState {
  isLoading: boolean;
  startCardIndex?: number;
  cards: Card[];
}

export type ResourceType =
  'gold' | 'damage' | 'glory' | 'health';

export type ResourceList = {
  [type in ResourceType]?: number;
};

export interface BoardCondition {
  description: string;
}

interface BaseCardAction {
  description: string;
}

export interface OrAction extends BaseCardAction {
  type: 'or';
  actions: CardAction[];
}

export interface AndAction extends BaseCardAction {
  type: 'and';
  actions: CardAction[];
}

export interface GainAction extends BaseCardAction {
  type: 'gain';
  resources: ResourceList;
}

export interface LoseAction extends BaseCardAction {
  type: 'lose';
  resources: ResourceList;
}

export interface DrawAction extends BaseCardAction {
  type: 'draw';
  count: number;
  optional: boolean;
}

export interface DiscardAction extends BaseCardAction {
  type: 'discard';
  count: number;
  optional: boolean;
}

export interface ConditionalAction extends BaseCardAction {
  type: 'conditional';
  action: CardAction;
  condition: BoardCondition;
}

export type CardAction = OrAction
  | AndAction
  | GainAction
  | LoseAction
  | DrawAction
  | DiscardAction
  | ConditionalAction;

export interface CardAbility {
  description: string;
  action: CardAction;
  cost?: ResourceList;
  unlimited: boolean;
}

export type KeywordList = {
  [key: string]: true;
};

export type Faction = 'river'
  | 'mountain'
  | 'sea'
  | 'desert'
  | 'jungle';

export interface Card {
  id: number;
  name: string;
  code: string;
  version: number;
  form: string;
  keywords: KeywordList;
  faction?: Faction;
  type: string;
  store?: StoreCardMeta;
  board?: BoardCardMeta;
}

export interface StoreCardMeta {
  cost: ResourceList;
  bounty?: CardAction;
  acquire: boolean;
}

export interface BoardCardMeta {
  effect?: CardAction;
  abilities?: CardAbility[];
  permanent?: PermanentCardMeta;
}

export interface PermanentCardMeta {
  removalCost?: ResourceList;
  fortification: boolean;
}

export interface StoreCard extends Card {
  store: StoreCardMeta;
}

export interface BoardCard extends Card {
  board: BoardCardMeta;
}

export interface PermanentCard extends BoardCard {
  board: BoardCardMeta & {
    permanent: PermanentCardMeta;
  }
}

export interface Hero extends PermanentCard {
  store: undefined;
  board: BoardCardMeta & {
    permanent: PermanentCardMeta & {
      removalCost: undefined;
      fortification: false;
    }
  }
}

export interface Spell extends BoardCard, StoreCard {
  store: StoreCardMeta & {
    cost: ResourceList & {
      gold: number
    }
    bounty: undefined;
    acquire: true;
  }
  board: BoardCardMeta & {
    permanent: undefined;
  }
}

export interface Monster extends StoreCard {
  store: StoreCardMeta & {
    cost: ResourceList & {
      damage: number
    }
    bounty: CardAction;
    acquire: false;
  }
  board: undefined;
}

export interface Fortification extends PermanentCard, StoreCard {
  store: StoreCardMeta & {
    cost: ResourceList & {
      gold: number
    }
    bounty: undefined;
    acquire: true;
  }
  board: BoardCardMeta & {
    permanent: PermanentCardMeta & {
      removalCost: ResourceList & {
        damage: number
      }
      fortification: true;
    }
  }
}

export interface Outpost extends PermanentCard, StoreCard {
  store: StoreCardMeta & {
    cost: ResourceList & {
      gold: number
    }
    bounty: undefined;
    acquire: true;
  }
  board: BoardCardMeta & {
    permanent: PermanentCardMeta & {
      removalCost: ResourceList & {
        damage: number
      }
      fortification: false;
    }
  }
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestCardsAction {
  type: 'REQUEST_CARDS';
  startCardIndex: number;
}

interface ReceiveCardsAction {
  type: 'RECEIVE_CARDS';
  startCardIndex: number;
  cards: Card[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestCardsAction | ReceiveCardsAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
  requestCards: (startCardIndex: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
    // Only load data if it's something we don't already have (and are not already loading)
    const appState = getState();
    if (appState && appState.cards && startCardIndex !== appState.cards.startCardIndex) {
      fetch(`api/cards`)
        .then(response => response.json() as Promise<Card[]>)
        .then(data => {
          dispatch({ type: 'RECEIVE_CARDS', startCardIndex: startCardIndex, cards: data });
        });

      dispatch({ type: 'REQUEST_CARDS', startCardIndex: startCardIndex });
    }
  }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: CardsState = { cards: [], isLoading: false };

export const reducer: Reducer<CardsState> = (state: CardsState | undefined, incomingAction: Action): CardsState => {
  if (state === undefined) {
    return unloadedState;
  }

  const action = incomingAction as KnownAction;
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