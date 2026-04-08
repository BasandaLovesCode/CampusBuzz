import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { EventService } from '../../services/event.service';
import { Event } from '../../models/event.model';
import { NgFor } from '@angular/common';


@Component({
  selector: 'app-event-list',
  imports: [RouterModule, MatCardModule, MatButtonModule, NgFor],
  templateUrl: './event-list.component.html',
  styleUrl: './event-list.component.css'
})
export class EventListComponent implements OnInit {

  // Array to store events from API - same pattern as slides' games:Game[]=[]
  events: Event[] = [];

  constructor(private eventService: EventService) {}

  ngOnInit(): void {
    // Call service to get all events when component loads
    this.loadEvents();
  }


  loadEvents(): void {
    this.eventService.getAllEvents().subscribe(data => {
      // Reverse the array so newest event appears first
      this.events = data.reverse();
    });
  }

  deleteEvent(id: number): void {
    this.eventService.deleteEvent(id).subscribe(() => {
      // After deleting, reload the list
      this.loadEvents();
    });
  }
}