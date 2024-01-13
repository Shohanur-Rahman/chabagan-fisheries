import { IRouteConfig } from "../interfaces/IRouteConfig";
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
    }
]


export default privateRoutes;