import { IUserImage } from "../user/userimage.model";

export interface INotification {
    title:string;
    description:string;
    type:string;
    user:IUserImage;
    isRead:boolean;
    createdAt: Date;
}