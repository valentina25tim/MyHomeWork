import React from "react";
import classes from './CurrentBarPage.module.css';

const CurrentBarPage = ({props}) =>{
    return(
        <button className={classes.cbr__bar}>
                {props}
        </button>
    )
}
export default CurrentBarPage;