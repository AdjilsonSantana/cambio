import React, { ReactInstance } from "react";
import ReactToPrint from "react-to-print";
import Footer from '../Footer';
import { ReactComponent as LogoImage } from '../../core/assets/images/casa_de_câmbio24-logo.svg';
import './styles.scss';
import Navbar from "../../core/components/Navbar";
import { Link } from "react-router-dom";


 var dateFormat = require("dateformat");
  
 let operationInfosCliente:any;
 let rateTaxes: any;
 let operation: any;

// DetailedHTMLProps<ButtonHTMLAttributes<HTMLButtonElement>




class ComponentToPrint extends React.Component {



    
  
    
 constructor(props: any) {
     super(props);

      operation = JSON.parse(localStorage.getItem('dataConverter' || 'dataDatainfosCliente') || '{}');
     //console.log(operation.amount) ;
      operationInfosCliente = JSON.parse(localStorage.getItem('dataDatainfosCliente') || '{}');
 
     //console.log(operationInfosCliente.client.name) ;
      rateTaxes =  operation.operationTypeCode === "C" ? operation.currencyInput.taxRatePurchase :  operation.currencyInput.taxRateSales ;
 
     if (operation.currencyInput.code === "STN") {
         rateTaxes =  operation.operationTypeCode === "C" ? operation.currencyOutput.taxRatePurchase :  operation.currencyOutput.taxRateSales ;
         
     }

    
 }


 


  render() {

    

   
   


    return (
        <>

    


                            
        <div className="recibo" >
        

        <div id="page_1">
        <div id="p1dimg1">
            
            <LogoImage title="CASA DE CÂMBIO24"

        width="80"
        height="70"
        
        className=" p1img1" /> {' '}
                        
        </div>
        <div className="dclr"></div>
        <div id="id1_1">
            <div id="id1_1_1">
                <div>

                </div>
                <p className="p0 ft0">Câmbio 24</p>
                <p className="p1 ft1">Aeroporto Internacional de São Tomé</p>
                <p className="p2 ft1">Código postal: TMS</p>
                <p className="p3 ft1">Contacto: 933 111 233/ 222 111 222</p>
                <p className="p2 ft1">Email: casacambio24@gmail.com</p>
                
                <p className="p4 ft0">OPERAÇÃO -
                    <span className="ft2">ORIGINAL</span>
                </p>
                
                <p className="p5 ft3">Tipo operação:
                    <span className="ft0"> {operation.operationTypeDescription}</span>
                </p>
                <p className="p6 ft3">Moeda:
                    <span className="ft0"> {operation.currencyInput.code}</span>
                </p>
                <p className="p7 ft3">Moeda câmbio:
                    <span className="ft0"> {operation.currencyOutput.code}</span>
                </p>
                <p className="p8 ft0">DATA E ASSINATURAS</p>
                
                
                <p className="p9 ft3">Data: {dateFormat( "dd/mm/yyyy")}</p>
            </div>
            <div id="id1_1_2">
                <p className="p10 ft0">Cliente</p>
                <p className="p11 ft1">Nome: <span>{operationInfosCliente.client.name}</span> <span>{operationInfosCliente.client.lastName}</span> </p>
                {  
                
                    operationInfosCliente.client.name === "Consomidor"  && operationInfosCliente.client.lastName === "Final"
                
                    ? 
                    
                    <p className="p12 ft1">Documento: <span>-------------------------------------</span></p> 

                    :

                    <p className="p12 ft1">Documento: <span>{operationInfosCliente.client.docNumber}</span></p>

                }


                {
                    operationInfosCliente.client.phonenumber === "999999999"

                    ?

                    <p className="p12 ft1">Contacto: <span>----------------------------------------</span></p>

                    :


                    <p className="p12 ft1">Contacto: <span>{operationInfosCliente.client.phonenumber}</span></p>

                }
                
                
                <p className="p13 ft3">Taxa de câmbio:
                    <span className="ft0"> {operation.taxRate} </span>
                </p>
                <p className="p14 ft3">Valor:
                    <span className="ft0"> {operation.amountReceivedWithSymbol}</span>
                </p>
                <p className="p15 ft3">Valor á receber:
                    <span className="ft0"> {operation.amountWithSymbol} </span>
                </p>
            </div>

            

        </div>
        

        <div id="id1_2">
            <table cellSpacing="0"  className="t0">
                <tr>
                    <td className="tr0 td0">
                        <p className="p16 ft4">O OPERADOR</p>
                    </td>
                    <td className="tr0 td1">
                        <p className="p17 ft2">O CLIENTE</p>
                    </td>
                </tr>
                <tr>
                    <td className="tr1 td0">
                        <p className="p18 ft5">
                        ---------------------------------------------------
                        </p>
                    </td>
                    <td className="tr1 td1">
                        <p className="p19 ft6">
                        ---------------------------------------------------
                        </p>
                    </td>
                </tr>
            </table>
            <p className="p20 ft5">
                
            </p>
            
        </div>
        <p>----------------------------------------------------------------------------------------------------------------------------------------------------------</p>
        
        <div id="p1dimg1">
            
            <LogoImage title="CASA DE CÂMBIO24"

        width="80"
        height="70"
        
        className=" p1img1" /> {' '}
                        
        </div>
        <div className="dclr"></div>
        <div id="id1_1">
            <div id="id1_1_1">
                <div>

                </div>
                <p className="p0 ft0">Câmbio 24</p>
                <p className="p1 ft1">Aeroporto Internacional de São Tomé</p>
                <p className="p2 ft1">Código postal: TMS</p>
                <p className="p3 ft1">Contacto: 933 111 233/ 222 111 222</p>
                <p className="p2 ft1">Email: casacambio24@gmail.com</p>
                
                <p className="p4 ft0">OPERAÇÃO -
                    <span className="ft2">DUPLICADA</span>
                </p>
                
                <p className="p5 ft3">Tipo operação:
                    <span className="ft0"> {operation.operationTypeDescription}</span>
                </p>
                <p className="p6 ft3">Moeda:
                    <span className="ft0"> {operation.currencyInput.code}</span>
                </p>
                <p className="p7 ft3">Moeda câmbio:
                    <span className="ft0"> {operation.currencyOutput.code}</span>
                </p>
                <p className="p8 ft0">DATA E ASSINATURAS</p>
                
                
                <p className="p9 ft3">Data: {dateFormat( "dd/mm/yyyy")}</p>
            </div>
            <div id="id1_1_2">
                <p className="p10 ft0">Cliente</p>
                <p className="p11 ft1">Nome: <span>{operationInfosCliente.client.name}  {operationInfosCliente.client.lastName}</span> </p>
                {  
                
                operationInfosCliente.client.name === "Consomidor"  && operationInfosCliente.client.lastName === "Final"
            
                ? 
                
                <p className="p12 ft1">Documento: <span>-------------------------------------</span></p> 

                :

                <p className="p12 ft1">Documento: <span>{operationInfosCliente.client.docNumber}</span></p>

            }


            {
                operationInfosCliente.client.phonenumber === "999999999"

                ?

                <p className="p12 ft1">Contacto: <span>----------------------------------------</span></p>

                :


                <p className="p12 ft1">Contacto: <span>{operationInfosCliente.client.phonenumber}</span></p>

            }
                
                <p className="p13 ft3">Taxa de câmbio:
                    <span className="ft0"> {operation.taxRate} </span>
                </p>
                <p className="p14 ft3">Valor:
                    <span className="ft0"> {operation.amountReceivedWithSymbol}</span>
                </p>
                <p className="p15 ft3">Valor á receber:
                    <span className="ft0"> {operation.amountWithSymbol} </span>
                </p>
            </div>

            

        </div>

        <div id="id1_2">
            <table cellSpacing="0"  className="t0">
                <tr>
                    <td className="tr0 td0">
                        <p className="p16 ft4">O OPERADOR</p>
                    </td>
                    <td className="tr0 td1">
                        <p className="p17 ft2">O CLIENTE</p>
                    </td>
                </tr>
                <tr>
                    <td className="tr1 td0">
                        <p className="p18 ft5">
                        ---------------------------------------------------
                        </p>
                    </td>
                    <td className="tr1 td1">
                        <p className="p19 ft6">
                        ---------------------------------------------------
                        </p>
                    </td>
                </tr>
            </table>
            <p className="p20 ft5">
                
            </p>
            
        </div>

        </div>

        
 

        </div>

</>
    );
  }
}

class Recibo extends React.Component {
  componentRef!: ReactInstance | null;
  render() {
    return (

        <>

        <div>
        
        <ComponentToPrint ref={(el) => (this.componentRef = el)} />
        </div>

        <div  className="text-center">

        <Link to='/registaroperacao' 
           
            type="button"  
            className="btn btn-primary 
            mx-5 btn-voltar"

         
         >
             Voltar!
        </Link>

        <ReactToPrint
          trigger={() => <button type="button"  className="btn mx-5 btn-primary btn-imprimir">IMPRIMIR!</button>}
          content={() => this.componentRef}
          
        />

        </div>

        

        

        </>
     

     
    );
  }
}

export default Recibo;
