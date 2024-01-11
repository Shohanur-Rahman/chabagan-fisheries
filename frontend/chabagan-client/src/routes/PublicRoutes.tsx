import { IRouteConfig } from "../interfaces/IRouteConfig";
import SignIn from "../pages/auth/SignIn"; 
import KeyIcon from '@mui/icons-material/Key';

const publicRoutes: IRouteConfig[] = [
    {
        path: '/SignIn',
        element: <SignIn />,
        sidebarProps: {
            displayText: "Sign In",
            icon: KeyIcon
        }
    }
]

export default publicRoutes;