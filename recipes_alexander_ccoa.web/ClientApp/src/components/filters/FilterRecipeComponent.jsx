import React, { useEffect, useState } from "react";
import DateRangePicker from "@wojtekmaj/react-daterange-picker";
import { useHttp } from "../../hooks/useHttp";

export const FilterRecipeComponent = ({ OnlyDate, callback }) => {
  const [range, setRange] = useState([new Date(), new Date()]);

  const [recipe, setRecipe] = useState();
  const [loading, status, data, Run] = useHttp();

  const returnData = (x) => {
    callback(range, recipe);
  };

  useEffect(returnData, [recipe, range[0], range[1]]);

  useEffect((x) => {
    Run({
      url: `recipes/list`,
    });
  }, []);

  useEffect(
    (x) => {
      if (data) setRecipe(data[0]);
    },
    [data]
  );

  return (
    <>
      <div className="row">
        {!OnlyDate && (
          <>
            <div className="col-sm-12 col-md-4 mt-1">
              {loading && (
                <>
                  <div className="spinner-border text-psmary" role="status">
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
              {data && (
                <>
                  <label>Recetas</label>
                  <select
                    value={recipe}
                    className="form-control"
                    onChange={(x) => setRecipe(x.target.value)}
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
          </>
        )}
        <div className="col-sm-12 col-md-8 mt-1">
          <label>Rango de Tiempo</label> <br />
          <DateRangePicker onChange={setRange} value={range} />
        </div>
      </div>
    </>
  );
};
