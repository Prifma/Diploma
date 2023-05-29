import { ItemModel } from "./ItemModel";

export class HeroModel{
    heroId?:string;
    accountId?:string;
    netWorth?:string;
    playerSlot?:string;
    mainItems?:ItemModel[];
    backPackItems?:ItemModel[];
    neutralItme?:ItemModel;
    kills?:string;
    death?:string;
    assists?:string;
    goldPerMin?:string;
    expPerMin?:string;
    heroDamage?:string;
    lastHits?:string;
    denies?:string;
    level?:string;
    towerDamage?:string;
}