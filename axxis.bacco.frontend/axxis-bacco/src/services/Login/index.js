import ENDPOINTS from '../Endpoints';
import Post from '../BaseRequest';

const LoginAPI = {
    authenticate: (param) => {
        return Post(ENDPOINTS.login.authenticate, param);
    }
};

export default LoginAPI;

