import { Box, Table, TableBody, TableCell, TableHead, TableRow, TextField, TablePagination, Checkbox, IconButton } from "@mui/material";
import React, { useState } from "react";
import EditIcon from "@mui/icons-material/Edit";
import CheckIcon from "@mui/icons-material/Check";

export interface Item {
	id: number;
	name: string;
	quantity: number;
}

interface ItemTableProps {
	items: Item[];
	setItems: React.Dispatch<React.SetStateAction<Item[]>>;
}

const ItemTable: React.FC<ItemTableProps> = ({ items, setItems }) => {
	const [searchTerm, setSearchTerm] = useState("");
	const [page, setPage] = useState(0);
	const [rowsPerPage, setRowsPerPage] = useState(5);
	const [selectedItemIds, setSelectedItemIds] = useState<number[]>([]);
	const [isEditing, setIsEditing] = useState(false);
	const [editedItem, setEditedItem] = useState<Item | null>(null);

	const handleQuantityChange = (id: number, quantity: number) => {
		const updatedItems = items.map((item) => (item.id === id ? { ...item, quantity } : item));
		setEditedItem((prevItem) => {
			if (prevItem && prevItem.id === id) {
				return { ...prevItem, quantity };
			}
			return prevItem;
		});
		setItems(updatedItems);
	};

	const handleSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
		setSearchTerm(event.target.value);
		setPage(0);
	};

	const handlePageChange = (event: React.MouseEvent<HTMLButtonElement> | null, newPage: number) => {
		setPage(newPage);
	};

	const handleRowsPerPageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
		setRowsPerPage(parseInt(event.target.value, 10));
		setPage(0);
	};

	const handleRowClick = (id: number) => {
		if (isEditing) return;

		const isSelected = selectedItemIds.includes(id);
		if (isSelected) {
			setSelectedItemIds((prevIds) => prevIds.filter((itemId) => itemId !== id));
		} else {
			setSelectedItemIds((prevIds) => [...prevIds, id]);
		}
	};

	const handleEditClick = () => {
		if (selectedItemIds.length === 1) {
			setIsEditing(true);
			setEditedItem(items.find((item) => item.id === selectedItemIds[0]) || null);
		}
	};

	const handleSaveClick = () => {
		if (editedItem) {
			const updatedItems = items.map((item) => {
				if (selectedItemIds.includes(item.id)) {
					return editedItem;
				}
				return item;
			});
			setItems(updatedItems);
			setIsEditing(false);
			setEditedItem(null);
			setSelectedItemIds([]);
		}
	};

	const handleQuantityFieldChange = (event: React.ChangeEvent<HTMLInputElement>) => {
		if (editedItem) {
			setEditedItem({ ...editedItem, quantity: parseInt(event.target.value) });
		}
	};

	const filteredItems = items.filter((item) =>
		item.name.toLowerCase().includes(searchTerm.toLowerCase())
	);

	const paginatedItems = filteredItems.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage);

	return (
		<Box>
			<Box bgcolor="white" borderRadius={3} p={2}>
				<Box
					display="flex"
					justifyContent="space-between"
					alignItems="center"
					marginBottom={2}
				>
					<TextField
						type="text"
						value={searchTerm}
						onChange={handleSearchChange}
						label="Search"
						disabled={isEditing}
					/>
					{selectedItemIds.length === 1 && !isEditing && (
						<IconButton onClick={handleEditClick}>
							<EditIcon sx={{ color: "#0a1929" }} />
						</IconButton>
					)}
					{isEditing && (
						<IconButton onClick={handleSaveClick}>
							<CheckIcon sx={{ color: "green" }} />
						</IconButton>
					)}
				</Box>

				<Table sx={{ maxWidth: 400, width: "100%", backgroundColor: "white" }}>
					<TableHead>
						<TableRow>
							<TableCell></TableCell>
							<TableCell>ID</TableCell>
							<TableCell>Name</TableCell>
							<TableCell>Quantity</TableCell>
						</TableRow>
					</TableHead>
					<TableBody>
						{paginatedItems.map((item) => (
							<TableRow
								key={item.id}
								selected={selectedItemIds.includes(item.id)}
								onClick={() => handleRowClick(item.id)}
							>
								<TableCell padding="checkbox">
									<Checkbox
										checked={selectedItemIds.includes(item.id)}
										disabled={isEditing}
										onChange={() => { }}
									/>
								</TableCell>
								<TableCell>{item.id}</TableCell>
								<TableCell>{item.name}</TableCell>
								<TableCell>
									{isEditing && editedItem && selectedItemIds.includes(item.id) ? (
										<TextField
											type="number"
											value={editedItem.quantity}
											onChange={handleQuantityFieldChange}
										/>
									) : (
										<TextField type="number" value={item.quantity} disabled />
									)}
								</TableCell>
							</TableRow>
						))}
					</TableBody>
				</Table>

				<Box sx={{ width: "100%" }}>
					<TablePagination
						component="div"
						count={filteredItems.length}
						page={page}
						onPageChange={handlePageChange}
						rowsPerPage={rowsPerPage}
						onRowsPerPageChange={handleRowsPerPageChange}
					/>
				</Box>
			</Box>
		</Box>
	);
};

export default ItemTable;
