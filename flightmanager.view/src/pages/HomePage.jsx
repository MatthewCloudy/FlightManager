import { Select, MenuItem, FormControl, InputLabel, Box, TextField, Container, Typography, Button } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { useAuth0 } from "@auth0/auth0-react";
import './HomePage.css';

const SearchForm = () => {

    const navigate = useNavigate();
    const { isAuthenticated } = useAuth0();

    const handleClick = () => {
        navigate('/panel');
    };

    if (isAuthenticated)
    {
        return (
            <div className='container'>

                <Container className='form-container' maxWidth="sm">
                    <Button onClick={handleClick }>Manager panel</Button>
                </Container>
            </div>
        );
    }

    return (
        <div className='container'>

            <Container className='form-container' maxWidth="sm">
                <Typography>Log in to move to manager panel</Typography>
            </Container>
        </div>
    );
};

export default SearchForm;