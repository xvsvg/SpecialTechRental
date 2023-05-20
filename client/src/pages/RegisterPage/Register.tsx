import { Box } from "@mui/material";
import { RegisterForm } from "../../components";
import { Header } from "../../features";

const Register = () => {
	return (
		<Box bgcolor="#132f4b" minHeight="100vh">
			<Header />
			<RegisterForm />
		</Box>
	)
}

export default Register;