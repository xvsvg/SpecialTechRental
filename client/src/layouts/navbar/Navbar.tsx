import { Box, Button, Container, Stack, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import "./Navbar.css";

const Navbar = () => {
	return (
		<Box maxWidth='inherited' bgcolor="#071b2f" color="#fff" py={2} boxShadow={0}>
			<Container sx={{ display: "flex", justifyContent: "space-between", alignItems: "center" }}>
				<Typography variant="h3" className="logo">
					Tech rental
				</Typography>
				<Stack direction="row" spacing={2}>
					<Button component={Link} to="/">
						Home
					</Button>
					<Button component={Link} to="/profile">
						Profile
					</Button>
					<Button component={Link} to="/login">
						Login
					</Button>
					<Button component={Link} to="/register">
						Register
					</Button>
				</Stack>
			</Container>
		</Box>
	);
};

export default Navbar;
