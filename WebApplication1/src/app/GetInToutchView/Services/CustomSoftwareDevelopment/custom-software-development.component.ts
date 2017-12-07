import {AfterViewInit, Component} from '@angular/core';
import {AnimationClass} from '../../../animation.class';

@Component({
  selector: 'app-custom-soft-develop',
  templateUrl: './custom-software-development.html',
  styleUrls: [
    '../../../../assets/css/main.css',
    '../../../../assets/css/services.css'
  ]
})
export class CustomSoftwareDevelopmentComponent implements AfterViewInit {
  ngAfterViewInit(): void {
    AnimationClass.animWeb();
  }
  constructor() {}
}
