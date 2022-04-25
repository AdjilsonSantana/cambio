import React from 'react';
import { BrowserRouter, Switch, Route, Redirect } from 'react-router-dom';
import Navbar from './core/components/Navbar';
import Auth from './pages/Auth';
import RegistOperacao from './pages/RegistOperacao/converter';
import Home from './pages/Home';
import InfosCliente from './pages/InfosCliente';
import Recibo from './pages/ReciboCambio';
import history from './core/utils/history'
import NavbarHomeLogin from './core/components/NavbarHomeLogin';
import HomewithSession from './pages/HomewithSession';




const Routes = () => (

    <BrowserRouter>
        
        <Switch>
            <Route path="/" exact>
                <Home />
            </Route>
            <Route path="/homeSession" >
                <HomewithSession/>
            </Route>
            
            <Route path="/registaroperacao" exact >
                <RegistOperacao />
            </Route>
            <Route path="/infoscliente" >
                <InfosCliente/>
            </Route>
            <Redirect from="/auth" to="/auth/login" exact />
            <Route path="/auth">
                <Auth />
            </Route>
            <Route path="/recibocambio" >
               <Recibo/>
            </Route>


        </Switch>

    </BrowserRouter>
)





export default Routes;