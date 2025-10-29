import { Injectable } from '@angular/core';
import Swal, { SweetAlertIcon } from 'sweetalert2';

@Injectable({ providedIn: 'root' })
export class AlertService {

  // Mensagem simples
  show(message: string, title: string = 'Atenção', icon: SweetAlertIcon = 'info') {
    Swal.fire(title, message, icon);
  }

  // Sucesso
  success(message: string, title: string = 'Sucesso') {
    Swal.fire(title, message, 'success');
  }

  // Erro
  error(message: any, title: string = 'Erro') {
    const erros = message.error?.erros;
    const mensagemGeral = message.error?.mensagem;

    if (erros) {
      const mensagens: string[] = [];

      for (const campo in erros) {
        if (erros.hasOwnProperty(campo)) {
          mensagens.push(...erros[campo]);
        }
      }

      Swal.fire({
        icon: 'error',
        title: title,
        html: `
        <p>${mensagemGeral}</p>
        <ul style="list-style:none; padding:0; margin-top:10px;">
          ${mensagens.map(m => `<li>• ${m}</li>`).join('')}
        </ul>
      `,
        confirmButtonColor: '#dc2626'
      });
    } else {
      Swal.fire({
        icon: 'error',
        title: title,
        text: mensagemGeral || 'Ocorreu um erro inesperado. Tente novamente.',
        confirmButtonColor: '#dc2626'
      });
    }
  }

  // Confirmação com callback
  confirm(message: string, title: string = 'Confirmação'): Promise<boolean> {
    return Swal.fire({
      title,
      text: message,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#2563eb',
      cancelButtonColor: '#dc2626',
      confirmButtonText: 'Sim',
      cancelButtonText: 'Não'
    }).then(result => result.isConfirmed);
  }
}