import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "../auth/auth.guard";
import { LayoutComponent } from "./layout.component";

const routes: Routes = [
    {
        path: '',
        canActivate: [AuthGuard],
        component: LayoutComponent,
        children: [
            {
                path: 'home',
                loadChildren: () => import('../home/home.module').then(h => h.HomeModule)
            },
            {
                path: 'settings',
                loadChildren: () => import('../settings/settings.module').then(s => s.SettingsModule)
            },
            {
                path: 'teachers',
                loadChildren: () => import('../teachers/teachers.module').then(t => t.TeachersModule)
            },
            {
                path: 'students',
                loadChildren: () => import('../students/students.module').then(s => s.StudentsModule)
            }
        ]
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LayoutRoutingModule {

}