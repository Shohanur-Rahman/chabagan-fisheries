import { ReactNode } from "react";
import DashboardIcon from '@mui/icons-material/Dashboard';
import ChecklistIcon from '@mui/icons-material/Checklist';
import { ArrowRight } from "@mui/icons-material";
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import AdminPanelSettingsIcon from '@mui/icons-material/AdminPanelSettings';
import FileCopyIcon from '@mui/icons-material/FileCopy';
export interface IMenu {
    link?: string,
    label: string;
    icon?: ReactNode;
    submenu?: IMenu[],
}

const sidebarMenus: IMenu[] = [
    {
        label: "Dashboard",
        link: "/dashboard",
        icon: <DashboardIcon />,
    },
    {
        label: "Setup",
        icon: <ChecklistIcon />,
        submenu: [
            {
                label: "Categories",
                link: "/setup/category",
                icon: <ArrowRight />
            },
            {
                label: "Brands",
                link: "/setup/brands",
                icon: <ArrowRight />
            },
            {
                label: "Products",
                link: "/setup/products",
                icon: <ArrowRight />
            },
            {
                label: "Supplier",
                link: "/setup/suppliers",
                icon: <ArrowRight />
            },
            {
                label: "Projects",
                link: "/setup/projects",
                icon: <ArrowRight />
            }
        ]
    },
    {
        label: "Stock",
        icon: <AddShoppingCartIcon />,
        submenu: [
            {
                label: "Purchases",
                link: "/stock/purchases",
                icon: <ArrowRight />
            },
            {
                label: "Purchase Returns",
                link: "/stock/purchase-returns",
                icon: <ArrowRight />
            },
            {
                label: "Sales",
                link: "/stock/sales",
                icon: <ArrowRight />
            },
            {
                label: "Sales Returns",
                link: "/stock/sales-returns",
                icon: <ArrowRight />
            }
        ]
    },
    {
        label: "Reports",
        icon: <FileCopyIcon />,
        submenu: [
            {
                label: "Purchase",
                link: "/reports/purchases",
                icon: <ArrowRight />
            },
            {
                label: "Purchase Return",
                link: "/reports/purchase-return",
                icon: <ArrowRight />
            },
            {
                label: "Sales",
                link: "/reports/sales",
                icon: <ArrowRight />
            },
            {
                label: "Sales Returns",
                link: "/reports/sales-returns",
                icon: <ArrowRight />
            }
        ]
    },
    {
        label: "Administration",
        icon: <AdminPanelSettingsIcon />,
        submenu: [
            {
                label: "Roles",
                link: "/admin/roles",
                icon: <ArrowRight />
            },
            {
                label: "Users",
                link: "/admin/users",
                icon: <ArrowRight />
            }
        ]
    }
]


export { sidebarMenus }