import logo from './logo.svg';
import './App.css';
import LoginForm from './components/LoginForm';

function App() {
  return (
    <>
    <div className="blur-overlay"></div>  
    <div className="bacco-main-content">
      <h1 className="anchor-top-left">Bem-vindo ao Bacco!</h1>      
      <LoginForm />
    </div>      
    </>
  );
}

export default App;
