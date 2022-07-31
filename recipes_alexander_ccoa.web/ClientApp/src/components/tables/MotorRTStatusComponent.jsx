import React, { useEffect } from "react";
import { useHttp } from "../../hooks/useHttp";

export const MotorRTStatusComponent = () => {
  const [loading, status, data, Run] = useHttp();

  const interval = setTimeout(() => {
    if (!loading)
      Run({
        url: `motors/rt`,
      });
  }, 2000);

  useEffect(() => {
    return () => {
      clearInterval(interval);
    };
  }, []);

  useEffect(
    (x) => {
    //  console.log(data);
    },
    [data]
  );

  const statusC = [
    { color: "#3498db", description: "Paro" },
    { color: "#16a085", description: "Trabajando" },
    { color: "#c0392b", description: "Sobrecarga" },
    { color: "#f39c12", description: "Proteccion Desactivada" },
  ];

  return (
    <>
      <h3>Tiempo Real</h3>
      <ul className="list-group mt-1">
        {data == true &&
          data.map((x) => (
            <li
              key={x.id}
              className="list-group-item text-light"
              style={{ background: `${statusC[x.statu].color}` }}
            >
              <div className="row">
                <div className="col-sm-12 col-md-6">
                  <h6>{x.fecha.substring(11, 16).replace("T", " ")}</h6>
                </div>
                <div className="col-sm-12 col-md-6 d-flex justify-content-between">
                  <h5>Trabajando</h5>
                  <h5>{x.noMotor}</h5>
                </div>
              </div>
            </li>
          ))}
      </ul>
    </>
  );
};
