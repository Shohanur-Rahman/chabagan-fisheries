import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import MenuIcon from '@mui/icons-material/Menu';
import LogoutIcon from '@mui/icons-material/Logout';
import VpnKeyIcon from '@mui/icons-material/VpnKey';
import Person2Icon from '@mui/icons-material/Person2';
import userAvatar from '../../assets/img/img1.jpg';
import { Avatar, IconButton, Menu, MenuItem } from '@mui/material';
import React from 'react';
import { IToggleState } from '../../interfaces/IToggleState';
import { useNavigate } from 'react-router-dom';
import { IUserResponse } from '../../interfaces/IUserResponse';
import { useAppSelector } from '../../redux/app/hooks';
import { selectUser } from '../../redux/features/auth/authSlice';

const TopBar = ({ open, setOpen }: IToggleState) => {
    const navigate = useNavigate();
    const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
    const user: IUserResponse = useAppSelector(selectUser);

    const handleDrawerOpen = () => {
        setOpen(true);
    };
    const handleMenu = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };
    const handleLogout = () => {
        localStorage.clear();
        location.reload();
    }

    React.useEffect(() => {
        if (!user) {
            navigate("/SignIn");
        }
    }, []);

    return (
        <Toolbar className='top-bar'>
            <IconButton
                color="inherit"
                aria-label="open drawer"
                onClick={handleDrawerOpen}
                edge="start"
                sx={{ mr: 2, ...(open && { display: 'none' }) }}
            >
                <MenuIcon />
            </IconButton>
            <Typography variant="h6" component="div" className='w-90'>
                &nbsp;
            </Typography>
            <div className='user-profile'>
                <IconButton
                    size="large"
                    aria-label="account of current user"
                    aria-controls="menu-appbar"
                    aria-haspopup="true"
                    onClick={handleMenu}
                    color="inherit"
                >
                    <span className='user-title'>{user?.unique_name}</span>
                    <Avatar alt="Admin User" src={userAvatar} />
                </IconButton>
                <Menu
                    sx={{ mt: '50px' }}
                    id="menu-appbar"
                    anchorEl={anchorEl}
                    anchorOrigin={{
                        vertical: 'top',
                        horizontal: 'right',
                    }}
                    keepMounted
                    transformOrigin={{
                        vertical: 'top',
                        horizontal: 'right',
                    }}
                    open={Boolean(anchorEl)}
                    onClose={handleClose}
                >
                    <MenuItem onClick={handleClose}><Person2Icon /> &nbsp; Profile</MenuItem>
                    <MenuItem onClick={handleClose}><VpnKeyIcon /> &nbsp; Change Password</MenuItem>
                    <MenuItem onClick={handleLogout}><LogoutIcon /> &nbsp; Sign Out</MenuItem>
                </Menu>
            </div>
        </Toolbar>
    )
}

export default TopBar;