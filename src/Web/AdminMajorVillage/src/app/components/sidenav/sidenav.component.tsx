import React from "react"
import styles from './sidenav.module.css';
import { useAppSelector } from "../../hooks";
import imageDefault from '../../../assets/image/profile.png';

const SideNavComponent: React.FC = () => {
    const { user } = useAppSelector(state => state.login);
    return (
        <nav>
            <div className={styles.nav_content}>
                <div className={styles.nav_conent__profile}>
                    <div className={styles.nav_content__profile_img}>
                        <img src={imageDefault} alt={user?.name} />
                    </div>
                    <div>
                        <a href={'/'} className={styles.nav_content__profile_name}>{user?.name} {user?.lastName}</a>
                        <span className={styles.nav_content__profile_typeuser}>{user?.type.name}</span>
                    </div>
                </div>
                <div className={styles.nav_content__menu}>
                    <ul data-testid="list-item-nav" className={styles.nav_content__list}>
                        <li data-testid="item-nav-users" className={styles.nav_content__item}>Users</li>
                        <li data-testid="item-nav-typeusers" className={styles.nav_content__item}>Type Users</li>
                        <li data-testid="item-nav-settings" className={styles.nav_content__item}>Settings</li>
                    </ul>
                </div>
            </div>
        </nav>
    )
}

export default SideNavComponent;