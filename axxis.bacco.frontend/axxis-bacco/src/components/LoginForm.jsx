import './LoginForm.css';

function LoginForm() {
    return (       
        <>
        <h1 className="anchor-top-left">Bem-vindo ao Bacco!</h1> 
        <div className="login-form">
            <h3 className="form-title">Login</h3> 
            
                <form className="left-aligned-form" action='/login' method='post'>
                    <div>
                        <label for="email">Email:</label>
                        <input type="email" id="email" name="email" required></input>
                        <label for="senha">Senha:</label>
                        <input type="password" id="senha" name="senha" required></input>
                        <button type="submit">Login</button>
                        <button type="submit">Cadastre-se</button>
                    </div>
                </form>
            
        </div>        
        </> 
    );
}

export default LoginForm;

