import Icon from "@mui/material/Icon";
import { PagesRoutes } from "../constants/http/page.route";
import DashboardIcon from '@mui/icons-material/Dashboard';
import PersonIcon from '@mui/icons-material/Person';
import SettingsIcon from '@mui/icons-material/Settings';


// const icon = (name: string) => <Icon>{name}</Icon>
const NavConfiguration = [
    {
        title: 'Dashboard',
        path: PagesRoutes.dashboard,
        icon: <DashboardIcon/>
    },
    {
        title: 'Users',
        path: PagesRoutes.users,
        icon: <PersonIcon/>
    },
    {
        title: 'Settings',
        path: PagesRoutes.settings,
        icon: <SettingsIcon/>
    }
];

export default NavConfiguration;