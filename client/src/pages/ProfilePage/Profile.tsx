import { Box } from "@mui/material"
import { CreateProductForm, ItemTable, ProfileForm } from "../../components"
import { useEffect, useState } from "react";
import { getAllUsers } from "../../lib/users/users";
import { getCookie } from "typescript-cookie";
import { IProductPage, IUserPage } from "../../shared";
import { Notification } from "../../features";
import { useLocation } from "react-router-dom";
import { getIdentityUser } from "../../lib/identity/identity";
import { getAllProducts } from "../../lib/products/products";

const Profile = () => {
	const [error, setError] = useState<string | null>(null);
	const [isAdmin, setIsAdmin] = useState(false);
	const [products, setProducts] = useState<IProductPage | null>();

	const location = useLocation();
	const message = location.state && location.state.message;
	const type = location.state && location.state.type;

	useEffect(() => {
		getUser();
		fetchItems();
	}, []); // Пустой массив зависимостей, чтобы эффекты выполнялись только при монтировании компонента

	const getUser = async () => {
		try {
			const { data } = await getIdentityUser(
				getCookie("jwt-authorization") ?? "",
				getCookie("current-user") ?? ""
			);
			if (data.role === "admin") {
				setIsAdmin(true);
			}
		}catch(error){
		}
	};

	const fetchItems = () => {
			(async () => {
				try {
					const response = await getAllProducts();
					setProducts(response.data);
				} catch (error) {
					setProducts(null)
				}
			})();
	};

	return (
		<Box bgcolor="#132f4b" display={"flex"} alignItems={"center"} height={"100vh"} width={"100vw"}>
			{error && <Notification message={error} type="error" />}
			{message && <Notification message={message} type={type} />}
			<Box display={"flex"} justifyContent={"space-evenly"} width={"100%"}>
				<ProfileForm setError={setError} />
				<ItemTable products={products ?? { orders: [], page: 0, totalPage: 0 }} />
				{isAdmin && <CreateProductForm />}
			</Box>
		</Box>
	);
};

export default Profile;
