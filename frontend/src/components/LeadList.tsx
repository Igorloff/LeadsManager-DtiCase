import { useCallback, useEffect, useState } from "react";
import api from "../services/api";
import type { Lead } from "../types/Lead";
import LeadCard from "./LeadCard";

type LeadsListProps = {
  status: "Invited" | "Accepted";
};

export default function LeadsList({ status }: LeadsListProps) {
  const [leads, setLeads] = useState<Lead[]>([]);

  const fetchLeads = useCallback(async () => {
    try {
      const endpoint =
        status.toLowerCase() === "invited" ? "/Leads" : "/Leads/accepted";
      const response = await api.get<Lead[]>(endpoint);
      setLeads(response.data);
    } catch (err) {
      console.error("Erro ao buscar os leads:", err);
      setLeads([]);
    }
  }, [status]);

  useEffect(() => {
    fetchLeads();
  }, [fetchLeads]);

  return (
    <div className="leads-list">
      {leads.map((lead) => (
        <LeadCard key={lead.id} lead={lead} updateLeads={fetchLeads} />
      ))}
    </div>
  );
}
