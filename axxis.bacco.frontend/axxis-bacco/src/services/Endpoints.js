export const apiUrl = "https://localhost:7019"; // tornar dinamico
const ENDPOINTS = {
    login: {
        authenticate: `${apiUrl}/api/Login/authenticate`
    },
    usuario: {
        signUp: `${apiUrl}/api/Usuario/signup`,
        getRoles: `${apiUrl}/api/Usuario/getroles`
    }
} 

export default ENDPOINTS;