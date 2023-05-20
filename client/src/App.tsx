import { Route, Routes } from "react-router-dom";
import { HomePage, LoginPage, ProfilePage, RegisterPage } from "./pages";
import { Container } from "@mui/material";

function App() {
	return (
		<>
			<Container>
				<Routes>
					<Route path="/" element={<HomePage />} />
					<Route path="/register" element={<RegisterPage />} />
					<Route path="/login" element={<LoginPage />} />
					<Route path="/profile" element={<ProfilePage />} />
				</Routes>
			</Container>
		</>
	);
}

export default App;
