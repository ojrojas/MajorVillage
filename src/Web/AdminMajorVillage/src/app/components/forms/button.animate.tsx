import { Box } from "@mui/material";
import { animated } from '@react-spring/web';
import React from "react";

interface Props {
    click: boolean;
    children: JSX.Element;
    sx: React.CSSProperties;
}

const ButtonAnimateComponent: React.FC<Props> = ({ children, click=false, sx, ...other }) => {
    return (
        <Box
            component={animated.div}
            sx={{ display: 'inline-flex', ...sx, scale: .9, ":hover": { scale: 1.1 } }}
            {...other}>
            {children}
        </Box>
    )
}

export default ButtonAnimateComponent;