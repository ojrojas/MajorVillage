import React from 'react';
import { Provider } from 'react-redux';
import { RenderOptions, render } from '@testing-library/react';
import { PreloadedState } from '@reduxjs/toolkit';
import SnackbarComponent from '../app/components/snackbar/snackbar.component';
import  SnackbarProvider  from '../app/core/contexts/snackbar.context';
import { AppStore, RootState, setupStore } from './store-test';
import { RouterProvider } from 'react-router-dom';
import router from '../app/core/routes/route.component';

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
    function Wrapper(): React.JSX.Element {
        return <Provider store={appStore}>
            <SnackbarProvider />
                <RouterProvider router={router} />
                <SnackbarComponent />
        </Provider>
    }

    return { appStore, ...render(ui, { wrapper: Wrapper, ...renderOptions }) }
}