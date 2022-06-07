import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {
  constructor() { }

  ngOnInit(): void { }

  openNav(): void {
    let div = document.getElementById("sidenav") as HTMLDivElement;
    let divMain = document.getElementById("main-content") as HTMLDivElement;
    divMain.style.marginLeft = "250px"
    div.style.width = "250px";
  }

  closeNav(): void {
    let div = document.getElementById("sidenav") as HTMLDivElement;
    let divMain = document.getElementById("main-content") as HTMLDivElement;
    divMain.style.marginLeft = "0px"
    div.style.width = "0px";
  }
}
