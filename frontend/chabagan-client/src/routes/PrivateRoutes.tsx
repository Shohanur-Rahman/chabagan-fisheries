import { IRouteConfig } from "../interfaces/IRouteConfig";
import AddEditUser from "../pages/administration/AddEditUser";
import Role from "../pages/administration/Role";
import User from "../pages/administration/User";
import Dashboard from "../pages/dashboard/Dashboard";
import Brands from "../pages/setup/Brands";
import Product from "../pages/setup/Product";
import PurchaseAction from "../pages/stock/purchase/PurchaseAction";
import PurchaseReturn from "../pages/stock/PurchaseReturn";
import Sales from "../pages/stock/Sales";
import SalesReturn from "../pages/stock/SalesReturn";
import StockCategory from "../pages/setup/StockCategory";
import Supplier from "../pages/setup/Supplier";
import Project from "../pages/setup/Project";
import PurchaseList from "../pages/stock/purchase/PurchaseList";

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
        path: 'setup/projects',
        element: <Project />,
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
        element: <PurchaseList />,
    },
    {
        path: 'stock/purchases/new-purchase',
        element: <PurchaseAction />,
    },
    {
        path: 'stock/purchases/edit-purchase/:id',
        element: <PurchaseAction />,
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