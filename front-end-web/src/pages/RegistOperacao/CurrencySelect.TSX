import React from 'react'




  const  currencyInput = () => {

    return (
        <div>

            <select
                                        value={formData.id}
                                        placeholder=""
                                        name= "id"
                                        className="currency"
                                        onChange= {handleOnChange}
                                        >
                                            
                                            <option value="3">EUR - Euro</option>
                                            <option value="1">STN - Dobra</option>
                                            
                                            
                                        </select>


        </div>
    )

  }

    
