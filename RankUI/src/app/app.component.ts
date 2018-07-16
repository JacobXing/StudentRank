import { Component } from '@angular/core';
import { ProxyService } from './services/mvc-api/services/RankAPI.Controllers.Proxy.Service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(private proxyService: ProxyService){

  }

  score: number = 80;
  results: {
    score: number,
    rank: number
  }[] = [];

  click(){
    this.proxyService.Infer({
      "Inputs": {
        "input1": {
          "ColumnNames": [
            "rank",
            "score"
          ],
          "Values": [
            [
              "0",
              `${this.score}`
            ]
          ]
        }
      },
      "GlobalParameters": {}
    }).subscribe((res)=>{
      console.log(res);
      
      let rank: number = parseInt(res.Results.output1.value.Values[0][2]);
      this.results.push(
        {
          score: this.score,
          rank: rank
        }
      );
    });
  }
}