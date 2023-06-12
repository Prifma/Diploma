import { Guid } from "guid-typescript";

export abstract class BaseComunityEntity{
    public id?:Guid;
    public body:string = "";
    public userId?:string = ""
    public likeCount:number=0;
    public disCount:number=0;
}