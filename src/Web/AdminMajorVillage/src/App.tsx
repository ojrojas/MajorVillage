import { CssBaseline } from '@mui/material';
import React from 'react';
import { RouterProvider } from 'react-router-dom';
import router from './app/core/routes/route.component';
import { SnackbarProvider } from './app/core/contexts/snackbar.context';
import SnackbarComponent from './app/components/snackbar/snackbar.component';
import { ThemeProvider } from './app/core/contexts/theme.context';

const App: React.FC = () => {
  return (
    <ThemeProvider>
      <SnackbarProvider>
        <CssBaseline />
        <RouterProvider router={router} />
        <SnackbarComponent />
      </SnackbarProvider>
    </ThemeProvider>
  );
}

export default App;
