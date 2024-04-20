import { AppBar, Toolbar, styled } from '@mui/material';
import LoginButton from './LoginButton';
import LogoutButton from './LogoutButton';

const StyledToolbar = styled(Toolbar)({
    display: "flex",
    justifyContent: "flex-end",
    background: '#2F1B12',
    height: 60
});

const Filler = styled('div')({
    marginLeft: 'auto',
});


const NavMenu = () => {
    return (
        <AppBar position="fixed">
            <StyledToolbar>
                <Filler />
                <LoginButton />
                <LogoutButton />
            </StyledToolbar>
        </AppBar>
    );
};

export default NavMenu;