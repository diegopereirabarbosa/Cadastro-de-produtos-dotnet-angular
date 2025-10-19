import { Routes } from '@angular/router';
import { ProductsList } from './features/products/components/products-list/products-list';
import { Dashboard } from './features/dashboard/dashboard';
import { ProductsCreate } from './features/products/components/products-create/products-create';
import { ProductsUpdate } from './features/products/components/products-update/products-update';
import { ProductResolver } from './features/products/services/product-resolver.service';

export const routes: Routes = [
    { path: '', component: Dashboard },
    { path: 'produtos', component: ProductsList },
    { path: 'produtos/cadastrar', component: ProductsCreate},
    { path: 'produtos/update/:id', component: ProductsUpdate, resolve: { product: ProductResolver }}
];
