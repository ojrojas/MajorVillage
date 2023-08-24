import React, { useEffect } from "react";
import { useAppSelector } from "../../hooks";
import { Outlet, useNavigate } from "react-router-dom";
import { PagesRoutes } from "../../core/constants/http/page.route";

export const LayoutComponent: React.FC = () => {
    const { logged, user } = useAppSelector(state => state.login);
    const navigateOn = useNavigate();
    useEffect(() => {
        if (logged) {
            navigateOn(PagesRoutes.dashboard);
        }
        else {
            navigateOn(PagesRoutes.login);
        }
    }, [logged, navigateOn, user]);

    return (
        <React.Fragment>
            <h1>Drawer</h1>
            <Outlet />
        </React.Fragment>
        
    )
}