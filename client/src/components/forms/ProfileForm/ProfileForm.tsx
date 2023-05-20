import { Avatar, Box, Button, Card, Divider, IconButton, Stack, Typography } from "@mui/material";
import "./ProfileForm.css"
import { green, grey } from "@mui/material/colors";

export interface IProfileProps {
	firstName: string,
	middleName: string,
	lastName: string,
	birthDate: Date,
	total: number
	image: string
}

const ProfileForm = () => {
	const balance = 9999
	return (
		<Box className="profile">
			<Card sx={{ width: '500px', backgroundColor: '#0a1929' }}>
				<Box sx={{ p: 2, display: 'flex', alignItems: 'center', backgroundColor: '#0a1929' }}>
					<Avatar variant="rounded" src="" />
					<Stack spacing={0.5} sx={{ flex: 1, marginLeft: '10px' }}>
						<Typography variant="h6" sx={{ color: 'white' }}>{"firstname middlename lastname"}</Typography>
						<Typography variant="body2" sx={{ color: grey[500] }}>{"mm yy dd"}</Typography>
					</Stack>
				</Box>
				<Divider />
				<Box sx={{ p: 2, display: 'flex', justifyContent: 'space-between', backgroundColor: '#001e3c' }}>
					<Typography variant="button" component="div" sx={{ color: 'white', marginTop: '10px' }}>
						<Box component="span" fontWeight="fontWeightBold" marginRight="8px">
							balance:
						</Box>
						{balance}
					</Typography>
					<Button sx={{
              "&:hover": {
                backgroundColor: green[500],
                color: "white",
              }
            }}>Make deposit</Button>
				</Box>
			</Card>
		</Box>
	);
}

export default ProfileForm