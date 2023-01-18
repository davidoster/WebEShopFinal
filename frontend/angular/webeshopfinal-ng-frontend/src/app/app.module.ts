import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { CategoriesComponent } from './categories/categories.component';
import { CategoriesCreateComponent } from './categories-create/categories-create.component';

@NgModule({
  declarations: [
    AppComponent,
    CategoriesComponent,
    CategoriesCreateComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [CategoriesComponent]
})
export class AppModule { }
