import {toast, ToastContainer} from "react-toastify";

export const Login = ({
                          submitHandler,
                          changeHandler,
                          values,
                          changeAuthMode,
                          errors,
                          empty
}) => {

    return (
        <form className="Auth-form" onSubmit={submitHandler}>
            <div className="Auth-form-content">
                <h3 className="Auth-form-title">Login</h3>
                <div className="text-center">
                    Not registered yet?{" "}
                    <span className="link-primary" onClick={changeAuthMode}>
                Sign Up
              </span>
                </div>
                <div className="form-group mt-3">
                    <label>Username</label>
                    <input
                        type="text"
                        className="form-control mt-1"
                        placeholder="Enter username"
                        name='username'
                        value={values.username}
                        onChange={changeHandler}
                        onBlur={(e) => empty(e)}
                    />
                    {
                        errors.username &&
                        <p className="error" style={{color: "red"}}> The field can not be empty! </p>
                    }

                </div>
                <div className="form-group mt-3">
                    <label>Password</label>
                    <input
                        type="password"
                        className="form-control mt-1"
                        placeholder="Enter password"
                        name='password'
                        value={values.password}
                        onChange={changeHandler}
                        onBlur={(e) => empty(e)}
                    />
                    {
                        errors.password &&
                        <p className="error" style={{color: "red"}}> The field can not be empty! </p>
                    }
                </div>
                <div className="d-grid gap-2 mt-3">
                    <button type="submit" className="btn btn-primary">
                        Submit
                    </button>
                </div>
            </div>
        </form>

    )

}