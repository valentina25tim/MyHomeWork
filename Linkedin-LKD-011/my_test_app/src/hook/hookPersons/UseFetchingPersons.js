import React, { useState } from "react"

export const useFetchingPersons = (callback) => {
    const [personLoading, setPersonLoading] = useState(false)
    const [error, setError] = useState('')

    const fething = async(...args) => {
        try {
            setPerasonLoading(true)
            await callback(...args)
        }
        catch (e) {
            setError(e.message)
        }
        finally {
            setPersonLoading(false)
        }
    }
    return [fething, personLoading, error]
}