import './styles/styles.css';
import LoginForm from './components/LoginForm/LoginForm';
import AppLogo from './components/AppLogo/AppLogo';

function App() {
  return (
    <>
    <div className="blur-overlay"></div>      
    <div className="bacco-main-content">
      <h1 className="anchor-top-left"><AppLogo /></h1> 
      <LoginForm titleText="Acesso" loginFieldText="E-mail: " passwordFieldText="Senha: " loginButtonText="Entrar" signUpButtonText="Cadastre-se!" showOAuth="false"/>
    </div>      
    </>
  );
}

export default App;
