import axios, {Method} from 'axios';

import qs from 'qs';
import { getSessionData } from './auth';

type RequestParams = {
    method?: Method;
    url:string;
    data?: object | string;
    params?: object;
    headers?: object;
    
}

type LoginData = {

    email: string;
    username: string;
    password: string;
}



  //const BASE_url =  'https://localhost:5001/api/v1';
  
  const BASE_url =  'https://cambio24.azurewebsites.net/api/v1';






export const makeRequest = ({method ='GET', url, data, params, headers} : RequestParams) =>{

  
    return axios({
        method,
        url: `${BASE_url}${url}`,
        data,
        params,
        headers
        
        
    });
}


export const makePrivateRequest = ({method ='GET', url, data, params} : RequestParams) => {

    const sessionData = getSessionData();

    const headers = {
        
        'Authorization' : `Bearer ${sessionData.token}`
    }


    return makeRequest({method, url, data, params, headers })
}

export  const makeLogin = (loginData: LoginData) => {

    const payload = qs.stringify({...loginData});
    return makeRequest({ url: '/auth', data: payload,  method: 'POST' });
}