import React from "react";
import { BrowserRouter as Router, Route, Routes, Link } from "react-router-dom";
import FreeToPlayGames from "./FreeToPlayGames";
import Games from "./Games";
import GameDetails from "./GameDetails";
import MyPDFViewer from "./MyPDFViewer"; 
import "./App.css";

const App = () => (
  <div className="App">
    <header className="App-header">
      <Router>
        <nav>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/free-to-play">Free To Play Games</Link>
            </li>
            <li>
              <Link to="/games">Epic Free Games Week</Link>
            </li>
            <li>
              <Link to="/pdfviewer">PDF Viewer</Link>
            </li>
          </ul>
        </nav>
        <Routes>
          <Route path="/free-to-play" element={<FreeToPlayGames />} />
          <Route path="/games" element={<Games />} />
          <Route path="/game/:id" element={<GameDetails />} />
          <Route path="/pdfviewer" element={<MyPDFViewer />} /> 
        </Routes>
      </Router>
    </header>
  </div>
);
export default App;
