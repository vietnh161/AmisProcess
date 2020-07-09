import { Field } from './field';
import { Employee } from './employee';
import { Process } from './process';

export class Phase {
    
    phaseId: number;
    serial: number;
    name: string;
    description: string;
    canDel:boolean;
    posittion:number;
    timeImplementType:string;
    timeImplement: number;
    personImplementType:string;
    personImplement: Employee[];
    fields: Field[];
    processId:number;
    process: Process;

}