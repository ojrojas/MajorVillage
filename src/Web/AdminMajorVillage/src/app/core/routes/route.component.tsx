import { createBrowserRouter } from "react-router-dom";
import { PagesRoutes } from "../constants/http/page.route";
import  LayoutComponent  from "../../components/layout/layout.component";
import  LoginPage  from "../../pages/login/login";
import DashboardPage from "../../pages/dashboard/dashboard";

const router = createBrowserRouter([
    {
        path: PagesRoutes.root,
        element: <LayoutComponent />,
        children: [
            {
                path: PagesRoutes.dashboard,
                element: <DashboardPage />
            }
        ]
    },
    {
        path: PagesRoutes.login,
        element: <LoginPage />
    }
]);

export default router;