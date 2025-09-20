const enum LeadStatus {
  Invited,
  Accepted,
  Declined,
}

export type Lead = {
  id: number;
  firstName: string;
  lastName: string;
  fullName: string;
  contactPhone: string;
  email: string;
  city: string;
  category: string;
  description: string;
  price: number;
  dateCreated: string;
  status: LeadStatus;
};
