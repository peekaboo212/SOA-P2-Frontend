import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Employees } from "../components/employees/Employees";

export const MainRouter = () => {
  return (
    <div>
    < BrowserRouter>
        <Routes>
          <Route path="/employees" element={<Employees/>} />
        </Routes>
    </ BrowserRouter>
    </div>
  )
}
