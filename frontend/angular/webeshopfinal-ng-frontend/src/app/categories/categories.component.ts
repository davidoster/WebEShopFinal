import { Component, Injectable } from '@angular/core';
import { Http } from '@angular/http';

// import 'rxjs/add/operator/map';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
// @Injectable()
export class CategoriesComponent {
  title = "List of Categories";
  categories: any = [];
  


  constructor(public http: Http) {
    this.GetAllCategories();
  }

  GetAllCategories() {
    // let category = { title: "ABC", description: "ABC description" }; 
    // this.categories.push(category);

    // category = { title: "DEF", description: "DEF description" };
    // this.categories.push(category);

    // somehow to get via https://localhost:7258/api/categories
    console.log("Hello");
    this.http.get('https://localhost:7258/api/categories').subscribe(res => this.categories = res.json());
  }
}
