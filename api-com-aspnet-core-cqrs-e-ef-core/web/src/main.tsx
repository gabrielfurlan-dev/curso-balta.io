import React from 'react'
import ReactDOM from 'react-dom/client'
import TodoList from './assets/screens/App'
import './index.css'

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <React.StrictMode>
    <TodoList />
  </React.StrictMode>,
)
