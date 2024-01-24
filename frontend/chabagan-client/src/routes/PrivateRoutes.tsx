import { IRouteConfig } from "../interfaces/IRouteConfig";
import AddEditUser from "../pages/administration/AddEditUser";
import Role from "../pages/administration/Role";
import User from "../pages/administration/User";
import Dashboard from "../pages/dashboard/Dashboard";
import FishSetup from "../pages/setup/FishSetup";
import Setup from "../pages/setup/Setup";
import Brands from "../pages/stock/Brands";
import Product from "../pages/stock/Product";
import Purchase from "../pages/stock/Purchase";
import PurchaseReturn from "../pages/stock/PurchaseReturn";
import Sales from "../pages/stock/Sales";
import SalesReturn from "../pages/stock/SalesReturn";
import StockCategory from "../pages/stock/StockCategory";
import Supplier from "../pages/stock/Supplier";

const privateRoutes: IRouteConfig[] = [
    {
        path: 'dashboard',
        element: <Dashboard />,
    },
    {
        path: 'setup/suppliers',
        element: <Supplier />,
    },
    {
        path: 'setup/brands',
        element: <Brands />,
    },
    {
        path: 'setup/category',
        element: <StockCategory />,
    },
    {
        path: 'setup/products',
        element: <Product />,
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
        path: 'stock/purchases',
        element: <Purchase />,
    },
    {
        path: 'stock/purchase-returns',
        element: <PurchaseReturn />,
    },
    {
        path: 'stock/sales',
        element: <Sales />,
    },
    {
        path: 'stock/sales-returns',
        element: <SalesReturn />,
    }
]


export default privateRoutes;