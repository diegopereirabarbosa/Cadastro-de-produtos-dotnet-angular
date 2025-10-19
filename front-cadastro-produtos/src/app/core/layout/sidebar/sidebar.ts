import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

interface MenuItem {
  title: string;
  icon?: string;
  expanded?: boolean;
  route?: string;
  children?: { title: string; route?: string }[];
}

@Component({
  standalone: true,
  selector: 'app-sidebar',
  imports: [CommonModule, RouterModule],
  templateUrl: './sidebar.html',
  styleUrls: ['./sidebar.css'], // corrigido
})
export class Sidebar {
  isSidebarOpen = false;

  menuItems: MenuItem[] = [
    { title: '🏠 Início', icon: 'home', route: '/' },
    {
      title: '📦 Produtos',
      expanded: false,
      children: [
        { title: 'Lista de Produtos', route: '/produtos' },
        { title: 'Cadastrar Produto', route: '/produtos/cadastrar' },
      ],
    },
    {
      title: '👥 Usuários',
      expanded: false,
      children: [
        { title: 'Lista de Usuários', route: '/usuarios' },
        { title: 'Novo Usuário', route: '/usuarios/novo' },
      ],
    },
    { title: '⚙️ Configurações', route: '/configuracoes' },
  ];

  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }

  toggleSubmenu(item: MenuItem) {
    // fecha outros submenus
    this.menuItems.forEach(i => {
      if (i !== item && i.children) i.expanded = false;
    });
    // alterna o submenu clicado
    item.expanded = !item.expanded;
  }
}
