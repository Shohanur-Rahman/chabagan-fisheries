import { IIconBreadcrumbs } from "../interfaces/IBreadcrumbs";
import HomeIcon from '@mui/icons-material/Home';
import GrainIcon from '@mui/icons-material/Grain';
import AdminPanelSettingsIcon from '@mui/icons-material/AdminPanelSettings';

const dashboarBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/"
    },
    {
        text: "Dashboard",
        icon: <GrainIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

const fishBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/"
    },
    {
        text: "Fish",
        icon: <GrainIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

const roleBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Roles",
        icon: <GrainIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

const userBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Users",
        icon: <AdminPanelSettingsIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]
const userAddBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Users",
        icon: <AdminPanelSettingsIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/admin/users"
    },
    {
        text: "Manage User",
        icon: <GrainIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

const brandsBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Brands",
        icon: <AdminPanelSettingsIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

export default { dashboarBreadCrumb, fishBreadCrumb, roleBreadCrumb, userBreadCrumb, userAddBreadCrumb, brandsBreadCrumb }