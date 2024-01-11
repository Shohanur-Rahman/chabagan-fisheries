import { IRouteConfig } from "../interfaces/IRouteConfig";
import SignInSide from "../components/auth/SignInSide";
import KeyIcon from '@mui/icons-material/Key';

const publicRoutes: IRouteConfig[] = [
    {
        path: '/SignIn',
        element: <SignInSide />,
        sidebarProps: {
            displayText: "Sign In",
            icon: KeyIcon
        }
    }
]

export default publicRoutes;