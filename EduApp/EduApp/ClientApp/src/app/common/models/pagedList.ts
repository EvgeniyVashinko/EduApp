export interface PagedList<T> {
  canNext: boolean;
  canPrevious: boolean;
  from: number;
  items: T[];
  page: number;
  perPage: number;
  to: number;
  totalItems: number;
  totalPages: number;
}

export interface PagedListContainer<T> {
  pagedList: PagedList<T>;
}
