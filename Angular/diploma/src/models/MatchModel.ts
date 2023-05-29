import { HeroModel } from "./HeroModel";
import { TeamModel } from "./TeamModel";

export class MatchModel{
    matchId?:string;
    heroes?:HeroModel[];
    radiantWin?:string;
    dire?:TeamModel;
    radiant?:TeamModel;
    duration?:string;
    leagueId?:string;
}