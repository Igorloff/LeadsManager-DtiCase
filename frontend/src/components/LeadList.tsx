import { useCallback, useEffect, useState } from "react";
import api from "../services/api";
import type { Lead } from "../types/Lead";
import LeadCard from "./LeadCard";
import styles from "./LeadList.module.css";

type LeadsListProps = {
  status: "Invited" | "Accepted";
};

export default function LeadsList({ status }: LeadsListProps) {
  const [leads, setLeads] = useState<Lead[]>([]);

  const fetchLeads = useCallback(async () => {
    try {
      const endpoint =
        status === "Invited"
          ? "/Leads/status/invited"
          : "/Leads/status/accepted";

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
    <div className={styles.lead_list}>
      {leads.map((lead) => (
        <LeadCard
          key={`LeadCard_${lead.id}`}
          lead={lead}
          updateLeads={fetchLeads}
        />
      ))}
    </div>
  );
}
