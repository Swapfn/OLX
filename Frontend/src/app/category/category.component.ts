import { Component, OnInit } from '@angular/core';
import { Category } from '../_models/category';
import { CategoryService } from '../_services/categoryService';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css'],
})
export class CategoryComponent implements OnInit {
  categories: Category[];
  selectedCategory: number;
  constructor(public categoryService: CategoryService) {}

  ngOnInit(): void {
    this.getCategories();
   }

  getCategories() {
    this.categoryService.getCategories().subscribe(categories => this.categories=categories);
  }
}
