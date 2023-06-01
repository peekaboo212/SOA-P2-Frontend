import { useEffect, useState } from "react"
import styles from "./Assets.module.css"
import { useGet } from "../../hooks/Request"
import { OwnModal } from "../../common/OwnModal/OwnModal"
import { Add } from "../Add/Add"

export const Assets = () => {
  const [assets, setAssets] = useState([])
  const [open, setOpen] = useState(false)

  const GetAssets = async () => {
    try {
      const response = await useGet('Activo');
      console.log(response)
      setAssets(response)
    } catch (error) {
      console.error(error)
    }
  }

  const handleAdd = () => {
    setOpen(true)
  }

  useEffect(() => {
    GetAssets()
  }, [])
  
  return (
    <div className={styles.mainContainer}>
      <div className={styles.title}>
        <h1>Activos</h1>
      </div>
      <div className={styles.table}>
        <div className={styles.tHeader}>
          <p>name</p>
          <p>description</p>
          <p>status</p>
        </div>
        <div className={styles.tBody}>
          { assets.length >= 0 ?
            assets.map((asset, index) => (
              <div key={index} className={styles.row}>
                <p>{asset.name}</p>
                <p>{asset.description}</p>
                <p>{asset.status === false ? 'Disponible': 'Asignado'}</p>
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