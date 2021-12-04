import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Router } from "@angular/router";
import { FormControl, FormGroup } from "@angular/forms";
import { CookieService } from "ngx-cookie-service";

interface userModel {
  username: string;
  password: string;
}

@Component({
  selector: "app-account-login",
  templateUrl: "./account-login.component.html",
  styleUrls: ["./account-login.component.css"],
})
export class AccountLoginComponent implements OnInit {
  hide: boolean;
  error: string;
  cookieService: CookieService;

  loginForm = new FormGroup({
    username: new FormControl(""),
    password: new FormControl(""),
  });

  constructor(
    private http: HttpClient,
    private router: Router,
    private cookieServiceParam: CookieService
  ) {
    this.hide = true;
    this.cookieService = cookieServiceParam;
  }

  signIn() {
    let user: userModel = {
      username: this.loginForm.get("username").value,
      password: this.loginForm.get("password").value,
    };

    this.http.post(`${environment.apiUrl}/api/Account/Login`, user).subscribe(
      (result: UserResponse) => {
        this.cookieService.set("token", result.token);
        this.cookieService.set("accountId", result.accountId);
        this.router.navigate(["/"]);
        window.location.reload();
      },
      (error) => {
        this.error = error.error;
        console.log(error);
      }
    );
  }

  ngOnInit() {}
}
