import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { MatSnackBar } from "@angular/material";
import { ActivatedRoute, Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { User } from "src/app/common/models/user";
import { UserService } from "src/app/common/services/user.service";

@Component({
  selector: "app-user-update",
  templateUrl: "./user-update.component.html",
  styleUrls: ["./user-update.component.css"],
})
export class UserUpdateComponent implements OnInit {
  userId: string = this.activatedRoute.snapshot.paramMap.get("id");
  error: string;
  user: User;

  updateUserForm = new FormGroup({
    firstName: new FormControl(""),
    lastName: new FormControl(""),
    email: new FormControl(""),
    imageUrl: new FormControl(""),
  });
  constructor(
    private activatedRoute: ActivatedRoute,
    private userService: UserService,
    private router: Router,
    private cookieService: CookieService,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    if (this.cookieService.get("accountId") !== this.userId) {
      this.router.navigate(["/user/myProfile"]);
    }
    this.userService.getUserById(this.userId).subscribe(
      (result) => {
        this.updateUserForm.get("firstName").setValue(result.firstName);
        this.updateUserForm.get("lastName").setValue(result.lastName);
        this.updateUserForm.get("email").setValue(result.email);
        this.updateUserForm.get("imageUrl").setValue(result.image);
        this.user = result;
      },
      (error) => {
        this.router.navigate(["/user/myProfile"]);
      }
    );
  }

  deleteImage() {
    this.updateUserForm.get("imageUrl").setValue("");
  }

  uploadImage(file) {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      this.updateUserForm.get("imageUrl").setValue(reader.result);
    };
  }

  updateUser() {
    if (this.updateUserForm.valid) {
      this.user.firstName = this.updateUserForm.get("firstName").value;
      this.user.lastName = this.updateUserForm.get("lastName").value;
      this.user.email = this.updateUserForm.get("email").value;
      this.user.image = this.updateUserForm.get("imageUrl").value;
      this.userService.updateUser(this.user).subscribe((result) => {
        this._snackBar.open("Your profile was updated", "Ok");
      });
    }
  }
}
