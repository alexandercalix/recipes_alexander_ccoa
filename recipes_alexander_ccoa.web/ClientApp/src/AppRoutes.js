
import { Home } from "./components/Home";
import { MaintenancePage } from "./pages/maintenance/MaintenancePage";
import { RecipesPage} from './pages/recipes/RecipesPage'
import { SpecificPage } from "./pages/recipes/SpecificPage";
const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/recipes/general',
    element: <RecipesPage />
  },
  {
    path: '/recipes/specific',
    element: <SpecificPage />
  },
  {
    path: '/maintenance',
    element: <MaintenancePage />
  }
];

export default AppRoutes;
