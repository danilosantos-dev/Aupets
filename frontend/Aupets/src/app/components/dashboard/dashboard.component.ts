import { Component } from '@angular/core';
import { Chart, registerables } from 'node_modules/chart.js';
Chart.register(...registerables);
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

  ngOnInit(){
    this.RenderChart();
  }

  RenderChart(){
    new Chart("myChart", {
      type: 'line',
      data: {
        labels: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        datasets: [{
          label: 'Numero de visualizações',
          data: [0, 2, 1, 3, 5, 10],
          borderWidth: 3,
          borderColor: 'rgb(255,255,255)',


        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });

    new Chart("chart-line", {
      type: 'bar',
      data: {
        labels: ['Seg', 'Ter', 'Quar', 'Quin', 'Sex', 'Sab', 'Dom'],
        datasets: [{
          label: 'Numero de acessos',
          data: [1, 1, 3, 5, 4, 6, 3],
          borderWidth: 3,
          borderColor: 'rgb(255,255,255)',
          barPercentage: 0.07,
          borderRadius: 5


        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });
  }
}
