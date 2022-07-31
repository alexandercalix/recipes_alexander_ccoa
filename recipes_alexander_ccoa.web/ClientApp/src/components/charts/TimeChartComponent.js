import React, { useEffect } from 'react'
import {Line} from 'react-chartjs-3';

export const TimeChartComponent = ({labels, values, title}) => {

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

    useEffect(() => {
      console.log(labels,values)
    }, [labels,values])
    

  return (
    <div className='row' style={{height: "250px !important"}}>
      <Line  data={ds} options={options} />

    </div>
  )
}
