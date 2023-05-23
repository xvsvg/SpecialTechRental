import { Avatar, Box, Button, Card, Divider, IconButton, Modal, Stack, Typography } from "@mui/material";
import { green, grey } from "@mui/material/colors";
import { ReplenishForm } from "../ReplenishForm";
import EditIcon from "@mui/icons-material/Edit";
import { useState } from "react";

export interface IProfileProps {
	firstName: string,
	middleName: string,
	lastName: string,
	birthDate: string,
	total: number,
	image: string,
	phoneNumber: string,
}

const ProfileForm = ({ firstName, middleName, lastName, birthDate, total, image, phoneNumber }: IProfileProps) => {

	const [isModalOpen, setIsModalOpen] = useState(false)

	const handleOpen = () => {
		setIsModalOpen(true)
	}

	const handleClose = () => {
		setIsModalOpen(false)
	}

	return (
		<Box className="profile">

			<Card sx={{ width: '500px', backgroundColor: '#0a1929', borderRadius: '10px' }}>
					<IconButton onClick={() => console.log("xui")
					}>
						<EditIcon sx={{ color: "#0a1929" }} />
					</IconButton>
				<Box sx={{ p: 2, display: 'flex', alignItems: 'center', backgroundColor: '#0a1929' }}>
					<Avatar variant="rounded" src="image" />
					<Stack spacing={0.5} sx={{ flex: 1, marginLeft: '10px' }}>
						<Typography variant="h6" sx={{ color: 'white' }}>{firstName} {middleName} {lastName}</Typography>
						<Typography variant="body2" sx={{ color: grey[500] }}>{birthDate}</Typography>
					</Stack>
				</Box>
				<Divider />
				<Box sx={{ p: 2, display: 'flex', justifyContent: 'space-between', backgroundColor: '#001e3c' }}>
					<Typography variant="button" component="div" sx={{ color: 'white', marginTop: '10px' }}>
						<Box component="span" fontWeight="fontWeightBold" marginRight="8px">
							balance:
						</Box>
						{total}
					</Typography>
					<Button
						onClick={handleOpen}
						sx={{
							"&:hover": {
								backgroundColor: green[500],
								color: "white",
							}
						}}>Make deposit</Button>
				</Box>
			</Card>
			<Modal open={isModalOpen} onClose={handleClose} sx={{ backdropFilter: "blur(5px)" }}>
				<ReplenishForm close={handleClose} />
			</Modal>
		</Box>
	);
}

export default ProfileForm