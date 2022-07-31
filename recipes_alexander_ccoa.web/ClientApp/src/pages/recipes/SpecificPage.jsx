import React, { useEffect, useState } from "react";
import { BarChartComponent } from "../../components/charts/BarChartComponent";
import { FilterRecipeComponent } from "../../components/filters/FilterRecipeComponent";
import { useHttp } from "../../hooks/useHttp";

export const SpecificPage = () => {
  const [ loading,status,data, Run] = useHttp();

  const onChangeFilter = (date, recipe) => {
    if ((date, recipe))
      Run({
        url: `recipes/${recipe}/${date[0].toISOString()}/${date[1].toISOString()}`,
      });
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
        <FilterRecipeComponent callback={onChangeFilter} />
      </div>
      <div className="row">
        {data && (
          <BarChartComponent
            labels={data.map((x) => x.date.replace('T',' ').substring(0,16))}
            values={data.map((x) => x.total)}
            title={"Total"}
          />
        )}
      </div>
    </>
  );
};
