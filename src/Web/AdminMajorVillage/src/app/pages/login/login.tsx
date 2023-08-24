import React from "react";
import { LoginFormComponent } from "./components/login.form";
import styles from './login.module.css';

export const LoginPage: React.FC = () => {
    return (
        <div className={styles.login_container}>
            <LoginFormComponent />
        </div>
    );
}