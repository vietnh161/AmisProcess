import { Field } from './field';
import { Employee } from './employee';

export class Phase {
    
    id: number;
    serial: number;
    name: string;
    description: string;
    canDel:boolean;
    isLastPhase:boolean;
    timeImplementType:string;
    timeImplement: number;
    personImplementType:string;
    personImplement: Employee[];
    fields: Field[];
    processId:number;

}