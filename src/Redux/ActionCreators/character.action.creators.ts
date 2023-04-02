import { Character } from "../../Components/CharCreator/CharacterForm";
import * as actions from "../ActionTypes/character.action.types";

export function setCharacter(payload: Character): actions.SetCharacterAction {
  return {
    type: actions.SET_CHARACTER,
    payload,
  };
}

export function addCharacter(payload: Character): actions.AddCharacterAction {
  return {
    type: actions.ADD_CHARACTER,
    payload,
  };
}

export function getCharacter(payload: number): actions.GetCharacterAction {
  return {
    type: actions.GET_CHARACTER,
    payload,
  };
}

export function getCharacters(): actions.GetCharactersAction {
  return {
    type: actions.GET_CHARACTERS,
  };
}

export function deleteCharacter(
  payload: number
): actions.DeleteCharacterAction {
  return {
    type: actions.DELETE_CHARACTER,
    payload,
  };
}
