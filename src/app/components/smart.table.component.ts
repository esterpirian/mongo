

import { Component,OnInit,ChangeDetectionStrategy,
		ChangeDetectorRef,Input } from '@angular/core';    
    import { WeatherService} from '../services/weather.sevice';
    import { coordReq,RootObject,Header } from '../interfaces/coordWeather';
		import { Observable } from 'rxjs';
    import { LocalDataSource } from 'ng2-smart-table';
@Component({
	selector: 'spart-table',
	templateUrl: 'smart.table.component.html',
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class OldComponent implements OnInit {
	//@Input() data?: Observable<any[]>;
  @Input() data?:any[]=[];
	List: any[] = [];
  Header:Header={};
  source?: LocalDataSource;
	constructor(private cd: ChangeDetectorRef,private ser: WeatherService) {}
    
   
	ngOnInit() {
    
        if(this.data&&this.data[0]){
          this.Header=this.ser.CreateHeader(this.data[0][0]||this.data[0])
          this.source= new LocalDataSource(this.data)
        }
      
			}
	
	
}	
