import { ReactNode } from "react";
import DashboardIcon from '@mui/icons-material/Dashboard';
import ChecklistIcon from '@mui/icons-material/Checklist';
import { ArrowRight } from "@mui/icons-material";
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import AdminPanelSettingsIcon from '@mui/icons-material/AdminPanelSettings';

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
                label: "Fishes",
                link: "/setup/fishes",
                icon: <ArrowRight />
            },
            {
                label: "Feeds",
                link: "/setup/feeds",
                icon: <ArrowRight />
            },
            {
                label: "Categories",
                link: "/setup/categories",
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
                label: "Brands",
                link: "/stock/brands",
                icon: <ArrowRight />
            },
            {
                label: "Categories",
                link: "/stock/category",
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