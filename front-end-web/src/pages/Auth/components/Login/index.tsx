import React, { useState }  from 'react';
import AuthCard from '../Card';
import './styles.scss';
import { useForm } from 'react-hook-form';
import { makeRequest } from '../../../../core/utils/request';
import { saveSessionData } from '../../../../core/utils/auth';
import { useHistory } from 'react-router';
import Navbar from '../../../../core/components/NavbarHomeLogin';
import NavbarHomeLogin from '../../../../core/components/NavbarHomeLogin';

type FormData = {
    email: string;
    username: string;
    password: string;
}




const Login = () => {

    
    const {register, handleSubmit } = useForm<FormData>();
    const [hasError, setHasError] = useState(false);
    const history = useHistory();
    const onSubmit = (data: FormData) => {
        //console.log(data);
        //makeLogin(data);
        
        makeRequest({ url: '/auth', method: 'POST', data })
        .then(response => {
            setHasError(false);
            saveSessionData(response.data);
            
          
            console.log(response.data.success)
            if (response.data.success)
            history.replace('/homeSession')
            else
            history.push('/')    
            
            
     
        }
        
        
        )
        
        .catch(() => {
            setHasError(true);
        })

        
     
            

    }
    
      return (

        


        <>

        
        <AuthCard title="login">
         
            <form className="login-form"  onSubmit={handleSubmit(onSubmit)} >
                <div className="margin-bottom-30">
                       <div className="invalid-feedback d-block">
                            *
                        </div>
                    <input
                        
                        type="email"
                        className={"form-control input-base  currency-login"}
                        placeholder="Email"
                        
                        //{...register('email')}
                        {...register('email', { required: true })}

                        
                       
                    />
                    <div className="invalid-feedback d-block">
                            *
                    </div>
                  
                </div>
                <div className="margin-bottom-30">


                    <input
                        type="password"
                        className={"form-control input-base currency-login "}
                        placeholder="Senha"
                        
                        //{...register('password')}
                        {...register('password', { required: true })}
                      
                        
                        
                    />                              

                </div>
             
                <div className="login-submit">
                    <button 
                    className="my-10 btn-primary btn botao-login" 
                    

                    > 
                    Iniciar sessão

                    </button>
                </div>

               
            </form>
              
        </AuthCard>

        </>
    )
}

export default Login;