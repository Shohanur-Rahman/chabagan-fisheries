import { IRouteConfig } from "../interfaces/IRouteConfig";
import SignIn from "../pages/auth/SignIn"; 

const publicRoutes: IRouteConfig[] = [
    {
        path: '/SignIn',
        element: <SignIn />
    }
]

export default publicRoutes;