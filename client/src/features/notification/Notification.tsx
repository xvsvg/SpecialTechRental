import React, { useState, useEffect } from "react";
import { Alert, AlertTitle } from "@mui/material";
import { styled } from "@mui/system";
import { Fade } from "@mui/material";

const StyledNotification = styled("div")`
  position: fixed;
  bottom: 20px;
  right: 20px;
  z-index: 9999;
`;

interface NotificationProps {
	message: string;
	type: "success" | "warning" | "error";
	duration?: number;
}

const Notification = ({ message, type, duration = 3000 }: NotificationProps) => {
	const [visible, setVisible] = useState(true);

	useEffect(() => {
		const timer = setTimeout(() => {
			setVisible(false);
		}, duration);

		return () => clearTimeout(timer);
	}, [duration]);

	const handleAnimationEnd = () => {
		if (!visible) {
			// Additional actions to perform when the notification has completely disappeared
		}
	};

	const capitalize = (str: string) => {
		return str.charAt(0).toUpperCase() + str.slice(1);
	};

	return (
		<>
			<Fade in={visible} timeout={500} onExited={handleAnimationEnd}>
				<StyledNotification>
					<Alert severity={type}>
						<AlertTitle>{capitalize(type)}</AlertTitle>
						{message}
					</Alert>
				</StyledNotification>
			</Fade>
		</>
	);
};

export default Notification;
