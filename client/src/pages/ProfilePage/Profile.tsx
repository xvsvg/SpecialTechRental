import { Box } from "@mui/material"
import { ProfileForm } from "../../components"
import { Navbar } from "../../layouts"

const Profile = () => {
	return (
		<Box bgcolor="#132f4b" minHeight="100vh">
			<Navbar />
			<ProfileForm />
		</Box>
	)
}

export default Profile