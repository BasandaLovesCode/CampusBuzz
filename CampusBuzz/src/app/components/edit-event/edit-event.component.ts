import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { EventService } from '../../services/event.service';
import { Event } from '../../models/event.model';

@Component({
  selector: 'app-edit-event',
  imports: [FormsModule, MatCardModule, MatButtonModule, MatInputModule],
  templateUrl: './edit-event.component.html',
  styleUrl: './edit-event.component.css'
})
export class EditEventComponent implements OnInit {

  // Object to hold the event being edited
  campusEvent: Event = {
    eventId: 0,
    eventTitle: '',
    location: '',
    ticketPrice: ''
  };

  constructor(
    private eventService: EventService,
    private route: ActivatedRoute, // to get the ID from the URL
    private router: Router
  ) {}

  ngOnInit(): void {
    // Get the ID from the URL - same pattern as slides' game-details
    const id = this.route.snapshot.paramMap.get('id');
    this.eventService.getEventById(Number(id)).subscribe(data => {
      this.campusEvent = data;
    });
  }

  updateEvent(): void {
    this.eventService.updateEvent(this.campusEvent.eventId, this.campusEvent)
      .subscribe(() => {
        this.router.navigate(['/event-list']);
      });
  }

  cancel(): void {
    this.router.navigate(['/event-list']);
  }
}