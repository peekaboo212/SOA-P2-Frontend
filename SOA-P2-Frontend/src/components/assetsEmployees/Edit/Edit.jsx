/* eslint-disable react/prop-types */
import { useEffect, useState } from 'react'
import { usePost } from '../../hooks/Request'
import styles from './Edit.module.css'
import { OwnSelect } from '../../common/OwnSelect/OwnSelect';
import { useGet } from "../../hooks/Request"

// eslint-disable-next-line react/prop-types, no-unused-vars
export const Edit = ({entity}) => {
  const [employeesForSelect, setEmployeesForSelect] = useState([])
  const [assetsForSelect, setAssetsForSelect] = useState([])

  const [deliveryDate, setDeliveryDate] = useState('')
  const [idEmpleoyee, setidEmpleoyee] = useState('')
  const [idActivo, setIdActivo] = useState('')

  const handleIdEmpleoyee = (e) => setidEmpleoyee(e.target.value)
  const handleIdActivo = (e) => setIdActivo(e.target.value)
  const handleDeliveryDate = (e) => setDeliveryDate(e.target.value)

  const handleSubmit = async(e) => {
    e.preventDefault()
    const form = {
      id_empleoyee: idEmpleoyee,
      id_activo: idActivo,
      delivery_date: deliveryDate
    }
    // console.log(form)
    // eslint-disable-next-line react-hooks/rules-of-hooks
    await usePost('Activo_Employee', form )
    window.location.reload()
  }

  const formatEmployees = (employees) => {
    return employees.map((employee) => {
      return { label: `${employee.name}`, value: employee.num_employee }
    })
  }

  const formatAssets = (assets) => {
    let array = []
    assets.forEach(asset => {
      if (asset.status == false) {
        array.push({ label: `${asset.name}`, value: asset.id })
      }
    });
    return array
  }
  const GetEmployees = async () => {
    try {
      const response = await useGet('Employees')
      const data = formatEmployees(response)
      setEmployeesForSelect(data)
      data.map((element) => {
        // eslint-disable-next-line react/prop-types
        if(entity.id_empleoyee === element.value){
          setidEmpleoyee(element.value)
        }
      })
    } catch (error) {
      console.error(error)
    }
  }

  const GetAssets = async () => {
    try {
      const response = await useGet('Activo');
      const data = formatAssets(response)
      setAssetsForSelect(data)
      data.map((element) => {
        console.log(element.value + ' ' + entity.id_activo)
        if(entity.id_activo == element.value){
          setIdActivo(element.value)
        }
      })
    } catch (error) {
      console.error(error)
    }
  }

  // const setValuesForEdit = () => {
  //   employeesForSelect.map((employee) => {
  //     console.log(employee)
  //     // eslint-disable-next-line react/prop-types
  //     // if(entity.id_empleoyee === employee.value){
  //     //   setidEmpleoyee(employee.value)
  //     // }
  //   })
  // }

  useEffect(() => {
    // console.log(entity)
    GetEmployees()
    GetAssets()
    // setValuesForEdit()
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  return (
    <div className={styles.mainContainer}>
      <form className={styles.form} onSubmit={handleSubmit}>
        <div className={styles.field}>
          <OwnSelect label={'Empleado'} value={idEmpleoyee} handleChange={handleIdEmpleoyee} data={employeesForSelect} name={'id_employee'}/>
        </div>
        <div className={styles.field}>
          <OwnSelect label={'Activo'} value={idActivo} handleChange={handleIdActivo} data={assetsForSelect} name={'id_activo'} />
        </div>
        <div className={styles.field}>
          <label htmlFor="delivery_date">id_activo</label>
          <input type="text" placeholder="yyyy-mm-dd" name="delivery_date" value={deliveryDate} onChange={handleDeliveryDate}/>
        </div>
        <input type="submit" value="Guardar"/>
      </form>
    </div>
  )
}
