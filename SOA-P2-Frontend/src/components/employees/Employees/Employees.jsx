import { useEffect, useState } from "react"
import styles from "./Employees.module.css"
import { useGet } from "../../hooks/Request"
import { OwnModal } from "../../common/OwnModal/OwnModal"
import { Add } from "../Add/Add"

export const Employees = () => {
  const [employees, setEmployees] = useState([])
  const [open, setOpen] = useState(false)

  const handleAdd = () => {
    setOpen(true)
  }

  const GetEmployees = async () => {
    try {
      const response = await useGet('Employees')
      setEmployees(response)
      console.log(response)
    } catch (error) {
      console.error(error)
    }
  }

  useEffect(() => {
    GetEmployees()
  }, [])
  
  return (
    <div className={styles.mainContainer}>
      <div className={styles.title}>
        <h1>Empleados</h1>
      </div>
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
        <div className={styles.tBody}>
          { employees.length >= 0 ? 
            employees.map((employee, index) => (
              <div key={index} className={styles.row}>
                <p>{employee.name}</p>
                <p>{employee.last_name}</p>
                <p>{employee.birth_date}</p>
                <p>{employee.email}</p>
                <p>{employee.num_employee}</p>
                <p>{employee.curp}</p>
                <p>{employee.date_hire}</p>
                <p>{employee.status ? 'Activo': 'No activo'}</p>
              </div>
            ))
            : null
          }
        </div>
      </div>
      <div className={styles.btnAdd}>
        <button onClick={handleAdd}>Agregar</button>
      </div>
      <OwnModal setOpen={setOpen} open={open}>
        <Add />
      </OwnModal>
    </div>
  )
}