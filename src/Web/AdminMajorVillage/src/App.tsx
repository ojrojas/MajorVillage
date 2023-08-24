import { CssBaseline } from '@mui/material';
import React from 'react';
import { RouterProvider } from 'react-router-dom';
import router from './app/core/routes/route.component';
import { useTheme } from './app/hooks';
import { SnackbarProvider } from './app/core/contexts/snackbar.context';
import SnackbarComponent from './app/components/snackbar/snackbar.component';

const App: React.FC = () => {
  const theme = useTheme();
  return (
    <div style={{ ...theme as React.CSSProperties }}>
      <SnackbarProvider>
        <CssBaseline />
        <RouterProvider router={router} />
        <SnackbarComponent />
      </SnackbarProvider>
    </div>
  );
}

export default App;
