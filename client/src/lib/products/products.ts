import axios from "axios"
import { ChangeProductStatusDto, CreateOrderDto } from "../../shared/dto"
import { IProduct, IProductPage } from "../../shared"

let url = process.env.API_URL

if (process.env.NODE_ENV === 'development')
	url += 'Order'
else url += 'api/Order'

export const api = axios.create({ baseURL: url })

export const changeProductStatus = async (token: string, dto: ChangeProductStatusDto) => {
	return await api.put('status', dto, {
		headers: {
			Authorization: `Bearer ${token}`
		}
	})
}

export const createProduct = async (token: string, dto: CreateOrderDto) => {
	return await api.post<IProduct>('', dto, {
		headers: {
			Authorization: `Bearer ${token}`
		}
	})
}

export const getAllProduct = async (page?: number) => {
	return await api.get<IProductPage>(`${page}`)
}

export const getProduct = async (token: string, id: string) => {
	return await api.get<IProduct>(`${id}`, {
		headers: {
			Authorization: `Bearer ${token}`
		}
	})
}