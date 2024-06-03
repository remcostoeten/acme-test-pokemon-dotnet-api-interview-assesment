import { NextResponse } from "next/server";
import { getPokemonById } from "@/core/server/config";

export async function GET(
  request: Request,
  { params }: { params: { id: string } },
) {
  const { id } = params;
  try {
    const response = await fetch(getPokemonById(Number(id)));
    const data = await response.json();
    return NextResponse.json(data);
  } catch (error) {
    console.error(`Error fetching Pokémon with ID ${id}:`, error);
    return new NextResponse(
      JSON.stringify({ error: `Failed to fetch Pokémon with ID ${id}` }),
      {
        status: 500,
        headers: {
          "Content-Type": "application/json",
        },
      },
    );
  }
}
