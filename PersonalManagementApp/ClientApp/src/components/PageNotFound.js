import {Link} from "react-router-dom";

export const PageNotFound = () => {

    return (
        <div>
            <img src={PageNotFound}  />
            <p style={{textAlign:"center"}}>
                <Link to="/">Go to Home </Link>
            </p>
        </div>
    )

}