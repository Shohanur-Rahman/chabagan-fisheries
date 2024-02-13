import { useNavigate } from "react-router-dom";
import { ListItem, ListItemButton, ListItemIcon, ListItemText } from "@mui/material";

import { IMenu, sidebarMenus } from "../../data/Menu";
import SidebarDropdownMenu from "./SidebarDropdownMenu";

const SideNavigation = () => {
    const navigate = useNavigate();

    const handleRedirection = (url: string) => {
        navigate(url);
    }

    return (
        <>
            {sidebarMenus.map((item: IMenu, index) => {
                if (item.submenu?.length) {
                    return (
                        <SidebarDropdownMenu key={index} item={item} className="fn_dum_nav"/>
                    )
                } else {
                    return (
                        <ListItem key={`maim_${index}`} disablePadding>
                            <ListItemButton className="nav-dropdown" onClick={() => handleRedirection(`${item.link}`)}>
                                <ListItemIcon>
                                    {item.icon}
                                </ListItemIcon>
                                <ListItemText primary={item.label} />
                            </ListItemButton>
                        </ListItem>
                    )
                }
            })}

        </>
    );
};

export default SideNavigation;