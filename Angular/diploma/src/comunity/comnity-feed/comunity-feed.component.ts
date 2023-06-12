import { Component,Input } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { AccInfo } from 'src/models/AccInfo';
import { Post } from 'src/models/Comunity/Post';
import { SortingType } from 'src/models/Comunity/SortingType';
import { ServerService } from 'src/servisec/server';
import { AccountSingleton } from 'src/singleton/AccountSingleton';

@Component({
    selector: 'comunity-feed',
    templateUrl: './comunity-feed.component.html',
    styleUrls: ['./comunity-feed.component.css']
})
export class ComunityFeedComponent {
    posts:Post[] = []
    isFeed:boolean = true;
    constructor(private server:ServerService,private route: ActivatedRoute,private router:Router){
        this.ChoosePost();
        
        router.events.subscribe((val) => {
            if (val instanceof NavigationEnd) {
                
                if(!this.searchHasHappendAndNotComingYet)
                    this.ChoosePost()
            }
            
        })
    }
    ChoosePost(){
        this.searchHasHappendAndNotComingYet = true;
        let sort:SortingType = this.route.snapshot.queryParams['sort'];
        let search:string = this.route.snapshot.queryParams['search'];
        if(!sort) sort = SortingType.Common;
        if(!search)search = "";

        this.loadPosts(sort,search)
    }
    searchHasHappendAndNotComingYet:boolean = false;
    currentPost!:Post;
    
    goToPost(post:Post){
        this.router.navigate(
            [`comunity/post`,post.id]
        )
    }
    goToFeed(){
        this.loadPosts(SortingType.Common,"")
    }
    loadPosts(sort:SortingType,search:string){
        this.server.getPosts(sort,search).subscribe({next:(data:any) => {this.posts = data; console.log(this.posts); this.searchHasHappendAndNotComingYet = false}});
    }
    
}
