import { Component } from "@angular/core";
import { CookieService } from "ngx-cookie-service";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"],
})
export class NavMenuComponent {
  isExpanded = false;
  isAuthorized = false;
  accountId = null;

  constructor(private cookieService: CookieService) {
    if (
      this.cookieService.get("token") != "" &&
      this.cookieService.get("accountId") != ""
    ) {
      this.isAuthorized = true;
      this.accountId = this.cookieService.get("accountId");
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
