import { Box } from "@mui/material"
import { ItemTable, ProfileForm } from "../../components"
import { Item } from "../../components/tables/ItemTable";
import { useEffect, useState } from "react";
import { getUser } from "../../lib/users/users";
import { getCookie } from "typescript-cookie";
import { IUser } from "../../shared";
import { Notification } from "../../features";
import { useLocation } from "react-router-dom";

const initial: Item[] = [
	{ id: 1, name: "Item 1", quantity: 10 },
	{ id: 2, name: "Item 2", quantity: 5 },
	{ id: 3, name: "Item 3", quantity: 8 },
];

const Profile = () => {
	const [items, setItems] = useState(initial);
	const [error, setError] = useState<string | null>(null)
	const [user, setUser] = useState<IUser>({ id: '', firstName: 'first name', middleName: 'middle name', lastName: 'last name', birthDate: 'yy-mm-dd', number: 'phone number', image: '', money: 0, orders: [] })

	const location = useLocation()
	const message = location.state && location.state.message
	const type = location.state && location.state.type

	return (
		<Box bgcolor="#132f4b" display={"flex"} alignItems={"center"} height={"100vh"} width={"100vw"}>
			{error && <Notification message={error} type='error' />}
			{message && <Notification message={message} type={type} />}
			<Box display={"flex"} justifyContent={"space-evenly"} width={"100%"}>
				<ProfileForm
					setError={setError} />
				<ItemTable items={items} setItems={setItems} />
			</Box>
		</Box>
	)
}

export default Profile