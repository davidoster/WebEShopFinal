import { Component } from '@angular/core';
import { Category } from 'src/app/models/category/category';

 

@Component({
  selector: 'app-categories-create',
  templateUrl: './categories-create.component.html',
  //template: '',
  styleUrls: ['./categories-create.component.css']
})
export class CategoriesCreateComponent {
  title: String = "Create a new Product Category";
  category: Category;

  constructor()
  {
    this.category = new Category("no title", "no description");
  }

  onSubmit(f: any) {
    console.log(JSON.stringify(f.value));
  }
}
