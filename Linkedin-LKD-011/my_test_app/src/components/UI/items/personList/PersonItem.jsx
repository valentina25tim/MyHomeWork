import React from "react";
import { useHistory } from "react-router-dom";
import ButtonDeleteOpenOffer from "../../buttons/buttonDelOpOffer/ButtonDeleteOpenOffer";
import ButtonEmpty from "../../buttons/buttonEmpty/ButtonEmpty";
import ButtonLogin from "../../buttons/buttonLogin/ButtonLogin";
import classes from './PersonItem.module.css';

const PersonItem = (props) =>{

    const router = useHistory()

    return(

    <div className={classes.pi__form}>

        {/* чертёж таблицы */}
        
        <hr className={classes.pi__table_v1}/>
        <hr className={classes.pi__table_v2}/>
        <hr className={classes.pi__table_v3}/>
        <hr className={classes.pi__table_v4}/>
        <hr className={classes.pi__table_v5}/>
        <hr className={classes.pi__table_v6}/>
        <hr className={classes.pi__table_v7}/>
        <hr className={classes.pi__table_v8}/>
        <hr className={classes.pi__table_hr}/>

        {/* содержимое таблицы */}

        <div className={classes.pi__col1}>
            {props.item.id}
        </div>

        <div className={classes.pi__col2}>
            
            <ButtonEmpty className={classes.pi__text_link}
            onClick={() => router.push(`/result/${props.item.id}`)}>
           {props.item.name}
            </ButtonEmpty>
        </div>

        <div className={classes.pi__col3}>
            {props.item.address.street}
        </div>

        <div className={classes.pi__col4}>
            {props.item.email}
        </div>

        <div className={classes.pi__col5}>
            {props.item.address.street}
        </div>

        <div className={classes.pi__col6}>
            {props.item.email}
        </div>

        <div className={classes.pi__col7}>
        {props.item.address.street}
        </div>

        <div className={classes.pi__col8}>
            {props.item.email}
        </div>

        <div className={classes.pi__col9}>
            {/* кнопка для удаления персона - dont works*/}
                <ButtonDeleteOpenOffer
                    onClick={() => props.remove(props.item)
                    }>
                    Remove
                </ButtonDeleteOpenOffer>
        </div>

    </div>
        


    // <div className={classes.ol__offer}>
        
    //     <hr className={classes.ol__hr}/>

    //     <ButtonDeleteOpenOffer
    //         onClick={() => router.push(`/result/${props.item.id}`)}>
    //         Open 
    //     </ButtonDeleteOpenOffer>

    //     {/* кнопка дл удаления оффера */}
    //     <ButtonDeleteOpenOffer
    //         onClick={() => props.remove(props.item)}>
    //         Remove
    //     </ButtonDeleteOpenOffer>

    //     <div className={classes.ol__title_text}>Number:</div>

    //     <div className={classes.ol__body_text}>
    //         {/* {props.number} что-то надо с этим сделать - при удалении номера не обнуляются  */}
    //         {props.item.id}
    //     </div>

    //     <div className={classes.ol__title_text}>Name:</div>

    //     <div className={classes.ol__body_text}>
    //         {props.item.name}
    //     </div>
        
    //     <div className={classes.ol__title_text}>UserName:</div>
        
    //     <div className={classes.ol__body_text}>
    //             {props.item.email}
    //     </div>

    //     <div className={classes.ol__title_text}>Body:</div>
        
    //     <div className={classes.ol__body_text}>
    //             {props.item.address.street}
    //     </div>
    // </div>

   
    )
}
export default PersonItem;