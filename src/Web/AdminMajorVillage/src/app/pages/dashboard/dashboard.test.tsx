import { screen } from "@testing-library/react";
import { RenderWithProviders } from "../../../testing/utils-test";
import LayoutComponent from "../../components/layout/layout.component";

describe("load dashboard Page Should", () => {
    test('load nav list-items item-navs', async () => {
      const {appStore} = RenderWithProviders(<LayoutComponent/>,{
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