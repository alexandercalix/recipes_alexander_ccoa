import React, { useState, useEffect } from "react";
import { BarChartComponent } from "../../components/charts/BarChartComponent";
import { FilterRecipeComponent } from "../../components/filters/FilterRecipeComponent";
import { RecipesTableComponent } from "../../components/tables/RecipesTableComponent";
import { useHttp } from "../../hooks/useHttp";

export const RecipesPage = () => {
  const [loading, status, data, Run] = useHttp();
  const [graphData, setGraphData] = useState({
    labels: [],
    values: [],
  });

  const [dateRange, setDateRange] = useState();

  function onFilterChange(date, motor) {
    if (date)
    {
      setDateRange(date)
      Run({
        url: `recipes?fi=${date[0].toISOString()}&ff=${date[1].toISOString()}`,
      });
    }
  }

  useEffect(
    (x) => {
      if (data) {
        let ar = [];
        data.forEach((x) => (ar = ar.concat(x.items)));
        const calc = ar.reduce(function (groups, item) {
          var val = item["name"];
          groups[val] = groups[val] || 0;
          groups[val] += item.quantity;
          return groups;
        }, {});

        setGraphData({
          labels: Object.keys(calc),
          values: Object.values(calc),
        });
      }
    },
    [data]
  );

  return (
    <div className="row">
      <FilterRecipeComponent OnlyDate={true} callback={onFilterChange} />
      <div className="row mt-3">
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
        {!loading && !status.error && data && graphData && (
          <>
            <div className="row">
              <BarChartComponent
                labels={graphData.labels}
                values={graphData.values}
                title="Materias Primas"
              />
            </div>
            <div className="row mt-3 mb-2">
              <div className="row d-flex justify-content-between">
                <h3>Detalle Recetas</h3>

                {dateRange && data && (
                  <>
                    <a
                      target="_blank"
                      className="btn btn-success"
                      style={{ width: 120 }}
                      href={`http://localhost:5273/api/recipes/excel/${dateRange[0].toISOString()}/${dateRange[1].toISOString()}`}
                    >
                      Excel
                    </a>
                  </>
                )}
              </div>
              <RecipesTableComponent data={data} />
            </div>
          </>
        )}
      </div>
    </div>
  );
};
