import React from "react";
import CurrentBarPage from "../../UI/bars/currentBarPage/CurrentBarPage";
import LeftBarSide from "../../UI/bars/leftBarSide/LeftBarSide";
import TopBarSide from "../../UI/bars/topBarSide/TopBarSide";

const MainBarSides = () => {
    return (
        <div>
            <TopBarSide/>
        
            <div>
                <CurrentBarPage props={"SEARCH CANDIDATE"}/>
            </div>
     
            <LeftBarSide/>
        </div>
    )
}

export default MainBarSides;