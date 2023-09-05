import React from "react";
import { ISnackbarOptions } from "../../components/snackbar/snackbar.options";
import { useAppSelector } from "../../hooks";
import SnackbarComponent from "../../components/snackbar/snackbar.component";

export const SnackbarContext = React.createContext<ISnackbarOptions>({
    message: '',
    duration: undefined,
    severity: 'info',
    open: false
});

const SnackbarProvider: React.FC = () => {
    const { duration, message, severity, open } = useAppSelector(state => state.snackbar.snackbarOption);
    return (
        <SnackbarContext.Provider value={{ duration, message, severity, open }}>
            <SnackbarComponent />
        </SnackbarContext.Provider>
    );
}

export default SnackbarProvider;