import { object, string } from "yup";

export const Schema = object({
    username:string().required("Username is required"),
    password: string().required("Password is required")
})