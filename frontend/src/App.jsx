import { useState } from "react";
import LeadsList from "./components/LeadList";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import "./App.css";
import Button from "@mui/material/Button";

const App = () => {
  const [tab, setTab] = useState("Invited");

  return (
    <>
      <div>
        <div className="button-group">
          <Button
            variant={tab === "Invited" ? "contained" : "outlined"}
            onClick={() => setTab("Invited")}
          >
            Invited
          </Button>
          <Button
            variant={tab === "Accepted" ? "contained" : "outlined"}
            onClick={() => setTab("Accepted")}
          >
            Accepted
          </Button>
        </div>
        <div>
          {tab === "Invited" && <LeadsList status="Invited" />}
          {tab === "Accepted" && <LeadsList status="Accepted" />}
        </div>
      </div>
      <ToastContainer position="top-right" autoClose={3000} />
    </>
  );
};

export default App;
