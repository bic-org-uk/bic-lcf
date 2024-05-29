---
title: LCF Implementation Profiles Issue 3
menu: Implementation Profiles
weight: 6
---

# Book Industry Communication

## Library Interoperability Standards

## Library Data Communication Framework for Terminal Applications (LCF)

## Implementation Profiles

### Issue 3

### 16 December 2023

---

### Profiles

This document defines implementation profiles for the LCF data communication framework. 

Profiles are designed to assist terminal clients and server vendors to be confident with interoperability and consistency between system vendor implementations. The structure of the profiles is designed to show a server LMS implementation provides basic access to all LCF entities, and then ensure that end user centric services can be completed through use case structured profile definitions. 

Compliance with any given profile therefore confirms functionality is compliant with the expectations of LCF, and therefore should be compatible with any other system with compliance for that profile. 

The use of this document is subject to license terms and conditions that can be found *at* <http://www.bic.org.uk/resources/license-to-use-bic-standards/>.

#### P01 Core LMS Profile

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
- E16 LCF Version

#### P02 Patron Membership

Demonstrate the process of self sign-up to the library services, through creating a new Patron entity, including Contact information. Complete the lifecycle demonstration by deleting the Patron.

* Create a new Patron entity, demonstrate joining the library.
* Delete a Patron entity, demonstrating leaving the library. It is assumed that all Contact entities will be automatically deleted, and that all Charges and Loans have been previously processed. 


#### P03 Patron Account

The Patron Account Information profile is designed to show a terminal client and server are able to perform effectively to empower the display of the information relating to a Patron's interaction with the library. A typical usecase would be a terminal client showing a Patron their list of active and/or overdue Loans as the Patron started to use the terminal client.

* Read a Patron entity
* Show active Loans for a Patron, including the Title, Author and due date for any Loan. 
* Show active Reservations for a Patron, including the Title, Author and reservation queue position for any Reservation.
* Show outstanding debt for a Patron, breaking down into individual oustanding Charges.
* Show a Message targetting for a Patron. 

#### P04 Patron Contact Details

As a Patron, when I review my details of my Patron record, enable me to update existing information and provide new information where details are absent. 

* Authenticate Patron
* Trigger a Forgotten PIN/password process?
* Read a Patron entity
* Show the Patron Contact details
* Create a new Contact detail for a Patron
* Update an existing Contact for a Patron
* Delete an existing Contact for a Patron

#### P05 Patron Groups

Display and enable amendment of the associated group membership for a Patron. 

* Add a Patron to a Patron Group
* Display the Patron Group
* Remove a Patron from a Patron Group

#### P06 Circualation

The Circulation profile covers the library behaviour to:

* Issue/check-out an Item to a Patron
* Renew an Item on loan to a Patron
* Return/check-in an Item from a Patron, ending the Loan. 
* TBC: Overdue Fines - fit here?

#### P07 Reservations

The Reservation profile covers behaviour where a Patron is unable to take immedate loan of an Item, and therefore places a Reservation (a.k.a Hold) on the Item, allowing them to await their turn to Loan the Item. 

* Create a Reservation of an Item or Manifestation for a Patron
* Update a Reservation for an Item or Manifestation for a Patron.
* Cancel a Reservation for an Item or Manifestation for a Patron.
* Issue a Reserved Item to the reserving Patron.

#### P08 Patron Debt Management

The Patron Debt Managent profile relates to the accruing of Fines, Fees and Charges, including the request to create a Charge my the terminal client, and the subsequent ability to inform the LMS/ILS that the payment has been made. 

* Create a Charge for a Paton.
* List the Charges for a Patron.
* Record the Payment of a Charge.
* Create Credit for a Patron. 
* Record the Payment of a Charge from Patron Credit.
* Waive a Charge for a Patron.
* Update an existing Charge.

#### P09 Cataloguing

Enable a terminal service client to assist with cataloguing behaviour of the LMS/ILS.

* Create an Item for an existing Manifestation
* Update an existing Item

#### P10 Library Configuration

* Create/Update a Location
* Create/Update an Authorisation
* Create/Update an Authority/institution
* Create/Update/Delete a Message
