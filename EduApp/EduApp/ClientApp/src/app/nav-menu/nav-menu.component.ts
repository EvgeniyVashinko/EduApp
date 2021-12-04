import { Component } from "@angular/core";
import { CookieService } from "ngx-cookie-service";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"],
})
export class NavMenuComponent {
  isExpanded = false;
  cookieService: CookieService;
  isAuthorized = false;

  constructor(private cookieServiceParam: CookieService) {
    this.cookieService = cookieServiceParam;
    if (
      this.cookieService.get("token") != "" &&
      this.cookieService.get("accountId") != ""
    ) {
      this.isAuthorized = true;
    }
  }

  logOut() {
    this.cookieService.deleteAll("/");
    window.location.reload();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
