import { useEffect, useState } from "react"
import styles from "./AssetsEmployees.module.css"
import { useGet } from "../../hooks/Request"
import { OwnModal } from "../../common/OwnModal/OwnModal"
import { Add } from "../Add/Add"

export const AssetsEmployees = () => {
  const [assetsEmployees, setAssetsEmployees] = useState([])
  const [open, setOpen] = useState(false)

  const GetAssetsEmpolyees = async () => {
    try {
      const response = await useGet('Activo_Employee/undelivery');
      console.log(response)
      setAssetsEmployees(response)
    } catch (error) {
      console.error(error)
    }
  }

  const handleAdd = () => {
    setOpen(true)
  }

  useEffect(() => {
    GetAssetsEmpolyees()
  }, [])
  
  return (
    <div className={styles.mainContainer}>
      <div className={styles.title}>
        <h1>Activos Empleados</h1>
      </div>
      <div className={styles.table}>
        <div className={styles.tHeader}>
          <p>Empleado</p>
          <p>Activo</p>
          <p>assignment_date</p>
          <p>release_date</p>
          <p>activo</p>
          <p>Acciones</p>
        </div>
        <div className={styles.tBody}>
          { assetsEmployees.length >= 0 ?
            assetsEmployees.map((assetsEmployees, index) => (
              <div key={index} className={styles.row}>
                <p>{assetsEmployees.nameEmployee}</p>
                <p>{assetsEmployees.nameActivo}</p>
                <p>{assetsEmployees.assignment_date}</p>
                <p>{assetsEmployees.release_date}</p>
                <p>{assetsEmployees.status === false ? 'Disponible': 'Asignado'}</p>
                <div className={styles.btnEdit}>
                  <button>Editar</button>
                </div>
              </div>
            )): null
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
