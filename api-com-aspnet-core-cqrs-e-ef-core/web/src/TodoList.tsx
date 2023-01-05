import React, { FormEvent, useEffect, useState } from "react"
import { TodoNew } from "./TodoNew"
import { TodoItem } from "./TodoItem"
import { Todo } from "./types"
import axios from "axios"
import firebase from 'firebase/app';
import { getFirestore, collection, getDocs } from 'firebase/firestore/lite';

const firebaseConfig = {
  //my firebase config here
};

// const app = initializeApp(firebaseConfig);

// firebase.initializeApp(firebaseConfig);

// export const auth = firebase.auth();

// export const AuthContext = React.createContext<firebase.User | null>(null);

// const db = getFirestore(app);


const urlApi = "http://localhost:5291";

function TodoList() {
  const [todos, setTodos] = useState<Todo[]>([])

  useEffect(() => {
    axios
      .get(urlApi + "/v1/todos")
      .then(response => {
        setTodos(response.data);
      });
  }, [todos])

  const handleCreateTodo = (todoText: string) => {
    const oldTodos = [...todos]
    oldTodos.push({
      id: Math.floor(Math.random() * 10000000),
      text: todoText,
      isCompleted: false,
    })
    setTodos(oldTodos)
  }

  const handleDeleteTodo = (todoId: number) => {
    let updatedTodos = [...todos]
    let selectedTodoIdx = todos.findIndex((todo) => todo.id === todoId)
    updatedTodos.splice(selectedTodoIdx, 1)
    setTodos(updatedTodos)
  }

  const handleComplete = (todoId: number) => {
    // clone the original array to avoid mutate by reference
    let updatedTodos = [...todos]
    // find the todo based on todo id
    let selectedTodo = todos.find((todo) => todo.id === todoId)
    // find the todo index based on todo id
    let selectedTodoIdx = todos.findIndex((todo) => todo.id === todoId)

    if (selectedTodo) {
      updatedTodos[selectedTodoIdx] = {
        ...selectedTodo,
        isCompleted: !selectedTodo.isCompleted,
      }
      setTodos(updatedTodos)
    }
  }

  return (
    <div className="bg-white shadow-md w-96 p-8 rounded-xl">
      <h1 className="text-2xl font-bold">Todo List</h1>
      <hr className="mt-2" />
      <TodoNew createTodo={handleCreateTodo} />
      <div className="mt-4">
        You have {todos.filter((it) => it.isCompleted === false).length} pending
        task(s)
      </div>
      <div className="mt-4">
        {todos
          .filter((it) => it.isCompleted === false)
          .map((it) => (
            <TodoItem
              key={it.id}
              item={it}
              deleteTodo={handleDeleteTodo}
              complete={handleComplete}
            />
          ))}
      </div>
      <div className="mt-4">
        {todos
          .filter((it) => it.isCompleted === true)
          .map((it) => (
            <TodoItem
              key={it.id}
              item={it}
              deleteTodo={handleDeleteTodo}
              complete={handleComplete}
            />
          ))}
      </div>
    </div>
  )
}

export default TodoList
