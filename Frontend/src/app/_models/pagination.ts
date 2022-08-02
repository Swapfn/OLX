import { Post } from "./post"

export interface Pagination{

    searchObject:{
        categoryId: number,
        subCategoryId:number,
        locationId: number,
        minPrice: number,
        maxPrice: number,
        title:string,
        description:string
    },
    pageNumber: number,          //current page
    pageSize: number,            //items per page
    sortBy: string,
    sortDirection: string 
}