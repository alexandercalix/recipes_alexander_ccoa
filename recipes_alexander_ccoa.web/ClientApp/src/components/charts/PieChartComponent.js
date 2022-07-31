import React from 'react'
import {Pie} from 'react-chartjs-3';

export const PieChartComponent = ({labels, values}) => {

  const statusC = [
    { color: "#3498db", description: "Paro" },
    { color: "#16a085", description: "Trabajando" },
    { color: "#c0392b", description: "Sobrecarga" },
    { color: "#f39c12", description: "Proteccion Desactivada" },
  ];


    const ds = {
      labels: labels.map(x=> statusC[x].description),
      datasets: [
        {
          label: "Estado",
          data: values,
          borderColor: labels.map(x=> statusC[x].color),
          backgroundColor: labels.map(x=> statusC[x].color),
        }
      ]
    };

    const options= {
        responsive: true,
        maintainAspectRatio: true,
        plugins: {
          title: {
            display: true,
            text: 'Custom Chart Title'
        },
          tooltip: {
            callbacks: {
              label: (item) => {
                // Note this code is not handling edge cases
                const value = item.dataset[item.dataIndex];                
                return `${item.label}: ${value}%`;
              }
            }
          }
        }
    }
  return (
    <div className='row' style={{height: "250px !important"}}>
      <Pie  data={ds} options={options} />
    </div>
  )
}
