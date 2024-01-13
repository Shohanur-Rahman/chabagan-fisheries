import './App.css'
import { Routes, Route } from "react-router";
import { BrowserRouter } from "react-router-dom";
import MainLayout from './layouts/admin/MainLayout'

import publicRoutes from "./routes/PublicRoutes";
import privateRoutes from "./routes/PrivateRoutes";

// import css
import "./assets/css/style.css";
import "./assets/css/responsive.css";
import { IRouteConfig } from './interfaces/IRouteConfig';
import ProtectedRouteGuard from './routes/ProtectedRouteGuard';
import PublicRouteGuard from "./routes/PublicRouteGuard";
function App() {

  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<MainLayout />}>
            {privateRoutes.map((route: IRouteConfig, index) => {
              return (
                <Route
                  path={route.path}
                  key={index}
                  element={
                    <ProtectedRouteGuard>
                      {route.element}
                    </ProtectedRouteGuard>
                  }
                ></Route>
              );
            })}
          </Route>
          {publicRoutes.map((route, index) => {
            return (
              <Route
                path={route.path}
                key={index}
                element={
                  <PublicRouteGuard>
                    {route.element}
                  </PublicRouteGuard>
                }
              ></Route>
            );
          })}
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
