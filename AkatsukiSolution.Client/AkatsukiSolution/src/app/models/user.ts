import { Role } from "./role";

export class User {
    id?: number;
    firstName!:string;
    lastName!:string;
    title!:string;
    role!: Role | null;
    manager?: User | null;
}