import React from 'react';
import './styles.scss';
import { ReactComponent as ArrowIcon } from '../../assets/images/arrow.svg';


type Props = {
    text?: string;
}

const ButtonIconLogin = ({ text }: Props) => {

    return (

    <>

        <div className="d-flex">
            <button className="btn btn-primary btn-icon-login">
                <h5>{text}</h5>
            </button>

             
            <div className="btn btn-icon-content">
                <ArrowIcon />
            </div>

        

        </div>

    </>
);

 
};


export default ButtonIconLogin;