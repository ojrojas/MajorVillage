import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { ISnackProps } from "../snackbar.options";

interface State {
    open: boolean;
    snackOptions: ISnackProps;
}

const InitialState: State = {
    open: false,
    snackOptions: {
        message: '',
        duration: 0,
        title: '',
        severity: undefined
    }
}

const snackbarSlice = createSlice({
    name: 'snack',
    initialState: InitialState,
    reducers: {
        openSnack: (state, action: PayloadAction<ISnackProps>) => {
            state.open = true;
            state.snackOptions.title = action.payload.title;
            state.snackOptions.message = action.payload.message;
            state.snackOptions.duration = action.payload.duration;
            state.snackOptions.severity = action.payload.severity;
        },
        closeSnack: (state) => {
            state.open = false;
        }
    }
})

export const { openSnack, closeSnack } = snackbarSlice.actions;
export default snackbarSlice.reducer;