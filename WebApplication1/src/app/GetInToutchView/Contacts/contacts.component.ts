import {Component, ViewEncapsulation} from '@angular/core';

@Component({
  selector: 'contacts',
  templateUrl: './contacts.html',
  styleUrls: ['../../../assets/css/main.css',
    '../../../assets/css/services.css'],
  encapsulation: ViewEncapsulation.None
})
export class ContactsComponent {
  constructor() {}
}
