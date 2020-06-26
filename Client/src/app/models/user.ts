import { Role } from "./role";

export class User {
    id: number;
    username: string;
    role: string;
    token?: string;
}