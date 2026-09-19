# holiday-home-rental-system

A desktop booking system for holiday properties, built in C# with an Oracle
database. Developed as an academic project at Munster Technological University,
Kerry.

The project was built requirements-first: I wrote the full specification -
use cases, data flow diagrams and the database schema — and then implemented
the system against it. The specification is in `/pdf`.

## Features

- User registration and login with role-based access
- Property listings: owners can add and edit their properties
- Availability management by date
- Booking and cancellation, handled as database transactions so two users
  cannot book the same dates
- Admin screens for managing accounts
- Reporting screens showing bookings and revenue

## Built with

- C# (.NET Framework 4.7.2), Windows Forms
- Oracle Database, accessed through ODP.NET
- Visual Studio

## Database

Four related tables with sequences for primary keys. The schema diagram and
normalisation notes are in the specification document.

## Documentation

`/pdf` contains the requirements specification: use cases, data flow
diagrams and the database design.

## Author

Anastasiia Tkachenko - BSc (Hons) Computing, MTU Kerry
