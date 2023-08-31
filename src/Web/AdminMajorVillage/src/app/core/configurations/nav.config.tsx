//import Icon from "@mui/material/Icon";
import { PagesRoutes } from "../constants/http/page.route";
import DashboardIcon from '@mui/icons-material/Dashboard';
import PersonIcon from '@mui/icons-material/Person';
import SettingsIcon from '@mui/icons-material/Settings';
import GroupIcon from '@mui/icons-material/Group';


// const icon = (name: string) => <Icon>{name}</Icon>
const NavConfiguration = [
    {
        title: 'Dashboard',
        testid: 'dashboard',
        path: PagesRoutes.dashboard,
        icon: <DashboardIcon/>
    },
    {
        title:'Type Users',
        testid: 'typeusers',
        path:PagesRoutes.typeUsers,
        icon: <GroupIcon />
    },
    {
        title: 'Users',
        testid: 'users',
        path: PagesRoutes.users,
        icon: <PersonIcon/>
    },
    {
        title: 'Settings',
        testid: 'settings',
        path: PagesRoutes.settings,
        icon: <SettingsIcon/>
    }
];

export default NavConfiguration;