import { useEffect, useState } from "react"
import axios from "axios"
import { Product } from "../forms"
import ProductsContainer from "../containers/ItemContainer"

export interface IProductTest {
	id: number,
	title: string,
	thumbnailUrl: string
}

export interface IPaginationProps {
	apiUrl: string
}

const Pagination = ({ apiUrl }: IPaginationProps) => {
	const [products, setProducts] = useState<IProductTest[]>([])
	const [currentPage, setCurrentPage] = useState(1)
	const [fetching, setFetching] = useState(true)

	useEffect(() => {
		if (fetching) {
			axios.get(`${apiUrl}?_limit=10&_page=${currentPage}`)
				.then(response => {
					setProducts([...products, ...response.data])
					setCurrentPage(prev => prev + 1)
				})
				.finally(() => setFetching(false))
		}
	}, [fetching])

	useEffect(() => {
		document.addEventListener('scroll', handleScroll);

		return function () {
			document.removeEventListener('scroll', handleScroll)
		}
	}, [])

	const handleScroll = (e: any) => {
		if (e.target.documentElement.scrollHeight - (e.target.documentElement.scrollTop + window.innerHeight) < 100) {
			setFetching(true)
		}
	}

	return (
		<>
			<ProductsContainer products={products} />
		</>
	)
}

export default Pagination