import {  useState } from "react";

export const useHttp = () => {
  const [loading, setLoading] = useState(false);
  const [status, setStatus] = useState({ error: false, msg: "" });
  const [data, setData] = useState();

  const [ urlBase, setUrlBase ] = useState(!process.env.NODE_ENV || process.env.NODE_ENV === 'development' ? "http://localhost:5273/api/" : "http://localhost/api/");

  const Run = ({ url }) => {
    if (url) setStatus({ ...status, error: false });
    setLoading(true);
  

    fetch(urlBase+url)
      .then((x) => x.json())
      .then((x) => {       
        setLoading(false);
        setData(x);
      })
      .catch((x) => {
        setStatus({
          error: true,
          msg: "Error al intentar Consultar Informacion",
        });
        setLoading(false)
      });
  };

  return [loading, status, data, Run, urlBase];
};
