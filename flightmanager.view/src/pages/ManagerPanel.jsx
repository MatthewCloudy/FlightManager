import { useState, useEffect } from 'react';
import { Box, TextField, Container, Typography, Button } from '@mui/material';
import { useAuth0 } from "@auth0/auth0-react";
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import './HomePage.css';

const ManagerPanel = () => {
    const { isAuthenticated, getIdTokenClaims } = useAuth0();
    const [flights, setFlights] = useState();
    const [departureCity, setDepartureCity] = useState('');
    const [arrivalCity, setArrivalCity] = useState('');
    const [departureDate, setDepartureDate] = useState('');
    const baseUrl = "https://localhost:7119/";

    const fetchData = async () => {
        try {
            //const claims = await getIdTokenClaims();
            const response = await fetch(`${baseUrl}api/flights`);
            const data = await response.json();
            console.log(data);
            setFlights(data);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    useEffect(() => {
        fetchData();
    }, [isAuthenticated]);

    const handleDelete = async (id) => {
        try {
            const claims = await getIdTokenClaims();
            await fetch(`${baseUrl}api/flights/${id}`, {
                method: 'DELETE',
                headers: {
                    Authorization: `Bearer ${claims["__raw"]}`
                }
            });
            fetchData();
        } catch (error) {
            console.error('Error deleting flight:', error);
        }
    };

    const handleEdit = (id) => {
        console.log(id);
    };

    const handleAdd = async () => {
        try {
            const claims = await getIdTokenClaims();
            await fetch('YOUR_API_ENDPOINT', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    Authorization: `Bearer ${claims["__raw"]}`
                },
                body: JSON.stringify({
                    departureCity,
                    arrivalCity,
                    departureDate
                })
            });
            fetchData();
        } catch (error) {
            console.error('Error adding flight:', error);
        }
    };

    if (isAuthenticated) {
        return (
            <div className='container'>
                <Container className='form-container' maxWidth="sm" sx={{
                    mb: 2,
                    display: "flex",
                    flexDirection: "column",
                    height: 700,
                    overflow: "hidden",
                    overflowY: "scroll",
                }}>
                    <Typography variant="h3" gutterBottom sx={{ color: "maroon" }}>Add Flight</Typography>
                    <TextField
                        label="Departure City"
                        value={departureCity}
                        onChange={(e) => setDepartureCity(e.target.value)}
                        sx={{ mb: 2 }}
                        fullWidth
                    />
                    <TextField
                        label="Arrival City"
                        value={arrivalCity}
                        onChange={(e) => setArrivalCity(e.target.value)}
                        sx={{ mb: 2 }}
                        fullWidth
                    />
                    <div>
                        <LocalizationProvider dateAdapter={AdapterDayjs}>
                            <TextField
                                label="Departure Time"
                                type="datetime-local"
                                value={departureDate}
                                onChange={(e) => setDepartureDate(e.target.value)}
                                InputLabelProps={{ shrink: true }}
                                sx={{ mb: 2 }}
                                fullWidth
                            />
                        </LocalizationProvider>

                    </div>
                    <Button onClick={handleAdd} variant="contained" sx={{ backgroundColor: 'maroon', mb: 3, '&:hover': { backgroundColor: 'brown' } }}>Add</Button>

                    {/* Flight list */}
                    <Typography variant="h3" gutterBottom sx={{ color: "maroon" }}>Flights</Typography>
                    {flights && flights.map(flight => (
                        <Box key={flight.id} border={1} borderRadius={5} p={2} mb={2} >
                            <Typography variant="h6">{flight.name}</Typography>
                            <Typography>Departure Time: {flight.departureTime.split('T')[0]}{' '}{flight.departureTime.split('T')[1]}</Typography>
                            <Typography>Departure City: {flight.departureCity.name}</Typography>
                            <Typography>Arrival City: {flight.arrivalCity.name}</Typography>
                            <Typography>Airplane: {flight.airplane.name}</Typography>
                            <Box sx={{ display: 'flex', justifyContent: 'space-between' }}>
                                <Button onClick={() => handleEdit(flight.id)} variant="contained" sx={{ backgroundColor: 'maroon', '&:hover': { backgroundColor: 'brown' } }}>Edit</Button>
                                <Button onClick={() => handleDelete(flight.id)} variant="contained" sx={{ backgroundColor: 'maroon', '&:hover': { backgroundColor: 'brown' } }}>Delete</Button>
                            </Box>
                            </Box>
                    ))}
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

export default ManagerPanel;
