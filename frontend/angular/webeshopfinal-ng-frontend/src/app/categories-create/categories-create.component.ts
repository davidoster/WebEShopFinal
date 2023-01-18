import { Component } from '@angular/core';
import { Category } from 'src/app/models/category/category';
import { Http, Headers } from '@angular/http';

@Component({
  selector: 'app-categories-create',
  templateUrl: './categories-create.component.html',
  //template: '',
  styleUrls: ['./categories-create.component.css']
})
export class CategoriesCreateComponent {
  title: String = "Create a new Product Category";
  category: Category;
  

  constructor(public http: Http)
  {
    this.category = new Category("no title", "no description");
  }

  onSubmit(f: any) {
    var formValue: any = JSON.stringify(f.value);
    console.log(formValue);
    var options = new Headers({ 'Content-Type': "application/json; charset=utf8" });
    console.log(JSON.stringify(this.category));
    this.http.post('https://localhost:7258/api/category', JSON.stringify(this.category), { headers: options })
      .subscribe(res => console.log(res.json()));


      // 1st attempt : url, formValue <---- NOK
      // 2nd attempt : url, formValue, headers: options <----- options
      // 3rd attempt : url, category as JSON

    //this.http.post('https://localhost:7258/api/category', formValue, { 'headers': options })
    //.subscribe(res => console.log(res.json()));
  }
}
