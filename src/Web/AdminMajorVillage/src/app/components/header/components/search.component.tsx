import { Search, SearchRounded } from "@mui/icons-material";
import { Box, Button, ClickAwayListener, Icon, Input, InputAdornment, Slide, alpha, styled } from "@mui/material"
import React, { useState } from "react"

const APPBAR_MOBILE = 64;
const APPBAR_DESKTOP = 92;

const SearchbarStyle = styled('div')(({theme}) => ({
    top: 0,
    left: 0,
    zIndex: 1000,
    width: '100%',
    display: 'flex',
    position: 'absolute',
    alignItems: 'center',
    height: APPBAR_MOBILE,
    backdropFilter: 'blur(6px)',
    WebkitBackdropFilter: 'blur(6px)', // Fix on Mobile
    padding: theme.spacing(0, 3),
    boxShadow: theme.shadows[12],
    backgroundColor: `${alpha(theme.palette.background.default, 0.72)}`,
    [theme.breakpoints.up('md')]: {
      height: APPBAR_DESKTOP,
      padding: theme.spacing(0, 5)
    }
}));

const SearchComponent:React.FC = ()=> {

    const [isOpen, setOpen] = useState(false);

    const handleOpen = () => {
      setOpen((prev) => !prev);
    };
  
    const handleClose = () => {
      setOpen(false);
    };

    return (
        <ClickAwayListener onClickAway={handleClose}>
      <div>
        {!isOpen && (
          <Search onClick={handleOpen} />
        )}

        <Slide direction="down" in={isOpen} mountOnEnter unmountOnExit>
          <SearchbarStyle>
            <Input
              autoFocus
              fullWidth
              disableUnderline
              placeholder="Search…"
              startAdornment={
                <InputAdornment position="start">
                  <Box component={SearchRounded} sx={{ color: 'text.disabled', width: 20, height: 20 }} />
                </InputAdornment>
              }
              sx={{ mr: 1, fontWeight: 'fontWeightBold' }}
            />
            <Button variant="contained" onClick={handleClose}>
              Search
            </Button>
          </SearchbarStyle>
        </Slide>
      </div>
    </ClickAwayListener>
    )
}

export default SearchComponent;