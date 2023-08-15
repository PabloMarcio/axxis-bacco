import React, { useState } from 'react';
import SignUpForm from '../SignUpForm/SignUpForm';
import classes from './LoginForm.module.css'
import LoginAPI from '../../services/Login';

function LoginForm(props) {
    const [signUpOpen, setSignUpOpen] = useState(false);
    const [currentEmail, setCurrentEmail] = useState('');
    const [currentPassword, setCurrentPassword] = useState('');
    const openModal = () => {
        setSignUpOpen(true);
      };
    
      const closeModal = () => {
        setSignUpOpen(false);
      };

    const onEmailChangeHandler = (event) => {
        setCurrentEmail(event.target.value);
    };

    const onPasswordChangeHandler = (event) => {
        setCurrentPassword(event.target.value);
    };

    const onLoginButtonClickHandler = (event) => {
        var payload = {
            username: currentEmail,
            password: currentPassword
        };

        LoginAPI.authenticate(payload)
            .then(response => {
                if (response.ok == false) {
                    alert(response.message);
                    return;
                }
                alert('Login successful, check console');
                console.log(response);
            })
            .catch(error => {
                alert('Error on login, check console');
                console.log(error);
            })
    };

    return (       
        <>        
        <div className={classes.loginForm}>
            <h3 className={classes.formTitle}>{props.titleText}</h3> 
            
                <form className={classes.leftAlignedForm} >
                    <div>
                        <label htmlFor="email">{props.loginFieldText}</label>
                        <input type="email" id="email" name="email" required onChange={onEmailChangeHandler}></input>
                        <label htmlFor="senha">{props.passwordFieldText}</label>
                        <input type="password" id="senha" name="senha" required onChange={onPasswordChangeHandler}></input>
                        <button type="button" onClick={onLoginButtonClickHandler}>{props.loginButtonText}</button>
                        <button type="button" onClick={openModal}>{props.signUpButtonText}</button>                        
                    </div>                    
                </form>            
        </div>         
        {showOAuth(props.showOAuth)}               
        <SignUpForm isOpen={signUpOpen} onClose={closeModal} />
        </> 
    );
}

function showOAuth(show) {
    if (show == "true") {
        return (
            <div className={classes.loginForm}>
                <h3 className={classes.formTitle}>Ou se preferir...</h3> 
                <div className={classes.loginFacebook}></div>
                <div className={classes.loginGoogle}></div>
            </div>
        );
    }
    else {
        return (
            <></>
        );
    }
}

export default LoginForm;

