import { Component,EventEmitter,Input,Output } from '@angular/core';
import { AccInfo } from 'src/models/AccInfo';
import { Post } from 'src/models/Comunity/Post';
import { ServerService } from 'src/servisec/server';


@Component({
    selector: 'comunity-post-preview',
    templateUrl: './comunity-post-preview.component.html',
    styleUrls: ['./comunity-post-preview.component.css']
})
export class ComunityPostPreviewComponent {
    @Input() set post(P:Post){
        this._post = P;
        console.log(this._post.userId)
        this.server.getUser(this._post!.userId!).subscribe({next:(data:any) => this.Acc = data});
    }
    _post?:Post;
    Acc?:AccInfo;
    constructor(private server:ServerService){}
    @Output() e = new EventEmitter<Post>();
    changePost(){
        this.e.emit(this._post);
    }
}
