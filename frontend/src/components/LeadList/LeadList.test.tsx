import { expect, test, it, vi, describe } from "vitest";
import { render, fireEvent, waitFor } from "@testing-library/react";
import LeadList from "./LeadList";
import type { Lead } from "../../types/Lead";
import axios from "axios";

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

describe("LeadList", () => {
  it("Busca dados de status invited", () => {
    const getMock = vi.spyOn(axios, "get");
    const container = render(<LeadList status={"Invited"} />);
    expect(getMock).toHaveBeenCalledWith("/Leads/status/invited");

    container.unmount();
  });

  it("Busca dados de status accepted", () => {
    const getMock = vi.spyOn(axios, "get");
    const container = render(<LeadList status={"Accepted"} />);
    expect(getMock).toHaveBeenCalledWith("/Leads/status/accepted");

    container.unmount();
  });
});

// renderiza cards de status invited

// renderiza cards de status accepted
