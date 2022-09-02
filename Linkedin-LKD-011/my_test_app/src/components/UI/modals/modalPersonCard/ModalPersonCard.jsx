import React from "react";
import classes from './ModalPersonCard.module.css';

const ModalPersonCard = ({children, visible, setVisible}) => {
    
    const rootClasses= [classes.mad__modal]

    if(visible){
        rootClasses.push (classes.mad__active)
    }

    return (
        <div className={rootClasses.join(' ')} onClick={() => setVisible(false)}>
            <div className={classes.mad__content} onClick={(e) => e.stopPropagation()}>
                {children}
            </div>
        </div>
    );
};
export default ModalPersonCard;