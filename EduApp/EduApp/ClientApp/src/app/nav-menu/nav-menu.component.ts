import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"],
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  isAuthorized = false;
  accountId = null;

  constructor(private cookieService: CookieService, private router: Router) {
    if (
      this.cookieService.get("token") != "" &&
      this.cookieService.get("accountId") != ""
    ) {
      this.isAuthorized = true;
      this.accountId = this.cookieService.get("accountId");
    }
  }

  ngOnInit() {}

  logOut() {
    this.cookieService.deleteAll("/");
    this.router.navigate(["/"]).then(() => {
      window.location.reload();
    });
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
