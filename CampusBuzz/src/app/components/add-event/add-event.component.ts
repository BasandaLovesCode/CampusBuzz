import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { EventService } from '../../services/event.service';
import { Event } from '../../models/event.model';

@Component({
  selector: 'app-add-event',
  imports: [FormsModule, MatCardModule, MatButtonModule, MatInputModule],
  templateUrl: './add-event.component.html',
  styleUrl: './add-event.component.css'
})
export class AddEventComponent {

  // New event object bound to the form
  newEvent: Event = {
    eventId: 0,
    eventTitle: '',
    location: '',
    ticketPrice: ''
  };

  constructor(private eventService: EventService, private router: Router) {}

  addEvent(): void {
    this.eventService.addEvent(this.newEvent).subscribe(() => {
      // After adding, go back to event listing
      this.router.navigate(['/event-list']);
    });
  }

  cancel(): void {
    this.router.navigate(['/event-list']);
  }
}