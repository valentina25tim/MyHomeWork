import React from 'react';
import './styles/app.css';
import {
  BrowserRouter,
  Routes,
  Route,Link 
} from "react-router-dom";

import Posts from './pages/Posts';
import About from './pages/About';
 

function App() {
    return (
      <BrowserRouter>
      <Routes>
      <div className="navBar">
        <div className="navBar__links">
          <Link to="/about">About Site</Link>
          <Link to="/posts">Posts</Link>
        </div>
      </div>

      <Route path="/about">
        <About/>
      </Route>

      <Route path="/posts">
        <Posts/>
      </Route>

      </Routes>
      </BrowserRouter>
    )
        
}

export default App;