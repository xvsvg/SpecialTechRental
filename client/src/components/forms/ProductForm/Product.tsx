import { Box, Button, CardMedia, Divider, Modal, Stack, Typography } from "@mui/material"
import { IProduct } from "../../../shared/models/product";
import { green, grey } from "@mui/material/colors";
import { PurchaseForm } from "../PurchaseForm";
import { useState } from "react";

const Product = ({ name, total, status, image }: IProduct) => {
	const [isModalOpen, setIsModalOpen] = useState(false)

	const handleClick = () => {
		setIsModalOpen(true)
	}

	const handleCloseModal = () => {
		setIsModalOpen(false)
	}
	return (
		<>
			<Box sx={{ p: 2, display: 'flex', alignItems: 'center', backgroundColor: '#0a1929' }}>
				<CardMedia component="img" src={image} alt={name} />
			</Box>
			<Divider sx={{ backgroundColor: 'white' }} />
			<Box sx={{ p: 2, display: 'flex', justifyContent: 'space-between', flexDirection: "column" }}>
				<Stack maxWidth={'inherit'} padding={0} spacing={0.5} sx={{ flex: 1, marginLeft: '10px' }}>
					<Typography variant="h5" color={grey[600]}>{name}</Typography>
					<Typography variant="body1" color={grey[600]}>Total: {total}</Typography>
					<Typography variant="body1" color={grey[600]}>Status: {status}</Typography>
				</Stack>
				<div style={{ display: "flex", justifyContent: "flex-end", alignItems: "flex-end" }}>
					<Button sx={{
						"&:hover": {
							backgroundColor: green[500],
							color: "white",
						}
					}}
						onClick={handleClick}
					>
						Purchase</Button>
				</div>
			</Box>
			<Modal open={isModalOpen} onClose={handleCloseModal} sx={{ backdropFilter: "blur(5px)" }}>
				<PurchaseForm />
			</Modal>
		</>
	);
};
export default Product