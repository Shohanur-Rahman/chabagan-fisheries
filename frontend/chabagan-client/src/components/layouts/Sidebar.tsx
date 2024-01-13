import { styled } from '@mui/material/styles';
import Drawer from '@mui/material/Drawer';
import Divider from '@mui/material/Divider';
import IconButton from '@mui/material/IconButton';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import { IToggleState } from '../../interfaces/IToggleState';
import logo from '../../assets/img/logo-default.png';
import SideNavigation from './SideNavigation';
import { Link } from 'react-router-dom';
const drawerWidth = 240;
const DrawerHeader = styled('div')(({ theme }) => ({
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(0, 1),
    // necessary for content to be below app bar
    ...theme.mixins.toolbar,
    justifyContent: 'flex-end',
}));

const Sidebar = ({ open, setOpen }: IToggleState) => {

    const handleDrawerClose = () => {
        setOpen(false);
    };

    return (
        <Drawer className='left-sidebar'
            sx={{
                width: drawerWidth,
                flexShrink: 0,
                '& .MuiDrawer-paper': {
                    width: drawerWidth,
                    boxSizing: 'border-box',
                },
            }}
            variant="persistent"
            anchor="left"
            open={open}
        >
            <DrawerHeader className='drawer-header'>
                <Link to="/dashboard" className='w-100'>
                    <img alt="Logo" src={logo} className='logo-img' />
                </Link>
                <IconButton onClick={handleDrawerClose}>
                    <ChevronLeftIcon />
                </IconButton>
            </DrawerHeader>
            <Divider />
            <SideNavigation />
            <Divider />
        </Drawer>
    )
}

export default Sidebar;