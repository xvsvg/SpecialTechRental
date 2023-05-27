import { Box, Container, Grid } from "@mui/material";
import { Product } from "../forms";
import { IProduct } from "../forms/ProductForm/Product";

interface ProductContainerProps {
	products: IProduct[]
}

const ProductsContainer = ({ products }: ProductContainerProps) => {
	return (
		<Container sx={{ display: "flex", justifyContent: "center" }}>
			<Grid container spacing={2} sx={{ marginTop: "80px" }} >
				{products.map((product) => (
					<Grid key={product.id} item xs={2} sm={2} md={4} sx={{ marginBottom: "20px" }}>
						<Box
							height={"100%"}
							sx={{
								display: "flex",
								flexDirection: "column",
								justifyContent: "space-between",
								backgroundColor: "#0a1929",
								padding: "10px",
								borderRadius: "4px",
								boxShadow: "0 2px 4px rgba(0, 0, 0, 0.2)",
							}}>
							<Product
								id={product.id}
								image={product.image}
								name={product.name}
								total={product.total}
								status={product.status}
							/>
						</Box>
					</Grid>
				))}
			</Grid>
		</Container>
	);
};

export default ProductsContainer;