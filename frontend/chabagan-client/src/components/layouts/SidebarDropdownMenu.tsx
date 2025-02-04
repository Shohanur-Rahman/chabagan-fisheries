import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Collapse, List, ListItemButton, ListItemIcon, ListItemText, Typography } from "@mui/material";
import { ExpandLessOutlined, ExpandMoreOutlined } from "@mui/icons-material";
import { IMenu } from "../../data/Menu";

const SidebarDropdownMenu: React.FC<{ item: IMenu, className?: string }> = ({ item, className }) => {
    const [open, setOpen] = useState(false);
    const navigate = useNavigate();

    const handleRedirection = (url: string) => {
        navigate(url);
    }

    const handleClick = () => {
        const elements = document.querySelectorAll(`.${className}`);
        elements.forEach(element => {
            if (element.classList.contains('active')) {
                console.log('Active class is available');
            } else {
                console.log('Active class is not available');
            }
        });

        setOpen(!open);
    }

    return (
        <>
            <ListItemButton onClick={() => setOpen(!open)} className={open ? `nav-dropdown open  ${className}` : `nav-dropdown ${className}`}>
                <ListItemIcon>
                    {item.icon}
                </ListItemIcon>
                <ListItemText
                    disableTypography
                    primary={
                        <Typography>{item.label}</Typography>
                    }
                />
                {open ? <ExpandLessOutlined /> : <ExpandMoreOutlined />}
            </ListItemButton>
            <Collapse in={open} timeout="auto" className={open ? "nav-dropdown-items open" : "nav-dropdown-items"}>
                <List>
                    {item.submenu?.map((subItem: IMenu, subIndex) => {
                        return (
                            <ListItemButton onClick={() => handleRedirection(`${subItem.link}`)} key={`sub_${subIndex}`} className="sidebar-link">
                                <ListItemIcon>
                                    {subItem.icon}
                                </ListItemIcon>
                                {subItem.label}
                            </ListItemButton>
                        )
                    })}
                </List>
            </Collapse>
        </>
    )
}

export default SidebarDropdownMenu;