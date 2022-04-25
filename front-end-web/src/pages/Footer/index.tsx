import './styles.scss';
import { ReactComponent as YoutubeIcon } from './youtube.svg';
import { ReactComponent as LinkedinIcon } from './linkedin.svg';
import { ReactComponent as InstagramIcon } from './instagram.svg'
import { Link, NavLink } from 'react-router-dom';

var dateFormat = require("dateformat");

function Footer() {
    return (
        <footer className="main-footer pt-2">

            

                
                <div className=" dev-staff ">
                    ©  {dateFormat( "yyyy")} CÂMBIO24 | DESENVOLVIDO POR <Link to="/" target="_new" >  <span className="link-dev"> &nbsp; STP-SANTECH</span> </Link>
                 </div>


       
          
           

        </footer>

    );
}


export default Footer;