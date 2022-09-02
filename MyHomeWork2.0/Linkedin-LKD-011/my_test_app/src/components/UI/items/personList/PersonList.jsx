import React from "react";
import { CSSTransition, TransitionGroup } from "react-transition-group";
import PersonItem from "./PersonItem";

const PersonList = ({persons, remove, open, visible, setVisible}) => {
    
    function handleSubmit(e) {
        e.preventDefault();}

    if (!persons.length){
        return(
            <h2 style={{textAlign:'center'}}>
                Don`t have candidates
            </h2>
        )
    }
    return (

        <form onSubmit={handleSubmit}>
            <TransitionGroup>
                {persons.map((person, index )=> 
                    <CSSTransition
                    key={person.id}
                    timeout={500}
                    classNames="person"
                    type="submit"
                    >
                        <PersonItem 
                            remove={remove}
                            number={index + 1}
                            item={person}
                            open={open}
                            visible={visible} 
                            setVisible={setVisible}
                            

                        />
                   </CSSTransition>)}
            </TransitionGroup>
        </form>
    );
};

export default PersonList;