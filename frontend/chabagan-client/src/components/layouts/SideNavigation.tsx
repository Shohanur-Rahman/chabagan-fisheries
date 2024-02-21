import { useNavigate } from "react-router-dom";
import { Collapse, List, ListItem, ListItemButton, ListItemIcon, ListItemText, Typography } from "@mui/material";
import { ExpandLessOutlined, ExpandMoreOutlined } from "@mui/icons-material";
import { IMenu, sidebarMenus } from "../../data/Menu";
import { useState } from "react";


const SideNavigation = () => {
    const navigate = useNavigate();
    const [openCollapseIndex, setOpenCollapseIndex] = useState<number>(0);
    const [activeIndex, setActiveIndex] = useState<number>(0);
    const handleRedirection = (index: string, url: string) => {
        let currentIndex: number = parseInt(index);
        setActiveIndex(currentIndex);
        navigate(url);
    }
    const handleOpenClick = (index: number) => {
        setOpenCollapseIndex(index);
    }
    const handleActiveIndex = (index: number, url?: string | null) => {
        setActiveIndex(index);
        setOpenCollapseIndex(index);
        if (url)
            navigate(url);
    }

    return (
        <ul className="sidebar-main-nav">
            {sidebarMenus.map((item: IMenu, index) => {
                if (item.submenu?.length) {
                    return (
                        <>
                            <ListItemButton onClick={() => handleOpenClick(index)} className={`nav-dropdown ${(openCollapseIndex === index) ? "open" : ""}`}>
                                <ListItemIcon>
                                    {item.icon}
                                </ListItemIcon>
                                <ListItemText
                                    disableTypography
                                    primary={
                                        <Typography>{item.label}</Typography>
                                    }
                                />
                                {(openCollapseIndex === index) ? <ExpandLessOutlined /> : <ExpandMoreOutlined />}
                            </ListItemButton>
                            <Collapse in={openCollapseIndex === index} timeout="auto" className={`nav-dropdown-items ${(openCollapseIndex === index) ? "open" : ""}`}>
                                <List>
                                    {item.submenu?.map((subItem: IMenu, subIndex) => {
                                        return (
                                            <ListItemButton onClick={() => handleRedirection(`${index}${subIndex}`, `${subItem.link}`)} key={`sub_${subIndex}`} className="sidebar-link">
                                                <ListItemIcon>
                                                    {subItem.icon}
                                                </ListItemIcon>
                                                {subItem.label}
                                            </ListItemButton>
                                        )
                                    })}
                                </List>
                            </Collapse >
                        </>
                    )
                } else {
                    return (
                        <ListItem key={`maim_${index}`} disablePadding>
                            <ListItemButton className={`nav-dropdown ${(activeIndex === index) ? "open" : ""}`} onClick={() => handleActiveIndex(index, `${item.link}`)}>
                                <ListItemIcon>
                                    {item.icon}
                                </ListItemIcon>
                                <ListItemText primary={item.label} />
                            </ListItemButton>
                        </ListItem>
                    )
                }
            })}

        </ul >
    );
};

export default SideNavigation;