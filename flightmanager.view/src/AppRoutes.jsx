import HomePage from './pages/HomePage';
import ManagerPanel from './pages/ManagerPanel';

const AppRoutes = [
    {
        index: true,
        element: <HomePage />,
    },
    {
        path: "/panel",
        element: <ManagerPanel />,
    },
    {
        path: "*",
        element: <HomePage />,
    },
];

export default AppRoutes;