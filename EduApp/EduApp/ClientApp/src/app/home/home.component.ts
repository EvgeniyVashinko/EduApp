import { Component } from "@angular/core";
import { Course } from "../common/models/course";
import { PagedList, PagedListContainer } from "../common/models/pagedList";
import { CourseService } from "../common/services/course.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent {
  courses: Course[] = null;
  titleOrder = undefined;
  priceOrder = undefined;
  query: string;

  constructor(private courseService: CourseService) {}

  ngOnInit() {
    this.courseService
      .getAllCourses({})
      .subscribe((result: PagedListContainer<Course>) => {
        this.courses = result.pagedList.items;
      });
  }

  sortByTitle(){
    this.titleOrder = -(this.titleOrder || -1);

    const collator = new Intl.Collator('ru', { numeric: true });
    const comparator = (order:number) => (a:Course, b:Course) => order * collator.compare(
        a.title,
        b.title
    );

    this.courses = this.courses.sort(comparator(this.titleOrder))

    console.log(this.courses);
    
  }

  sortByPrice(){
    this.priceOrder = -(this.priceOrder || -1);

    const comparator = (order:number) => (a:Course, b:Course) => order * (Number(b.price<a.price) - Number(a.price<b.price));

    this.courses = this.courses.sort(comparator(this.priceOrder))
    console.log(this.courses);
  }

  filterCourses(){
    this.courseService
      .getAllCourses(
        {
          title: this.query
        })
      .subscribe((result: PagedListContainer<Course>) => {
        this.courses = result.pagedList.items;
      });
  }
}
