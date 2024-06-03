import { NextResponse } from "next/server";
import { getPokedex } from "@/core/server/config";

export async function GET(request: Request) {
  try {
    const response = await fetch(getPokedex());
    const data = await response.json();
    return NextResponse.json(data);
  } catch (error) {
    console.error("Error fetching Pokédex:", error);
    return new NextResponse(
      JSON.stringify({ error: "Failed to fetch Pokédex" }),
      {
        status: 500,
        headers: {
          "Content-Type": "application/json",
        },
      },
    );
  }
}
