import { GetCookie } from '../helpers/utils/cookies';

export default function Post(url, payload) {    
    var request = {
        method: 'POST',
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json',            
            'Access-Control-Allow-Origin': '*',
            'Access-Control-Allow-Methods': 'GET, POST, PATCH, PUT, DELETE, OPTIONS',
            'Access-Control-Allow-Headers': 'Origin, Content-Type, X-Auth-Token',
        },
        body: JSON.stringify(payload)        
    };    

    var session = GetCookie();        
    if (session != null) {
        request.headers.Authorization = `Bearer ${session.token}`
    }    

    return fetch(url, request).then(response => {
        if (!response.ok) {
          throw new Error('Network error');
        }
        return response.json();
      });    
}