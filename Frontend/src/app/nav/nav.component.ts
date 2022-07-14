import { outputAst } from '@angular/compiler';
import { Component, OnInit ,Input,EventEmitter, Output} from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  //______________________Location Filter_________________________________________
  EgyCities=["Alexandria","Awan","Asyut","Beheira","Beni Suef","Cairo","Dakahlia","Damietta",
  "Faiyum","Gharbia","Giza","Ismailia","Kafr El Sheikh","Luxor","Matruh","Minya","Monufia","New Valley",
  "North Sinai","Port Said","Qalyubia","Qena","Red Sea","Sharqia","Sohag","South Sinai","Suez"]

  locationSelectedValue:string="Egypt";

  @Output()
  locationselect:EventEmitter<string> = new EventEmitter<string>();
  
  onlocationSelect(e:any){
    this.locationselect.emit(this.locationSelectedValue)
    //console.log(this.locationSelectedValue);
  }


  //________________________________Search___________________________________________

  searchValue:string="";
  
  @Output()
  searchText:EventEmitter<string>= new EventEmitter<string>();

  OnsearchText(){
    this.searchText.emit(this.searchValue);
    
  }





  
}
