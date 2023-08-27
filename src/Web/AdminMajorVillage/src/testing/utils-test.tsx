import React, { PropsWithChildren } from 'react';
import { Provider } from 'react-redux';
import { RenderOptions, render } from '@testing-library/react';
import { PreloadedState } from '@reduxjs/toolkit';
import SnackbarComponent from '../app/components/snackbar/snackbar.component';
import { SnackbarProvider } from '../app/core/contexts/snackbar.context';
import { AppStore, RootState, setupStore } from './store-test';

interface ExtendedRenderOptions extends Omit<RenderOptions, 'queries'> {
    preloadedState?: PreloadedState<RootState>
    appStore?: AppStore,
}

export function RenderWithProviders(
    ui: React.ReactElement,
    {
        preloadedState = {},
        appStore = setupStore(preloadedState),
        ...renderOptions
    }: ExtendedRenderOptions = {}
) {
    function Wrapper({ children }: PropsWithChildren<{}>): React.JSX.Element {
        return <Provider store={appStore}>
            <SnackbarProvider>
                {children}
                <SnackbarComponent />
            </SnackbarProvider>
        </Provider>
    }

    return { appStore, ...render(ui, { wrapper: Wrapper, ...renderOptions }) }
}