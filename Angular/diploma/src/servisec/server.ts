import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class ServerService{
    constructor(private http:HttpClient){}
    private matchUrl:string = "/api/match?id="
    private playerUrl:string = "/api/account?id="
    private recentUrl:string = "/api/rMatches?id="
    private totals:string = "/api/totals?id="

    public getMatch(id:number){
        return this.http.get(this.matchUrl + id);
    }
    public getPlayer(id:number){
        return this.http.get(this.playerUrl + id);
    }
    public getRecentMatches(id:number){
        return this.http.get(this.recentUrl + id);
    }
    public getTotals(id:number){
        return this.http.get(this.totals + id);
    }
}