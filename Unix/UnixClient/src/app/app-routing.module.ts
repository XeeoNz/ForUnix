import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AutoCreateComponent } from './auto-create/auto-create.component';
import { AutoDetailsComponent } from './auto-details/auto-details.component';
import { AutoEditComponent } from './auto-edit/auto-edit.component';
import { AutokComponent } from './autok/autok.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', component: AutokComponent },
  { path: 'autok/:id', component: AutoDetailsComponent },
  { path: 'autok/create/new', component: AutoCreateComponent },
  { path: 'autok/edit/:id', component: AutoEditComponent },
  { path: 'autok', redirectTo: '' },
  { path: '**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
