import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { User } from "src/app/common/models/user";
import { UserService } from "src/app/common/services/user.service";

@Component({
  selector: "app-user-view",
  templateUrl: "./user-view.component.html",
  styleUrls: ["./user-view.component.css"],
})
export class UserViewComponent implements OnInit {
  @Input() userId: string = this.activatedRoute.snapshot.paramMap.get("id");

  user: User = null;

  constructor(
    private activatedRoute: ActivatedRoute,
    private cookieService: CookieService,
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit() {
    if (this.userId === "myProfile") {
      this.userId = this.cookieService.get("accountId");
    }
    this.userService.getUserById(this.userId).subscribe(
      (result: User) => {
        this.user = result;
        console.log(this.user);
      },
      (error) => {
        this.router.navigate(["/"]);
      }
    );
  }
}
