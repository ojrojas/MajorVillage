import React from "react";
import { DotWave, LeapFrog, Orbit, RaceBy, Ring, Waveform } from "@uiball/loaders"
import { useAppSelector } from "../../hooks";
import { Backdrop } from "@mui/material";

const LoaderComponent: React.FC = () => {
    const { size, type, color, speed, lineWeight, open } = useAppSelector(state => state.loader.options);

    switch (type) {
        case 'dotwave':
            return (
                <React.Fragment>
                    <Backdrop
                        open={open}
                        aria-labelledby="keep-mounted-Backdrop-title"
                        aria-describedby="keep-mounted-Backdrop-description"
                    >
                        <DotWave size={size} color={color} speed={speed} />
                    </Backdrop>
                </React.Fragment>
            );
        case 'leapfrog':
            return (
                <React.Fragment>
                    <Backdrop
                        open={open}
                        aria-labelledby="keep-mounted-Backdrop-title"
                        aria-describedby="keep-mounted-Backdrop-description"
                    >
                        <LeapFrog size={size} color={color} speed={speed} />
                    </Backdrop>
                </React.Fragment>
            );
        case 'raceby':
            return (
                <React.Fragment>
                    <Backdrop
                        open={open}
                        aria-labelledby="keep-mounted-Backdrop-title"
                        aria-describedby="keep-mounted-Backdrop-description"
                    >
                        <RaceBy size={size} color={color} speed={speed} lineWeight={lineWeight} />
                    </Backdrop>
                </React.Fragment>
            );
        case 'ring':
            return (
                <React.Fragment>
                    <Backdrop
                        open={open}
                        aria-labelledby="keep-mounted-Backdrop-title"
                        aria-describedby="keep-mounted-Backdrop-description"
                    >
                        <Ring size={size} color={color} speed={speed} lineWeight={lineWeight} />
                    </Backdrop>
                </React.Fragment>
            );
        case 'waveform':
            return (
                <React.Fragment>
                    <Backdrop
                        open={open}
                        aria-labelledby="keep-mounted-Backdrop-title"
                        aria-describedby="keep-mounted-Backdrop-description"
                    >
                        <Waveform size={size} color={color} speed={speed} lineWeight={lineWeight} />
                    </Backdrop>
                </React.Fragment>
            );
        case 'orbit':
            return (
                <React.Fragment>
                    <Backdrop
                        open={open}
                        aria-labelledby="keep-mounted-Backdrop-title"
                        aria-describedby="keep-mounted-Backdrop-description"
                    >
                        <Orbit size={size} color={color} />
                    </Backdrop>
                </React.Fragment>
            );
        default:
            return null;
    }
}

export default LoaderComponent;