import {AfterViewInit, Component} from '@angular/core';
import {AnimationClass} from '../../../animation.class';

@Component({
  selector: 'app-mobile-app-develop',
  templateUrl: './mobile-application-development.html',
  styleUrls: [
    '../../../../assets/css/main.css',
    '../../../../assets/css/services.css'
  ]
})
export class MobileApplicationDevelopmentComponent implements AfterViewInit {
  ngAfterViewInit(): void {
    AnimationClass.animWeb();
  }
  constructor() {}
}
