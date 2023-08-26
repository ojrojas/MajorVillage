import { TypedUseSelectorHook, useDispatch, useSelector } from 'react-redux';
import type { RootState, AppDispatch } from './store';
import { ThemeContext } from './core/contexts/theme.context';
import React from 'react';
import { Breakpoint, useMediaQuery, useTheme as muiUseTheme } from '@mui/material';

// Use throughout your app instead of plain `useDispatch` and `useSelector`
export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
export const useTheme = () => React.useContext(ThemeContext);
export const useResponsive = (query: string, start: number | Breakpoint, end: number | Breakpoint) => {
    const theme = muiUseTheme();

    const mediaUp = useMediaQuery(theme.breakpoints.up(start));
    const mediaDown = useMediaQuery(theme.breakpoints.down(start));
    const mediaBetween = useMediaQuery(theme.breakpoints.between(start, end));
    const mediaOnly = useMediaQuery(theme.breakpoints.only(start as Breakpoint));

    switch (query) {
        case 'up':
            return mediaUp;
        case 'down':
            return mediaDown;
        case 'between':
            return mediaBetween;
    }

    return mediaOnly;
}

