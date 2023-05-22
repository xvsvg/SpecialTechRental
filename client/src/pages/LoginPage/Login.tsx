import { Box } from "@mui/material";
import { LoginForm } from "../../components";
import { Header } from "../../features";

const Login = () => {
	return (
		<Box bgcolor="#132f4b" minHeight='100vh'>\
			<Header />
			<LoginForm />
		</Box>
	)
}

export default Login;