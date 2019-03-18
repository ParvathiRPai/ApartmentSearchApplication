import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { createActions, handleActions, combineActions } from 'redux-actions';
import { combineReducers } from 'redux';

export interface IApartment {
    price: number;
    address: string;
    id: string;
}

export interface IApartmentStore {
    cities: string[];
    keyWords: string[];
    apartments: { [city: string] : IApartment[] };
}

const defaultApartmentStore: IApartmentStore = {
    cities: ["city1", "city2"],
    keyWords: ["kw1", "kw2"],
    apartments: {
        "city1": [{
            id: "id11",
            price: 1000,
            address: "addr11"
        },
        {
            id: "id12",
            price: 2000,
            address: "addr12"
        }],
        "city2": [{
            id: "id21",
            price: 1000,
            address: "addr21"
        },
        {
            id: "id22",
            price: 2000,
            address: "addr22"
        }],
    }
};

export const actionCreators = createActions({
    ADD_KEYWORD: (keyword: string) => ({ kw: keyword }),
    REMOVE_KEYWORD: (keyword: string) => ({ kw: keyword })
});

export const apartmentsReducer = handleActions(
    {
        ADD_KEYWORD: (state: IApartmentStore, action: any) => {
            return {
                ...state,
                keyWords: [...state.keyWords, action.kw]
            }
        },
        REMOVE_KEYWORD: (state: IApartmentStore, action: any) => {
            var index = state.keyWords.indexOf(action.kw, 0);
            if (index > -1) {
                state.keyWords.splice(index, 1);
            }

            return {
                ...state,
                keyWords: [...state.keyWords]
            }
        }
    },
    defaultApartmentStore
);


