import { SnackbarComponent } from '../components/snackbar/snackbar';
import { FormLoginComponent } from './components/form.login';
import styles from './login.module.css';
import { useAppDispatch } from '../hooks';
import { openSnack } from '../components/snackbar/redux/snackbar.slice';
import { useState } from 'react';

export const LoginComponent: React.FC = () => {
    const dispatch = useAppDispatch();
    const [isActive, setIsActive] = useState(false);

    return (
        <div className={styles.container}>
            <div className={styles.card_container}>
                <FormLoginComponent />
            </div>
            <SnackbarComponent />
        </div>
    )
}

