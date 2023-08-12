import React, { useState } from 'react';
import SignUpForm from '../SignUpForm/SignUpForm';
import classes from './LoginForm.module.css'

function LoginForm(props) {
    const [signUpOpen, setSignUpOpen] = useState(false);
    const openModal = () => {
        setSignUpOpen(true);
      };
    
      const closeModal = () => {
        setSignUpOpen(false);
      };
    return (       
        <>        
        <div className={classes.loginForm}>
            <h3 className={classes.formTitle}>{props.titleText}</h3> 
            
                <form className={classes.leftAlignedForm} action='/login' method='post'>
                    <div>
                        <label for="email">{props.loginFieldText}</label>
                        <input type="email" id="email" name="email" required></input>
                        <label for="senha">{props.passwordFieldText}</label>
                        <input type="password" id="senha" name="senha" required></input>
                        <button type="button">{props.loginButtonText}</button>
                        <button type="submit" onClick={openModal}>{props.signUpButtonText}</button>                        
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

