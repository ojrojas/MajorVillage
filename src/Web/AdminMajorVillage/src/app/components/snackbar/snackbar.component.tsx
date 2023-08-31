import React, { useEffect, useState } from 'react';
import CloseIcon from '@mui/icons-material/Close';
import { Alert, IconButton, Stack, Typography } from '@mui/material';
import { useAppDispatch, useAppSelector } from '../../hooks';
import { closeSnackbar } from './redux/snackbar.slice';
import styles from './snackbar.module.css';

const SnackbarComponent: React.FC = () => {
    const { open, severity, message, duration } = useAppSelector(state => state.snackbar.snackbarOption);
    const dispatch = useAppDispatch();
    const [timer, setTimer] = useState<number>(duration ?? 4000);

    let time: NodeJS.Timeout | undefined;

    const handleTimeOut = () => {
        time = setTimeout(() => {
            dispatch(closeSnackbar());
        }, timer);
    }

    const handleClose = () => {
        clearTimeout(time);
    }

    useEffect(() => {
        if (open) {
            handleTimeOut();
        }
        return () => {
            clearTimeout(time);
        }
    }, [open, time]);

    return (
        <React.Fragment>
            {open &&
                <Stack spacing={2} className={styles.container}>
                    <Alert variant='standard' severity={severity}
                        className={styles.alert_content}
                        action={
                            <IconButton
                                aria-label="close"
                                color="inherit"
                                size="small"
                                onClick={() => {
                                    handleClose();
                                }}
                            >
                                <CloseIcon fontSize="inherit" />
                            </IconButton>
                        }>
                        <Typography>{message}</Typography>
                    </Alert>
                </Stack>
            }
        </React.Fragment >
    );
}

export default SnackbarComponent;