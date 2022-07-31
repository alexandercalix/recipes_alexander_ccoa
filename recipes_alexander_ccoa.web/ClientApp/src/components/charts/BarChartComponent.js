import React, { useEffect } from 'react'
import {Bar} from 'react-chartjs-3';

export const BarChartComponent = ({labels, values, title}) => {
  
    const ds = {
      labels: labels,
      datasets: [
        {
          label: title,
          data: values,
          borderColor: '#3498db',
          backgroundColor: '#2980b9',
        }
      ]
    };

    const options= {
        responsive: true,
        maintainAspectRatio: true,
    }

    useEffect(x=>{
    },[])

  return (
    <div className='row' style={{height: "250px !important"}}>
      <Bar  data={ds} options={options} />

    </div>
  )
}
