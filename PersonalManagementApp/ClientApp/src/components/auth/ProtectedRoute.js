import {
    Navigate,
    Outlet,
} from 'react-router-dom';

export const ProtectedRoute = ({
                            user,
                            redirectPath = '/login',
                            children,
                        }) => {

    if (!user || Object.keys(user).length === 0) {
        return <Navigate to={redirectPath} replace />;
    }

    return children ? children : <Outlet />;
};