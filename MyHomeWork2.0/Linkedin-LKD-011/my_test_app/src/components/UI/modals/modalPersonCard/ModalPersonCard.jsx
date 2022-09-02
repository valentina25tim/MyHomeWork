import React from "react";
import classes from './ModalPersonCard.module.css';

const ModalPersonCard = ({children, visible, setVisible}) => {
    
    const rootClasses= [classes.mpc__modal]

    if(visible){
        rootClasses.push (classes.mpc__active)
    }

    return (
        <div className={rootClasses.join(' ')} onClick={() => setVisible(false)}>
            <div className={classes.mpc__frame} onClick={(e) => e.stopPropagation()}>
                {children}
            </div>
        </div>
    );
};
export default ModalPersonCard;