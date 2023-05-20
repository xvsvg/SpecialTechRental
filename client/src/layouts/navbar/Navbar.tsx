import { Box, Button, Container, Stack, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import "./Navbar.css";

const Navbar = () => {
	return (
		<Box maxWidth='inherited'
			bgcolor="rgba(7, 27, 47, 0.8)"
			color="#fff"
			top={0}
			py={2}
			boxShadow={0}
			position='fixed'
			width="100%"
			zIndex={1}
			sx={{backdropFilter: 'blur(2px)'}}
		>
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
