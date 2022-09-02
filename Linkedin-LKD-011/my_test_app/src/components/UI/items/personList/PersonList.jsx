import React from "react";
import { CSSTransition, TransitionGroup } from "react-transition-group";
import PersonItem from "./PersonItem";

const PersonList = ({persons, remove}) => {
    
    if (!persons.length){
        return(
            <h2 style={{textAlign:'center'}}>
                Don`t have candidates
            </h2>
        )
    }
    return (

        <div>
            <TransitionGroup>
                {persons.map((person, index )=> 
                    <CSSTransition
                    key={person.id}
                    timeout={500}
                    classNames="person"
                    >
                        <PersonItem 
                            remove={remove}
                            number={index + 1}
                            item={person} 
                        />
                   </CSSTransition>)}
            </TransitionGroup>
        </div>
    );
};

export default PersonList;