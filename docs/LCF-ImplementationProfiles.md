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

#### P00 Core LMS Profile
*(Added in v1.2.0)*

This profile defines which of the core functions by entity type need to be supported by an LMS.

| Core&nbsp;function:       | 01<br/>Retrieve/View entity instance information | 02<br/>Retrieve entity instance list | 03<br/>Create entity instance | 04<br/>Modify entity instance | 05</br>Delete entity instance|
|---------------------------|----|----|----|----|----|
| E01<br/>Manifestation     |  y |  y |    |    |    |
| E02<br/>Item              |  y |  y |    |  y |    |
| E03<br/>Patron            |  y |  y |  y |  y |  y |
| E04<br/>Location          |  y |  y |    |    |    |
| E05<br/>Loan              |  y |  y |    |    |    |
| E06<br/>Reservation       |  y |  y |  y |    |  y |
| E07<br/>Charge            |  y |  y |  y |    |    |
| E08<br/>Payment           |  y |  y |  y |    |    |
| E09<br/>Contact           |  y |  y |  y |  y |    |
| E13<br/>Authorization     |  y |  y |    |    |    |
| E14<br/>Authority/Inst.   |  y |  y |    |    |    |
| E15<br/>Message/alert     |  y |  y |    |    |    |


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
