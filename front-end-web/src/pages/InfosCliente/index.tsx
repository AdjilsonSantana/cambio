import React, { useEffect, useState } from 'react';
import './styles.scss';
import Footer from '../Footer';
import ButtonIconNextStep from '../../core/components/ButtonIconNextStep';
import { Link, useHistory, useParams } from 'react-router-dom';
import 'font-awesome/css/font-awesome.min.css';
import {reactLocalStorage} from 'reactjs-localstorage';
import { makePrivateRequest, makeRequest } from '../../core/utils/request';

import { ReactComponent as SearchIcon} from '../../core/assets/images/search-icon.svg'
import { useForm } from 'react-hook-form';
import { toast } from 'react-toastify';
import userEvent from '@testing-library/user-event';
import ButtonIcon from '../../core/assets/styles/ButtonIcon';
import { saveSessionDataConverter, saveSessionDatainfosCliente } from '../../core/utils/auth';
import Navbar from '../../core/components/Navbar';
import { DocumentType } from '../../core/Types/DocumentType';


type FormState = {
    name: string;
    lastName: string;
    address: string;
    email: string;
    birthDate: string;
    phonenumber: string;
    taxNumber: string;
    docNumber: string;
    documentTypeId: string;
    employeeId: string;
    

}

type FormStatetaxNumber = {
    
    nif: string;

}

type ConverterResponse = {

    CurrencyInput: string

}

type op = {

    currencyInputId : string;
    code: string;
    taxRate: string;
    taxRatePurchase:string;
    taxRateSales:string;
    name:string;
    balance:string;
    symbol:string;

}





const InfosCliente = () => {

    

    const  [currentUser, setCurrentUser]  = useState('');

    useEffect(() => {

        const currentUserData = setFormData;
        setCurrentUser(setFormData.name);

    }, []);

    const history = useHistory();
    const {register ,formState: { errors } } = useForm<FormState>();
    
    const [formData, setFormData] = useState<FormState>({
        name: '',
        lastName: '',
        address: '',
        email: '',
        birthDate: '01/01/0001',
        phonenumber: '',
        taxNumber: '',
        docNumber: '',
        documentTypeId: '',
        employeeId: '',
        


    });

    const [formDatataxNumber, setFormDatataxNumber] = useState<FormStatetaxNumber>({
   
        nif: '',     
  
    });

    const [formDatataxNumberop, setFormDatataxNumberop] = useState<op>({
   
        currencyInputId: '',
        code: '',
        taxRate: '',
        taxRatePurchase:'',
        taxRateSales:'',
        name:'',
        balance:'',
        symbol:''      
  
    });


    const  [formDataConverterResponse] = useState<ConverterResponse>()

    

    const searchClient = () => {

       
        const payloadNif =  {
            nif :  formDatataxNumber.nif
            
        }
           // console.log(payloadNif);
            
          if ( payloadNif.nif !== '') {

            makePrivateRequest({ url: `/client/getByDocNumberOrNif?docOrnif=${payloadNif.nif}`})
            .then( response => 
               
                {
                     var msg = 'Cliente não encontrado!'; 
                      if(response.data.client != null &&  response.data.success)   {
                        setFormData( response.data.client)
                        ///setdocumentType(response.data.client);
                        toast.success('Cliente encontrado com sucesso!');
                        saveSessionDatainfosCliente(response.data);
                        console.log('aqui')
                      }
                      else {
                          //todo validation button
                        //msg=response.data.message ===  '' ? msg : response.data.message;
                        toast.error(msg);
                        console.log(response.data.message)
                      }

                     //console.log(response.data);
                    
                }
            )

            .catch((error) => {
                toast.error('Erro do servidor, Tente Novamente.');       
          
              })
              
          }
          else{
            toast.warning('Deve indicar o NIF ou Nº do');

          }
            
    }

    const [documentTypeListe, setdocumentTypeListe] = useState<DocumentType[]>([]);
    let [documentType,  setdocumentType] = useState<DocumentType[]>([{id:0,docTypeCode:"",docDescription:"Tipo de documento..."}]);
    useEffect(() => {
        
        makePrivateRequest({ url: '/documentType', method: 'GET'})
        .then(response  => 

            {
                documentType.push(...response.data.documentTypes);
                setdocumentType(documentType);

                setdocumentTypeListe(documentType);

                console.log(documentTypeListe)
            }
            
           
            )    
            
        
    }, [])


    const adiocinarCliente = () => {
             
        //reactLocalStorage.get('authData','employeeId')      
        
        var user = JSON.parse(localStorage.getItem('authData') || '{}');
        console.log(user.employeeId) ;
        if(user.employeeId > 0 ){

            //console.log(user) ;

            const jr=  new Date (formData.birthDate)

            let jsonStr = JSON.stringify(jr) ;  

            console.log(jsonStr);

            const payload =  {
                ...formData,

                //birthDate : jsonStr,
                
                
                employeeId: user.employeeId

            }


    
        //console.log(formData.birthDate);
            
        makePrivateRequest({ url: '/client', method: 'POST', data: payload })
            
            .then((response) => {
                
                var msg = 'Erro ao adiconar cliente!';
                if(response.data.success){
                     toast.success('Cliente adicionado com sucesso!');
                     saveSessionDatainfosCliente(response.data);
                     
                     
                }
               
             
                
                else{
                    msg=response.data.message ==  null ? msg : response.data.message;
                    toast.error(msg);
                    toast.warning('Por favor inicie Sessão!');
                }
                
    
            })
            .catch((error) => {
                toast.error('Erro do servidor, Tente Novamente.');
            })
    
        }       
               
            
    }

    

    const operation = () => {

        var operation = JSON.parse(localStorage.getItem('dataConverter' || 'dataDatainfosCliente') || '{}');
        
        //console.log(operation.operationTypeCode);
        ///console.log(operation.currencyInput.id);
        //console.log(operation.currencyOutput.id);

        var user = JSON.parse(localStorage.getItem('authData') || '{}');
        //console.log(user.employeeId) ;
        //console.log(user.user.id) ;

        var operationInfosCliente = JSON.parse(localStorage.getItem('dataDatainfosCliente') || '{}');
        //console.log(operationInfosCliente.client.id)
        
        

        
            
            
            const payloadOP =  {

            ...formDataConverterResponse,
            
            operationTypeCode: operation.operationTypeCode,       
            currencyInputId: operation.currencyInput.id,
            currencyInput: {
                Id: operation.currencyInputId,
                code: operation.currencyInput.code,
                taxRate: operation.currencyInput.taxRate,
                taxRatePurchase: operation.currencyInput.taxRatePurchase,
                taxRateSales: operation.currencyInput.taxRateSales,
                name: operation.currencyInput.name,
                balance: operation.currencyInput.balance,
                symbol: operation.currencyInput.symbol
              
            },

        
            currencyOutputId: operation.currencyOutput.id,
            currencyOutput: {
                Id: operation.currencyOutput.Id,
                code: operation.currencyOutput.code,
                taxRate: operation.currencyOutput.taxRate,
                taxRatePurchase: operation.currencyOutput.taxRatePurchase,
                taxRateSales: operation.currencyOutput.taxRateSales,
                name: operation.currencyOutput.name,
                balance: operation.currencyOutput.balance,
                symbol: operation.currencyOutput.symbol
              
            },

            
            amountReceived: operation.amountReceived,
            amount: operation.amount,
            userId: user.user.id,
            
            clientId: operationInfosCliente.client.id,
             employeeId: user.employeeId
             
        }


        

            //console.log(user) ;

    
            //console.log(payloadOP);
            
            makePrivateRequest({ url: '/operation', method: 'POST',data: payloadOP })
            .then((response) => {

                //console.log(response.data)
                
                var msg = 'Erro ao finalzar operação!';
                if(response.data.success) {
                    toast.success('Operação finalizada!');
                   
                    history.push('/recibocambio')
                }
                
                else{
                    msg=response.data.message ==  null ? msg : response.data.message;
                    toast.error(msg);
                    toast.warning('Por favor inicie Sessão!');
                }
                
    
            })
            .catch((error) => {
                toast.error('Erro do servidor, Tente Novamente.');
            })
                

     

    }

    

    const editarCliente = () => {
         
         
        var user = JSON.parse(localStorage.getItem('authData') || '{}');
        const payload =  {
            ...formData,
            
            employeeId: user.employeeId
        }
    
        //console.log(formData);
       
        
        makePrivateRequest({ url: '/client', method: 'PUT', data: payload })
        .then((response) => {
            

          

            var msg = 'Erro ao editar cliente!';
            if(response.data.success) {
                toast.success('Cliente editado com sucesso!');
                saveSessionDatainfosCliente(response.data);
                
               
                
            }
           
            
            else{
                msg=response.data.message ==  null ? msg : response.data.message;
                toast.error(msg);
            }

            
            
                  
            
            

        })

        
        .catch((error) => {
            toast.error('Erro do servidor, Tente Novamente.');
        })

            
    }


   
    

    const handleOnChange = (event: React.ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLButtonElement>) => {
        const name = event.target.name;
        const value = event.target.value;

        console.log(name, value);

        setFormData(data => ({ ...data, [name]: value }));

        setFormDatataxNumber(data => ({ ...data, [name]: value }));

        //setdocumentType(data => ({ ...data, [name]: value }));
    }
   
  
    const handleSubmit = (event: React.FormEvent<HTMLFormElement | HTMLAnchorElement>) => {
        event.preventDefault();
  
                  
    }


    return (

        <>


            <Navbar/>
        
 

            <form onSubmit={handleSubmit}>

                <div className="conversor-container">
                    <div className=" row conversor-content card-base border-radius-20">
                        <h1> Informações do Cliente</h1>
                              <div className="currency conversor-moeda-cliente  ">

                             
                                

                                        <input 
                                        
                                            placeholder="Procurar com NIF/Nº Documento " 
                                            className=" currrency-search " 
                                            value={formDatataxNumber.nif}
                                            type="text"                                                                
                                            name="nif"
                                            onChange={handleOnChange}
                                            //{...register("nif", {required: true, maxLength: 80})}
                                            
                                            
                                            

                                        />

                                         <button onClick={searchClient} 

                                         className="  currency icon-search" 
                                         //disabled={!formDatataxNumber.nif}
                                          
                                        />

                                     
                        </div>
                        <div className="conversor-moeda">
                            <div className="conversor-moeda-conteudo">
                                <div className="conversor-moeda-conteudo-items infos-title">

                                    <div className="conversor-moeda-cliente btn-add-ed ">
                                        <button 
                                            className="btn-primary mx-2 btn-adicionar"
                                            onClick={adiocinarCliente} 
                                            >
                                            Adicionar
                                        </button>
                                        <button 
                                        className="btn-primary btn-editar "
                                        onClick={editarCliente} 
                                        disabled={!formDatataxNumber.nif}
                                        >
                                            Editar
                                        </button>
                                    </div>

                                </div>
                                <div className="conversor-moeda-conteudo-items">


                                    <div className="conversor-moeda-cliente ">
                                    <div className="invalid-feedback d-block">
                                          *
                                    </div>

                                        <input
                                            value={formData.name}
                                            type="text"
                                            placeholder="Nome"
                                            className="currency"
                                            name="name"
                                            //{...register('name', { required: true })}
                                            onChange={handleOnChange}

                                           
                                        />

                                    </div>


                                    <div className="conversor-moeda-cliente ">
                                        <div className="invalid-feedback d-block">
                                            *
                                        </div>
                                        <input
                                            value={formData.lastName}
                                            type="text"
                                            placeholder="Sobrenome"
                                            className="currency"
                                            name="lastName"
                                            onChange={handleOnChange}
                                        />


                                    </div>


                                </div>

                                <div className="conversor-moeda-conteudo-items">

                                    <div className="conversor-moeda-cliente ">

                                        <input
                                            value={formData.address}
                                            type="text"
                                            placeholder="Endereço"
                                            className="currency"
                                            name="address"
                                            onChange={handleOnChange}
                                        />


                                    </div>


                                </div>

                              

                                <div className="conversor-moeda-conteudo-items">

                                    <div className="conversor-moeda-cliente ">
                                        <div className="invalid-feedback d-block">
                                            *
                                        </div>
                                        <select className="currency" 
                                         onChange={handleOnChange}
                                         name= "documentTypeId"
                                         value= {formData.documentTypeId}
                                         >
                                         
                                         {documentTypeListe.map((d)=>(
                                             <option key={d.id} value={d.id}>
                                                 {d.docDescription}
                                                 </option>
                                         ))}
                                     </select>

                                    </div>


                                    <div className="conversor-moeda-cliente ">
                                        <div className="invalid-feedback d-block">
                                            *
                                        </div>
                                        <input
                                        value={formData.docNumber}
                                            type="text"
                                            placeholder="Nº documento"
                                            className="currency"
                                            name="docNumber"
                                            onChange={handleOnChange}
                                        />

                                    </div>


                                </div>

                                <div className="conversor-moeda-conteudo-items">

                                    <div className="conversor-moeda-cliente ">
                                    <div className="invalid-feedback d-block">
                                            *
                                        </div>

                                        <input
                                            value={formData.taxNumber}
                                            type="text"
                                            placeholder="NIF"
                                            className="currency"
                                            name="taxNumber"
                                            onChange={handleOnChange}
                                        />

                                    </div>


                                    <div className="conversor-moeda-cliente ">

                                        <input
                                            value={formData.birthDate}
                                            type="date"
                                            placeholder="Data Nascimento"
                                            className="currency"
                                            name="birthDate"
                                            onChange={handleOnChange}
                                        />

                                    </div>


                                </div>
                                <div className="conversor-moeda-footer-title">Contactos</div>
                                <div className="conversor-moeda-conteudo-items">

                                    <div className="conversor-moeda-from ">


                                        <input
                                            value={formData.email}
                                            type="email"
                                            placeholder="Email"
                                            className="currency"
                                            name="email"
                                            onChange={handleOnChange}
                                        />

                                    </div>


                                    <div className="conversor-moeda-from ">

                                        <input
                                            value={formData.phonenumber}
                                            type="text"
                                            placeholder="Nº Telemóvel ou Fixe"
                                            className="currency"
                                            name="phonenumber"
                                            onChange={handleOnChange}
                                        />

                                    </div>


                                </div>


                            </div>

                            <div className="conversor-moeda-footer-cliente btn-transacao">
                                <div>
                                    <div className="conversor-moeda-footer-title"></div>

                                </div >


                              

                                        <button 
                                        onClick={operation} 
                                        disabled={!formData.taxNumber}
                                        
                                        className="my-10 btn-primary  btn-operation my-3"
                                        >
                                             Confirmar Operação
                                        </button>
                                        
                                 

                         
                             


                            </div>


                        </div>

                    </div>




                </div>


            </form>



            <Footer />

        </>

    );
};




export default InfosCliente;