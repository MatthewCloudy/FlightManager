import HomePage from './pages/HomePage';

const AppRoutes = [
    {
        index: true,
        element: <HomePage />,
    },
    {
        path: "*",
        element: <HomePage />,
    },
];

export default AppRoutes;