import { IRouteConfig } from "../interfaces/IRouteConfig";
import AddEditUser from "../pages/administration/AddEditUser";
import Role from "../pages/administration/Role";
import User from "../pages/administration/User";
import Dashboard from "../pages/dashboard/Dashboard";
import FishSetup from "../pages/setup/FishSetup";
import Setup from "../pages/setup/Setup";
import Brands from "../pages/stock/Brands";

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
    },
    {
        path: 'admin/users/add-user',
        element: <AddEditUser />,
    },
    {
        path: 'admin/users/edit-user/:id',
        element: <AddEditUser />,
    },
    {
        path: 'stock/brands',
        element: <Brands />,
    }
]


export default privateRoutes;