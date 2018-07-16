import { Ipredictobject } from './predict-rank.service';
import {Injectable} from '@angular/core'
import {Http} from '@angular/http'

const predict_uri = 'https://ussouthcentral.services.azureml.net/workspaces/c2cc6936eedb4079a2eb9d068e6124be/services/750fd19e11174329accef7fa1e27a1f9/execute?api-version=2.0&details=true'

@Injectable()
export class PredictRankService{
    constructor(private http:Http){
    }
    PredictRank(score: number){
        var query: Ipredictobject = {
            Imports:{
                imput1:{
                    ColumNames:["score"];
                    Values:[];
                    [score]
                }
            }
        };

        return this.http.post(predict_uri, query)
}
}
export interface Ipredictobject{
    Imports: IIputEntry;

}

export interface IpredictobjectInput{
    imput1: IIputEntry;
}
export interface IIputEntry{
    ColumNames: string[];
    Values: (string|number)[][];
}