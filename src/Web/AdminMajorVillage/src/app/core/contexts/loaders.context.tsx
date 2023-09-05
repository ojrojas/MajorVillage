import React from "react";
import { LoaderOptions } from "../../components/loaders/loader.options"
import LoaderComponent from "../../components/loaders/loader.component";
import { useAppSelector } from "../../hooks";

export const initialLoaderOptions: LoaderOptions = {
    size: 105,
    lineWeight: undefined,
    speed: 4,
    color: '#d55448',
    type: 'leapfrog',
    open: false
};

const LoaderContext = React.createContext<LoaderOptions>(initialLoaderOptions);

const LoaderProvider: React.FC = () => {
    const { options } = useAppSelector(state => state.loader);
    return (
        <LoaderContext.Provider value={options}>
            <LoaderComponent />
        </LoaderContext.Provider>
    )
}

export default LoaderProvider;