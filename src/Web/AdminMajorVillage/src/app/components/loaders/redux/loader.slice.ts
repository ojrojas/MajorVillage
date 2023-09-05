import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { initialLoaderOptions } from "../../../core/contexts/loaders.context";
import { LoaderOptions } from "../loader.options";

interface State {
    options: LoaderOptions;
}

const initialState: State = {
    options: initialLoaderOptions
}

const loaderSlice = createSlice({
    name: 'loader',
    initialState: initialState,
    reducers: {
        openLoader: (state, payload: PayloadAction<LoaderOptions>) => {
            state.options = payload.payload;
        },
        closeLoader: (state) => {
            state.options = initialLoaderOptions;
        }
    }
});

export default loaderSlice.reducer;
export const { openLoader, closeLoader } = loaderSlice.actions;