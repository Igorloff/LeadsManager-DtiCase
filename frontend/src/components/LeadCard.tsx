// components/LeadCard.tsx (CORRIGIDO)

import { Avatar, Button } from "@mui/material";
import type { Lead } from "../types/Lead";
import api from "../services/api";

type LeadCardProps = {
  lead: Lead;
  updateLeads: () => void;
};

// Função para formatar a data
function formatDate(dateString: string): string {
  const date = new Date(dateString);
  return date
    .toLocaleString("en-US", {
      month: "long",
      day: "numeric",
      year: "numeric",
      hour: "numeric",
      minute: "numeric",
      hour12: true,
    })
    .replace(" at", " @");
}

export default function LeadCard({ lead, updateLeads }: LeadCardProps) {
  const handleAccept = async () => {
    try {
      await api.post(`/Leads/${lead.id}/accept`);
      updateLeads();
    } catch (error) {
      console.error("Erro ao aceitar lead:", error);
      alert("Erro ao aceitar lead.");
    }
  };

  const handleDecline = async () => {
    try {
      await api.post(`/Leads/${lead.id}/decline`);
      updateLeads();
    } catch (error) {
      console.error("Erro ao recusar lead:", error);
      alert("Erro ao recusar lead.");
    }
  };

  const name =
    lead.status === "Accepted"
      ? `${lead.firstName} ${lead.lastName}`
      : lead.firstName;

  return (
    <div className="lead-card">
      <div className="card-header">
        <Avatar>{lead.firstName.charAt(0)}</Avatar>
        <div className="header-info">
          <h4>{name}</h4>
          <p>{formatDate(lead.dateCreated)}</p>
        </div>
      </div>

      <div className="card-details">
        <span>{lead.city}</span>
        <span>{lead.category}</span>
        <span>Job ID: {lead.id}</span>
        <span>${lead.price.toFixed(2)} Lead Invitation</span>
      </div>

      {lead.status === "Accepted" && (
        <div className="contact-info">
          <span>📞 {lead.contactPhone}</span>
          <span>📧 {lead.email}</span>
        </div>
      )}

      <p className="description">{lead.description}</p>

      {lead.status === "Invited" && (
        <div className="card-actions">
          <Button variant="contained" color="primary" onClick={handleAccept}>
            Accept
          </Button>
          <Button variant="outlined" color="secondary" onClick={handleDecline}>
            Decline
          </Button>
        </div>
      )}
    </div>
  );
}
