import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { ISnackbarOptions } from "../snackbar.options";

interface IState {
    snackbarOption: ISnackbarOptions;
}

const initialState: IState = {
    snackbarOption: {
        message: '',
        duration: undefined,
        open: false,
        severity: 'info',
    }
}

const snackbarSlice = createSlice({
    name: 'snack',
    initialState: initialState,
    reducers: {
        openSnackbar: (state, action: PayloadAction<ISnackbarOptions>) => {
            state.snackbarOption = action.payload;
        },
        closeSnackbar: (state) => {
            state.snackbarOption = initialState.snackbarOption;
        },
    },
});

export default snackbarSlice.reducer;
export const { openSnackbar,closeSnackbar } = snackbarSlice.actions;