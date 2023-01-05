import React, { useState, useEffect } from 'react';
import axios from 'axios';

interface Todo {
    id: string;
    title: string;
    done: boolean;
    date: string;
    refUser: string;
}

const urlApi = "http://localhost:5291";

const TodoList: React.FC = () => {

    const [todos, setTodos] = useState<Todo[]>([]);

    useEffect(() => {
        axios
            .get(urlApi + "/v1/todos")
            .then(response => {
                setTodos(response.data);
            });
    }, []);

    function toggleTodo(id: string) {
        setTodos(
            todos.map(todo => {
                if (todo.id === id) {
                    if (todo.done)
                        axios.put(`${urlApi}/mark-as-undone/`, {id: todo.id})
                    else
                        axios.put(`${urlApi}/mark-as-done/`, {id: todo.id})

                    return { ...todo, completed: !todo.done };
                }
                return todo;
            })
        );
    }

    return (
        <div className="bg-black shadow-md rounded px-8 pt-6 pb-8 mb-4">
            <h1 className="text-2xl font-semibold text-white mb-4">My Todos</h1>
            <ul style={{listStyle:'none'}}>
                {todos.map(todo => (
                    <li
                        key={todo.id}
                        className="flex items-center mb-4"
                    >
                        <input
                            type="checkbox"
                            className="form-checkbox text-indigo-600"
                            checked={todo.done}
                            onChange={() => toggleTodo(todo.id)}
                        />
                        <span className="ml-2 text-white">{todo.title}</span>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default TodoList;