import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import { environment } from "src/environments/environment";

interface userModel {
  FirstName: string;
  LastName: string;
  Email: string;
  Username: string;
  Password: string;
  Birthday: Date;
  Sex: number;
  ImageUrl: string;
}

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

  constructor(private http: HttpClient, private router: Router) {
    this.hide = true;
    this.router = router;
    this.apiUrl = environment.apiUrl + "/Account/Registration";
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
    let user: userModel = {
      FirstName: this.registerForm.get("firstName").value,
      LastName: this.registerForm.get("lastName").value,
      Email: this.registerForm.get("email").value,
      Username: this.registerForm.get("username").value,
      Password: this.registerForm.get("password").value,
      Birthday: this.registerForm.get("birthday").value,
      Sex: this.registerForm.get("sex").value,
      ImageUrl: this.registerForm.get("imageUrl").value,
    };

    if (this.registerForm.valid) {
      this.http.post(this.apiUrl, user).subscribe(
        (result) => {
          this.router.navigate(["/"]);
        },
        (error) => {
          this.error = error.error;
          console.log(error);
        }
      );
    }
  }

  ngOnInit() {}
}
