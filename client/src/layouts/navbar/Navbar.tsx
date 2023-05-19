import { Button } from "@mui/material"
import "./Navbar.css"
import { Link } from "react-router-dom"

const Navbar = () => {
	return (
		<div>
			<div id="main-navbar" className="navbar">
				<h2 className="logo">Tech rental</h2>
				<nav className="panel">
					<ul>
						<li>
							<Button component={Link} to="/">Home</Button>
						</li>
						<li>
							<Button>Profile</Button>
						</li>
						<li>
							<Button component={Link} to="/login">Login</Button>
						</li>
						<li>
							<Button component={Link} to="/register">Register</Button>
						</li>
					</ul>
				</nav>
			</div>
		</div>
	)
}

export default Navbar