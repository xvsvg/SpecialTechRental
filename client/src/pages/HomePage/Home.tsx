import { Box } from "@mui/material"
import { Header, Notification } from "../../features"
import { useLocation } from "react-router-dom";
import { Pagination } from "../../components";

const HomePage = () => {
	const location = useLocation()
	const message = location.state && location.state.message
	const type = location.state && location.state.type

	return (
		<Box bgcolor="#001e3c" minHeight='100vh' >
			{message && <Notification message={message} type={type} />}
			<Pagination apiUrl={"https://jsonplaceholder.typicode.com/photos"} />
		</Box>
	)
}

export default HomePage