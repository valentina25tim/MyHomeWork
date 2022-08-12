import React, { useContext } from "react";
import { Link } from "react-router-dom";
import { AuthorizContext } from "../../../context";
import ButtonTopBar from "../../UI/buttons/buttomTopBarSide/ButtonTopBar";
import ButtonEmpty from "../../UI/buttons/buttonEmpty/ButtonEmpty";
import ButtonLogin from "../../UI/buttons/buttonLogin/ButtonLogin";
import ButtonStart from "../../UI/buttons/buttonStart/ButtonStart";
import InputAddNewVacancy from "../../UI/inputs/addNewVacancy/InputAddNewVacancy";
import InputLogin from "../../UI/inputs/inputLogin/InputLogin";
import classes from './LoginPage.module.css';

const LoginPage = () => {

    const {isAuthoriz, setIsAuthoriz} = useContext(AuthorizContext)
   
    const login = event => {
        event.preventDefault();
        setIsAuthoriz(true);
        localStorage.setItem('auth', 'true')
    }

    return (  
    
    <form className={classes.login__frame}onSubmit={login}>

        <div className={classes.login__form}>

            <h2 className={classes.login__title}>
                please, before we start...
            </h2>

           <hr className={classes.login__horiz}/>

           <div className={classes.login__div_input}>
                <h2 className={classes.login__text_inside}>input login:</h2>
                
                <InputLogin type="text" placeholder=''/>
                
                <h2 className={classes.login__text_inside}>input password:</h2>
                
                <InputLogin type="password" placeholder=''/>

                <ButtonLogin>GO</ButtonLogin>

                {console.log(isAuthoriz)}

                <h2 className={classes.login__question}>Don`t have a registration?</h2>
                
            </div>

            <form onSubmit={login}>
                <Link  to="/registration" >
                    <ButtonEmpty className={classes.login__link_text}>
                        link to registration
                    </ButtonEmpty>
                </Link>
            </form>

        </div>
    </form>
    )
}

export default LoginPage;