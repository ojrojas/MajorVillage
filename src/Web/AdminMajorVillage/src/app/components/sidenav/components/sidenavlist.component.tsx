import React from "react";
import { Box, List, ListItemText } from "@mui/material";
import { StyledNavItem, StyledNavItemIcon } from "./sidenavitem.component";
import { NavLink as RouterLink } from 'react-router-dom';

interface IPropsNavList {
    data: Array<any>
}

export const  NavListComponent: React.FC<IPropsNavList> = ({ data = [], ...other }) => {
    return (
        <Box {...other}>
            <List disablePadding sx={{ p: 1 }}>
                {data.map(item => (
                    <NavItem
                        key={item.title}
                        title={item.title}
                        path={item.path}
                        icon={item.icon}
                        info={item.info} />
                ))}
            </List>
        </Box>
    )
};

interface IPropsNavItem {
    title: string;
    path: string;
    icon: React.ReactNode,
    info: any;
}

export const NavItem: React.FC<IPropsNavItem> = ({ icon, title, path, info }: IPropsNavItem) => {
    return (
        <StyledNavItem
            component={RouterLink}
            to={path}
            sx={{
                '&.active': {
                    color: 'text.primary',
                    bgcolor: 'action.selected',
                    fontWeight: 'fontWeightBold'
                }
            }}>
            <StyledNavItemIcon>{icon && icon}</StyledNavItemIcon>
            <ListItemText disableTypography primary={title} />
            {info && info}
        </StyledNavItem>
    )
}

export default NavListComponent;