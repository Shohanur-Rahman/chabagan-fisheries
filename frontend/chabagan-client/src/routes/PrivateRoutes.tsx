import { IRouteConfig } from "../interfaces/IRouteConfig";
import AddEditUser from "../pages/administration/AddEditUser";
import Role from "../pages/administration/Role";
import User from "../pages/administration/User";
import Dashboard from "../pages/dashboard/Dashboard";
import Brands from "../pages/setup/Brands";
import Product from "../pages/setup/Product";
import PurchaseAction from "../pages/stock/purchase/PurchaseAction";
import StockCategory from "../pages/setup/StockCategory";
import Supplier from "../pages/setup/Supplier";
import Project from "../pages/setup/Project";
import PurchaseList from "../pages/stock/purchase/PurchaseList";
import PurchaseReturnList from "../pages/stock/purchase-return/PurchaseReturnList";
import PurchaseReturnAction from "../pages/stock/purchase-return/PurchaseReturnAction";
import SalesList from "../pages/stock/sales/SalesList";
import SalesAction from "../pages/stock/sales/SalesAction";
import SalesReturnsList from "../pages/stock/sales-return/SalesReturnsList";
import SalesReturnAction from "../pages/stock/sales-return/SalesReturnAction";
import TransectionSummary from "../pages/reports/TransectionSummary";
import PurchaseReport from "../pages/reports/PurchaseReport";
import Payment from "../pages/stock/payment-collection/Payment";
import Collection from "../pages/stock/payment-collection/Collection";

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
        element: <PurchaseReturnList />,
    },
    {
        path: 'stock/purchase-returns/new-purchase-returns',
        element: <PurchaseReturnAction />,
    },
    {
        path: 'stock/purchase-returns/edit-purchase-returns/:id',
        element: <PurchaseReturnAction />,
    },
    {
        path: 'stock/sales',
        element: <SalesList />,
    },
    {
        path: 'stock/sales/new-sales',
        element: <SalesAction />,
    },
    {
        path: 'stock/sales/edit-sales/:id',
        element: <SalesAction />,
    },
    {
        path: 'stock/sales-returns',
        element: <SalesReturnsList />,
    },
    {
        path: 'stock/sales-returns/new-sales-returns',
        element: <SalesReturnAction />,
    },
    {
        path: 'stock/sales-returns/edit-sales-returns/:id',
        element: <SalesReturnAction />,
    },
    {
        path: 'stock/payments',
        element: <Payment />,
    },
    {
        path: 'stock/collections',
        element: <Collection />,
    },
    {
        path: 'reports/purchases',
        element: <PurchaseReport />,
    },
    {
        path: 'reports/trasection-summaries',
        element: <TransectionSummary />,
    }
]


export default privateRoutes;