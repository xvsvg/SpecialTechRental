import { Button, Checkbox, MenuItem, Select, TextField, TextareaAutosize } from "@mui/material"

const CreateProductForm = () => {
	return (
		<form>
			<TextField
				label="Название"
				// onChange={(e) => setName(e.target.value)}
				required
			/>
			<br />
			<TextareaAutosize
				// rowsMin={3}
				placeholder="Описание"
				// value={description}
				// onChange={(e) => setDescription(e.target.value)}
				required
			/>
			<br />
			<Select
				label="Категория"
				// value={category}
				// onChange={(e) => setCategory(e.target.value)}
				required
			>
				<MenuItem value="category1">Категория 1</MenuItem>
				<MenuItem value="category2">Категория 2</MenuItem>
				<MenuItem value="category3">Категория 3</MenuItem>
			</Select>
			<br />
			<TextField
				label="Цена"
				type="number"
				// value={price}
				// onChange={(e) => setPrice(e.target.value)}
				required
			/>
			<br />
			<Checkbox
				// checked={isFeatured}
				// onChange={(e) => setIsFeatured(e.target.checked)}
			/>
			Показывать на главной странице
			<br />
			<Button type="submit" variant="contained" color="primary">
				Отправить
			</Button>
		</form>
	)
}

export default CreateProductForm