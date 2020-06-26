import { Category } from './category';
import { Phase } from '.';

export class Process {
    processId: number;
    name: string;
    description: string;
    createdBy: string;
    createdAt: string;
    updatedAt: string;
    updatedBy: string;
    status: string;
    categoryId: number;
    category: Category;
    phase: Phase[];
}