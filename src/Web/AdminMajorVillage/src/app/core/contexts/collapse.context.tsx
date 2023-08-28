import { createContext, useEffect, useState } from "react";
import { useMediaQuery, useTheme } from "@mui/material";

interface ICollapseContextProps {
    isCollapse: boolean,
    collapseClick: boolean;
    collapseHover: boolean;
    onToggleCollapse: Function,
    onHoverEnter: Function,
    onHoverLeave: Function
}

const InitialState: ICollapseContextProps = {
    isCollapse: false,
    collapseClick: false,
    collapseHover: false,
    onToggleCollapse: () => { },
    onHoverEnter: () => { },
    onHoverLeave: () => { }
}

export const CollapseDrawerContext = createContext<ICollapseContextProps>(InitialState);

interface Props {
    children: React.ReactNode;
}

export const CollapseDrawerProvider: React.FC<Props> = ({ children }) => {
    const theme = useTheme();
    const isMobile = useMediaQuery(theme.breakpoints.down('lg'));
    const [collapse, setCollapse] = useState({
        click: false,
        hover: false
    });

    useEffect(() => {
        if (isMobile) {
            setCollapse({
                click: false,
                hover: false
            });
        }
    }, [isMobile]);

    const handleToogleCollapse = () => {
        setCollapse({ ...collapse, click: !collapse.click });
    }

    const handleHoverEnter = () => {
        if (collapse.click)
            setCollapse({ ...collapse, hover: true });
    }

    const handleHoverLeave = () => {
        setCollapse({ ...collapse, hover: false });
    }

    return (
        <CollapseDrawerContext.Provider value={{
            isCollapse: collapse.click && !collapse.hover,
            collapseClick: collapse.click, 
            collapseHover: collapse.hover, 
            onToggleCollapse: handleToogleCollapse, 
            onHoverEnter: handleHoverEnter, 
            onHoverLeave: handleHoverLeave
        }} >
            {children}
        </CollapseDrawerContext.Provider>
    )
}