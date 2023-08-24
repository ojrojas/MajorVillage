import React from "react";
import { ISnackbarOptions } from "../../components/snackbar/snackbar.options";
import { useAppSelector } from "../../hooks";

export const SnackbarContext = React.createContext<ISnackbarOptions>({
    message: '',
    duration: undefined,
    severity: 'info',
    open: false
});

interface Props {
    children: React.ReactNode;
}

export const SnackbarProvider: React.FC<Props> = ({ children }) => {
    const { duration, message, severity, open } = useAppSelector(state => state.snackbar.snackbarOption);
    return (
        <SnackbarContext.Provider value={{ duration, message, severity, open }}>
            {children}
        </SnackbarContext.Provider>
    );
}