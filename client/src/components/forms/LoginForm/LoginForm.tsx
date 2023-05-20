import { useState, ChangeEvent, FormEvent } from "react";
import { Button, TextField, Typography, Box } from "@mui/material";
import { Link, useNavigate } from "react-router-dom";
import { green } from "@mui/material/colors";

const LoginForm = () => {
	const [username, setUsername] = useState("");
	const [password, setPassword] = useState("");
	const navigate = useNavigate();

	const handleSubmit = (event: FormEvent<HTMLFormElement>) => {
		event.preventDefault();
		console.log(username, password);
		navigate("/", { state: { message: "Successfully logged in!", type: "success" } })
	};

	const handleUsernameChange = (event: ChangeEvent<HTMLInputElement>) => {
		setUsername(event.target.value);
	};

	const handlePasswordChange = (event: ChangeEvent<HTMLInputElement>) => {
		setPassword(event.target.value);
	};

	return (
		<>
			<Box
				component="form"
				autoComplete="off"
				onSubmit={handleSubmit}
				sx={{
					display: "flex",
					flexDirection: "column",
					alignItems: "center",
					marginTop: "100px"
				}}
			>
				<Typography variant="h4" sx={{ mb: 3, color: 'white' }}>
					Login Form
				</Typography>
				<TextField
					label="Username"
					onChange={handleUsernameChange}
					required
					variant="outlined"
					color="primary"
					type="text"
					sx={{
						mb: 3, backgroundColor: 'white', borderRadius: 1,
						"& .MuiOutlinedInput-root.Mui-focused .MuiOutlinedInput-notchedOutline": {
							borderColor: "white",
						},
						"& .MuiInputLabel-root.Mui-focused": {
							color: 'white',
							textShadow: '0 2px grey'
						}
					}}
					value={username}
				/>
				<TextField
					label="Password"
					onChange={handlePasswordChange}
					required
					variant="outlined"
					color="primary"
					type="password"
					sx={{
						mb: 3, backgroundColor: 'white', borderRadius: 1,
						"& .MuiOutlinedInput-root.Mui-focused .MuiOutlinedInput-notchedOutline": {
							borderColor: "white",
						},
						"& .MuiInputLabel-root.Mui-focused": {
							color: 'white',
							textShadow: '0 2px grey'
						}
					}}
					value={password}
				/>
				<Button
					variant="contained"
					color="primary"
					type="submit"
					sx={{
						backgroundColor: 'inherit', "&:hover": {
							backgroundColor: green[500],
							color: "white",
						}
					}}>
					Login
				</Button>
				<Typography variant="body2" sx={{ mt: 2, color: 'white' }}>
					Need an account? <Link to="/register">Register here</Link>
				</Typography>
			</Box>
		</>
	);
};

export default LoginForm;
