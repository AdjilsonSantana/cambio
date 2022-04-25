import React from 'react';
import './styles.scss';
import { ReactComponent as AuthImage } from './../../core/assets/images/auth.svg';
import { Route, Switch } from 'react-router-dom';
import Login from './components/Login';
import Footer from '../Footer';
import Navbar from '../../core/components/NavbarHomeLogin';
import NavbarHomeLogin from '../../core/components/NavbarHomeLogin';



const Auth = () => {

    return (

        <>

        <NavbarHomeLogin/>
             <div className="auth-container">
            <div className="auth-info">
              {/*   <h1 className="auth-info-title">
                Faça Câmbio <br />da melhor forma!
                </h1>
                <p className="auth-info-subtitle">
                Ajudaremos você a encontrar o melhor câmbio<br /> para sua transação com cotação em tempo real.
                </p> */}
                <p>
                    <br />
                    <br />
                    <br />
                    <br />
                </p>
                <AuthImage />
            </div>
            <div className="auth-content">
                <Switch>
                    <Route path="/auth/login">
                       <Login/>
                    </Route>
                   
                </Switch>
            </div>
    
    
        </div>
    
        
        <Footer/>
        </>
       );

};

  





export default Auth;