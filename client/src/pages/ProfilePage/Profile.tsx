import { Box } from "@mui/material"
import { ItemTable, ProfileForm } from "../../components"
import { Navbar } from "../../layouts"
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
	const [user, setUser] = useState<IUser>({ id: '', firstName: 'anonym', middleName: 'anonym', lastName: 'anonym', birthDate: 'mm yy dd', number: '', image: '', money: 0, orders: [] })

	const location = useLocation()
	const message = location.state && location.state.message
	const type = location.state && location.state.type
	
	const fetchData = async () => {
		try {
			setError(null)
			const { data } = await fetchUser()
			setUser(data)
		} catch (error: any) {
			setError("You are not authorized")
		}
	}

	const fetchUser = async () => {
		return await getUser(getCookie("current-user") ?? '')
	}

	useEffect(() => {
		(async () => await fetchData())()
	}, [user])

	return (
		<Box bgcolor="#132f4b" minHeight="100vh">
			{error && <Notification message={error} type='warning' />}
			{message && <Notification message={message} type='warning' />}
			<Navbar />
			<ProfileForm
				firstName={user.firstName}
				middleName={user.middleName}
				lastName={user.lastName}
				birthDate={user.birthDate}
				image={user.image}
				phoneNumber={user.number}
				total={user.money} />
			<ItemTable items={items} setItems={setItems} />
		</Box>
	)
}

export default Profile