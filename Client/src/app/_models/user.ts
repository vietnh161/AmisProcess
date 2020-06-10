import { Role } from "./role";

export class User {
    id: number;
    username: string;
    firstName: string;
    employeeCode: string;
    lastName: string;
    role: string;
    token?: string;
}