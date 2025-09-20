import { toast } from "react-toastify";
import api from "../services/api";
import type { Lead } from "../types/Lead";
import styles from "./LeadCard.module.css";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import Divider from "@mui/material/Divider";
import { format } from "date-fns";
import {
  Email,
  Phone,
  CalendarToday,
  LocationOn,
  Numbers,
} from "@mui/icons-material";

type LeadCardProps = {
  lead: Lead;
  updateLeads: () => void;
};

export default function LeadCard({ lead, updateLeads }: LeadCardProps) {
  function formatDate(dateString: string): string {
    if (!dateString) return "";
    return format(new Date(dateString), "dd/MM/yyyy HH:mm");
  }

  const handleAccept = async () => {
    try {
      await api.post(`/Leads/${lead.id}/accept`);
      updateLeads();
      toast.success("Lead aceito com sucesso!");
      setTimeout(() => {
        toast.info(
          `Email enviado para ${lead.firstName.toLowerCase()}@gmail.com`
        );
      }, 800);
    } catch (error) {
      console.error("Erro ao aceitar lead:", error);
      toast.error("Erro ao aceitar lead!");
    }
  };

  const handleDecline = async () => {
    try {
      await api.post(`/Leads/${lead.id}/decline`);
      updateLeads();
      toast.info("Lead recusado.");
    } catch (error) {
      console.error("Erro ao recusar lead:", error);
      toast.error(" Erro ao recusar lead!");
    }
  };

  if (lead.status === 0) {
    return (
      <div className={styles.card}>
        <div className={styles.header_containers}>
          <Avatar>{lead.firstName.charAt(0)}</Avatar>
          <div className={styles.header}>
            <span className={styles.name}>{lead.firstName}</span>
            <span className={styles.category}>{lead.category}</span>
          </div>
        </div>

        <Divider sx={{ my: 1 }} />

        <div className={styles.details}>
          <p>
            <CalendarToday fontSize="small" style={{ marginRight: "6px" }} />
            {formatDate(lead.dateCreated)}
          </p>
          <p>
            <LocationOn fontSize="small" style={{ marginRight: "6px" }} />{" "}
            {lead.city}
          </p>
          <p>
            <Numbers fontSize="small" style={{ marginRight: "6px" }} />
            {lead.id}
          </p>
        </div>

        <Divider sx={{ my: -1 }} />

        <p>{lead.description}</p>

        <Divider sx={{ my: -1 }} />

        <div className={styles.last_line}>
          <div className={styles.price}> R$ {lead.price.toFixed(2)}</div>

          <div className={styles.actions}>
            <Button
              color="info"
              variant="contained"
              className={`${styles.button} ${styles.accept}`}
              onClick={handleAccept}
            >
              Accept
            </Button>
            <Button
              color="warning"
              variant="contained"
              className={`${styles.button} ${styles.decline}`}
              onClick={handleDecline}
            >
              Decline
            </Button>
          </div>
        </div>
      </div>
    );
  }
  return (
    <div className={styles.card}>
      <div className={styles.header_containers}>
        <Avatar>{lead.firstName.charAt(0)}</Avatar>
        <div className={styles.header}>
          <span className={styles.name}>{lead.fullName}</span>
          <span className={styles.category}>{lead.category}</span>
        </div>
      </div>

      <Divider sx={{ my: 1 }} />

      <div className={styles.details}>
        <p>
          <CalendarToday fontSize="small" style={{ marginRight: "6px" }} />
          {formatDate(lead.dateCreated)}
        </p>
        <p>
          <LocationOn fontSize="small" style={{ marginRight: "6px" }} />{" "}
          {lead.city}
        </p>
        <p>
          <Numbers fontSize="small" style={{ marginRight: "6px" }} />
          {lead.id}
        </p>
      </div>

      <Divider sx={{ my: -1 }} />

      <div className={styles.additional_details}>
        <p>
          <Phone fontSize="small" style={{ marginRight: "6px" }} />{" "}
          {lead.contactPhone}
        </p>
        <p>
          <Email fontSize="small" style={{ marginRight: "6px" }} />
          {lead.email}
        </p>
      </div>

      <Divider sx={{ my: -1 }} />

      <p>{lead.description}</p>

      <Divider sx={{ my: -1 }} />

      <div className={styles.last_line}>
        <div className={styles.price}> R$ {lead.price.toFixed(2)}</div>
      </div>
    </div>
  );
}
