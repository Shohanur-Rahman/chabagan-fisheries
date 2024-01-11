import { IUserResponse } from "../interfaces/IUserResponse"; 
import { FC, ReactNode } from "react";
import { Navigate } from "react-router-dom";
import { useAppSelector } from "../redux/app/hooks"; 
import { selectUser } from "../redux/features/auth/authSlice"; 

interface Props {
    children: ReactNode
}
const PublicRouteGuard: FC<Props> = ({ children }) => {
    const user: IUserResponse = useAppSelector(selectUser);

    if (!user) {
        return children;
    } else {
        // Redirect to the login page or any other appropriate page for unauthenticated users
        return <Navigate to="/" />;
    }
}

export default PublicRouteGuard;
