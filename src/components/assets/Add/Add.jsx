import { useState } from 'react'
import { usePost } from '../../hooks/Request'
import styles from './Add.module.css'

// eslint-disable-next-line react/prop-types
export const Add = () => {
  const [form, setForm] = useState({
    name: '',
    description: ''
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
    await usePost('Activo', form )
    window.location.reload()
  }

  return (
    <div className={styles.mainContainer}>
      <form className={styles.form} onSubmit={handleSubmit}>
        <div className={styles.field}>
          <label htmlFor="name">Nombre</label>
          <input type="text" name="name" value={form.name} onChange={handleChange}/>
        </div>
        <div className={styles.field}>
          <label htmlFor="description">Descripción</label>
          <input type="text" name="description" value={form.description} onChange={handleChange}/>
        </div>
        <input type="submit" value="Guardar"/>
      </form>
    </div>
  )
}
