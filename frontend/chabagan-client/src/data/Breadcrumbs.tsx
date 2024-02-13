import { IIconBreadcrumbs } from "../interfaces/IBreadcrumbs";
import HomeIcon from '@mui/icons-material/Home';
import GrainIcon from '@mui/icons-material/Grain';
import AdminPanelSettingsIcon from '@mui/icons-material/AdminPanelSettings';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import AddIcon from '@mui/icons-material/Add';
import EditIcon from '@mui/icons-material/Edit';
import AirlineStopsIcon from '@mui/icons-material/AirlineStops';

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

const categoryBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Categories",
        icon: <AdminPanelSettingsIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]
const productBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Products",
        icon: <AdminPanelSettingsIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]
const purchaseBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Purchases",
        icon: <ShoppingCartIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

const addPurchaseBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Purchases",
        path: "/stock/purchases",
        icon: <ShoppingCartIcon sx={{ mr: 0.5 }} fontSize="inherit" />
    },
    {
        text: "New Purchase",
        icon: <AddIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

const editPurchaseBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Purchases",
        path: "/stock/purchases",
        icon: <ShoppingCartIcon sx={{ mr: 0.5 }} fontSize="inherit" />
    },
    {
        text: "Edit Purchase",
        icon: <EditIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

const purchaseReturnBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Purchase Returns",
        icon: <ShoppingCartIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]
const addPurchaseReturnBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Purchase Returns",
        path: "/stock/purchase-returns",
        icon: <ShoppingCartIcon sx={{ mr: 0.5 }} fontSize="inherit" />
    },
    {
        text: "New Purchase Return",
        icon: <AddIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

const editPurchaseReturnBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Purchase Returns",
        path: "/stock/purchase-returns",
        icon: <ShoppingCartIcon sx={{ mr: 0.5 }} fontSize="inherit" />
    },
    {
        text: "Edit Purchase Return",
        icon: <EditIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

const salesBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Sales",
        icon: <ShoppingCartIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]
const addSalesBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Sales",
        path: "/stock/sales",
        icon: <ShoppingCartIcon sx={{ mr: 0.5 }} fontSize="inherit" />
    },
    {
        text: "New Sale",
        icon: <AddIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

const editSalesBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Sales",
        path: "/stock/sales",
        icon: <ShoppingCartIcon sx={{ mr: 0.5 }} fontSize="inherit" />
    },
    {
        text: "Edit Sale",
        icon: <EditIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

const salesReturnBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Sales Returns",
        icon: <ShoppingCartIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]
const addSalesReturnBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Sales Returns",
        path: "/stock/sales-returns",
        icon: <ShoppingCartIcon sx={{ mr: 0.5 }} fontSize="inherit" />
    },
    {
        text: "New Sales Returns",
        icon: <AddIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

const editSalesReturnBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Sales Returns",
        path: "/stock/sales-returns",
        icon: <ShoppingCartIcon sx={{ mr: 0.5 }} fontSize="inherit" />
    },
    {
        text: "Edit Sales Returns",
        icon: <EditIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]
const supplierBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Supplier",
        icon: <AdminPanelSettingsIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

const projectBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Projects",
        icon: <AdminPanelSettingsIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]

const transectionBreadCrumb: IIconBreadcrumbs[] = [
    {
        text: "Home",
        icon: <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        path: "/dashboard"
    },
    {
        text: "Transection Summaries",
        icon: <AirlineStopsIcon sx={{ mr: 0.5 }} fontSize="inherit" />,
        isLast: true
    }
]



export default {
    dashboarBreadCrumb,
    fishBreadCrumb,
    roleBreadCrumb,
    userBreadCrumb,
    userAddBreadCrumb,
    brandsBreadCrumb,
    categoryBreadCrumb,
    productBreadCrumb,
    purchaseBreadCrumb,
    addPurchaseBreadCrumb,
    editPurchaseBreadCrumb,
    purchaseReturnBreadCrumb,
    addPurchaseReturnBreadCrumb,
    editPurchaseReturnBreadCrumb,
    salesBreadCrumb,
    addSalesBreadCrumb,
    editSalesBreadCrumb,
    salesReturnBreadCrumb,
    addSalesReturnBreadCrumb,
    editSalesReturnBreadCrumb,
    supplierBreadCrumb,
    projectBreadCrumb,
    transectionBreadCrumb
}