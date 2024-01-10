export interface IMenuProps {
    label: String;
    link: String;
    icon: String;
}
export interface ISubMenuProps {
    label: String;
    link: String;
}

export interface IMultiLevelMenuProps {
    label: String;
    link: String;
    icon: String;
    submenu: ISubMenuProps[]
}

const AdminDashboardMenu: IMenuProps = {
    label: "Dasboard",
    link: "/admin/dashboard",
    icon: "ri-home-7-line",
}

const AdminSetupdMenu: IMultiLevelMenuProps[] = [
    {
        label: "Setup",
        link: '#',
        icon: "ri-heart-add-line",
        submenu: [
            {
                label: "Fishes",
                link: "/admin/fishes"
            },
            {
                label: "Feeds",
                link: "/admin/feeds"
            },
            {
                label: "Categories",
                link: "/admin/categories"
            },
            {
                label: "Projects",
                link: "/admin/projects"
            }
        ]
    }
]


export { AdminDashboardMenu, AdminSetupdMenu }