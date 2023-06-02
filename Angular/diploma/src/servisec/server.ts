import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class ServerService{
    constructor(private http:HttpClient){}
    private matchUrl:string = "/api/match?id="
    private playerUrl:string = "/api/account?id="
    private recentUrl:string = "/api/rMatches?id="
    private totals:string = "/api/totals?id="
    private valve:string = "/api/user?id="

    public getMatch(id:number){
        this.log(this.getMatch);
        return this.http.get(this.matchUrl + id);
    }
    public getPlayer(id:number){
        this.log(this.getPlayer);
        return this.http.get(this.playerUrl + id);
    }
    public getRecentMatches(id:number){
        this.log(this.getRecentMatches);
        return this.http.get(this.recentUrl + id);
    }
    public getTotals(id:number){
        this.log(this.getTotals);
        return this.http.get(this.totals + id);
    }
    public loadUser(){
        this.log(this.getTotals);
        return this.http.get("/auth/loaduser")
    }
    public getUser(id:string){
        this.log(this.getTotals);
        return this.http.get(this.valve + id);
    }
    private log(f:Function){
        console.log(f.name)
    }
}