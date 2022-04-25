import React, {  useEffect, useState } from 'react';
import './styles.scss';
import Footer from '../Footer';
import { Icon } from '@iconify/react';
import mathEqual from '@iconify/icons-gg/math-equal';
import { Link } from 'react-router-dom';
import { makePrivateRequest, makeRequest } from '../../core/utils/request';
import ButtonIcon from '../../core/assets/styles/ButtonIcon';
import { saveSessionDataConverter } from '../../core/utils/auth';
import Navbar from '../../core/components/Navbar';
import { Rate } from '../../core/Types/Rate';
import { OperationTypes } from '../../core/Types/OperationType';
import { toast } from 'react-toastify';


type FormDataAmount = {
    amountWithSymbol: number;
    balance: string;
    balanceInfo: string
}

type FormState = {
    amountReceived: string;
    currencyInput:string;
    currencyOutput: string;
    OperationTypeCode: string;
}

const Conversor = () => {

    let [rates,  setRate] = useState<Rate[]>([{id:0,code:"",rateName:"Escolher Moeda"}]);
    const [ratesSelectOne, setRateSelectOne] = useState<Rate[]>([]);
    const [ratesSelectTwo, setRateSelectTwo] = useState<Rate[]>([]);
    const [operationType, setOperationType] = useState<OperationTypes[]>([]);
   
    const [formDataAmount,setFormDataAmount] = useState<FormDataAmount>({
        amountWithSymbol: 0,
        balance: '',
        balanceInfo: ''
    });

    const [formData, setFormData] = useState<FormState>({
        amountReceived: '',
        currencyInput: '',
        currencyOutput: '',
        OperationTypeCode: '',
   

    });

    useEffect(() => {
        
        makePrivateRequest({ url: '/operationType', method: 'GET'})
        .then(response  => 
            setOperationType(response.data.operationTypes)
            
            )    
        
    }, [])

    useEffect(() => {
        
        makePrivateRequest({ url: '/rate', method: 'GET'})
        .then(response  =>  {
           rates.push(...response.data.rates);
            setRate(rates);
           
            setRateSelectOne(rates);
            setRateSelectTwo(rates);
         },
  
        );
             
        
    }, [])

    const payload =  {
        ...formData,
    }

    console.log(payload)

    useEffect(() => {
        makeRequest({ url: '/conversion', method: 'POST', data: payload})
        .then( responserate => {setFormDataAmount(responserate.data) } )
    }, [])

    const handleOnChange = (event: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        
        const name = event.target.name;
        const value = event.target.value;

        setFormData(data => ({ ...data, [name]: value }));
    }

    const handleOnChangeONE = (event: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        
        const name = event.target.name;
        const value = event.target.value;
        
        setFormData(data => ({ ...data, [name]: value }));

        const rate = rates.find(r => r.id.toString()===value);

        if (rate?.code !== "STN" && value !=="0") {
            setRateSelectTwo(rates.filter(o => o.code === "STN"));
            const id = rates.find(o => o.code === "STN")?.id.toString();
            const outName="currencyOutput";
            setFormData(data => ({ ...data, [outName]: id??"" }));
        }
        else{
            setRateSelectTwo(rates.filter(o => o.id.toString() !== value));
        }
    }

    const handleOnChangeTWO = (event: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        
        const name = event.target.name;
        const value = event.target.value;

        setFormData(data => ({ ...data, [name]: value }));

       setRateSelectOne(rates.filter(o => o.id.toString() !== value));
    }

    const handleSubmit = (event: React.FormEvent<HTMLFormElement | HTMLAnchorElement>) => {
        event.preventDefault();

        makePrivateRequest({ url: '/conversion', method: 'POST', data: payload})
        .then(response => {

            if(response.data.success) {
                toast.success('Conversão feita com sucesso!');
                setFormDataAmount(response.data);
                saveSessionDataConverter(response.data);

            }
            else{
                toast.warning(response.data.message)
                setFormDataAmount(response.data);
            

            }
             
          }   
          
        
        )  
                         
    }

    return (
        
        <>

            <Navbar/>
       
            <form onSubmit={handleSubmit}>
            <div className="conversor-container">
                <div className=" row conversor-content card-base border-radius-20">
                    <h1> Dados da Operação</h1>
                    { formDataAmount.balanceInfo &&(
                        <>
                            <h6 className="alert alert-danger  " >{formDataAmount.balanceInfo}</h6>
                            
                        </>

                    )}
                    
                    

                    <div className="conversor-moeda">
                    <div>
                    
                        <select 
                            className="currency botao-tipooperacao my-3" 
                                onChange={handleOnChange}
                                name="operationTypeCode"
                                    
                                    >
                                    <option value="">Tipo de Operação...</option>
                                    {operationType.map((d)=>(
                                    
                                        <option key={d.id} value={d.code}>
                                            {d.description}
                                    </option>
                                    ))}
                        </select>

                    </div>
                        <div className="conversor-moeda-conteudo">
                            <div className="conversor-moeda-conteudo-items">
                                

                                <div className="conversor-moeda-from ">
                                
                                    
                                    <p>De:</p>
                                     <select className="currency" 
                                      onChange={handleOnChangeONE}
                                      name="currencyInput"
                                         
                                         >
                                         {ratesSelectOne.map((d)=>(
                                             <option key={d.id} value={d.id}>
                                                 {d.rateName}
                                            </option>
                                         ))}
                                     </select>

                                        <input
                                            value={formData.amountReceived}
                                            type="number"
                                            placeholder="Digite o montante a trocar"
                                            className="currency"
                                            
                                            name="amountReceived"
                                            onChange={handleOnChange}

                                         />
                                   
                                </div>


                                <div className="swap-rate-container ">

                                
                                <Icon icon={mathEqual}    />

                                   
                                </div>

                                                      

                                <div className="conversor-moeda-from ">
                                    <p>Para:</p>

                                    {
                                        <select className="currency" 
                                        onChange={handleOnChangeTWO}
                                        name="currencyOutput"
                                       
                                           >
                                              
                                            {
                                                ratesSelectTwo.length === 1 ? 
                                                ratesSelectTwo.map((o)=>(
                                                    
                                                    <option key={o.id} value={o.id} selected={true}>
                                                            {    o.rateName  } 
                                                    </option>
                                                )) 
                                                : 
                                                ratesSelectTwo.map((o)=>(
                                                    
                                                    <option key={o.id} value={o.id}>
                                                                {    o.rateName  } 
                                                    </option>
                                                ))
                                           }
                                       </select> 
                                    }

                                        <input
                                           value={formDataAmount.amountWithSymbol}
                                            type="text"
                                            placeholder="Total"
                                            className="currency"
                                            
                                            name="amountWithSymbol"
                                            onChange={handleOnChange}

                                         />
                                   
                      

                                </div>
                            </div>

                           


                        </div>

                        <div className="conversor-moeda-footer ">
                
                        
                            

                            <div className=" ">

                                <div>
                              {/*   <select 
                                className="currency botao-tipooperacao my-3" 
                                      onChange={handleOnChange}
                                      //value={formData.rate}
                                      name="operationTypeCode"
                                         
                                         >
                                            <option value="">Tipo de Operação...</option>
                                         {operationType.map((d)=>(
                                            
                                             <option key={d.id} value={d.code}>
                                                 {d.description}
                                            </option>
                                         ))}
                                     </select> */}

                                </div>

                           


                                    <div className="botao-opConversao ">
                                            
                                             

                                        <div className="btn-cambio">
                                            <button className=" btn-primary  btn btn-conversion"> Câmbio</button>

                                        </div>
                                        


                                                  

                                              
                                            

                            

                                            <div>
                                                <Link to="/infoscliente"  className="">
                                                    
                                                    <ButtonIcon  text="Continuar"/>


                                                </Link>

                                            </div>
                                              

                                            

                                              
                                                
                                              

                                            
                                
                                    </div>  
                                    

                               

                            </div>

                           
                           

                            
                            

                            
                       

                        </div>
                        
                       

                    </div>

                </div>

               
        

            </div>
           

            </form>

            

            <Footer />



        </>
    );

};



export default Conversor;