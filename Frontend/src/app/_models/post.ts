import { Photo } from "./Photo";

export interface Post {
    userId:number;
    id: number;
    title: string;
    categoryId: number;
    subcategoryId:number;
    subcategoryName:string
    description: string;
    isNew:boolean;
    price: number;
    negotiatable: boolean;
    photos: Photo[];
    location: string;
    createdAt: Date;
    userFullname:string;
    phoneNumber:number;
    
}
