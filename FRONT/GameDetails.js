import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import './GameDetails.css';

const GameDetails = () => {
  const [game, setGame] = useState({});
  const { id } = useParams();

  useEffect(() => {
    const fetchGameDetails = async () => {
      const response = await fetch(`https://localhost:7296/api/GameDetail/${id}`);
      const data = await response.json();
      setGame(data);
    };

    fetchGameDetails();
  }, [id]);

  return (
    <div className="GameDetails">
      <h1>{game.title}</h1>
      <img src={game.thumbnail} alt={game.title} />
      <p>{game.description}</p>
      <p className="metadata">Genre: {game.genre}</p>
      <p className="metadata">Platform: {game.platform}</p>
      <p className="metadata">Publisher: {game.publisher}</p>
      <p className="metadata">Developer: {game.developer}</p>
      <div className="screenshots">
        <h2>Screenshots:</h2>
        {game.screenshots?.length > 0 ? (
          game.screenshots.map((screenshot) => (
            <img key={screenshot.id} src={screenshot.image} alt={`Screenshot ${screenshot.id}`} />
          ))
        ) : (
          <p>No screenshots available</p>
        )}
      </div>
    </div>
  );
};

export default GameDetails;




