import {AfterViewInit, Component} from '@angular/core';
import {AnimationClass} from '../../animation.class';


@Component({
    selector: 'app-about-us',
    templateUrl: './about-us.html',
  styleUrls: [
    '../../../assets/css/main.css',
    '../../../assets/css/services.css'
  ]
})
export class AboutUsComponent implements AfterViewInit {
  ngAfterViewInit(): void {
    AnimationClass.animWeb();
    AnimationClass.animWebMap();
  }
constructor() {}
}
