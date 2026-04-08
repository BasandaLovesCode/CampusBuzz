import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Event } from '../models/event.model';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  // API URL - same as what we saw in Swagger
  private apiUrl = 'https://localhost:7038/api/Event';

  constructor(private http: HttpClient) { }

// Fetches all events from the API
getAllEvents(): Observable<Event[]> {
  return this.http.get<Event[]>(this.apiUrl);
}

// Fetches a single event by its ID
getEventById(id: number): Observable<Event> {
  return this.http.get<Event>(`${this.apiUrl}/${id}`);
}

// Sends a new event to the API to be saved
addEvent(campusEvent: Event): Observable<Event> {
  return this.http.post<Event>(this.apiUrl, campusEvent);
}

// Updates an existing event in the database
updateEvent(id: number, campusEvent: Event): Observable<Event> {
  return this.http.put<Event>(`${this.apiUrl}/${id}`, campusEvent);
}

// Deletes an event from the database by ID
deleteEvent(id: number): Observable<void> {
  return this.http.delete<void>(`${this.apiUrl}/${id}`);
}
}