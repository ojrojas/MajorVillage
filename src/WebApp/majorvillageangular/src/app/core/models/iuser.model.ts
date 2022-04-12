import { IBaseEntity } from "./ibaseentity";

export interface IUser extends IBaseEntity{
    firstName:string;
    middlename:string | null;
    lastName:string;
    surName:string | null;
    identification:string;
    typeIdentification:string;
    age:number;
    birthDate:Date;
    typeUser:string;
    email:string;
}