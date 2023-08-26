import { Button, Card, FormControl, IconButton, InputAdornment, TextField, Typography } from "@mui/material";
import React from "react";
import styles from './login.form.module.css';
import { Visibility, VisibilityOff } from "@mui/icons-material";
import { useAppDispatch } from "../../../hooks";
import { openSnackbar } from "../../../components/snackbar/redux/snackbar.slice";
import { useForm } from "react-hook-form";
import { ILogin } from "../../../core/models/login/login.request";
import { schema } from "../schemas/login.form.schema";
import useYupValidationResolver from "../../../helpers/resolver.forms";
import { login } from "../redux/login.actions";
import { IError } from "../../../core/models/error/error.model";
import { useNavigate } from "react-router-dom";
import { PagesRoutes } from "../../../core/constants/http/page.route";
import { setlogged } from "../redux/login.slice";
import '@fontsource/comic-mono';

export const LoginFormComponent: React.FC = () => {
    const dispatch = useAppDispatch();
    const [showPassword, setShowPassword] = React.useState(false);
    const navigationTo = useNavigate();
    const { register, handleSubmit, formState: { errors } } = useForm<ILogin>({
        mode: 'all',
        defaultValues: {
            username:'pepe@example.com',
            password:'Abc123456#'
        },
        resolver: useYupValidationResolver(schema)
    });

    const handleClickShowPassword = () => setShowPassword((show) => !show);

    const handleMouseDownPassword = (event: React.MouseEvent<HTMLButtonElement>) => {
        event.preventDefault();
    };

    const onSubmit = handleSubmit(async (data) => {
        var response = await dispatch(login(data));
        if (login.fulfilled.match(response)) {
            if (response.payload.access_token) {
                dispatch(openSnackbar({
                    duration: 3000,
                    open: true,
                    message: 'Login success',
                    severity: 'success'
                }));
                dispatch(setlogged(true));
                navigationTo(PagesRoutes.dashboard);
            } else {
                const result = (response.payload as any as IError).items[".error_description"];
                dispatch(openSnackbar({
                    duration: 3000,
                    open: true,
                    message: result,
                    severity: 'error'
                }));
            }
        } else {
            dispatch(openSnackbar({
                duration: 3000,
                open: true,
                message: 'Login error, contact with administrator.',
                severity: 'error'
            }))
        }
    });

    return (
        <Card elevation={4} className={styles.form_login}>
            <Typography variant={'h5'} gutterBottom fontFamily={'Nunito'} fontWeight={900} className={styles.form_login__title}>Major Village</Typography>
            <Typography variant={'h6'} gutterBottom fontFamily={'Nunito'} fontWeight={900} className={styles.form_login__title}>Admin Site</Typography>

            <FormControl size="small" sx={{ m: 1, width: '30ch' }} variant="outlined">
                <TextField
                    size="small"
                    required
                    id="outlined-username"
                    data-testid="outlined-username"
                    error={errors.username ? true : false}
                    type={'text'}
                    {...register("username", { required: true })}
                    label={`Username`}
                    helperText={errors.username?.message ?? ''}
                />
            </FormControl>
            <FormControl size="small" sx={{ m: 1, width: '30ch' }} variant="outlined">
                <TextField
                    size="small"
                    id="outlined-password"
                    data-testid="outlined-password"
                    type={showPassword ? 'text' : 'password'}
                    required
                    error={errors.password ? true : false}
                    {...register("password", { required: true })}
                    InputProps={{
                        endAdornment:
                            <InputAdornment position="end">
                                <IconButton
                                    aria-label="toggle password visibility"
                                    onClick={handleClickShowPassword}
                                    onMouseDown={handleMouseDownPassword}
                                    edge="end"
                                >
                                    {showPassword ? <Visibility /> : <VisibilityOff />}
                                </IconButton>
                            </InputAdornment>
                    }}
                    helperText={errors.password?.message ?? ''}
                    label={`Password`}
                />
            </FormControl>
            <FormControl sx={{ marginTop: 5 }}>
                <Button variant='text' onClick={onSubmit}>Login in</Button>
            </FormControl>
        </Card>
    );
};