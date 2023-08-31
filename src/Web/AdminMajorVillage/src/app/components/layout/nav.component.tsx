import { List, ListItem, ListItemButton, ListItemIcon, ListItemText } from "@mui/material"
import NavConfiguration from "../../core/configurations/nav.config";
import { useNavigate } from "react-router-dom";

const NavComponent: React.FC = () => {
    const navigateOn = useNavigate();
    return (
        <List data-testid="list-item-nav">
            {NavConfiguration.map((nav, index) => (
                <ListItem
                    key={nav.title}
                    data-testid={`item-nav-${nav.testid}`}
                    disablePadding
                    onClick={() => navigateOn(nav.path)}
                >
                    <ListItemButton>
                        <ListItemIcon>
                            {nav.icon}
                        </ListItemIcon>
                        <ListItemText primary={nav.title} />
                    </ListItemButton>
                </ListItem>
            ))}
        </List>
    )
}

export default NavComponent;