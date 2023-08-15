const defaultTokenName = "__token__bacco__v1";
const defaultTokenTimeout = 2 * 60 * 60 * 1000;

export function SetCookie (json) {
    const expires = new Date();
    expires.setTime(expires.getTime() + defaultTokenTimeout);
    const cookieValue = encodeURIComponent(JSON.stringify(json));
    document.cookie = defaultTokenName + '=' + cookieValue;
}

export function GetCookie() {
    const cookieName = defaultTokenName + '=';
    const cookieArray = document.cookie.split(';');
    
    for (let i = 0; i < cookieArray.length; i++) {
      let cookie = cookieArray[i].trim();
      
      if (cookie.indexOf(cookieName) === 0) {
        const encodedJson = cookie.substring(cookieName.length, cookie.length);
        const json = JSON.parse(decodeURIComponent(encodedJson));
        return json;
      }
    }
    
    return null;
  }

  