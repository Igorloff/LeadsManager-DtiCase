import { useState } from "react";
import LeadsList from "./components/LeadList";
import "./App.css";

const App = () => {
  const [tab, setTab] = useState("Invited");

  return (
    <div className="app-container">
      <div className="tabs-container">
        <button onClick={() => setTab("Invited")}>Invited</button>
        <button onClick={() => setTab("Accepted")}>Accepted</button>
      </div>
      <div className="content-container">
        {tab === "Invited" && <LeadsList status="Invited" />}
        {tab === "Accepted" && <LeadsList status="Accepted" />}
      </div>
    </div>
  );
};

export default App;
