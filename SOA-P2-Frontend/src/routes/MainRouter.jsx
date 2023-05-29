import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Employees } from "../components/employees/Employees";
import { Assets } from "../components/assets/Assets";
import { AssetsEmployees } from "../components/assetsEmployees/AssetsEmployees";

export const MainRouter = () => {
  return (
    <div>
    < BrowserRouter>
        <Routes>
          <Route path="/employees" element={<Employees/>} />
          <Route path="/assets" element={<Assets/>} />
          <Route path="/assetsEmployees" element={<AssetsEmployees/>} />
        </Routes>
    </ BrowserRouter>
    </div>
  )
}
