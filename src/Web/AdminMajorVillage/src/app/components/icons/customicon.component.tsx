import { IconButton } from "@mui/material"
import React from "react"
import ButtonAnimateComponent from "../forms/button.animate";

interface Props {
    children: React.ReactNode;
    sx: React.CSSProperties;
    size: 'small' | 'medium' | 'large'
    color: 'primary' | 'default'
}
export const CustomIconComponent = React.forwardRef<HTMLDivElement, Props>((props, ref) => {
    return (
        <ButtonAnimateComponent sx={props.sx} click={false}>
            <IconButton {...ref}>
                {props.children}
            </IconButton>
        </ButtonAnimateComponent>
    )
});