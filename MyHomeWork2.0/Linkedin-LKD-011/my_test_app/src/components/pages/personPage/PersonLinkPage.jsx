import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import PersonService from "../../../API/services/PersonService";
import { useFetching } from "../../../hook/hookOffers/UseFetching";
import ButtonPhoto from "../../UI/buttons/buttonPhoto/ButtonPhoto";
import LoaderOfferList from "../../UI/loaders/loaderOffersList/LoaderOfferList";
import classes from './PersonLinkPage.module.css';
import user from './user.png'
import icon from './icon.png'

const PersonLinkPage = ({item}) => {
// сделать правильные поля 
    const params = useParams()
    
    const [titleStrip_1_1, setTitleStrip_1_1] = useState([
        {name: 'First name:', value: item.name},
        {name: 'Location:', value: item.address.street},
        {name: 'Sector job:', value: item.name},
        {name: 'Current position:', value: item.name}
    ])
    const [titleStrip_1_2, setTitleStrip_1_2] = useState([
        {name: 'Last name:', value: item.username},
        {name: 'Wait offer:', value: item.email},
        {name: 'Work (years):', value: item.id}
    ])

    return (
        <div className={classes.pc__frame}>
            
            <div className={classes.pc__form}>

                {/* заголовок */}
                <h2 className={classes.pc__title}>
                    Candidate Card
                </h2>
            
                <hr className={classes.pc__horiz_1}/>

                {/* первый сектор с инф */}

                <img src={icon} className = {classes.pc__icon}/>
                {/* добавить загружен фото кандидата */}

                <div className={classes.pc_strip1_col1}>
                {titleStrip_1_1.map(text =>
                    <div className={classes.pc__text_options_1} key={text.name}>
                        {text.name}
                    </div>
                )}
                </div>

                <div className={classes.pc_strip1_col1_value}>
                {titleStrip_1_1.map(text =>
                    <div className={classes.pc__text_value_1} key={text.name}>
                        {text.value}
                    </div>
                )}
                </div>

                <div className={classes.pc_strip1_col2}>
                {titleStrip_1_2.map(text =>
                    <div className={classes.pc__text_options_2} key={text.name}>
                        {text.name}
                    </div>
                )}  
                </div> 

                <div className={classes.pc_strip1_col2_value}>
                {titleStrip_1_2.map(text =>
                    <div className={classes.pc__text_value_2} key={text.name}>
                        {text.value}
                    </div>
                )}
                </div>

                <hr className={classes.pc__horiz_2}/>

                {/* воторой сектор с инф */}
           </div>

            

        </div>
    )
}
export default PersonLinkPage