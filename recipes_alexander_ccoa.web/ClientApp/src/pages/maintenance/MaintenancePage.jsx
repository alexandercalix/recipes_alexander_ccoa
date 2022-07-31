import React, { useEffect, useState } from "react";
import { PieChartComponent } from "../../components/charts/PieChartComponent";
import { FilterMaintenanceComponent } from "../../components/filters/FilterMaintenanceComponent";
import { MotorRTStatusComponent } from "../../components/tables/MotorRTStatusComponent";
import { MotorStatusComponent } from "../../components/tables/MotorStatusComponent";
import { useHttp } from "../../hooks/useHttp";

export const MaintenancePage = () => {
  const [loading, status, data, Run, urlBase] = useHttp();
  const [dateRange, setDateRange] = useState();
  const [motor, setMotor] = useState();
  const statusC = [
    { color: "#3498db", description: "Paro" },
    { color: "#16a085", description: "Trabajando" },
    { color: "#c0392b", description: "Sobrecarga" },
    { color: "#f39c12", description: "Proteccion Desactivada" },
  ];

  const OnChange = (range, motor) => {
    if (range && motor) {
      setDateRange(range)
      setMotor(motor)
      Run({
        url: `motors/${motor}/${range[0].toISOString()}/${range[1].toISOString()}`,
      });
    }
  };

  useEffect(
    (x) => {
      console.log(data);
    },
    [data]
  );

  return (
    <>
      <div className="row">
        <FilterMaintenanceComponent callback={OnChange} />
      </div>
      <div className="row mt-2 ">
        {dateRange && data && (
          <>
            <a
              target="_blank"
              className="btn btn-success"
              style={{ width: 120 }}
              href={`${urlBase}motors/excel/${motor}/${dateRange[0].toISOString()}/${dateRange[1].toISOString()}`}
            >
              Excel
            </a>
          </>
        )}
      </div>
      <div className="row mt-3">
        <div className="col-sm-12 col-md-6">
          <MotorRTStatusComponent />
        </div>

        <div className="col-sm-12 col-md-6">
          {data && <MotorStatusComponent history={data.history} />}
        </div>
      </div>
      <div className="row ">
        <div className="col-sm-12 col-md-6 mt-4">
          <h3>OEE</h3>
          {data && (
            <PieChartComponent
              labels={data.oee.map((x) => x.status)}
              values={data.oee.map((x) => x.percentage)}
              title={"Tiempo"}
            />
          )}
        </div>
        <div className="col-sm-12 col-md-6 mt-4">
          <h3>Resumen OEE</h3>
          <ul className="list-group">
            {data &&
              data.oee.map((x) => (
                <li
                  key={x.id}
                  className="list-group-item"
                  style={{
                    borderLeftWidth: 5,
                    borderLeftColor: statusC[x.status].color,
                  }}
                >
                  <h6>{statusC[x.status].description}</h6>
                  <h6>{x.time.substring(1, 8)}</h6>
                </li>
              ))}
          </ul>
        </div>
      </div>
    </>
  );
};
