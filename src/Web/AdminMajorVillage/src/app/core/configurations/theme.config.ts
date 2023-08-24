import { ColorConstants } from "../constants/color.constants";
import { ITheme, ThemeType } from "../models/theme.model";

export const THEMES: Record<ThemeType, ITheme> = {
    light: {
        '--primary': ColorConstants.PRIMARY,
        '--secondary': ColorConstants.SECOND,
        '--third': ColorConstants.PRIMARY,
        '--background-1': ColorConstants.PRIMARY,
        '--background-2': ColorConstants.PRIMARY,
        '--background-3': ColorConstants.PRIMARY,
        '--color-1': ColorConstants.COLOR_1,
        '--color-2': ColorConstants.PRIMARY,
        '--color-3': ColorConstants.PRIMARY,
    },
    dark: {
        '--primary': ColorConstants.PRIMARY_VARIANT,
        '--secondary': ColorConstants.SECOND_VARIANT,
        '--third': ColorConstants.PRIMARY_VARIANT,
        '--background-1': ColorConstants.PRIMARY_VARIANT,
        '--background-2': ColorConstants.PRIMARY_VARIANT,
        '--background-3': ColorConstants.PRIMARY_VARIANT,
        '--color-1': ColorConstants.COLOR_1_VARIANT,
        '--color-2': ColorConstants.PRIMARY_VARIANT,
        '--color-3': ColorConstants.PRIMARY_VARIANT
    }
}