import { Box, Button, Container, Divider, Grid, Typography } from "@mui/material";
import { Product } from "../forms";
import { IProductTest } from "../pagination/Pagination";

interface ProductContainerProps {
	products: IProductTest[]
}

const ProductsContainer = ({ products }: ProductContainerProps) => {
	return (
		<Container sx={{ display: "flex", justifyContent: "center" }}>
			<Grid container spacing={2} sx={{ marginTop: "80px" }} >
				{products.map((product, index) => (
					<Grid key={index} item xs={2} sm={2} md={4} sx={{ marginBottom: "20px" }}>
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
								image={product.thumbnailUrl}
								name={product.title}
								total={0}
								status="available"
							/>
						</Box>
					</Grid>
				))}
			</Grid>
		</Container>
	);
};

export default ProductsContainer;