import { Project } from "./project";
import { User } from "./user";

export class WorkingDay {
    id?: number;
    date!: Date;
    taskDescription!: string;
    hours!: number;
    employeeId!: number;
    projectId!: number;
}