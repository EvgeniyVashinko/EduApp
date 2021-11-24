import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-account-login",
  templateUrl: "./account-login.component.html",
  styleUrls: ["./account-login.component.css"],
})
export class AccountLoginComponent implements OnInit {
  hide: boolean;

  username: string;
  password: string;

  constructor(private http: HttpClient) {
    this.hide = true;
  }

  signIn() {
    let requestObj = { username: this.username, password: this.password };
    this.http
      .post(`${environment.apiUrl}/api/Account/Login`, requestObj)
      .subscribe({
        next(ans) {
          console.log(`Succes ${ans}`);
        },
        error(msg) {
          console.log(`Something was wrong! ${msg}`);
        },
      });
  }

  ngOnInit() {}
}
