import { Routes } from '@angular/router';
import { EventListComponent } from './components/event-list/event-list.component';
import { AddEventComponent } from './components/add-event/add-event.component';
import { EditEventComponent } from './components/edit-event/edit-event.component';

export const routes: Routes = [
  { path: '', redirectTo: '/event-list', pathMatch: 'full' }, // default page
  { path: 'event-list', component: EventListComponent },      // event listing page
  { path: 'add-event', component: AddEventComponent },        // add event page
  { path: 'edit-event/:id', component: EditEventComponent }   // edit event page with id
];
