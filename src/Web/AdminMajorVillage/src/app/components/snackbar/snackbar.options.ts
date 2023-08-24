import { AlertColor } from "./alertcolor.type";

export interface ISnackbarOptions {
    message: string;
    open: boolean;
    severity: AlertColor;
    duration?: number;
}


