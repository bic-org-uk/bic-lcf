---
title: LCF v1.0.2 Implementation Profiles
menu: Implementation Profiles
weight: 6
---

# Book Industry Communication

## Library Interoperability Standards

## Library Data Communication Framework for Terminal Applications (LCF)

## Implementation Profiles

### Issue 2

### DRAFT, 12 July 2018

---

### Profiles

#### P01 Self Issue

This profile has the following function groups:

* Basic check-in / check-out with standard HTTP response (no XML payload)
* Handle item security information on check-in / check-out
* Retrieve Patron-specific loan information
* Reservation-related activities (retrieve reservation information, make / cancel reservations)
* Handle payments (handle charge refs in check-in/check-out response, make payment).

|                        |       *Basic*       |      *Security*      |    *Loans*    | *Reservations* |     *Payments*    |
|------------------------|---------------------|----------------------|---------------|----------------|-------------------|
| Basic check out        |         *X*         |                      |               |                |                   |
| Check out with <br/>security |               |         *X*          |               |                |                   |
| Check out with <br/>charge |                 |                      |               |                |        *X*        |
| Basic check in         |         *X*         |                      |               |                |                   |
| Check in with <br/>security   |              |         *X*          |               |                |                   |
| Check in with <br/>charge |                  |                      |               |                |        *X*        |
| List checked-out items (loans) |             |                      |      *X*      |                |                   |
| List reserved items    |                     |                      |               |      *X*       |                   |
| Make payment           |                     |                      |               |                |        *X*        |
|------------------------|---------------------|----------------------|---------------|----------------|-------------------|

#### P02 Patron information maintenance

This profile has the following function groups:

* Maintain personal contact details
* Manage reservations
* Manage charges

|                        |       Personal      |     Reservations     |    Charges    |
|------------------------|---------------------|----------------------|---------------|
| Retrieve patron record |         *X*         |                      |               |
| Modify patron record   |         *X*         |                      |               |
| List contact records   |         *X*         |                      |               |
| Modify contact record  |         *X*         |                      |               |
| Delete contact record  |         *X*         |                      |               |
| List reserved items    |                     |          *X*         |               |
| Cancel reservation     |                     |          *X*         |               |
|------------------------|---------------------|----------------------|---------------|
