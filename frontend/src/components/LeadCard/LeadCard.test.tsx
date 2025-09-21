import { expect, test, it, vi, describe } from "vitest";
import { render, fireEvent, waitFor } from "@testing-library/react";
import LeadCard from "./LeadCard";
import type { Lead } from "../../types/Lead";

vi.mock("axios", () => {
  return {
    default: {
      post: vi.fn(),
      get: vi.fn(),
      delete: vi.fn(),
      put: vi.fn(),
      create: vi.fn().mockReturnThis(),
      interceptors: {
        request: {
          use: vi.fn(),
          eject: vi.fn(),
        },
        response: {
          use: vi.fn(),
          eject: vi.fn(),
        },
      },
    },
  };
});

const leadMock: Lead = {
  id: 1,
  firstName: "John",
  lastName: "Doe",
  fullName: "John Doe",
  contactPhone: "123456789",
  email: "eareis@gmail.com",
  city: "New York",
  category: "Real Estate",
  description: "Looking for a 2-bedroom apartment in downtown.",
  price: 2500,
  dateCreated: "2023-10-01T10:00:00Z",
  status: 0,
};

const mockFn = vi.fn();

describe("LeadCard", () => {
  it("Aceita um LeadCard", async () => {
    const container = render(<LeadCard lead={leadMock} updateLeads={mockFn} />);
    const acceptButton = container.getByText("Accept");

    expect(acceptButton).toBeDefined();

    await waitFor(() => {
      fireEvent.click(acceptButton);
      expect(mockFn).toHaveBeenCalled();
    });

    container.unmount();
  });

  it("Rejeita um LeadCard", async () => {
    const container = render(<LeadCard lead={leadMock} updateLeads={mockFn} />);
    const declineButton = container.getByText("Decline");

    expect(declineButton).toBeDefined();

    await waitFor(() => {
      fireEvent.click(declineButton);
      expect(mockFn).toHaveBeenCalled();
    });

    container.unmount();
  });

  it("Rendezira LeadCard com status 0", () => {
    const container = render(<LeadCard lead={leadMock} updateLeads={mockFn} />);
    expect(container).toMatchSnapshot();

    container.unmount();
  });

  it("Rendezira LeadCard com status 1", () => {
    const container = render(
      <LeadCard lead={{ ...leadMock, status: 1 }} updateLeads={mockFn} />
    );
    expect(container).toMatchSnapshot();

    container.unmount();
  });
});
