/* eslint-disable react/prop-types */
import Select from '@mui/material/Select'
import MenuItem from '@mui/material/MenuItem'
import FormControl from '@mui/material/FormControl'

export const OwnSelect = ({ label, value, handleChange, data, name }) => {
  return (
    <FormControl>
      <label >
        {label}
        <Select 
        // className={styles.optionSelect}
        displayEmpty
        inputProps={{ 'aria-label': 'Without label' }}
        value={value}
        onChange={handleChange}
        name={name}
        >
          {data.map((option, index) => (
              <MenuItem key={index} value={option.value}>{option.label}</MenuItem>
          ))}
        </Select>
      </label>
    </FormControl>
  )
}