import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "../auth/auth.guard";
import { LayoutComponent } from "./layout.component";

const routes: Routes = [
    {
        path:'',
        canActivate:[AuthGuard],
        component:LayoutComponent,
        children:[
            {
                path:'home',
                loadChildren: ()=> import('../home/home.module').then(h => h.HomeModule)
            }
        ]
    }
]

@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports:[RouterModule]
})
export class LayoutRoutingModule {

}