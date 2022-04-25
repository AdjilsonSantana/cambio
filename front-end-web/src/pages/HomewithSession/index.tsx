import React from 'react';
import './styles.scss';
import { ReactComponent as MainImage } from '../../core/assets/images/casa_de_cambio24.svg';
import { Link } from 'react-router-dom';
import Footer from '../Footer';

import Navbar from '../../core/components/Navbar';





const Home = () => {

    

    return (

        

        <>

        <Navbar/>
            <div className="home-container">
                <div className=" row home-content card-base border-radius-20">
                    <div className="col-6 home-text">
                        <h2 className="text-title">Bem-vindo! </h2>
                   {/*      <p className="text-subtitle">
                            Ajudaremos você a encontrar o melhor câmbio para sua transação com cotação em tempo real.
            </p> */}



                      


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