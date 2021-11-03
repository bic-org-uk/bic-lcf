---
title: LCF vx.x.0 Implementation Profiles
menu: Implementation Profiles
weight: 6
---

# Book Industry Communication

## Library Interoperability Standards

## Library Data Communication Framework for Terminal Applications (LCF)

## Implementation Profiles

### Issue 3

### Publication date to be determined

---

### Profiles

This document defines implementation profiles for the LCF data communication framework.

The use of this document is subject to license terms and conditions that can be found *at* <http://www.bic.org.uk/files/bicstandardslicence.pdf>.

#### P00 Core LMS Profile
*(Added in Issue 2, substantially revised in Issue 3)*

This profile defines which of the LCF core functions by entity type need to be supported by an LMS that implements LCF. As a minimum, an LMS must support all retrieval functions, to allow an authorised terminal, operated by an authorised user, to retrieve specific entities and lists of entities of all the specified types.

The core functions that must be supported are:

- 01 Retrieve entity instance information
- 02 Retrieve entity instance list

The following function elements in requests must be supported: Q01D01, Q01D02, Q02D01.

The following function elements in responses must be supported: R01C01, R02D01, _either_ R02D06 _or_ R02C07 _or both_.

Using these core functions it must be possible for authorised users to operate authorised terminals to retrieve instances and lists for each of the following entity types:

- E01 Manifestation
- E02 Item
- E03 Patron
- E04 Location
- E05 Loan
- E06 Reservation
- E07 Charge
- E08 Payment
- E09 Contact
- E13 Authorisation
- E14 Authority/institution
- E15 Message/alert

#### P01 Self Issue 
*(Substantially revised in Issue 3)*

Implementation of this profile involves implementation of one or more of the following four function groups: 

**P01.1**: Basic self-issue, including check-out, renewal and check-in.
**P01.2**: Reservations, including making reservations
**P01.3**: Payments, including the ability of the terminal user to make payments and of the server to accept payments.

*P01.1 Basic self-issue*

In addition to the core functions specified in Profile P00, the following functions must be supported:

- 11 Check-out/renewal
- 12 Check-in

*P01.2 Reservations*

In addition to the core functions specified in Profile P00, the following function must also be supported:

- 16 Reserve manifestation / item

*P01.3 Payments*

In addition to the core functions specified in Profile P00, the following function must also be supported:

- 13 Patron payment

#### P02 Record management 
*(Substantially revised in Issue 3)*

Implementation of this profile involves implementation of one or more of the following five function groups: 

**P02.1**: Maintain patron contact details, involving the creation, modification or deletion of Contact records and possible consequential modification of the associated Patron record.
**P02.2**: Patron cancellation of library membership, involving the consequential modification or deletion of Patron records and any associated Contact and Reservation records; it is assumed that all Charges would have been paid and all Items on Loan would have been checked in.
**P02.3**: Manage loans, involving the creation, modification or deletion of Loan records and possible consequential modification of Item, Patron and Charge records.
**P02.4**: Manage reservations, involving the creation, modification or deletion of Reservation records and possible consequential modification of Item, Patron and Charge records.
**P02.5**: Manage charges, involving the creation, modification or deletion of Charge records and possible consequential modification of Item, Patron, Loan and Reservation records.

*P02.1 Maintain patron contact details*

In addition to the core functions specified in Profile P00, the following functions must be supported for the specified entity types:

- 03 Create new entity, to add a new contact, for entity type E09 Contact
- 04 Modify existing entity, to change contact details, for entity type E09 Contact
- 04 Modify existing entity, to add or delete contact references,, for entity type E03 Patron
- 05 Delete entity, to remove an existing contact, for entity type E09 Contact

*P02.2 Patron cancellation of library membership

In addition to the core functions specified in Profile P00, the following functions must be supported for the specified entity types:

- 04 Modify existing entity, to change patron status, for entity type E03 Patron
- 04 Modify existing entity, to remove any references to this patron, for entity types E02 Item and E05 Loan
- 05 Delete entity, for entity type E09 Contact

*P02.3 Manage loans*

In addition to the core functions specified in Profile P00, the following functions must be supported for the specified entity types:

- 03 Create new entity, to create a new loan, for entity type E05 Loan
- 04 Modify existing entity, to change loan details, for entity type E05 Loan
- 04 Modify existing entity, to change charge details associated with a loan, for entity type E07 Charge
- 04 Modify existing entity, to add or remove references to a loan for entity types E02 Item, E03 Patron and E07 Charge
- 05 Delete entity, for entity type E05 Loan

*P02.4 Manage reservations*

In addition to the core functions specified in Profile P00, the following functions must be supported for the specified entity types:

- 03 Create new entity, to create a new reservation, for entity type E06 Reservation
- 04 Modify existing entity, to change reservation details, for entity type E06 Reservation
- 04 Modify existing entity, to change charge details associated with a reservation, for entity type E07 Charge
- 04 Modify existing entity, to add or remove references to a reservation for entity types E02 Item, E03 Patron and E07 Charge
- 05 Delete entity, for entity type E06 Reservation

*P02.5 Manage charges*

In addition to the core functions specified in Profile P00, the following functions must be supported for the specified entity types:

- 03 Create new entity, to create a new reservation, for entity type E07 Charge
- 04 Modify existing entity, to change charge details, for entity type E07 Charge
- 04 Modify existing entity, to add or remove references to a charge for entity types E02 Item, E03 Patron, E05 Loan and E06 Reservation
- 05 Delete entity, for entity type E07 Charge
