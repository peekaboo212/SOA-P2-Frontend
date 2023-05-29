import { useEffect, useState } from "react"
import styles from "./styles.css"
//import { useGet } from "../hooks/Request"

export const Employees = () => {
  const [employees, setEmployees] = useState([])

  const GetEmployees = async () => {
    try {
    //   const response = await useGet('Employees')
    //   setEmployees(response)
    setEmployees([])

    } catch (error) {
      console.error(error)
    }
  }

  useEffect(() => {
    GetEmployees()
  }, [])
  
  return (
    <div>
        <h1>Empleados</h1>
        <div className={styles.table}>
          <div className={styles.tHeader}>
            <p>name</p>
            <p>last_name</p>
            <p>birth_date</p>
            <p>email</p>
            <p>num_employee</p>
            <p>curp</p>
            <p>date_hire</p>
            <p>status</p>
          </div>
          <div>
            {employees.map((employee, index) => (
              <div key={index} className={styles.row}>
                <p>{employee.name}</p>
                <p>{employee.last_name}</p>
                <p>{employee.birth_date}</p>
                <p>{employee.email}</p>
                <p>{employee.num_employee}</p>
                <p>{employee.curp}</p>
                <p>{employee.date_hire}</p>
                <p>{employee.status}</p>
              </div>
            ))}
          </div>
        </div>
    </div>
  )
}