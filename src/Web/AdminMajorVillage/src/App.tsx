import { CssBaseline } from '@mui/material';
import React from 'react';
import { RouterProvider } from 'react-router-dom';
import router from './app/core/routes/route.component';
import SnackbarProvider from './app/core/contexts/snackbar.context';
import ThemeProvider from './app/core/contexts/theme.context';
import LoaderProvider from './app/core/contexts/loaders.context';

const App: React.FC = () => {
  return (
    <ThemeProvider>
      <CssBaseline />
      <SnackbarProvider />
      <LoaderProvider />
      <RouterProvider router={router} />
    </ThemeProvider>
  );
}

export default App;
