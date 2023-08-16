import { useForm } from 'react-hook-form';
import styles from './form.login.module.css';
import { BiUserCircle, BiLock } from 'react-icons/bi'
import { Schema } from '../schema/login.schema';
import useYupValidationResolver from '../../components/forms/resolver';
import { useAppDispatch } from '../../hooks';
import { login } from '../redux/login.action';
import { ILoginRequest } from '../../core/model/login/login.request';
import { ILoginResponse } from '../../core/model/login/login.response';
import { openSnack } from '../../components/snackbar/redux/snackbar.slice';

export const FormLoginComponent: React.FC = () => {
    const dispatch = useAppDispatch();
    const { register, handleSubmit, formState: { errors } } = useForm<{ username: string, password: string }>({
        defaultValues: {
            username: '',
            password: ''
        }, mode: 'all',
        resolver: useYupValidationResolver(Schema)
    });

    const onSubmit = handleSubmit(async (data) => {
        await dispatch(login({ username: data.username, password: data.password } as ILoginRequest))
            .then(response => {
                if (response.payload.status === 200) {
                    dispatch(openSnack({
                        title: 'Login',
                        severity: 'success',
                        duration: 0,
                        message: 'Login successful'
                    }));
                } else {
                    dispatch(openSnack({
                        title: 'Login',
                        severity: 'warn',
                        duration: 0,
                        message: 'Username or password is wrong'
                    }))
                }
            }).catch(error => {
                dispatch(openSnack({
                    title: 'Login',
                    severity: 'error',
                    duration: 0,
                    message: `Error: ${error}`
                }))
            });
    });

    return (
        <form>
            <h1>Login</h1>
            <div className={styles.input_box}>
                <BiUserCircle className={styles.icon} />
                <input {...register('username')} type="text" required />
                {errors.username ? <label className={styles.error}>{errors.username.message}</label> : <label>UserName</label>}
            </div>
            <div className={styles.input_box}>
                <BiLock className={styles.icon} />
                <input {...register('password')} type="password" required />
                {errors.password ? <label className={styles.error}>{errors.password.message}</label> : <label>Password</label>}
            </div>
            <button type="submit" onClick={onSubmit} className={styles.btn}>Login</button>
        </form>
    );
}