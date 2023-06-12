import { Component,Input } from '@angular/core';
import { HttpClient,HttpParams} from '@angular/common/http';
import { AccInfo } from 'src/models/AccInfo';
import { ServerService } from 'src/servisec/server';

@Component({
    selector: 'comunity-user',
    templateUrl: './comunity-user.component.html',
    styleUrls: ['./comunity-user.component.css']
})
export class ComunityUserComponent {
    @Input() set user(acc:string | undefined){
        console.log(acc);
        this.server.getUser(acc!).subscribe({next:(data:any)=> 
        {
            this.Acc = data;
            console.log(acc);
            if(this.Acc){
                this.userNotNull = true;
            }
            else this.userNotNull = false;
        }});
    }
    Acc?:AccInfo;
    userNotNull:boolean = false;
    constructor(private server:ServerService){}
}
