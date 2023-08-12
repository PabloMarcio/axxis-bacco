import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-modal';
import classes from './SignUpForm.module.css';
import mainClasses from '../../styles/styles.css';

Modal.setAppElement('#root');

const SignUpForm = ({ isOpen, onClose }) => {
    

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
                <input type="text" id="nome" name="nome" className="form-control" required />
                </div>
                <div className="col-md-6">
                <label htmlFor="email">E-mail:</label>
                <input type="email" id="email" name="email" className="form-control" required />
                </div>
            </div>
            <div className="row">
                <div className="col-md-6">
                <label htmlFor="birthday">Aniversário:</label>
                <input type="text" id="birthday" name="birthday" className="form-control" required />
                </div>
                <div className="col-md-6">
                <label htmlFor="cpf">CPF:</label>
                <input type="text" id="cpf" name="cpf" className="form-control" />
                </div>
            </div>
            <div className="row">
                <div className="col-md-6">
                <label htmlFor="telephone">Telefone:</label>
                <input type="text" id="telephone" name="telephone" className="form-control" />
                </div>
                <div className="col-md-6">
                <label htmlFor="address">Endereço:</label>
                <input type="text" id="address" name="address" className="form-control" />
                </div>
            </div>
            <div className="row">
                <div className="col-md-6">
                <label htmlFor="password">Senha:</label>
                <input type="password" id="password" name="password" className="form-control" required />
                </div>
                <div className="col-md-6">
                <label htmlFor="passwordConfirm">Confirme a senha:</label>
                <input type="password" id="passwordConfirm" name="passwordConfirm" className="form-control" required />
                </div>
            </div>
            <div className="row">
                <div className="col-md-12 text-center mt-3">
                    <button type="button" className={classes.roundButtonWithMargin}>Cadastrar</button>
                    <button type="button" className={classes.roundButtonWithMargin}>Registrar depois</button>
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