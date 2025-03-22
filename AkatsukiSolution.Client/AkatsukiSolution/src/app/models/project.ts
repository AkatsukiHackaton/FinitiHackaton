import { User } from "./user";

export class Project {
    id?: number;
    name!: string;
    manager!: User
}