import { IProduct } from "../product";

interface IProductPage{
	orders: IProduct[];
	page: number;
	totalPage: number;
}

export default IProductPage