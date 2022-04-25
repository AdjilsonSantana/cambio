import jwtDecode from 'jwt-decode';
import history from './history'

export const CLIENT_ID = '';
export const CLIENT_SECRET = '';

type LoginResponse = {


           user : { 
            id: number;
            username: string;
            email: string;
            password: string;
            avatar: string;
            role: string;
            createdAt: string;
            updatedAt: string
        }
        token: string;
        firstAccess: string;
        employeeId: number;
        success: string;
         message: string;
    
}


type ConverterResponse = {

         CurrencyInput: {
            id: number;
            code: string;
            taxRate: number;
            taxRatePurchase: number;
            taxRateSales: number;
            name: string;
            balance: number;
            symbol: string;
            createdAt: Date;
            updatedAt: Date;
            rateName: string
        }
    
      CurrencyOutput :{
            id: number;
            code: string;
            taxRate: number;
            taxRatePurchase: number;
            taxRateSales: number;
            name: string;
            balance: number;
            symbol: string;
            createdAt: Date;
            updatedAt: Date;
            rateName: string
        }
    
     
            amount: number;
            amountReceived: number;
            operationTypeCode: string;
            success: boolean;
            message: string;
        
    
    }
    
    
    type InfosClienteResponse = {

         Client : {
            id: number;
            name: string;
            lastName: string;
            address: string;
            email: string;
            birthDate: Date;
            phonenumber: string;
            taxNumber: string;
            docNumber: string;
            documentTypeId: number;
            documentType?: any;
            employeeId: number;
            employee?: any;
            createdAt: Date;
            updatedAt: Date
        }
    
 
    
    }
    



    type AcessToken = {

    
        
        user : { 
            id: number;
            username: string;
            email: string;
            password: string;
            avatar: string;
            role: string;
            createdAt: string;
            updatedAt: string
        }
        
        }





export const saveSessionData = (loginResponse: LoginResponse) => {
    localStorage.setItem('authData', JSON.stringify(loginResponse));
    sessionStorage.setItem('authData', JSON.stringify(loginResponse));
}

export const getSessionData = () => {

    const sessionData = localStorage.getItem('authData') ?? '{}';
    const parsedSessionData = JSON.parse(sessionData);
    
    return parsedSessionData as LoginResponse;
}


export const getAcessTokenDecoded = (acessToken: AcessToken) => {

    const sessionData = localStorage.getItem('authData') ?? '{}';
    
    

}


export const saveSessionDataConverter = (converterResponse: ConverterResponse) => {
        localStorage.setItem('dataConverter',JSON.stringify(converterResponse));
}

export const saveSessionDatainfosCliente = (infosClienteResponse: InfosClienteResponse) => {
    localStorage.setItem('dataDatainfosCliente',JSON.stringify(infosClienteResponse));
}





export const logout = () => {

  

    
    localStorage.clear();


    
}