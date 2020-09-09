import React from "react";
import { Route, Switch } from "react-router-dom";

// Pages for routing
import Home from "./pages/Home";
import ErrorPage from "./pages/Error";

// Components used
import Header from "./components/Header";

import "./App.css";

function App() {
  return (
    <div className="App">
      <Switch>
        <Route exact={true} path="/" component={Home} />
        <Route path="/:id" component={ErrorPage} />
      </Switch>
    </div>
  );
}

export default App;
