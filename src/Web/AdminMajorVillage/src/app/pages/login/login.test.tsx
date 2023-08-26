import { screen } from "@testing-library/react";
import { RenderWithProviders } from "../../../testing/utils-test";
import App from "../../../App";


describe("load Login Page Should", () => {
    test('load input username login page', async () => {
        RenderWithProviders(<App />);
        expect(screen.getByTestId('outlined-username')).toHaveTextContent('*Username *')
    });

    test('load input password login page', async () => {
        RenderWithProviders(<App />);
        expect(screen.getByTestId('outlined-password')).toHaveTextContent('*Password *')
    });
})
