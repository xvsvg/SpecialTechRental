import { Box } from "@mui/material"
import { ItemTable, ProfileForm } from "../../components"
import { Navbar } from "../../layouts"
import { Item } from "../../components/tables/ItemTable";
import { useState } from "react";

const initial: Item[] = [
	{ id: 1, name: "Item 1", quantity: 10 },
	{ id: 2, name: "Item 2", quantity: 5 },
	{ id: 3, name: "Item 3", quantity: 8 },
];

const Profile = () => {
	const [items, setItems] = useState(initial);

	return (
		<Box bgcolor="#132f4b" minHeight="100vh">
			<Navbar />
			<ProfileForm />
			<ItemTable items={items} setItems={setItems} />
		</Box>
	)
}

export default Profile