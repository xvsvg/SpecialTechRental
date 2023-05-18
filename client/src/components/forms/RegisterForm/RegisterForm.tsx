import { Button, TextField } from "@mui/material";
import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import "../styles.css"



const RegisterForm = () => {
	const [username, setUsername] = useState('')
	const [password, setPassword] = useState('')
	const navigate = useNavigate();

	const handleSubmit = (event: React.FormEvent) => {
		event.preventDefault();
		console.log(username, password)
		navigate("/login")
	}

	const handleUsernameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
		setUsername(event.target.value)
	}

	const handlePasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
		setPassword(event.target.value)
	}

	return (
		<>
			<form onSubmit={handleSubmit}>
				<h2>Register Form</h2>
				<TextField
					type="username"
					variant="outlined"
					color='primary'
					label="Username"
					onChange={handleUsernameChange}
					value={username}
					fullWidth
					required
					sx={{ mb: 4 }}
				/>
				<TextField
					type="password"
					variant='outlined'
					color='primary'
					label="Password"
					onChange={handlePasswordChange}
					value={password}
					fullWidth
					required
					sx={{ mb: 4 }}
				/>
				<Button variant="contained" color="inherit" type="submit">Register</Button>
				<small>Already have an account? <Link to="/login">Login Here</Link></small>
			</form>
		</>
	)
}

export default RegisterForm