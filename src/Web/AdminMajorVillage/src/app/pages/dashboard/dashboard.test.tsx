import { screen } from "@testing-library/react";
import { RenderWithProviders } from "../../../testing/utils-test";
import DashboardPage from "./dashboard";

describe("load dashboard Page Should", () => {
    test('load nav item item-nav-typeusers', async () => {
      const {appStore} =   RenderWithProviders(<DashboardPage/>,{
            preloadedState: {
                login: {
                    loginRequest: undefined,
                    loginResponse: undefined,
                    loading: false,
                    error: undefined,
                    logged: true,
                    user: undefined
                }, snackbar: {
                    snackbarOption: {
                        message: '',
                        duration: undefined,
                        open: false,
                        severity: 'info'
                    }
                }
            }
        });
        expect(screen.getByTestId('list-item-nav').hasChildNodes()).toBe(true)
        expect(screen.getByTestId('item-nav-typeusers')).toHaveTextContent('Type Users')
        expect(screen.getByTestId('item-nav-users')).toHaveTextContent('Users')
        expect(screen.getByTestId('item-nav-settings')).toHaveTextContent('Settings')
        expect(appStore.getState().login.logged).toBe(true)
    });
})