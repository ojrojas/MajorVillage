import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {

  showMenu = false;

  constructor() { }

  ngOnInit(): void { }

  toggleMenu = () => {
    alert("This show ? " + !this.showMenu);
    this.showMenu =  !this.showMenu;
    return this.showMenu;
    
  }
}
