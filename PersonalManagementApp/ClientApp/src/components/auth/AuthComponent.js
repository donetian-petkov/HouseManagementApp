import {useContext, useState} from "react";
import './AuthComponent.css';
import {useNavigate} from "react-router-dom";
import * as authService from "../../services/authService";
import {UserContext} from "../../contexts/userContext";
import {Login} from "./Login";

export const AuthComponent = (props) => {

/*
    const [authMode, setAuthMode] = useState("signin");
*/
    const [errors, setErrors] = useState({});


    const { userLogin } = useContext(UserContext);
    const navigate = useNavigate();

    const [values, setValues] = useState({
        username: '',
        password: '',
    });

    const submitHandler = (e) => {

        e.preventDefault();

      /*  if (authMode === 'signin') { */

            authService.login(values.username, values.password)
                .then(authData => {
                    userLogin(authData);
                    navigate('/');
                })
                .catch(() => {
                    navigate('/PageNotFound');
                });


       /* } else if (authMode === 'signup') {

            authService.register(values.username, values.email, values.password)
                .then(authData => {
                    userLogin(authData);
                    navigate('/');
                })
                .catch(() => {
                    navigate('/PageNotFound');
                });
        }*/

    };

    const changeHandler = (e) => {
        setValues(state => ({
            ...state,
            [e.target.name]: e.target.value
        }));
    };

    /*const changeAuthMode = () => {
        setAuthMode(authMode === "signin" ? "signup" : "signin");
    };*/

    const empty = (e) => {

        setErrors(oldValues => ({
            ...oldValues,
            [e.target.name]: values[e.target.name].length === 0
        }));

    };



    /*if (authMode === "signin") {*/
        return (
            <div className="Auth-form-container">
                <Login changeHandler={changeHandler}
                       submitHandler={submitHandler}
                       /*changeAuthMode={changeAuthMode}*/
                       values={values}
                       errors={errors}
                       empty={empty}
                />
            </div>
        )
    /*}*/

    /*return (
        <div className="Auth-form-container">
            <Register changeHandler={changeHandler}
                      submitHandler={submitHandler}
                      changeAuthMode={changeAuthMode}
                      values={values}
                      errors={errors}
                      empty={empty}
            />
        </div>
    )*/

}
