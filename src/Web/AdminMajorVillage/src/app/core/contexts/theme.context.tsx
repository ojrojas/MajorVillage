import React from "react";
import { Dispatch, SetStateAction } from "react";
import { ITheme, ThemeType } from "../models/theme.model";
import { THEMES } from "../configurations/theme.config";

interface IThemeProviderProps {
    children: React.ReactNode;
}

interface IThemeContextProps {
    themeType: ThemeType;
    theme: ITheme;
    setCurrentTheme:Dispatch<SetStateAction<ThemeType>>;
}

export const ThemeContext = React.createContext<IThemeContextProps>({
    themeType: 'light',
    theme: THEMES['light']
   
} as IThemeContextProps);

export const IThemeProvider: React.FC<IThemeProviderProps> = ({children})=> {
    const [currentTheme, setCurrentTheme] = React.useState<ThemeType>('light');
    return (
        <ThemeContext.Provider value={{
            themeType: currentTheme,
            theme: THEMES[currentTheme],
            setCurrentTheme
        }}>
            {children}
        </ThemeContext.Provider>
    )
}