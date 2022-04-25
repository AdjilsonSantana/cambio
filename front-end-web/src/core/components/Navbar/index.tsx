import React from 'react';
import './styles.scss';
import { Link, NavLink, useLocation } from 'react-router-dom';
import { ReactComponent as LogoImage } from '../../assets/images/casa_de_câmbio24-logo.svg';
import { logout } from '../../utils/auth';

import { useHistory } from 'react-router';



const Navbar = () => {


    const history = useHistory();

    //const  [currentUser, setCurrentUser]  = useState('');
    

    //console.log(user.user.email);
/*
    const [formData, setFormData] = useState<FormState>({
        currentUser: ''
    });

    */

    //const  [currentUser, setCurrentUser]  = useState('');
    //const location = useLocation();


    


        //var user = JSON.parse(localStorage.getItem('authData') || '{}');
    


    var user = JSON.parse(localStorage.getItem('') || '{}');
    var usero = JSON.parse(localStorage.getItem('authData') || '{}');
    console.log(usero.user.email)
    
     //const email='';
     //const currentUser = user.user.email;;

     /*
     if (user !== null && user.user.email !== undefined ?  user.user.email : '') {
        currentUser = user.user.email;
     }
    

     */

     //currentUser = user.user.email;
    //const currentUser = 'mari@gmail.com'

       
    
    
    const handleLogout = (event: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
        event.preventDefault();
        logout();
          history.push ('/auth/login');
          

    }

    

    return (

        

    <nav className="row  main-nav">
    <div className="col-2">
        <Link to="/homeSession" className="nav-logo-text link-nav d-inline-block align-top">
            <LogoImage title="CASA DE CÂMBIO24"

                width="60"
                height="70"
                className=" " /> {' '}
            CÂMBIO24
        </Link>

    </div>

     <div className="col-6 main-menu-nav  ">
        <ul className="main-menu">
            <li>
                <NavLink to="/homeSession" activeClassName="active" className="link-menu" exact>
                    ÍNICIO
                </NavLink>
            </li>
           
            <li>
                <NavLink to="/registaroperacao" className="link-menu" >
                    REGISTAR OPERAÇÃO
                </NavLink>
            </li>
          

          



        </ul>
    </div> 

    <div className="col text-right ">


            
             {/*
                user  && (
                    <Link to="/auth/login" className="nav-link active ">
                    LOGIN
                </Link> 
                )
            }


            {
                !usero && (
                    <>   


        
                            
                            <Link to="/"
                             className="nav-link active d-inline"
                             onClick={handleLogout}
                             
                             >
                                LOGOUT
                
                            </Link>
                      </>
               
    

                )
                */ }


                    <>
{/* 
                    <Link to="/homeSession" className="nav-link active d-inline link-menu" >
                                INÍCIO
                    </Link>

                    <Link to="/conversor" className="nav-link active d-inline link-menu" >
                                REGISTAR OPERAÇÃO
                    </Link> */}

                    {
                         !localStorage.getItem('authData') &&
                           <Link to="/auth/login" className="nav-link active d-inline">
                                Inciar Sessão
                            </Link>

                    }

                 
  


                    </>


                    <>
                    
                    {   localStorage.getItem('authData') &&
                          
                                (
                                
                                         <>
                                          { <span className="seesion_email">{usero.user.email }</span>}
                                            <Link to="/"
                                            className="nav-link d-inline"
                                            onClick={handleLogout}
                                    
                                             >
                                               TERMINAR SESSÃO
                        
                                         </Link>

                                    </>
                            )}


                    </>
     
               
                   
           

               
                 

              

                

                
                
            </div>

        </nav>


    )

}


export default Navbar;

