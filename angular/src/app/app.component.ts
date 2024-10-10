import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { MenuComponent } from "./navegacao/menu/menu.component";


@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    styles: [],
    template: `
      <app-menu></app-menu>
      <router-outlet></router-outlet>
      `,
    standalone: true,
    imports: [RouterOutlet, MenuComponent]
})
export class AppComponent {
  title = 'CliniCorpapp';
}
