import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import './index.css'
import { Auth0Provider } from "@auth0/auth0-react";
import { BrowserRouter } from 'react-router-dom';

const domain = "dev-gj7hu2jxjjewofk8.us.auth0.com";
const clientId = "tazJPS9HIKBVN10dLEeSFbP2JHD7eQqm";


ReactDOM.createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <BrowserRouter>
            <Auth0Provider
                domain={domain}
                clientId={clientId}
                redirectUri={window.location.origin}
            >
                <App />
            </Auth0Provider>
        </BrowserRouter>
    </React.StrictMode>,
)