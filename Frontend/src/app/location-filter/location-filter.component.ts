import { outputAst } from '@angular/compiler';
import { Component, OnInit, Input,EventEmitter, Output} from '@angular/core';


@Component({
  selector: 'app-location-filter',
  templateUrl: './location-filter.component.html',
  styleUrls: ['./location-filter.component.css']
})
export class LocationFilterComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }


  EgyCities=["Alexandria","Aswan","Asyut","Beheira","Beni Suef","Cairo","Dakahlia","Damietta",
  "Faiyum","Gharbia","Giza","Ismailia","Kafr El Sheikh","Luxor","Matruh","Minya","Monufia","New Valley",
  "North Sinai","Port Said","Qalyubia","Qena","Red Sea","Sharqia","Sohag","South Sinai","Suez"]

  locationSelectedValue:string="Egypt";

  @Output()
  locationselect:EventEmitter<string> = new EventEmitter<string>();
  
  onlocationSelect(e:any){
    this.locationselect.emit(this.locationSelectedValue)
    //console.log(this.locationSelectedValue);
  }

}
