import { useEffect, useState } from "react"
import styles from "./styles.css"
//import { usePost } from "../hooks/Request"

export const Assets = () => {
  const [assets, setAssets] = useState([])

  const GetAssets = async () => {
    try {
    //   const response = usePost('assets');
    //   setAssets(response)
    setAssets([])
    } catch (error) {
      console.error(error)
    }
  }

  useEffect(() => {
    GetAssets()
  }, [])
  
  return (
    <div>
        <h1>Empleados</h1>
        <div className={styles.table}>
          <div className={styles.tHeader}>
            <p>name</p>
            <p>description</p>
            <p>status</p>
          </div>
          <div>
            {assets.map((asset, index) => (
              <div key={index} className={styles.row}>
                <p>{asset.name}</p>
                <p>{asset.description}</p>
                <p>{asset.status}</p>
                <div className={styles.btnEdit}>
                  <button>Editar</button>
                </div>
              </div>
            ))}
          </div>
        </div>
        <div className={styles.btnAdd}>
          <button>Agregar</button>
        </div>
    </div>
  )
}