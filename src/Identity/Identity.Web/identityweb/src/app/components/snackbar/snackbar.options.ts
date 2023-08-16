export interface ISnackProps {
    severity: 'info' |'warn' |'success'| 'error' | undefined;
    title: string;
    message: string;
    duration: number;
}