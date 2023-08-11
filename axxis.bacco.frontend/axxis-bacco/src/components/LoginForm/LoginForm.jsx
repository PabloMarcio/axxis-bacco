import classes from './LoginForm.module.css'

function LoginForm(props) {
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
                        <button type="submit">{props.loginButtonText}</button>
                        <button type="submit">{props.signUpButtonText}</button>                        
                    </div>                    
                </form>            
        </div> 
        {showOAuth(props.showOAuth)}               
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

