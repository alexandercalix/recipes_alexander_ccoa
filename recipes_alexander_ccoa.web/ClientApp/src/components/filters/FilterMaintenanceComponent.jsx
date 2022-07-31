import React, { useEffect, useState } from "react";
import DateRangePicker from "@wojtekmaj/react-daterange-picker";
import { useHttp } from "../../hooks/useHttp";

export const FilterMaintenanceComponent = ({ callback }) => {
  const [range, setRange] = useState([new Date(), new Date()]);
  const [motors, setMotors] = useState();
  const [loading, status, data, Run] = useHttp();

  const returnData = (x) => {
    callback(range, motors);
  };

  const getMotors = () => {
    Run({
      url: `motors`,
    });
  };

  //Component Mounted
  useEffect((x) => {
    getMotors();
  }, []);

  //Data Changed
  useEffect((x) => {}, [data]);

  useEffect(returnData, [range, motors]);

  return (
    <>
      <div className="row">
        <div className="col-sm-12 col-md-4 mt-1">
          {loading && (
            <>
              <div className="spinner-border text-primary" role="status">
                <span className="sr-only"></span>
              </div>
            </>
          )}
          {status.error && (
            <>
              <div className="alert alert-danger">
                <strong>Danger!</strong> Error
              </div>
            </>
          )}
          {!loading && !status.error && !data && (
            <>
              <div className="alert alert-info">
                <strong>Informacion!</strong> No hay Informacion que mostrar
              </div>
            </>
          )}
          {!loading && !status.error && data && (
            <>
              <label>Motores</label>
              <select
                className="form-control"
                onChange={(e) => setMotors(e.target.value)}
              >
                {data.map((x) => (
                  <option key={x} value={x}>
                    {x}
                  </option>
                ))}
              </select>
            </>
          )}
        </div>
        <div className="col-sm-12 col-md-8 mt-1">
          <label>Rango de Tiempo</label> <br />
          <DateRangePicker onChange={setRange} value={range} />
        </div>
      </div>
    </>
  );
};
