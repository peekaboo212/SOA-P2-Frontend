import { useState } from 'react'
import { usePost } from '../../hooks/Request'
import styles from './Add.module.css'

// eslint-disable-next-line react/prop-types
export const Add = () => {
  const [form, setForm] = useState({
    id_empleoyee: '',
    id_activo: '',
    delivery_date: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target
    setForm((prev) => {
      return {...prev, [name]: value}
    })
  }

  const handleSubmit = async(e) => {
    e.preventDefault()
    // eslint-disable-next-line react-hooks/rules-of-hooks
    await usePost('Activo_Employee', form )
    window.location.reload()
  }

  return (
    <div className={styles.mainContainer}>
      <form className={styles.form} onSubmit={handleSubmit}>
        <div className={styles.field}>
          <label htmlFor="id_employee">id_empleado</label>
          <input type="text" name="id_employee" value={form.id_employee} onChange={handleChange}/>
        </div>
        <div className={styles.field}>
          <label htmlFor="id_activo">id_activo</label>
          <input type="text" name="id_activo" value={form.id_activo} onChange={handleChange}/>
        </div>
        <div className={styles.field}>
          <label htmlFor="delivery_date">id_activo</label>
          <input type="text" placeholder="yyyy-mm-dd" name="delivery_date" value={form.delivery_date} onChange={handleChange}/>
        </div>
        <input type="submit" value="Guardar"/>
      </form>
    </div>
  )
}