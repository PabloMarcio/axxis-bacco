import ENDPOINTS from '../Endpoints';
import Post from '../BaseRequest';

const UsuarioAPI = {
    signUp: (param) => {
        return Post(ENDPOINTS.usuario.signUp, param);
    },
    getRoles: (param) => {
        return Post(ENDPOINTS.usuario.getRoles, param);
    }
};

export default UsuarioAPI;