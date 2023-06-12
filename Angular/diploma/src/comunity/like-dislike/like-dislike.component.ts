import { Component,Input } from '@angular/core';
import { Guid } from 'guid-typescript';
import { AccInfo } from 'src/models/AccInfo';
import { Reaction } from 'src/models/Comunity/Reaction';
import { ReactionType } from 'src/models/Comunity/ReactionType';
import { UserType } from 'src/models/Comunity/UserType';
import { ServerService } from 'src/servisec/server';

@Component({
    selector: 'like-dislike',
    templateUrl: './like-dislike.component.html',
    styleUrls: ['./like-dislike.component.css']
})
export class LikeDislikeComponent {

    @Input()
    numberOfLikes : number=0;
    @Input()
    numberOfDislike: number=0;
    @Input()
    postId?:Guid
    @Input() set userId(acc:AccInfo|undefined){
        this._userId = acc;
        console.log(acc)
        if(this._userId && this._userId.id ){
            this.server.checkReactionIsExist(+this._userId!.id!,this.postId!).subscribe({next:(data:any) => {
                if(data === false){

                }else{
                    if(data.reactionType === ReactionType.Like){
                        this.likesCounter = false;
                    }
                    else {
                            this.dislikeCounter = false;
                    }
                }
                    
                
                this.answerCome = true;
            }})
        }
    }
    _userId?:AccInfo

    likesCounter:boolean = true;
    dislikeCounter:boolean = true;

    reactionExist:boolean = false;
    answerCome:boolean = false;


    constructor(private server:ServerService){
    }
    
    likeButtonClick() {
        if(this._userId?.userType == UserType.Banned){
            console.log("banned")
            return;
        }
        if(this._userId && this.postId && this._userId.id){
            this.like()
        }
    }
    like(){
        if (this.likesCounter === true && this.dislikeCounter === true) {
            this.numberOfLikes++;
            this.likesCounter = false;
            this.sendReaction(ReactionType.Like);
        } else if (this.likesCounter === true && this.dislikeCounter === false) {
            this.numberOfLikes++;
            this.likesCounter = false;
            this.numberOfDislike--;
            this.dislikeCounter = true;
            this.sendReaction(ReactionType.Like);
        } else if (this.likesCounter === false && this.dislikeCounter === true) {
            this.numberOfLikes--;
            this.likesCounter = true;
            this.sendReaction(ReactionType.None);
        }
    }
    dislikeButtonClick() {
        if(this._userId?.userType == UserType.Banned){
            console.log("banned")
            return;
        }
        if(this._userId && this.postId && this._userId.id){
            this.dislike()
        }
    }
    dislike(){
        if (this.dislikeCounter === true && this.likesCounter === true) {
            this.numberOfDislike++;
            this.dislikeCounter = false;
            this.sendReaction(ReactionType.Dislike);
        } else if (this.dislikeCounter === true && this.likesCounter === false) {
            this.numberOfDislike++;
            this.numberOfLikes--;
            this.dislikeCounter = false;
            this.likesCounter = true;
            this.sendReaction(ReactionType.Dislike);
        } else if (this.dislikeCounter === false && this.likesCounter === true) {
            this.numberOfDislike--;
            this.dislikeCounter = true;
            this.sendReaction(ReactionType.None);
        }

    }
    private sendReaction(ReactionType:ReactionType){
        let r:Reaction = new Reaction();
        r.EntityId = this.postId!;
        r.UserId = +this._userId!.id!;
        r.Type = ReactionType;
        
        this.server.submitReaction(r).subscribe({next:(data:any)=> console.log(data)});
    }
}
