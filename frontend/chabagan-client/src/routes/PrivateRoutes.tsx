import { IRouteConfig } from "../interfaces/IRouteConfig";
import Dashboard from "../pages/dashboard/Dashboard";
import DashboardIcon from '@mui/icons-material/Dashboard';
import FishSetup from "../pages/setup/FishSetup";
import Setup from "../pages/setup/Setup";

const privateRoutes: IRouteConfig[] = [
    {
        path: '/dashboard',
        element: <Dashboard />,
        sidebarProps: {
            displayText: "Dashboard",
            icon: DashboardIcon
        }
    },
    {
        path: '#',
        sidebarProps: {
            displayText: "Setup",
            icon: DashboardIcon
        },
        child: [
            {
                path: '/fish',
                element: <Setup />,
                sidebarProps: {
                    displayText: "Fish"
                }
            },
            {
                path: '/feed',
                element: <FishSetup />,
                sidebarProps: {
                    displayText: "Feed"
                }
            }
        ]
    }
]


export default privateRoutes;