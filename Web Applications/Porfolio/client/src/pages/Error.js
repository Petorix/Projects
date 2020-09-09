import React, { useEffect } from "react";
import sadpanda from "../assets/sadpanda.svg";

import "./Error.css";

function Error() {
  useEffect(() => {
    document.title = "Page not found";
  });

  return (
    <div>
      <div className="error-wrapper">
        <p>Whoopsie</p>
        <img className="error404" src={sadpanda} alt="" />
        <p>Page not found</p>
      </div>
    </div>
  );
}

export default Error;
