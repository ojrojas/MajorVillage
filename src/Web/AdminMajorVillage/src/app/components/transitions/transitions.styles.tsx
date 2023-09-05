import { Fade, FadeProps, Grow, GrowProps, Slide, SlideProps } from "@mui/material";
import React from "react";

export const TransitionSlide = React.forwardRef(function Transition(
    props: SlideProps & {
        children: React.ReactElement<any, any>;
    },
    ref: React.Ref<unknown>

) {
    return <Slide direction={props.direction} ref={ref} {...props} />
});

export const TransitionFade = React.forwardRef(function Transition(
    props: FadeProps & {
        children: React.ReactElement<any, any>;
    },
    ref: React.Ref<unknown>

) {
    return <Fade in={props.in} ref={ref} {...props} />
});

export const TransitionGrow = React.forwardRef(function Transition(
    props: GrowProps & {
        children: React.ReactElement<any, any>;
    },
    ref: React.Ref<unknown>

) {
    return <Grow in={props.in} style={props.style} ref={ref} {...props} />
});