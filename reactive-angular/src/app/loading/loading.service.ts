import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";

@Injectable()
export class loadingservice
{
    private loadingsuject = new BehaviorSubject<boolean>(false);

    loading$ : Observable<boolean> = this.loadingsuject.asObservable();
        
    showloadinguntillcomplted()
    {
        
    }

    loadingon()
    {
        this.loadingsuject.next(true);
    }
    loadingoff()
    {
        this.loadingsuject.next(false);
    }
}