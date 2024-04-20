import { useState, useEffect } from 'react';
import { Box, TextField, Container, Typography, Button } from '@mui/material';
import { useAuth0 } from "@auth0/auth0-react";
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import './HomePage.css';

const ManagerPanel = () => {
    const { isAuthenticated, getIdTokenClaims } = useAuth0();
    const [flights, setFlights] = useState();
    const [flightId, setFlightId] = useState('');
    const [departureCity, setDepartureCity] = useState('');
    const [arrivalCity, setArrivalCity] = useState('');
    const [departureDate, setDepartureDate] = useState('');
    const [name, setName] = useState('');
    const [airplane, setAirplane] = useState('');
    const [editing, setEditing] = useState(false);
    //const baseUrl = "https://localhost:7119/";
    const baseUrl = "http://localhost:5127/";

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

    const handleEdit = (flight) => {
        setEditing(true);
        setFlightId(flight.id);
        setDepartureCity(flight.departureCity.name);
        setArrivalCity(flight.arrivalCity.name);
        setDepartureDate(flight.departureTime);
        setName(flight.name);
        setAirplane(flight.airplane.name);
    };
    const handleEditCancel = () => {
        setEditing(false);
        setDepartureCity('');
        setArrivalCity('');
        setDepartureDate('');
        setName('');
        setAirplane('');
    };
    const handleEditAccept = async () => {
        setEditing(false);
        try {
            const claims = await getIdTokenClaims();
            await fetch(`${baseUrl}api/flights/${flightId}`, {
                method: 'PATCH',
                headers: {
                    'Content-Type': 'application/json',
                    Authorization: `Bearer ${claims["__raw"]}`
                },
                body: JSON.stringify({
                    DepartureCity: departureCity,
                    ArrivalCity: arrivalCity,
                    Airplane: airplane,
                    Name: name,
                    DepartureTime: departureDate,
                })
            });
            fetchData();
            setDepartureCity('');
            setArrivalCity('');
            setDepartureDate('');
            setName('');
            setAirplane('');
        } catch (error) {
            console.error('Error adding flight:', error);
        }
    };

    const handleAdd = async () => {
        try {
            const claims = await getIdTokenClaims();
            await fetch(`${baseUrl}api/flights`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    Authorization: `Bearer ${claims["__raw"]}`
                },
                body: JSON.stringify({
                    DepartureCity: departureCity,
                    ArrivalCity: arrivalCity,
                    Airplane: airplane,
                    Name: name,
                    DepartureTime: departureDate,
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
                    
                    {!editing ? (
                        <Typography variant="h3" gutterBottom sx={{ color: "maroon" }}>Add Flight</Typography>
                    ) : (
                        <Typography variant="h3" gutterBottom sx={{ color: "maroon" }}>Edit Flight</Typography>
                    )}
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
                    <TextField
                        label="Name"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        sx={{ mb: 2 }}
                        fullWidth
                    />
                    <TextField
                        label="Airplane type"
                        value={airplane}
                        onChange={(e) => setAirplane(e.target.value)}
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
                    {!editing ? (
                        <Button onClick={handleAdd} variant="contained" sx={{ backgroundColor: 'maroon', mb: 3, '&:hover': { backgroundColor: 'brown' } }}>Add</Button>
                    ) : (
                            <div>
                                <Button onClick={handleEditAccept} variant="contained" sx={{ backgroundColor: 'maroon', mb: 3, '&:hover': { backgroundColor: 'brown' } }}>Accept</Button>
                                <Button onClick={handleEditCancel} variant="contained" sx={{ backgroundColor: 'maroon', mb: 3, '&:hover': { backgroundColor: 'brown' } }}>Cancel Edit</Button>
                            </div>
                        )}

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
                                <Button onClick={() => handleEdit(flight)} variant="contained" sx={{ backgroundColor: 'maroon', '&:hover': { backgroundColor: 'brown' } }}>Edit</Button>
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
