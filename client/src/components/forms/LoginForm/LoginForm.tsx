import { Button, TextField } from "@mui/material"
import { useState } from "react"
import { Link, useNavigate } from "react-router-dom"
import "../styles.css"

const LoginForm = () => {
	const [username, setUsername] = useState("")
	const [password, setPassword] = useState("")
	const navigate = useNavigate()

	const handleSubmit = (event: React.FormEvent) => {
		event.preventDefault()
		console.log(username, password)
		navigate("/");
	}

	const handleUsernameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
		setUsername(event.target.value)
	}

	const handlePasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
		setPassword(event.target.value)
	}

	return (
		<>
			<form autoComplete="off" onSubmit={handleSubmit}>
				<h2>Login Form</h2>
				<TextField
					label="Username"
					onChange={handleUsernameChange}
					required
					variant="outlined"
					color="primary"
					type="username"
					sx={{ mb: 3 }}
					fullWidth
					value={username}
				/>
				<TextField
					label="Password"
					onChange={handlePasswordChange}
					required
					variant="outlined"
					color="primary"
					type="password"
					value={password}
					fullWidth
					sx={{ mb: 3 }}
				/>
				<Button variant="contained" color="inherit" type="submit">Login</Button>
				<small>Need an account? <Link to="/register">Register here</Link></small>
			</form>
		</>
	);
}

export default LoginForm