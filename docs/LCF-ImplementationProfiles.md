---
title: LCF v1.2.0 Implementation Profiles
menu: Implementation Profiles
weight: 6
---

# Book Industry Communication

## Library Interoperability Standards

## Library Data Communication Framework for Terminal Applications (LCF)

## Implementation Profiles

### Issue 2

### DRAFT

---

### Profiles

This document defines implementation profiles for the LCF data communication framework.

The use of this document is subject to license terms and conditions that can be found *at* <http://www.bic.org.uk/files/bicstandardslicence.pdf>.

#### P01 Self Service Kiosk

Scenario 1 - Getting current loans for a patron, whether they are overdue and the renewal details

| Information Required by LMS | Information Required by Kiosk |
| --- | ---  |
| Patron,  Authentication Token | For each loan: name of item, type of item, due date, fees owing |


Scenario 2 - Getting all current reservation information

| Information Required by LMS | Information Required by Kiosk |
| --- | ---  |
| Patron,  Authentication Token | name of item, type of item, pick up location, pickup date, reservation charge |


Scenario 3 - Getting the overall money a Patron owes, and how much is currently payable

| Information Required by LMS | Information Required by Kiosk |
| --- | ---  |
| Patron,  Authentication Token | total outstanding, what is payable |


Scenario 4 - Charge details for all outstanding charges tied to the patrons account

| Information Required by LMS | Information Required by Kiosk |
| --- | ---  |
| Patron,  Authentication Token | for each charge: name of item, type of item, original due date, fees owning, is payable (i.e. returned or still on loan |


Scenario 5 - Paying for outstanding charges

| Information Required by LMS | Information Required by Kiosk |
| --- | ---  |
| Patron,  Authentication Token, amount paid, optionally specific charge | confirmation   |


Scenario 6 - Making a loan

| Information Required by LMS | Information Required by Kiosk |
| --- | ---  |
| Patron, Item,  Authentication Token | charge, due date, start date |

Scenario 7 - Making a renewal

| Information Required by LMS | Information Required by Kiosk |
| --- | ---  |
| Patron, Item,  Authentication Token | charge, due date, start date |


Scenario 8 – Post Check out information?

| Information Required by LMS | Information Required by Kiosk |
| --- | ---  |
| Patron, Item,  Authentication Token | charge, due date, start date |


Scenario 9 – How to return items?

| Information Required by LMS | Information Required by Kiosk |
| --- | ---  |
| Patron, Item,  Authentication Token | charge, return location\bin |


* error and reasons when failed






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
