import React, { useEffect } from "react";
import { useAppSelector } from "../../hooks";
import { Outlet, useNavigate } from "react-router-dom";
import { PagesRoutes } from "../../core/constants/http/page.route";
import NavListComponent from "../sidenav/components/sidenavlist.component";
import NavConfiguration from "../../core/configurations/nav.config";

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
            <NavListComponent data={NavConfiguration} />
            <Outlet />
        </React.Fragment>
        
    )
}