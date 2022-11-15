


    export interface Weather {
        id?:number;
        main?:string;
        description?:string;
        icon?:string;
    }

    export interface Current {
        dt?:number;
        sunrise?:number;
        sunset?:number;
        temp?:number;
        feels_like?:number;
        pressure?:number;
        humidity?:number;
        dew_point?:number;
        uvi?:number;
        clouds?:number;
        visibility?:number;
        wind_speed?:number;
        wind_deg?:number;
        wind_gust?:number;
        weather?:Weather[];
    }
    export class CurrentObject {
        dt?:number;
        sunrise?:number;
        sunset?:number;
        temp?:number;
        feels_like?:number;
        pressure?:number;
        humidity?:number;
        dew_point?:number;
        uvi?:number;
        clouds?:number;
        visibility?:number;
        wind_speed?:number;
        wind_deg?:number;
        wind_gust?:number;
        constructor(obj: Current) {
            
            this.dt= obj.dt;
            this.sunrise= obj.sunrise;
            this.sunset= obj.sunset;
            this.temp= obj.temp;
            this.feels_like= obj.feels_like;
            this.pressure= obj.pressure;
            this.humidity= obj.humidity;
            this.dew_point= obj.dew_point;
            this.uvi= obj.uvi;
            this.clouds= obj.clouds;
            this.visibility= obj.visibility;
            this.wind_speed= obj.wind_speed;
            this.wind_deg= obj.wind_deg;
            this.wind_gust= obj.wind_gust;
            // here you apply all properties you need from AnotherObjectThatHasMoreProperties
        }

    }
    export interface Weather2 {
        id?:number;
        main?:string;
        description?:string;
        icon?:string;
    }

    export interface Hourly {
        dt?:number;
        temp?:number;
        feels_like?:number;
        pressure?:number;
        humidity?:number;
        dew_point?:number;
        uvi?:number;
        clouds?:number;
        visibility?:number;
        wind_speed?:number;
        wind_deg?:number;
        wind_gust?:number;
        weather?:Weather2[];
        pop?:number;
    }

    export interface Temp {
        day?:number;
        min?:number;
        max?:number;
        night?:number;
        eve?:number;
        morn?:number;
    }

    export interface FeelsLike {
        day?:number;
        night?:number;
        eve?:number;
        morn?:number;
    }

    export interface Weather3 {
        id?:number;
        main?:string;
        description?:string;
        icon?:string;
    }

    export interface Daily {
        dt?:number;
        sunrise?:number;
        sunset?:number;
        moonrise?:number;
        moonset?:number;
        moon_phase?:number;
        temp?:Temp;
        feels_like?:FeelsLike;
        pressure?:number;
        humidity?:number;
        dew_point?:number;
        wind_speed?:number;
        wind_deg?:number;
        wind_gust?:number;
        weather?:Weather3[];
        clouds?:number;
        pop?:number;
        uvi?:number;
    }

    export interface RootObject {
        lat?:number;
        lon?:number;
        timezone?:string;
        timezone_offset?:number;
        current?:Current;
        hourly?:Hourly[];
        daily?:Daily[];
    }
    export interface coordReq {
        lon?:number;
        lat?:number;
        
    }
    export interface Table {
        key?:any;
          
    }
    export interface Header {
        columns?:any;
          
    }



