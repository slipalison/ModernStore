import { ModuleWithProviders } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'

import { HomePageComponent } from './pages/home-page/home-page.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { SingupPageComponent } from './pages/singup-page/singup-page.component';
import { CartPageComponent } from './pages/cart-page/cart-page.component';

const appRoutes: Routes = [
    { path: '', component: LoginPageComponent },
    { path: 'home', component: HomePageComponent },
    { path: 'cart', component: CartPageComponent },
    { path: 'singup', component: SingupPageComponent }
];

export const RoutingProviders:any[]=[];
export const Routing : ModuleWithProviders = RouterModule.forRoot(appRoutes);