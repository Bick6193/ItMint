import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    template: `<h1>Hello {{name}} test to build</h1>
<button class="btn btn-sm btn-danger">test button</button>`
})
export class AppComponent { name = 'Angular'; }


/*
Copyright 2017 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/