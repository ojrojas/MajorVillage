import { useAppSelector } from '../../../hooks';
import styles from './snackbar.message.module.css';
import { BiCheck, BiInfoCircle, BiError, BiLogoOkRu } from 'react-icons/bi'

export const SnackbarMessageComponent: React.FC = () => {
    const {title, message, duration, severity} = useAppSelector(state => state.snackbar.snackOptions);

    const adapterIcons = (severity: string | undefined) => {
        switch (severity) {
            case "info":
                return <BiCheck/>;
            case 'warn':
                return <BiInfoCircle/>;
            case 'error':
                return <BiError/>;
            case 'success':
                return <BiLogoOkRu/>;
            default:
                break;
        }
    }

    return (
        <div className={styles.content}>
            {adapterIcons(severity)}
            <div className={styles.content_message} >
                <span className={styles.title}>
                    {title}
                </span>
                <span className={styles.submessage}>
                    {message}
                </span>
            </div>
        </div>
    )
}