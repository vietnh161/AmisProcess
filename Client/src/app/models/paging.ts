export class Paging {
    currentPage: number;
    pageSize: number;
    sort: string;
    sortBy: string;
    filters: Filter[]; 
}

class Filter{
    property: string;
    value: string;
}