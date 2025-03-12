import React from 'react';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import HomeIcon from '@mui/icons-material/Home';

const Navbar: React.FC = () => {
  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
          ProFit
        </Typography>
        <Button color="inherit" startIcon={<HomeIcon />}>
          Home
        </Button>
      </Toolbar>
    </AppBar>
  );
};

export default Navbar;