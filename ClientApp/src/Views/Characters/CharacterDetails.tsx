import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getCharacter, updateCharacter } from "../../Redux/ActionCreators/character.action.creators";
import { RootState } from "../../Redux/store";
import { Character } from "../../@types/global";
import CharacterSheet from "./CharacterSheet";
import * as ActionCreators from "../../Redux/ActionCreators/character.action.creators";
import { useParams } from "react-router-dom";

function CharacterDetails(): JSX.Element {
    const dispatch = useDispatch();
    const characterReducer = useSelector((store: RootState) => store.characterReducer);
    const [character, setCharacter] = useState<Character>(characterReducer);
    const { id } = useParams();

    useEffect(() => {
        dispatch(getCharacter(Number(id)))
    }, [dispatch])

    useEffect(() => {
        setCharacter(characterReducer)
    }, [characterReducer])

    useEffect(() => {
        document.title = character.name;
        return () => {
            document.title = 'D&D Buddy';
        }
    }, [character]);

    useEffect(() => {
        return () => {
            dispatch(ActionCreators.clearCharacter());
        }
    }, [])


    const submitHandler = (character: Character, cb?: () => void): void => {
        console.log(character)
        if (character.name !== "") {
            if (character.id) {
                dispatch(updateCharacter(character))
            }
        } else {
            character.name="Dingus";
            dispatch(updateCharacter(character))
        }
    };

    return (
        <>
            <button
                onClick={() => {
                    submitHandler(character);
                }}
            >
                SAVE
            </button>
            <CharacterSheet />
        </>);
}

export default CharacterDetails;
