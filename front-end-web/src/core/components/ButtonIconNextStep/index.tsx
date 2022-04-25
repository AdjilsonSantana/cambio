import React from 'react';
import './styles.scss';
import { ReactComponent as ArrowIcon } from '../../assets/images/arrow.svg';


type Props = {
    text?: string;
}

const ButtonIconNextStep = ({ text }: Props) => {

    return (

    <>

        <div className="d-flex">
            <button className="btn btn-primary btn-continuar">
                <h6>{text}</h6>
            </button>

             
            <div className="btn btn-icon-content">
                <ArrowIcon />
            </div>

        

        </div>

    </>
);

 
};


export default ButtonIconNextStep;