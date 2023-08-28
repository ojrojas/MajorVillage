import React from 'react';
import { alpha, styled, useTheme } from '@mui/material/styles';
import { useCollapseDrawer } from '../../../hooks';
import MuiAppBar , {AppBarProps as MuiAppBarProps} from '@mui/material/AppBar'
import { Icon, IconButton, Toolbar } from '@mui/material';
import { FaceRetouchingOffRounded } from '@mui/icons-material';

const DRAWER_WIDTH = 280;
const APPBAR_MOBILE = 64;
const APPBAR_DESKTOP = 92;
const COLLAPSE_WIDTH = 102;

const RootStyle = styled(MuiAppBar)(({theme}) => ({
    boxShadow: 'none',
    backdropFilter: 'blur(6px)',
    WebkitBackdropFilter: 'blur(6px)', // Fix on Mobile
    backgroundColor: alpha(theme.palette.background.default, 0.72),
    [theme.breakpoints.up('lg')]: {
      width: `calc(100% - ${DRAWER_WIDTH}px)`
    }
}));


const ToolbarStyle = styled(Toolbar)(({theme}: any) => ({
    minHeight: APPBAR_MOBILE,
    [theme.breakpoints.up('lg')]: {
        minHeight: APPBAR_DESKTOP,
        padding: theme.spacing(0, 5)
    }
}));

interface Props {
    onOpen: Function
}

const NavBarComponent: React.FC<Props> = ({onOpen}) => {
    const theme = useTheme();
    const { isCollapse } = useCollapseDrawer();
    return (
        <RootStyle sx={{ 
            ...(isCollapse && {
                width: { lg: `calc(100% - ${COLLAPSE_WIDTH}px)` }
            })}}>
           <ToolbarStyle>
                <IconButton>
                    <FaceRetouchingOffRounded />
                </IconButton>
           </ToolbarStyle>
        </RootStyle>
    );
}

export default NavBarComponent;