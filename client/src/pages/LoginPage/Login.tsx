import { Box } from "@mui/material";
import { LoginForm } from "../../components";
import { Notification } from "../../features";
import { useLocation } from "react-router-dom";

const Login = () => {
	const location = useLocation()
	const message = location.state && location.state.message
	const type = location.state && location.state.type

	return (
		<Box bgcolor="#132f4b" minHeight='100vh'>
			{message && <Notification message={message} type={type} />}
			<LoginForm />
		</Box>
	)
}

export default Login;