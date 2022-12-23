import * as request from "./requester";

const userAPI = 'https://localhost:7156/api/User'

export const login = async (username, password) => {

    try {
        // Pass the username and password to logIn function
        const data = {
            Username: username,
            Password: password
        }
      
        let token = await request.post(`${userAPI}/login`, data, {'content-type': 'application/json'});
        
        if (token) {

            return {
                Username: data.Username,
                Token: token
            };
        }
        
        return false;
        
    } catch (error) {
        throw new Error('Could not Login');
    }

}

export const logout = async (userName) => {
    try {
        console.log(userName);
        
        const data = {
            username: userName
        }
        return await request.post(`${userAPI}/logout`, data, {'content-type': 'application/json'});
        
    } catch (error) {
        console.log(error);
        return false;
    }
};



