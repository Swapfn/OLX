import { Photo } from "./photo";

export interface Post {
    id: number;
    adTtitle: string;
    categoryId: number;
    subCategoryId: number;
    isNew: boolean;
    description: string;
    price: number;
    negotiable: boolean;
    photos: Photo[];
    locationId: string;
    createdAt: Date;
}