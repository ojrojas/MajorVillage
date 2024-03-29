import React from "react";
import  LoginFormComponent from "./components/login.form";
import styles from './login.module.css';

const LoginPage: React.FC = () => {
    return (
        <div className={styles.login_container}>
            <LoginFormComponent />
        </div>
    );
}

export default LoginPage;