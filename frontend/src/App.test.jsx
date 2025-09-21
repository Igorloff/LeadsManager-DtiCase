import { expect, it, describe } from "vitest";
import { render, fireEvent, waitFor } from "@testing-library/react";
import App from "./App";

describe("App", () => {
  it("Renderiza corretamente", () => {
    const container = render(<App />);
    expect(container).toMatchSnapshot();

    container.unmount();
  });

  it("Altera lista para 'Accepted'", async () => {
    const container = render(<App />);
    expect(container).toMatchSnapshot();

    const acceptedButton = container.getByText("Accepted");
    expect(acceptedButton).toBeDefined();

    await waitFor(() => {
      fireEvent.click(acceptedButton);
      expect(container).toMatchSnapshot();
    });

    container.unmount();
  });
});
