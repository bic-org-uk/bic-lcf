---
title: LCF Profiles Validation Issue 3
menu: Implementation Profiles
weight: 6
---

# Book Industry Communication

## Library Interoperability Standards

## Library Communication Framework for Terminal Applications (LCF)

## Implementation Profile Validation

LCF has multiple operational profiles described at [LCF-ImplementationProfiles.md](LCF-ImplementationProfiles.md).
Each profile describes a specific set of behaviours expected from LCF Client and Server interactions. The validation of these implementation profiles ensures that any client will work with any server provided both have been validated to the same compliance profile. 
Any validation process must be able to confirm both the client operation and the server operation to ensure that both halves of the equation can be confirmed. This also implies an internal self-check, where the LCF client validator works consistently with the LCF server validator, and both achieve positive certification when operating together.

To provide effective LCF validation, a validation process for both the client and the server must be provided. These validators should be provided in a method that empowers use by LCF Consortium members. 

The responsibilities of the Validation Client and Server are as below:

![image](https://github.com/bic-org-uk/bic-lcf/assets/6545701/53a7fcd6-8ead-4f16-b60b-7c77e9725e04)

Incumbent with the profile validation is the duty to determine whether the request and responses with the LCF standard have been understood. For example, whether the response to an LCF get instance list has been understood by the caller. The validation process must include steps to provide the confidence that responses have been correctly processed. 

## Implementation Proposal
Provide two services:
1.	A mock server implementation that provides the LCF REST API endpoint, plus an overlay to provide the validation service controls and output. This implementation must be aware of when a test for a specific profile is starting, has ended, and report on the outcome. 

2.	A mock client implementation, driving the LCF REST API endpoint with specific behaviours.  This implementation must be able to trigger the start of a specific profile test, drive the REST API calls to fulfil the test, trigger the end of the profile test, and report on the outcome. 

## Test Management
### Server Implemenetation
To enable the server to trace the client's behaviour during profile validation, the server must understand where the client is within the validation process. This will require a method of communication with the server to inform it of the state of the test. Given that all REST service implementations are stateless, this behaviour must be provided outside of the normal operation of the service.

The proposal is to provide a simple Web UI and underlying API as part of the server implementation. The Web UI presents a simple human user interface enabling the user to select which profile is under test, activate the test, complete the test and view the outcome. The API underpinning the Web UI enables the same behaviour, enabling automation of the test cycle process if required by LCF Consortium members. This is in line with modern CI/CD pipeline creation. 

### Client Implementation
There are multiple existing client solutions which enable the integration testing of Web APIs. Postman is widely accepted as an industry standard for API validation and is available as a SaaS implementation, requiring no locally installed software. This does however introduce a limitation, where the LCF Server deployment under test must be available to the public internet. 

Alternate client side implementations, such as Apache jMeter, also enable the functional testing of a Web API and do require a locally installed agent. This would not require the LCF Server deployment under test to be available to the public internet. 

Both options will enable the execution, testing and validation of LCF Server API reponses and only require the creation of a test script within the tool to be executed. 

# Profile Validation Strategies

## Profile P00 - Basic Service Interaction

1. E16 LCF Version Check
2. Authentication

### E16 LCF VERSION
The E16 VERSION entity, added in LCF 1.4.x follows the pattern for a Entity List response however it will return the Entity representing the running version of the LCF implementation. There is therefore no requirement to iterate for this Entity, but only perform and act upon the VERSION described. 

1. Perform a GET request against the ``/lcf/version`` entity.
For LCF v1.4.x and higher, the LCF implementation responds with a code 200 and a valid LCF Version payload.
For LCF v1.3.x and lower, the LCF Version service did not exist. An HTTP code 404 response is expected. 
2. Confirm the expected HTTP response code and payload.

### Authentication
Core to all operations with LCF is terminal service and patron authentication, discussed [here](LCF-RESTWebServiceSpecification.md#implementation-notes)

This sets out the structure for:
* a terminal client authenticating against an LCF endpoint representing itself;
* a terminal client authenticating against an LCF endpoint impersonating a Patron;
* determining whether authentication is required; and
* determine whether patron authorisation is required.

The existing standard (1.3) allows for variation in how these four items are implemented, specifically, it does not mandate which authentication and authorisation is required for any LCF entity. This enables implementors of LCF to have the flexibility to define their system as they see fit, however also presents complexity for defining profile compliance. 

It is therefore intended to define profile compliance, including an implementation where authentication and authorisation will be flexible. However, this will increase the complexity of the profile validation solution. Market research also suggests that real-world implementations may have a more common strategy. If this proves true, this section of compliance validation could be simplified through standardisation. 

## Profile P01 - Core LMS Behaviour

### Minimum interaction for each entity type
To determine minimum interaction with the primary LCF entities, the system should be able to perform the client or server behaviour to iterate over the available values for each of the following entities:

* E01 Manifestation
* E02 Item
* E03 Patron
* E04 Location
* E05 Loan
* E06 Reservation
* E07 Charge
* E08 Payment
* E09 Contact
* E13 Authorisation
* E14 Authority/institution
* E15 Message/alert

Iterating over these entity types will require the following steps for each entity:

1. Perform an Entity List Request
2. Perform a GET request for each EntityRef in the response.
3. Perform an Entity List Request for the next page of results. 

## Profile P02 - Patron Membership
This scenario focusses on creating a new Patron for the library, where a new person joins the library to make use of their services. The second part of the vaildation is requesting to leave the library, by deleting the Patron which was just created. 

#### P02.1 Create Patron
1. Perform a POST to ``/lcf/patron`` containing a valid terminal client credential, and payload representing a valid Patron entity. 
2. Confirm an HTTP/200 successful response. 
3. Extract the ``identifier`` (field E03D01) from the response for use in the DELETE request. 
4. Perform a GET against the URI ``/lcf/patrons/{identifier}`` and confirm that the provided fields from step 1 match the response. 
5. Confirm that there are zero loans, reservations, or charges against the Patron. 

#### P02.2 Delete Patron

1. Perform a DELETE to ``/lcf/patrons/{identifier}``
2. Confirm an HTTP/200 successful response. 
3. Perform a GET against the URI /lcf/patrons/{identifier} and confirm an HTTP/404 response with no data within the payload. 

## Profile P03 - Patron Account

Retrieve all the required information about a Patron and their current interactions with the Library to be able to show a summary of their position. This should include a list of any on loan items (including the Title and Author), a list of any outstanding charges, and a list of all active reservations (including title and author).

1. Perform a GET to ``/lcf/patrons``
2. Perform a GET against the first ``entity-ref`` containing a URI for a Patron
3. Confirm an HTTP/200 successful response
4. Iterate through each ``contact-ref`` for Contacts
    1. Confirm that the Patron entity data contains ``contact-ref`` URIs for Contacts
    2. Perform a GET to each Contact ``contact-ref``.

5. Iterate through each ``authorisation-ref`` for Patron Authorisations
    1. Perform a GET to each Authorisation ``authorisation-ref``
    2. Confirm the Authorisations are valid. 

6. Iterate through each ``loan-ref`` for Loans
    1. Confirm that the Patron entity data contains ``loan-ref`` URIs for multiple Loans
    2. Perform a GET to each Loan ``loan-ref``
    3. Perform a GET to the ``item-ref`` within the Loan
    4. Perform a GET to the ``manifestation-ref`` within the Item
    5. Extract the Title and Author for the Manifestation.

7. Iterate through each ``reservation-ref`` for Reservations
    1. Perform a GET to each Reservation ``reservation-ref``
    2. Perform a GET to the ``manifestation-ref`` within the Item
    3. Extract the Title and Author for the Manifestation.

8. Iterate through each ``charge-ref`` for Charges
    1. Perform a GET to each Charge ``charge-ref``

## Profile P04 - Patron Contact Details
This profile aims to ensure that the LCF implementation can update Contact details for a Patron in real time. This enables self-service use to maintain Patron details.

1. Perform a GET to ``/lcf/patrons``
2. Perform a GET against the first ``entity-ref`` containing a URI for a Patron
3. Confirm an HTTP/200 successful response
4. Iterate through each ``contact-ref`` for Contacts
    1. Confirm that the Patron entity data contains ``contact-ref`` URIs for Contacts
    2. Perform a GET for each Contact ``contact-ref``.
    3. Update the Contact entity with different contact details. 
    4. Perform a PUT to the Contact ``contact-ref`` with the modified Contact as the payload. 
    5. Confirm a successful response
5. Perform a GET agains the first ``entity-ref`` containing a URI for a Patron (as per step 2)
6. Iterate through each ``contact-ref`` for Contacts
    1. Perform a GET for each Contact ``contact-ref``
    2. Confirm that the Contact record contains the modified information from step 4.3.

## Profile P05 - Patron Groups
This profile aims to ensure that the LCF implementation can group Patron records together in a Patron Group, enabling the lead patron to perform transactions on behalf of all others within the group. 

The key principle behind a Patron Group is to model structures between Patrons, such as a family with one or more parents and/or children. The role of the "lead patron" means a patron permitted to perform any action on behalf of any member of the group. For example, be able to view the loans for all other Patrons in the group, or view all the charges for all other Patrons in the group. See https://github.com/bic-org-uk/bic-lcf/issues/54#issuecomment-386060669.

1. Using the same steps from P02.1, create two Patron entities, Patron#1 and Patron#2.
2. Update Patron#1, populating the E03C33 composite entity to show Patron#1 as the lead group member (PGP02).
4. Update Patron#2, populating the E03C33 composite entity to show Patron#2 as a member of the group (PGP01).
5. Confirm Patron#1 can view the loans and charges of Patron#2.

## Profile P06 - Circulation

## Profile P07 - Reservations

## Profile P08 - Patron Debt Management

## Profile P09 - Cataloguing

## Profile P10 - Library Configuration




