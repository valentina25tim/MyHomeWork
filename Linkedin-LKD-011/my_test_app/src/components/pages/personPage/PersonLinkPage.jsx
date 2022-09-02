import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import PersonService from "../../../API/services/PersonService";
import { useFetchingPersons } from "../../../hook/hookPersons/UseFetchingPersons";
import LoaderOfferList from "../../UI/loaders/loaderOffersList/LoaderOfferList";
import MainBarSides from "../setsBarSide/MainBarSides";

const PersonLinkPage = () => {

    const params = useParams()
    const [person, setPerson] = useState({})

    const [fetchPersonById, personLoading, personError] = 
    useFetchingPersons(async(id) => {
            const response = await PersonService.getPersonById(id)
            setPerson(response.data)
            console.log(response.data)
        }
    )

    useEffect(() => {
        fetchPersonById(params.id)
    }, [])

    return (
        <div>
            <MainBarSides/>
            
            {personLoading
                ? <LoaderOfferList/>
                : 
                <div>
                    {person.id} 
                    {person.name} 
                    {person.username}
                    {person.email}
                    {person.address.street}
                </div>
            }
        </div>
    )
}
export default PersonLinkPage