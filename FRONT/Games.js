import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import "./Games.css";

const Games = () => {
  const [games, setGames] = useState([]);

  useEffect(() => {
    const fetchGames = async () => {
      const response = await fetch("https://localhost:7296/Games");
      const data = await response.json();
      setGames(data.freeGames.current);
    };
  
    fetchGames();
  }, []);
  

  return (
    <div className="Games">
      <h1>All Games</h1>
      {games.map((game) => (
        <div key={game.id} className="game-item">
          <h2>
            <Link to={`/game/${game.id}`}>{game.title}</Link>
          </h2>
          <p>{game.description}</p>
          <p>Status of the game: {game.status}</p>
          <p>Effective date {game.effectiveDate}</p>
        </div>
      ))}
    </div>
  );
};

export default Games;
