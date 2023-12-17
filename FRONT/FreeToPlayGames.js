import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import './FreeToPlayGames.css';

const FreeToPlayGames = () => {
  const [games, setGames] = useState([]);

  useEffect(() => {
    const fetchGames = async () => {
      const response = await fetch("https://localhost:7296/FreeToPlayGames");
      const data = await response.json();
      setGames(data);
    };

    fetchGames();
  }, []);

  return (
    <div className="FreeToPlayGames">
      <h1>Free to Play Games</h1>
      {games.map((game) => (
        <div className="game" key={game.id}>
          <h2>
            <Link to={`/game/${game.id}`}>{game.title}</Link>
          </h2>
          <img src={game.thumbnail} alt={game.title} />
          <p>{game.short_description}</p>
        </div>
      ))}
    </div>
  );
};

export default FreeToPlayGames;







