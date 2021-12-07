import { Category } from "./category";

export class Course {
  id: string;
  title: string;
  description: string;
  price: number;
  ownerId: string;
  categories: string[];
  isActive: boolean;
  categoriesObj: Category[];
}
