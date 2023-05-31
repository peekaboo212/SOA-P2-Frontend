import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Employees } from "../components/employees/Employees/Employees";
import { Assets } from "../components/assets/Assets/Assets";
import { AssetsEmployees } from "../components/assetsEmployees/AssetsEmployees/AssetsEmployees";

export const MainRouter = () => {
  return (
    <div>
    < BrowserRouter>
        <Routes>
          <Route path="/" element={<Employees/>} />
          <Route path="/assets" element={<Assets/>} />
          <Route path="/assetsEmployees" element={<AssetsEmployees/>} />
        </Routes>
    </ BrowserRouter>
    </div>
  )
}
