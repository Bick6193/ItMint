import {AfterViewInit, Component} from '@angular/core';
import {AnimationClass} from '../animation.class';


@Component({
    selector: 'app-about-us',
    templateUrl: './about-us.html'
})
export class AboutUsComponent implements AfterViewInit {
  ngAfterViewInit(): void {
    AnimationClass.animWeb();
    AnimationClass.animWebMap();
  }
constructor() {}
}
