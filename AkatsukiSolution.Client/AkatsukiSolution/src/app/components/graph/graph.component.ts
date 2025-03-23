import { Component, Input, SimpleChanges } from '@angular/core';
import { Chart, CategoryScale, LinearScale, BarElement, Title, Tooltip, Legend, BarController } from 'chart.js';
import { TotalProjectTime } from 'src/app/models/totalProjectTime';

Chart.register(CategoryScale, LinearScale, BarElement, Title, Tooltip, Legend, BarController);

@Component({
  selector: 'app-graph',
  templateUrl: './graph.component.html',
  styleUrls: ['./graph.component.scss']
})
export class GraphComponent {

  @Input() projects: TotalProjectTime[] = []

  chart: any;

  ngOnInit(): void {
    this.createChart();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['projects']) {
      if (this.chart) {
        this.chart.destroy();
      }

      this.createChart();
    }
  }

  createChart() {
    const projectNames = this.projects?.map(p => p.projectName);
    const totalHours = this.projects?.map(p => p.totalHours);

    this.chart = new Chart('projectHoursChart', {
      type: 'bar', 
      data: {
        labels: projectNames, 
        datasets: [{
          label: 'Ukupno sati po projektu',
          data: totalHours, 
          backgroundColor: '#4CAF50',  
          borderColor: '#388E3C',  
          borderWidth: 1
        }]
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });
  }
}
