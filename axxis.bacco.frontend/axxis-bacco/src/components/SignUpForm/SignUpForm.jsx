import React, { useState } from 'react';
import DateInput from '../DateInput/DateInput'
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-modal';
import classes from './SignUpForm.module.css';
import mainClasses from '../../styles/styles.css';
import UsuarioAPI from '../../services/Usuario';
import CompleteDateTimeString from '../../helpers/utils/dateTimeFormatter';


Modal.setAppElement('#root');

const SignUpForm = ({ isOpen, onClose }) => {
    const [formName, setFormName] = useState('');
    const [formEmail, setFormEmail] = useState('');
    const [formBirthday, setFormBirthday] = useState('');
    const [formCpf, setFormCpf] = useState('');
    const [formTelephone, setFormTelephone] = useState('');
    const [formAddress, setFormAddress] = useState('');
    const [formPassword, setFormPassword] = useState('');
    const [formPasswordConfirmation, setFormPasswordConfirmation] = useState('');

    function nameChangeHandler(event) {
        setFormName(event.target.value);
    }

    function emailChangeHandler(event) {
        setFormEmail(event.target.value);
    }

    function birthdayChangeHandler(date) {
        setFormBirthday(date);
    }

    function cpfChangeHandler(event) {
        setFormCpf(event.target.value);
    }
    
    function telephoneChangeHandler(event) {
        setFormTelephone(event.target.value);
    }

    function addressChangeHandler(event) {
        setFormAddress(event.target.value);
    }

    function passwordChangeHandler(event) {
        setFormPassword(event.target.value);
    }

    function passwordConfirmationChangeHandler(event) {
        setFormPasswordConfirmation(event.target.value);
    }

    function clearForm() {
        setFormName('');
        setFormEmail('');
        setFormBirthday('');
        setFormCpf('');
        setFormTelephone('');
        setFormAddress('');
        setFormPassword('');
        setFormPasswordConfirmation('');        
    }

    function signupButtonClickHandler() {
        var payload = {
            name: formName,
            birthday: new Date(formBirthday).toISOString(),
            email: formEmail,
            password: formPassword,
            passwordConfirmation: formPasswordConfirmation,
            cpf: formCpf,
            telephone: formTelephone,
            address : formAddress
          };

          UsuarioAPI.signUp(payload)
            .then(response => {
                if (response.ok == false) {
                    alert(`Não foi possível realizar o seu cadastro. Motivo: ${response.message}`);    
                    return;
                }
                alert("Cadastro realizado com sucesso, bem-vindo(a) ao Bacco");
                clearForm();
            })
            .catch(error => {
                alert(`Ocorreu um erro ao cadastrar. Erro -> ${error}`);
            });
    }

    return (
        <Modal
        isOpen={isOpen}
        onRequestClose={onClose}
        contentLabel="Cadastro"
        className={classes.modal}
        overlayClassName={classes.overlay}
        >      
        <h2>Cadastro</h2>
        <form className={`${mainClasses.leftAlignedForm} container`}>
            <div className="row">
                <div className="col-md-6">
                <label htmlFor="nome">Nome:</label>
                <input type="text" id="nome" name="nome" className="form-control" required onChange={nameChangeHandler} />
                </div>
                <div className="col-md-6">
                <label htmlFor="email">E-mail:</label>
                <input type="email" id="email" name="email" className="form-control" required onChange={emailChangeHandler} />
                </div>
            </div>
            <div className="row">
                <div className="col-md-6 vcenter">
                <label htmlFor="birthday">Aniversário:</label>   
                <br/>             
                <DateInput 
                    value={formBirthday} 
                    startdate={formBirthday} 
                    onChange={birthdayChangeHandler} 
                    id="birthday" 
                    name="birthday" 
                    type="date"
                />                    
                </div>
                <div className="col-md-6">
                <label htmlFor="cpf">CPF:</label>
                <input type="text" id="cpf" name="cpf" className="form-control" onChange={cpfChangeHandler}/>
                </div>
            </div>
            <div className="row">
                <div className="col-md-6">
                <label htmlFor="telephone">Telefone:</label>
                <input type="text" id="telephone" name="telephone" className="form-control" onChange={telephoneChangeHandler}/>
                </div>
                <div className="col-md-6">
                <label htmlFor="address">Endereço:</label>
                <input type="text" id="address" name="address" className="form-control" onChange={addressChangeHandler}/>
                </div>
            </div>
            <div className="row">
                <div className="col-md-6">
                <label htmlFor="password">Senha:</label>
                <input type="password" id="password" name="password" className="form-control" required onChange={passwordChangeHandler}/>
                </div>
                <div className="col-md-6">
                <label htmlFor="passwordConfirm">Confirme a senha:</label>
                <input type="password" id="passwordConfirm" name="passwordConfirm" className="form-control" required onChange={passwordConfirmationChangeHandler}/>
                </div>
            </div>
            <div className="row">
                <div className="col-md-12 text-center mt-3">
                    <button type="button" className={classes.roundButtonWithMargin} onClick={signupButtonClickHandler}>Cadastrar</button>
                    <button type="button" className={classes.roundButtonWithMargin} onClick={onClose}>Registrar depois</button>
                </div>            
            </div>
        </form>      
        </Modal>
    );
};

function close(props) {
    props.isOpen = false;
}

export default SignUpForm;