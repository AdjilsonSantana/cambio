import React from 'react';
import './styles.scss';
import { ReactComponent as MainImage } from '../../core/assets/images/casa_de_cambio24.svg';
import { Link } from 'react-router-dom';
import Footer from '../Footer';
import NavbarHomeLogin from '../../core/components/NavbarHomeLogin';





const Home = () => {

    

    return (

        

        <>

        <NavbarHomeLogin/>
            <div className="home-container">
                <div className=" row home-content card-base border-radius-20">
                    <div className="col-6 home-text">
                        <h2 className="text-title">Uso exclusivo! </h2>
                        <p className="text-subtitle">
                            Faça o login para ter acesso as funcionalidades do sistema.
            </p>



                      


                    </div>
                    <div className="col-6">
                        <MainImage className="main-image" />

                    </div>

                </div>


            </div>

           

            
            <Footer />
     
            
           
        </>
    );

}



export default Home;