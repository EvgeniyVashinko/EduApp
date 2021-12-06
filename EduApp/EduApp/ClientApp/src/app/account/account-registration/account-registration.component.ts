import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { User } from "src/app/common/models/user";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-account-registration",
  templateUrl: "./account-registration.component.html",
  styleUrls: ["./account-registration.component.css"],
})
export class AccountRegistrationComponent implements OnInit {
  registerForm = new FormGroup({
    firstName: new FormControl(""),
    lastName: new FormControl(""),
    email: new FormControl(""),
    username: new FormControl(""),
    password: new FormControl(""),
    birthday: new FormControl(""),
    sex: new FormControl(""),
    imageUrl: new FormControl(""),
  });

  hide: boolean;
  apiUrl: string;
  error: string;

  constructor(
    private http: HttpClient,
    private router: Router,
    private cookieService: CookieService
  ) {
    this.hide = true;
    this.apiUrl = environment.apiUrl + "/api/Account/Registration";
  }

  deleteImage() {
    this.registerForm.get("imageUrl").setValue("");
  }

  uploadImage(file) {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      this.registerForm.get("imageUrl").setValue(reader.result);
    };
  }

  registration() {
    let user: Partial<User> = {
      firstName: this.registerForm.get("firstName").value,
      lastName: this.registerForm.get("lastName").value,
      email: this.registerForm.get("email").value,
      username: this.registerForm.get("username").value,
      password: this.registerForm.get("password").value,
      birthday: this.registerForm.get("birthday").value,
      sex: JSON.parse(this.registerForm.get("sex").value),
      image: this.registerForm.get("imageUrl").value,
    };

    if (this.registerForm.valid) {
      this.http.post(this.apiUrl, user, environment.options).subscribe(
        (result: UserResponse) => {
          this.cookieService.set("token", result.token);
          this.cookieService.set("accountId", result.accountId);
          this.router.navigate(["/"]).then(() => {
            window.location.reload();
          });
        },
        (error) => {
          this.error = error.message;
          console.log(error);
        }
      );
    }
  }

  ngOnInit() {}
}
