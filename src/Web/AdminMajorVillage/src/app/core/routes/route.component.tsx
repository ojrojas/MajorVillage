import { createBrowserRouter } from "react-router-dom";
import { PagesRoutes } from "../constants/http/page.route";
import  LayoutComponent  from "../../components/layout/layout.component";
import  LoginPage  from "../../pages/login/login.page";
import DashboardPage from "../../pages/dashboard/dashboard.page";
import UsersPage from "../../pages/users/users.page";
import TypeUsersPage from "../../pages/typeusers/typeusers.page";
import SettingsPage from "../../pages/settings/settings.page";

const router = createBrowserRouter([
    {
        path: PagesRoutes.root,
        element: <LayoutComponent />,
        children: [
            {
                path: PagesRoutes.dashboard,
                element: <DashboardPage />
            },
            {
                path:PagesRoutes.users,
                element: <UsersPage />
            },
            {
                path: PagesRoutes.typeUsers,
                element: <TypeUsersPage />
            },
            {
                path: PagesRoutes.settings,
                element: <SettingsPage />
            }
        ]
    },
    {
        path: PagesRoutes.login,
        element: <LoginPage />
    }
]);

export default router;