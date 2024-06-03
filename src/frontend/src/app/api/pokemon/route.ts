import { NextResponse } from "next/server";
import { getPokemon } from "@/core/server/config";

export async function GET(request: Request) {
  try {
    const response = await fetch(getPokemon());
    const data = await response.json();
    return NextResponse.json(data);
  } catch (error) {
    console.error("Error fetching Pokémon:", error);
    return new NextResponse(
      JSON.stringify({ error: "Failed to fetch Pokémon" }),
      {
        status: 500,
        headers: {
          "Content-Type": "application/json",
        },
      },
    );
  }
}
