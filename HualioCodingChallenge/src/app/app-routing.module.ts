import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SiteLayoutComponent } from './components/layout/site-layout/site-layout.component';
const routes: Routes = [
      {
        path: '', 
        component: SiteLayoutComponent,
        children: [
          {
            path:'home',
            loadChildren: () => import('./components/home/home.module').then(m => m.default)
          },
          {
            path:'products',
            loadChildren: () => import('./components/products/products.module').then(m => m.default)
          }
        ]
      },
      {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
      }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
