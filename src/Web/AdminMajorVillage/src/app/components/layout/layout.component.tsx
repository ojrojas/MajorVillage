import React, { useEffect } from "react";
import { useAppSelector } from "../../hooks";
import { Outlet, useNavigate } from "react-router-dom";
import { PagesRoutes } from "../../core/constants/http/page.route";
import HeaderComponent from "../header/header.component";
import { Box, CssBaseline } from "@mui/material";

export const LayoutComponent: React.FC = () => {
    const { logged, user } = useAppSelector(state => state.login);
    const navigateOn = useNavigate();
    const onOpen = () => { }

    useEffect(() => {
        if (logged) {
            navigateOn(PagesRoutes.dashboard);
        }
        else {
            navigateOn(PagesRoutes.login);
        }
    }, [logged, navigateOn, user]);

    return (
        <Box sx={{ display: 'flex', flexDirection: 'column', margin: 0, padding: 0 }}>
            <CssBaseline />
            <div style={{ flex: 1 }}>
                <HeaderComponent onOpen={onOpen} />
            </div>
            <div style={{ display:'flex', flexDirection:'row' }}>
                <Box component="main" sx={{ backgroundColor: 'papayawhip' }}>
                <Outlet />
            </Box>
            </div>
           
        </Box>
    );
}