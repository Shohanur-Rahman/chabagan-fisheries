import { IRouteConfig } from "../interfaces/IRouteConfig";
import Role from "../pages/administration/Role";
import User from "../pages/administration/User";
import Dashboard from "../pages/dashboard/Dashboard";
import FishSetup from "../pages/setup/FishSetup";
import Setup from "../pages/setup/Setup";

const privateRoutes: IRouteConfig[] = [
    {
        path: 'dashboard',
        element: <Dashboard />,
    },
    {
        path: 'setup/fishes',
        element: <FishSetup />,
    },
    {
        path: 'setup/feeds',
        element: <Setup />,
    },
    {
        path: 'admin/roles',
        element: <Role />,
    },
    {
        path: 'admin/users',
        element: <User />,
    }
]


export default privateRoutes;