import * as request from "./requester";

const userAPI = 'https://localhost:7156/api/User'

export const login = async (username, password) => {

    try {
        // Pass the username and password to logIn function
        const data = {
            Username: username,
            Password: password
        }
      
        const token = await request.post(`${userAPI}/login`, data, {'content-type': 'application/json'});
        
        const isAdminData = await isAdmin(username);
        
        if (token) {

            return {
                Username: data.Username,
                Token: token,
                IsAdmin: isAdminData
            };
        }
        
        return false;
        
    } catch (error) {
        throw new Error('Could not Login');
    }

}

export const logout = async (userName) => {
    try {
        const data = {
            username: userName
        }
        return await request.post(`${userAPI}/logout`, data, {'content-type': 'application/json'});
        
    } catch (error) {
        console.log(error);
        return false;
    }
};

export const isAdmin = async (userName) => {
    try {
        const data = {
            username: userName
        }
        
        return await request.post(`${userAPI}/isAdmin`, data, {'content-type': 'application/json'});

    } catch (error) {
        console.log(error);
        return false;
    }
};


