import { useAppDispatch, useAppSelector } from "../../hooks";
import { SnackbarMessageComponent } from "./components/snackbar.message"
import { closeSnack } from "./redux/snackbar.slice";
import styles from './snackbar.module.css';
import { BiMessageSquareX } from 'react-icons/bi'


export const SnackbarComponent: React.FC = () => {
    const dispatch = useAppDispatch();
    const { open, snackOptions } = useAppSelector(state => state.snackbar);
    const onClose = () => {
        dispatch(closeSnack())
    }

    const adapterOptions = (severity: string | undefined) => {
        switch (severity) {
            case "info":
                return styles.content_info;
            case 'warn':
                return styles.content_warn;
            case 'error':
                return styles.content_error;
            case 'success':
                return styles.content_success;
            default:
                break;
        }
    }

    return (
        <div className={styles.snackbar + `${open ? ` ${styles.snackbar_active}`: ''} ${adapterOptions(snackOptions.severity)}`}>
            <BiMessageSquareX onClick={() => onClose()} className={styles.close} />
            <SnackbarMessageComponent />
            <div className={styles.progress}></div>
        </div>
    )
}