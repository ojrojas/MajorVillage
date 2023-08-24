import { RootState } from '../../store';

class StorageService {
    private static key: string = 'STATE_APP';

    public static SaveState = (state: RootState) => {
        localStorage.setItem(this.key, JSON.stringify(state))
    }

    public static GetState = () => {
        const response = localStorage.getItem(this.key);
        return JSON.parse(response ?? '{}');
    }

    public static ClearState = () => {
        localStorage.clear();
    }

}

export default StorageService;