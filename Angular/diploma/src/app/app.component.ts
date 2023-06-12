import { Component } from '@angular/core';
import { AccInfo } from 'src/models/AccInfo';
import { UserType } from 'src/models/Comunity/UserType';
import { ModalService } from 'src/servisec/modal';
import { ServerService } from 'src/servisec/server';
import { AccountSingleton } from 'src/singleton/AccountSingleton';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls:['./app.component.css']
})
export class AppComponent {
  constructor(private server:ServerService,protected modalService: ModalService){
    server.loadUser().subscribe({next:(data: any) => 
      {
        this.Acc.id = data.m;
        console.log(this.Acc.id);
        if(this.Acc.id){
          this.Acc.isAuth = true;
          server.getUser(this.Acc.id).subscribe({next:(data: any) => {
            this.Acc = data; 
            this.Acc.isAuth = true; 
            console.log(this.Acc);
            AccountSingleton.setInstance(this.Acc);
            if(this.Acc.userType === UserType.Banned)
              modalService.open('modal-1');
          }})
        }
        else this.Acc.isAuth = false;
        AccountSingleton.setInstance(this.Acc);
      }});
  }
  Acc:AccInfo = new AccInfo();
  currentPage:number = 1  ;
}
