import { IUser } from "../user";

interface IUserPage {
	users: IUser[];
	page: number;
	totalPage: number;
}

export default IUserPage