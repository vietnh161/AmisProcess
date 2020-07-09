import { Role } from "./role";

export class User {
    id: number;
    username: string;
    fullName: string;
    role: string;
    token?: string;
}