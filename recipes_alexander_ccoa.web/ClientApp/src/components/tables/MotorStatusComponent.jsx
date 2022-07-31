import React from "react";

export const MotorStatusComponent = ({ history }) => {
  const status = [
    { color: "#3498db", description: "Paro" },
    { color: "#16a085", description: "Trabajando" },
    { color: "#c0392b", description: "Sobrecarga" },
    { color: "#f39c12", description: "Proteccion Desactivada" },
  ];

 

  return (
    <>
    <h3>Historial</h3>
      <ul 
        className="list-group mt-1"
        style={{
          maxHeight: '50vh',
          overflow: "auto"
        }}
        >
        {history.map((x) => (
          <li key={x.id} class="list-group-item d-flex justify-content-between text-light" style={{background:`${status[x.status].color}`}}>
            <h6>{x.start.substring(0,16).replace("T", " ")}</h6>
            <h5>{status[x.status].description}</h5>
          </li>
        ))}
      </ul>
    </>
  );
};
