import { Component } from '@angular/core';
import { Player } from 'src/app/models/player.model';
import { PlayerService } from 'src/app/services/player.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  allPlayers: Player[] | undefined;
  
  constructor(private playerService: PlayerService) {}

  showAllPlayers() {
    this.playerService.getAllPlayers().subscribe({
      next: players => this.allPlayers = players,
      error: err => console.log(err)
    });
  }
} 
