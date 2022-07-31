import React from "react";

export const RecipesTableComponent = ({ data }) => {
  return (
    <>
      <table className="table table-responsive">
        <thead>
          <tr>
            <th>No.</th>
            <th>Nombre</th>
            <th>Fecha</th>
            <th>Inst 1</th>
            <th>Inst 2</th>
            <th>Inst 3</th>
            <th>Inst 4</th>
            <th>Inst 5</th>
            <th>Inst 6</th>
            <th>Inst 7</th>
            <th>Inst 8</th>
          </tr>
        </thead>
        <tbody>
          {data.map((i, index) => (
            <tr key={i.id}>
              <td>{index + 1}</td>
              <td>{i.mezcla}</td>
              <td>{i.fecha.replace("T", " ")}</td>
              {i.items.map((y) => (
                    <td key={y.name}>{y.name}: {y.quantity}</td>
                  ))}
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
};
