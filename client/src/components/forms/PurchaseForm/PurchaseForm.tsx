import { Box, Button, FormControl, IconButton, TextField, Typography } from "@mui/material";
import { useState } from "react";
import { Add, Remove } from "@mui/icons-material";
import { green } from "@mui/material/colors";
import { Report } from "../../reports";

interface PurchaseProps{
	total: number
	onSubmit: () => void
}

const PurchaseForm = ({total, onSubmit} : PurchaseProps) => {
	const [quantity, setQuantity] = useState(1);
	const [showReport, setShowReport] = useState(false)

	const handleIncreaseQuantity = () => {
		setQuantity((prevQuantity) => prevQuantity + 1);
	};

	const handleDecreaseQuantity = () => {
		if (quantity > 1) {
			setQuantity((prevQuantity) => prevQuantity - 1);
		}
	};

	const handleQuantityChange = (event: React.ChangeEvent<HTMLInputElement>) => {
		const newQuantity = parseInt(event.target.value);
		setQuantity(newQuantity || 0);
	};

	const calculateCost = (price: number, quantity: number) => {
		return price * quantity;
	};

	const handleSubmit = (event: React.FormEvent) => {
		event.preventDefault()
		onSubmit()
		setShowReport(true)
	};

	return (
		<Box sx={{
			p: 2,
			display: "flex",
			flexDirection: "column",
			alignItems: "center",
			justifyContent: "center",
			backgroundColor: "#132f4b",
			maxWidth: '400px',
			margin: '0 auto',
			marginTop: '100px',
			borderRadius: 3
		}}>
			<Typography variant="h6" align="center" color='white'>
				Purchase Form
			</Typography>
			<FormControl component="form" onSubmit={handleSubmit}>
				<Box sx={{ display: "flex", alignItems: "center", justifyContent: "space-between" }}>
					<IconButton onClick={handleDecreaseQuantity}>
						<Remove />
					</IconButton>
					<TextField
						id="quantity"
						variant="standard"
						type="text"
						value={quantity}
						onChange={handleQuantityChange}
						InputProps={{
							style: {
								color: "white",
							},
						}}
						sx={{
							width: "70px",
							textAlign: "center",
							"& .MuiInputBase-root": {
								color: "white",
								"&:before": {
									borderBottomColor: "white",
								},
								"&:hover:before": {
									borderBottomColor: "white",
								},
								"&.Mui-focused:before": {
									borderBottomColor: "green",
								},
								"&.Mui-focused:after": {
									borderBottomColor: "green",
								},
							},
						}}
					/>
					<IconButton onClick={handleIncreaseQuantity}>
						<Add />
					</IconButton>
				</Box>
				<Typography color='white'>Total price: {calculateCost(total, quantity)}</Typography>
				<Button
					variant="contained"
					color="primary"
					type="submit"
					onClick={handleSubmit}
					sx={{
						backgroundColor: 'inherit', "&:hover": {
							backgroundColor: green[500],
							color: "white",
						}
					}}>
					Submit
				</Button>
				{showReport && <Report />}
			</FormControl>
		</Box>
	);
};

export default PurchaseForm;
