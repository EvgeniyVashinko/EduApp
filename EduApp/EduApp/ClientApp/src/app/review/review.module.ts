import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReviewCreateComponent } from './review-create/review-create.component';
import { ReviewViewComponent } from './review-view/review-view.component';
import { MatButtonModule, MatCardModule, MatInputModule, MatSliderModule } from '@angular/material';
import { ReviewComponent } from './review/review.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ReviewCreateComponent,
    ReviewViewComponent,
    ReviewComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatInputModule,
    MatSliderModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule
  ],
  exports: [
    ReviewComponent
  ]
})
export class ReviewModule { }
