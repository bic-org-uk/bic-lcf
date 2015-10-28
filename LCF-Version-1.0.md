***Book Industry Communication***

**Library Interoperability Standards**

**Library Data Communication Framework for Terminal Applications (LCF)**[1]

Version 1.0, 10 January 2014

This document defines data frameworks for messages to meet the data communication requirements of a standard set of business functions for terminal applications within libraries.

The use of this document is subject to license terms and conditions that can be found at <http://www.bic.org.uk/files/bicstandardslicence.pdf>.

Terminal applications typically involve the use of terminal devices and systems by library staff and patrons to carry out a range of business functions that involve data communication between a user terminal and a Library Management System (LMS). The user terminal communicates with the LMS to request that a specific function be executed. Execution of the function will normally involve retrieval of or changes to information held in the LMS. The LMS will respond to the request in a variety of ways, depending upon the nature of the request. Terminal applications include self-service applications used by library patrons, as well as other applications used by library staff.

The standard business functions defined by this document are applicable both in circulation management and in stock / holdings management. User terminals may implement any reasonable subset of the functions defined by this document in either of these areas of application, or in others.

Each function is defined in terms of a pair of messages exchanged between the user terminal and the LMS. In terms of the client-server model for system architectures, the user terminal and LMS respectively take the roles of “client” and “server”. In the execution of each function the user terminal issues a request to the LMS and receives a response in return.

The information that these functions retrieve or change related to a number of "entities" that are fundamental to library management. The principal entities involved are:

-   manifestations (titles) in a library's catalogues

-   items – individual copies of manifestations – in a library's stock / holdings

-   patrons – users entitled to borrow items from a library

-   locations – where items may be located, usually inside a library; or the "home" location of a patron

-   loans – of items to patrons

-   reservations – of manifestations or specific copies of manifestations for patrons

-   charges – fees and fines incurred by patrons for various reasons

-   payments – made by patrons in respect of charges incurred

-   contacts – contact details for persons or organizations represented by patrons.

Each entity and each request and response message-pair is defined in terms of a data framework[2], or schema. A data framework specifies how to describe an entity in terms of a collection of properties (identifiers, name, etc.), and how to construct a message (request or response) in terms of entity descriptions and other parameters. Each data element and composite is defined in terms of what data it may contain and its meaning.

This document is inevitably influenced by the widespread use of the 3M™ Standard Interchange Protocol Version 2.00 (SIP2) by library systems. Where appropriate, the relationship between an LCF function or data element and the corresponding SIP2 message type or field is indicated, to promote interoperability wherever possible between SIP2 and the LCF standard.

Data frameworks for terminal applications
=========================================

Information entity types
------------------------

Data frameworks are defined for the following principal types of information entity:

-   Manifestations

-   Items (individual copies of manifestations)

-   Patrons (identified library users)

-   Locations

-   Loans

-   Reservations

-   Charges

-   Payments

-   Contacts (contact details for persons or organisations represented by patrons)

The data frameworks for the following other types of information entity are also defined:

-   Classification schemes (e.g. for manifestation classification)

-   Classification codes

-   Entity properties recognised by the LMS (used for constructing entity selection criteria)

Each of the data frameworks for entity types defines the properties associated with that entity type. These properties may be either simple data elements or composites: more complex structures, being groupings of data elements and other composites.

Terminal application functions
------------------------------

Data frameworks are defined for the following terminal application functions:

-   Core functions that can theoretically be applied to any type of information entity

    -   Create new entity record

    -   Retrieve entity list

    -   Retrieve entity record

    -   Modify existing entity record

    -   Terminate entity record

-   Applications of the core functions to circulation management

    -   Check-out / renewal of item to patron

    -   Check-in item from patron

    -   Make / confirm patron payment

<!-- -->

-   Reserve title

    -   Block patron account

    -   Un-block patron account

<!-- -->

-   Applications of the core functions to stock management

    -   Retrieve location list

    -   Retrieve item classification scheme list

    -   Retrieve classification list

    -   Retrieve stock / holding list

    -   Retrieve selection criterion type list

Each of the data frameworks for terminal application functions assumes that a function is implemented as a pair of messages exchanged between the terminal application and the LMS, connected over a network. The terminal application initiates the exchange by sending a request to the LMS to execute the function in question. The LMS then sends a response to the terminal application, indicating the outcome of the request.

Each entity and function is defined in terms of data elements. Data elements may be grouped into composites. Each element is identified by a number prefixed by ‘D’ for simple data elements and by ‘C’ for composite data elements.

In addition to defining data frameworks for each function, this standard also defines a data framework for common data components used to convey user identification information and other messaging control data in request and response messages.

NOTE – This document does not mandate that any specific underlying communication infrastructure be employed for connecting the terminal application and the LMS, and therefore does not mandate whether or how the common data components should be used. Their inclusion is to facilitate mapping between existing legacy messaging protocols (e.g. SIP2) and LCF.

Status and future development of this standard
----------------------------------------------

Version 1.0 of this standard has been prepared by BIC following pilot implementation and a detailed review of Version 0.9 in self-service applications in circulation management by a BIC Working Group representing self-service terminal developers, library management system developers and libraries. This detailed review has resulted in significant changes both to the technical content of the standard and to the way that the standard is organised.

This document should be read in conjunction with the latest issue of the LCF code lists.

This document is subject to revision from time to time. The latest versions of this document, the LCF code lists and resources supporting specific implementations of this standard may be found at <http://www.bic.org/lcf>.

It is intended to maintain and develop further this standard. Future development will continue to be guided by the requirements of libraries and carried out in collaboration with device and system developers. Details of how to report errors, request changes and contribute to future developments of the standard are to be found at http://www.bic.org.uk/lcf.

Data frameworks for information entity types
--------------------------------------------

### E01 MANIFESTATION

#### Description

An identified manifestation of an abstract work, e.g. a book, magazine, newspaper or recording (analogue or digital). Sometimes informally referred to as a "title", but this term is reserved in LCF for the title of a manifestation.

#### Properties

| *Id*       | *Element*   | *SIP2 ID*    | *Card.*[3] | *Format*   | *Description*                                    |
|------------|-------------|--------------|------------|------------|--------------------------------------------------|
| **E01D01** | **Identifier**                                  |       | **1**[4]   | **String** | **The&nbsp;primary&nbsp;LMS&nbsp;identifier normally used when referring to this manifestation.**  |
| *E01C02*   | *Additional identifier*                         |       | 1-n        |            | Composite element containing details of an additional identifier for the manifestation.  |
| E01D02.1   | Identifier type                                 |       | 1          | Code       | LCF code list **MNI** |
| E01D02.2   | Identifier type name                            |       | 0-1        | String     | If the identification scheme is proprietary, the name of the scheme.                                                                                                                                                                                                                                     |
| E01D02.3   | Identifier value                                |       | 1          | String     | The identifier string.                                                                                                                                                                                                                                                                                   |
| *E01C03*   | *Media type / format*                           | CK    | 0-n        |            |                                                                                                                                                                                                                                                                                                          |
| E01D03.1   | Media type / format scheme                      |       | 1          | Code       | LCF code list 
**MES**<br/>Allowed values to include ONIX code lists 150 and 175, SIP2 media type and proprietary |
| E01D03.2   | Scheme name                                     |       | 0-1        | String     | Name or description of proprietary scheme                                                                                                                                                                                                                                                                |
| E01D03.3   | Scheme code                                     |       | 1          | String     | Code from the specified scheme                                                                                                                                                                                                                                                                           |
| *E01C04*   | *Title*                                         | AJ    | 0-n        |            | Composite element containing a title of the manifestation. Repeatable for multiple types of title (e.g. full title, abbreviated title)                                                                                                                                                                   |
| E01D04.1   | Title type                                      |       | 1          | Code       | LCF code list **TTL**                                                                                                                                                                                                                                                                                    |
| E01D04.2   | Title text                                      |       | 1          | String     |                                                                                                                                                                                                                                                                                                          |
| E01D04.3   | Subtitle                                        |       | 0-1        | String     |                                                                                                                                                                                                                                                                                                          |
| *E01C05*   | *Contributor*                                   |       | 0-n        |            | Composite element containing author or other contributor. Repeatable for multiple contributors.                                                                                                                                                                                                          |
| E01D05.1   | Contributor role                                |       | 1          | Code       | Contributor role code from ONIX Code List 17[5].                                                                                                                                                                                                                                                         |
| E01D05.2   | Contributor name                                |       | 0-1        | String     | Either a contributor name or an unnamed contributor code must be included in each item contributor composite.                                                                                                                                                                                            |
| E01D05.3   | Unnamed contributor                             |       | 0-1        | Code       | LCF code list **UNC**                                                                                                                                                                                                                                                                                    |
| *E01C06*   | *Series*                                        |       | 0-1        |            | Composite element containing information about a series of which this manifestation is a member.                                                                                                                                                                                                         |
| *E01C06.1* | *Series title*                                  |       | 0-n        |            | Composite element containing the title of the series. Repeatable for multiple types of title.                                                                                                                                                                                                            |
| E01D06.1.1 | Title type                                      |       | 1          | Code       | LCF code list **TTL**                                                                                                                                                                                                                                                                                    |
| E01D06.1.2 | Title text                                      |       | 1          | String     |                                                                                                                                                                                                                                                                                                          |
| E01D06.1.3 | Subtitle                                        |       | 0-1        | String     |                                                                                                                                                                                                                                                                                                          |
| E01D06.2   | Volume or part                                  |       | 0-1        | String     | Volume or part number within series                                                                                                                                                                                                                                                                      |
| E01D06.3   | Identifier of other manifestation within series |       | 0-n        | String     | The primary identifier of another manifestation in the same series. Repeatable if there is more than one other manifestation in the same series.                                                                                                                                                         |
| E01D07     | Edition statement                               |       | 0-1        | String     | Edition of the item                                                                                                                                                                                                                                                                                      |
| E01D08     | Publisher name                                  |       | 0-1        | String     | Name of the publisher of the manifestation                                                                                                                                                                                                                                                               |
| E01D09     | Year of publication                             |       | 0-1        | YYYY       | Year of publication of the manifestation                                                                                                                                                                                                                                                                 |
| *E01C10*   | *Classification*                                |       | 0-n        |            |                                                                                                                                                                                                                                                                                                          |
| E01D10.1   | Classification scheme                           |       | 1          | Code       | LCF code list **LCS**                                                                                                                                                                                                                                                                                    |
| E01D10.2   | Scheme name                                     |       | 0-1        | String     | Name or description of proprietary scheme                                                                                                                                                                                                                                                                |
| E01D10.3   | Scheme code                                     |       | 1          | String     |                                                                                                                                                                                                                                                                                                          |
| E01D11     | Item cover art                                  |       | 0-n        | URI        | URI reference to cover art resource                                                                                                                                                                                                                                                                      |
| E01D12     | Other description                               |       | 0-1        | String     | Other descriptive information about the manifestation.                                                                                                                                                                                                                                                   |
| *E01C13*   | *Check-out restriction*                         |       | 0-n        |            | Composite element containing details of a restriction on check-out of this manifestation. Repeatable for multiple restriction types.                                                                                                                                                                     |
| E01D13.1   | Restriction type                                |       | 1          | Code       | LCF code list **CRT**<br/>The type of restriction imposed.                                                                                                                                                                                                                                                                          |
| E01D13.2   | Restriction code / value                        |       | 1          | String     | Restriction value of the specified type.                                                                                                                                                                                                                                                                 |
| E01D13.3   | Restriction note                                |       | 0-1        | String     | Free-text note or description of the restriction.                                                                                                                                                                                                                                                        |
| *E01C14*   | *Check-out fee*                                 | BO    | 0-n        |            | Composite element containing details of any fee required to check out this manifestation. Repeatable if there are fees of different types. NOTE – Infrequently used, as fees are rarely fixed for an individual manifestation and must be calculated at check-out time, based upon a variety of factors. |
| E01D14.1   | Fee type                                        | BT    | 1          | Code       | LCF code list **CHT**                                                                                                                                                                                                                                                                                    |
| E01D14.2   | Fee amount                                      | BV    | 1          | Value      | Currency value                                                                                                                                                                                                                                                                                           |
| E01D14.3   | Fee currency                                    | BH    | 0-1        | Code       | ISO three-letter currency code, e.g. ‘GBP’                                                                                                                                                                                                                                                               |
| E01D15     | Number of patrons in hold queue                 | CF    | 0-1        | Integer    |                                                                                                                                                                                                                                                                                                          |
| E01D16     | Manifestation record reference                  |       | 0-1        | String     | A reference (e.g. URI or query string) for retrieving a catalogue record for this manifestation from the LMS or online catalogue.                                                                                                                                                                        |
| **E01D17** | **Manifestation status**                        |       | **1**      | **Code**   | LCF code list **MNS**                                                                                                                                                                                                                                                                                    |
| E01D18     | Number of copies in stock / holding             |       | 0-1        | Integer    |                                                                                                                                                                                                                                                                                                          |
| E01D19     | Item reference                                  |       | 0-n        | String     | Reference to an item that is a copy of this manifestation                                                                                                                                                                                                                                                |
| E01D20     | Reservation reference                           |       | 0-n        | String     | If this manifestation has been reserved, a reference to the reservation record in the hold queue. Repeatable if there are multiple reservations in the “hold queue”.                                                                                                                                     |
| *E01C21*   | *Manifestation note*                            |       | 0-n        |            | A note attached to the LMS record for this title.                                                                                                                                                                                                                                                        |
| E01D21.1   | Note type                                       |       | 0-1        | Code       | LCF code list **NOT**                                                                                                                                                                                                                                                                                    |
| E01D21.2   | Note date-time                                  |       | 0-1        | DateTime   |                                                                                                                                                                                                                                                                                                          |
| E01D21.3   | Note text                                       |       | 1          | String     |                                                                                                                                                                                                                                                                                                          |

### 

### E02 ITEM

#### Description

An identified copy of a manifestation that is in a library's stock / holding.

#### Properties

| *Id*       | *Element*                    | *SIP2 ID* | *Card.* | *Format* | *Description*  |
|------------|------------------------------|-----------|---------|----------|----------------|
| **E02D01** | **Identifier**               | **AB** | **1**   | **String**                                          | **The primary LMS identifier normally used when referring to this item.**                                                                                                                                                                                                                                                                     |
| *E02C02*   | *Additional identifier*      |        | 0-n     |                                                     | Composite element containing details of an additional identifier for this item.                                                                                                                                                                                                                                                               |
| E02D02.1   | Identifier type              |        | 1       | Code                                                | LCF code list **IMI**<br/>The identification scheme.                                                                                                                                                                                                                                                                                                                     |
| E02D02.2   | Identifier type name         |        | 0-1     | String                                              | If the identification scheme is proprietary, the name of the scheme.                                                                                                                                                                                                                                                                          |
| E02D02.3   | Identifier value             |        | 1       | String                                              | The identifier string.                                                                                                                                                                                                                                                                                                                        |
| **E02D03** | **Manifestation reference**  |        | **1**   | **String**                                          | **Reference to the manifestation of which this item is an instance.**                                                                                                                                                                                                                                                                         |
| E02D04     | Item properties              | CH     | 0-1     | String                                              | Descriptive information about this item.                                                                                                                                                                                                                                                                                                      |
| E02D05     | Item owner                   | BG     | 0-1     | String                                              | Library identifier for owner of this item.                                                                                                                                                                                                                                                                                                    |
| E02C06     | *Associated location *       |        | 0-n     |                                                     | A location associated with this item.                                                                                                                                                                                                                                                                                                         |
| E02D06.1   | Location association type    |        | 1       | Code                                                | LCF code list **LAT**                                                                                                                                                                                                                                                                                                                         |
| E02D06.2   | Location reference           |        | 1-n     | String                                              |                                                                                                                                                                                                                                                                                                                                               |
| E02D07     | Item sensitive media warning |        | 1       | Code                                                | LCF code list **MEW**<br/>Flag indicating that the item contains a media component that is sensitive to some security setting devices.                                                                                                                                                                                                                                   |
| E02D08     | Desensitize item security    |        | 0-1     | Code                                                | LCF code list **SCD**<br/>Flag indicating that the security should or should not be desensitized / removed on check-out.                                                                                                                                                                                                                                                 |
| *E02C09*   | *Check-out restriction*      |        | 0-n     |                                                     | Composite element containing details of a restriction on check-out of this item. Repeatable for multiple restriction types. Overrides the same check-out restrictions specified for the title.                                                                                                                                                |
| E02D09.1   | Restriction type             |        | 1       | Code     | LCF code list **CRT**                                                                                                                                                                                                                                                                                                                         |
| E02D09.2   | Restriction code / value     |        | 1       | String                                              | Restriction value of the specified type.                                                                                                                                                                                                                                                                                                      |
| E02D09.3   | Restriction note             |        | 0-1     | String                                              | Free-text note or description of the restriction.                                                                                                                                                                                                                                                                                             |
| *E02C10*   | *Check-out fee*              | BO     | 0-n     |                                                     | Composite element containing details of any fee required to check out this item. Repeatable if there are fees of different types. NOTE – Rarely used, as fees are rarely fixed for an item and must be calculated at check-out time, based upon a variety of factors. If included, Overrides the same check-out fees specified for the title. |
| E02D10.1   | Fee type                     | BT     | 1       | Code     | LCF code list **CHT**                                                                                                                                                                                                                                                                                                                         |
| E02D10.2   | Fee amount                   | BV     | 1       | Value                                               | Currency value                                                                                                                                                                                                                                                                                                                                |
| E02D10.3   | Fee currency                 | BH     | 0-1     | Code                                                | ISO three-letter currency code, e.g. ‘GBP’                                                                                                                                                                                                                                                                                                    |
| **E02D11** | **Circulation status**       |        | **1**   | **Code** | **LCF code list CIS**                                                                                                                                                                                                                                                                                                                         |
| E02D12     | Reservation reference        |        | 0-n     | String                                              | If this item has been reserved, a reference to the reservation record in the hold queue. Repeatable if there are multiple reservations in the “hold queue”.                                                                                                                                                                                   |
| E02D13     | Number of patrons in hold queue                 | CF     | 0-1     | Integer                                             | Included only if this specific item is specified in the hold queue.                                                                                                                                                                                                                                                                           |
| E02D14     | Loan reference               |        | 0-1     | String                                              | If this item is on loan, a reference to the active loan record is mandatory.                                                                                                                                                                                                                                                                  |
| E02D15     | Condition code / value       |        | 0-n     | Code                                                | A proprietary (i.e. LMS-specific) code value indicating the condition of the item.                                                                                                                                                                                                                                                            |
| E02D16     | Condition description        |        | 0-1     | String                                              | A textual description of the condition of the item.                                                                                                                                                                                                                                                                                           |
| *E02C17*   | *Item note*                  |        | 0-n     |                                                     | A note attached to the LMS record for this item.                                                                                                                                                                                                                                                                                              |
| E02D17.1   | Note type                    |        | 0-1     | Code                                                | LCF code list **NOT**                                                                                                                                                                                                                                                                                                                         |
| E02D17.2   | Note date-time               |        | 0-1     | DateTime                                            |                                                                                                                                                                                                                                                                                                                                               |
| E02D17.3   | Note text                    |        | 1       | String                                              |                                                                                                                                                                                                                                                                                                                                               |

### 

### E03 PATRON

#### Description

An identified person or organization permitted to borrow an item from a library.

NOTE – Contact information is held in separate contact records for security and privacy reasons.See E09 below.

#### Properties

| *Id*         | *Element* | *SIP2 ID*     | *Card.* | *Format* | *Description* |
|--------------|-----------|---------------|---------|----------|---------------|
| **E03D01**   | **Identifier**                                          | **AA** | **1**   | **String**                                         | **The primary LMS identifier normally used when referring to this patron.**                                                                                             |
| E03D02       | Contact reference                                       |        | 0-1     | String                                             | A contact person or organisation represented by this patron                                                                                                             |
| *E03C03*     | *Associated location *                                  |        | 0-n     |                                                    | A location associated with this patron.                                                                                                                                 |
| E03D03.1     | Location association type                               |        | 1       | Code                                               | LCF code list **LAT**                                                                                                                                                   |
| E03D03.2     | Location reference                                      |        | 1-n     | String                                             |                                                                                                                                                                         |
| ***E03C04*** | ***Patron status***                                     |        | **1**   |                                                    | **Composite element containing a combination of zero or more conditions.**                                                                                              |
| **E03D04.1** | **Condition**                                           |        | **1-n** | **Code** | **LCF code list PNS**                                                                                                                                                   |
| E03D05       | Library card status                                     |        | 0-1     | Code                                               | LCF code list **PCS**                                                                                                                                                   
                                                                                                                                                  Only codes '02' and '03' would be relevant in this context.                                                                                                              |
| E03D06       | Blocked card message                                    | AL     | 0-1     | String                                             | Only included if E03D05 is included.                                                                                                                                    |
| E03D07       | Loan reference                                          |        | 0-n     | String                                             | A loan made to this patron. May include references to past as well as current (active) loans until the loan records are deleted.                                        |
| E03D08       | Number of items on loan                                 |        | 0-1     | Integer                                            | Only applies to active loans.                                                                                                                                           |
| E03D09       | Loan items limit                                        | CB     | 0-1     | Integer                                            |                                                                                                                                                                         |
| E03D10       | Number of overdue items                                 |        | 0-1     | Integer                                            |                                                                                                                                                                         |
| E03D11       | Overdue items limit                                     | CA     | 0-1     | Integer                                            |                                                                                                                                                                         |
| E03D12       | Number of recalled items                                |        | 0-1     | Integer                                            |                                                                                                                                                                         |
| E03D13       | Number of items for which fees other than fines are due |        | 0-1     | Integer                                            |                                                                                                                                                                         |
| E03D14       | Number of items for which fines are due                 |        | 0-1     | Integer                                            |                                                                                                                                                                         |
| E03D15       | Reservation reference                                   |        | 0-n     | String                                             | A reservation associated with this patron                                                                                                                               |
| E03D16       | Number of available hold items                          |        | 0-1     | Integer                                            |                                                                                                                                                                         |
| E03D17       | Number of unavailable hold items                        |        | 0-1     | Integer                                            |                                                                                                                                                                         |
| E03D18       | Hold items limit                                        | BZ     | 0-1     | Integer                                            |                                                                                                                                                                         |
| E03D19       | Charge reference                                        |        | 0-n     | String                                             | A charge associated with this patron. It is recommended that a patron record should include references to all unpaid charges.                                           |
| *E03C20*     | *Charge limit*                                          | CC     | 0-n     |                                                    | Composite element. The limit on charges (fees or fines) that this patron is allowed to owe. Repeatable if separate limits are specified for charges of different types. |
| E03D20.1     | Charge type                                             | BT     | 0-1     | Code    | LCF code list **CHT**<br/>May only be omitted if there is only one occurrence of the charge limit composite, in which case the amount is the limit on the aggregate of charges of all types.       |
| E03D20.2     | Charge amount                                           | BV     | 1       | Value                                              | Currency value                                                                                                                                                          |
| E03D20.3     | Charge currency                                         | BH     | 0-1     | Code                                               | ISO three-letter currency code, e.g. ‘GBP’                                                                                                                              |
| *E03C21*     | *Patron note*                                           |        | 0-n     |                                                    | A note attached to the LMS record for this patron.                                                                                                                      |
| E03D21.1     | Note type                                               |        | 0-1     | Code                                               | LCF code list **NOT**                                                                                                                                                   |
| E03D21.2     | Note date-time                                          |        | 0-1     | DateTime                                           |                                                                                                                                                                         |
| E03D21.3     | Note text                                               |        | 1       | String                                             |                                                                                                                                                                         |

### E04 LOCATION

#### Description

An identified place where an item may be located, either inside or outside a library.

#### Properties

| *Id*       | *Element*               | *SIP2 ID*    | *Card.* | *Format*   | *Description* |
|------------|-------------------------|-------|---------|------------|----------------------|
| **E04D01** | **Identifier**          |       | **1**   | **String** | **The primary LMS identifier normally used when referring to this location.**       |
| *E04C02*   | *Additional identifier* |       | 0-n     |            | Composite element containing details of an additional identifier for this location. |
| E04D02.1   | Identifier type         |       | 1       | Code       | LCF code list **LOI**<br/>The identification scheme                                                            |
| E04D02.2   | Identifier type name    |       | 0-1     | String     | If the identification scheme is proprietary, the name of the scheme.                |
| E04D02.3   | Identifier value        |       | 1       | String     | The identifier string.                                                              |
| E04D03     | Location name           |       | 0-1     | String     |                                                                                     |
| E04D04     | Location type           |       | 0-1     | Code       | LCF code list LOT                                                                   |
| E04D05     | Location description    |       | 0-1     | String     |                                                                                     |
| *E04C06*   | *Location note*         |       | 0-n     |            | A note attached to the LMS record for this location.                                |
| E04D06.1   | Note type               |       | 0-1     | Code       | LCF code list **NOT**                                                               |
| E04D06.2   | Note date-time          |       | 0-1     | DateTime   |                                                                                     |
| E04D06.3   | Note text               |       | 1       | String     |                                                                                     |

### 

### E05 LOAN

#### Description

An identified event in which one or more items have been loaned to a patron.

#### Properties

| *Id*       | *Element*                | *SIP2 ID*     | *Card.* | *Format*     | *Description* |
|------------|--------------------------|--------|---------|--------------|----------------------|
| **E05D01** | **Loan identifier**      |        | **1**   | **String**   | **The LMS identifier used when referring to this loan.**                        |
| **E05D02** | **Patron reference**     | **AA** | **1**   | **String**   |                                                                                 |
| **E05D03** | **Item reference**       | **AB** | **1**   | **String**   | **A loan applies to a single item**                                             |
| **E05D04** | **Loan start date-time** |        | **1**   | **DateTime** |                                                                                 |
| E05D05     | Loan end due date-time   |        | 0-1     | DateTime     | Omitted only if the loan is permanent or doesn't have a specific end date-time. |
| E05D06     | Loan end date-time       |        | 0-1     | DateTime     | Actual end date-time. Used when recording past loans.                           |
| **E05D07** | **Loan status**          |        | **1-n** | **Code**     | **LCF code list LOS**                                                           |
| E05D08     | Previous loan reference  |        | 0-1     | String       | Used when loan is a renewal                                                     |
| E05D09     | Renewal loan reference   |        | 0-1     | String       | Used when loan is superceded by a renewal loan                                  |
| E05D10     | Recall notice date-time  | CJ     | 0-n     | DateTime     | The date on which a recall notice for the item on loan was issued.              |
| E05D11     | Charge reference         |        | 0-n     | String       |                                                                                 |
| *E05C12*   | *Loan note*              |        | 0-n     | String       | A note attached to the LMS record for this loan.                                |
| E05D12.1   | Note type                |        | 0-1     | Code         | LCF code list **NOT**                                                           |
| E05D12.2   | Note date-time           |        | 0-1     | DateTime     |                                                                                 |
| E05D12.3   | Note text                |        | 1       | String       |                                                                                 |

### 

### E06 RESERVATION

#### Description

An identified event in which one or more titles have been reserved for a patron.

#### Properties

| *Id*       | *Element*                   | *SIP2 ID*     | *Card.* | *Format*   | *Description* |
|------------|-----------------------------|--------|---------|------------|----------------------|
| **E06D01** | **Reservation identifier**  |        | **1**   | **String** | **The LMS identifier used when referring to this reservation.**                                                                                                                                          |
| **E06D02** | **Reservation type**        |        | **1**   | **Code**   | **LCF code list RVT**                                                                                                                                                                                    |
| **E06D03** | **Patron reference**        | **AA** | **1**   | **String** |                                                                                                                                                                                                          |
| E06D04     | Manifestation reference     |        | 0-1     | String     | A reservation applies to either a single manifestation or a single item. Each reservation must have one or the other but not both.                                                                       |
| E06D05     | Item reference              |        | 0-1     | String     |                                                                                                                                                                                                          |
| E06D06     | Reservation start date-time |        | 0-1     | DateTime   |                                                                                                                                                                                                          |
| E06D07     | Pick-up site reference      | AO     | 0-1     | String     | The LMS identifier of the branch library or other site where the items are to be picked up by the patron. Normally only included if the reservation type is ‘04’.                                        |
| E06D08     | Pick-up location reference  |        | 0-1     | String     | The LMS identifier of the location within the site where the items are to be picked up by the patron. Normally only included if the reservation type is ‘04’, either instead of or additional to E06D07. |
| E06D09     | Pickup by date-time         | CM     | 0-1     | DateTime   | The date and optionally time by which the reserved item must be collected by the patron.                                                                                                                 |
| E06D10     | End date-time               |        | 0-1     | DateTime   | The date-time when the reservation ended, when the item was checked-out to the patron who had reserved it. Used when recording past reservations.                                                        |
| **E06D11** | **Reservation status**      |        | **1**   | **Code**   | **LCF code list RVS**                                                                                                                                                                                    |
| E06D12     | Loan reference              |        | 0-1     | String     | Only included if maintaining records of reservations that have ended with the item being loaned to the patron.                                                                                           |
| E06D13     | Charge reference            |        | 0-n     | String     | Reference to a charge incurred by this reservation.                                                                                                                                                      |
| *E06C14*   | *Reservation note*          |        | 0-n     | String     | A note attached to this reservation.                                                                                                                                                                     |
| E06D14.1   | Note type                   |        | 0-1     | Code       | LCF code list **NOT**                                                                                                                                                                                    |
| E06D14.2   | Note date-time              |        | 0-1     | DateTime   |                                                                                                                                                                                                          |
| E06D14.3   | Note text                   |        | 1       | String     |                                                                                                                                                                                                          |

### 

### E07 CHARGE

#### Description

An identified charge made to a patron. May be a fee or a fine.

#### Properties

| *Id*       | *Element*                 | *SIP2 ID*     | *Card.* | *Format* | *Description* |
|------------|---------------------------|--------|---------|-----------------|---------------|
| **E07D01** | **Charge identifier**     | **CG** | **1**   | **String**                                          | **The LMS identifier used when referring to this charge.**                                                               |
| **E07D02** | **Patron reference**      | **AA** | **1**   | **String**                                          |                                                                                                                          |
| **E07D03** | **Charge type**           | **BT** | **1**   | **Code** | **LCF code list CHT<br/>The type or category of charge.**                                                                                         |
| **E07D04** | **Charge status**         |        | **1**   | **Code**                                            | **LCF code list CHS**                                                                                                    |
| E07D05     | Charge description        |        | 0-1     | String                                              | Free-text description of charge.                                                                                         |
| E07D06     | item reference            | AB     | 0-1     | String                                              | An item to which this charge relates. Normally the single most precise reference (e.g. loan) will be sufficient.         |
| E07D07     | Manifestation reference   |        | 0-1     | String                                              | A manifestation to which this charge relates. Normally the single most precise reference (e.g. loan) will be sufficient. |
| E07D08     | Loan reference            |        | 0-1     | String                                              | A loan to which this charge relates. Normally the single most precise reference (e.g. loan) will be sufficient.          |
| E07D09     | Reservation reference     |        | 0-1     | String                                              | A reservation to which this charge relates. Normally the single most precise reference (e.g. loan) will be sufficient.   |
| E07D10     | Charge creation date-time |        | 0-1     | DateTime                                            | The date and optionally time on which the charge was created / recorded.                                                 |
| E07D11     | Payment due date-time     |        | 0-1     | DateTime                                            | The date and optionally time on which the charge becomes due for payment.                                                |
| **E07D12** | **Gross charge amount**   | **BV** | **1**   | **Value**                                           | **Currency value of original charge**                                                                                    |
| E07D13     | Charge amount paid        |        | 0-1     | Value                                               | Used if charge has been paid in part or in full                                                                          |
| E07D14     | Net charge amount due     |        | 0-1     | Value                                               | Charge remaining                                                                                                         |
| E07D15     | Payment date-time         |        | 0-1     | DateTime                                            | The date on which the charge was paid in full. Used when recording past charges.                                         |
| E07D16     | Payment reference         |        | 0-n     | String                                              | Reference to a payment that wholly or partly clears this charge.                                                         |
| E07D17     | Charge currency           | BH     | 0-1     | Code                                                | ISO three-letter currency code, e.g. ‘GBP’                                                                               |
| *E07C18*   | *Charge note*             |        | 0-n     | String                                              | A note attached to this charge.                                                                                          |
| E07D18.1   | Note type                 |        | 0-1     | Code                                                | LCF code list **NOT**                                                                                                    |
| E07D18.2   | Note date-time            |        | 0-1     | DateTime                                            |                                                                                                                          |
| E07D18.3   | Note text                 |        | 1       | String                                              |                                                                                                                          |

### 

### E08 PAYMENT

#### Description

An identified payment made by a patron to settle one or more charges.

#### Properties

| *Id*       | *Element*              | *SIP2 ID*     | *Card.* | *Format*   | *Description* |
|------------|------------------------|--------|---------|------------|----------------------|
| **E08D01** | **Payment identifier** | **AA** | **1**   | **String** | **The LMS identifier used when referring to this payment.**       |
| **E08D02** | **Patron reference**   |        | **1**   | **String** |                                                                   |
| **E08D03** | **Payment type**       |        | **1**   | **Code**   | **LCF code list PYT<br/>The type or method of payment.**                                   |
| E08D04     | Payment description    |        | 0-1     | String     | Further information on type or method of payment.                 |
| **E08D05** | **Charge reference**   |        | **1-n** | **String** | **One or more charges to which this payment relates.**            |
| E08D06     | Payment date-time      |        | 0-1     |            | The date and optionally time at which the payment was made.       |
| **E08D07** | **Payment amount**     | **BV** | **1**   | **Value**  | **Currency value**                                                |
| E08D08     | Payment currency       | BH     | 0-1     | Code       | ISO three-letter currency code, e.g. ‘GBP’                        |
| E08D09     | Payment status         |        | 0-1     | Code       | LCF code list **PYS**                                             |
| E08D10     | Transaction reference  |        | 0-1     | String     | Is a separate reference needed to a financial transaction record? |
| *E08C11*   | *Payment note*         |        | 0-n     | String     | A note attached to this payment.                                  |
| E08D11.1   | Note type              |        | 0-1     | Code       | LCF code list **NOT**                                             |
| E08D11.2   | Note date-time         |        | 0-1     | DateTime   |                                                                   |
| E08D11.3   | Note text              |        | 1       | String     |                                                                   |

### 

### E09 CONTACT

#### Description

The contact details for a person or organization represented by a patron.

#### Properties

| *Id*       | *Element*               | *SIP2 ID*     | *Card.* | *Format*   | *Description* |
|------------|-------------------------|--------|---------|------------|----------------------|
| **E09D01** | **Contact identifier**  |        | **1**   | **String** |                                                                                                                                              |
| **E09D02** | **Name**                | **AE** | **1**   | **String** | **Name of person or organization.**                                                                                                          |
| **E09D03** | **Patron ref**          |        | **1-n** | **String** |                                                                                                                                              |
| E09D04     | Address                 | BD     | 0-n     | String     | Repeatable if address is divided into multiple lines. Not included if a location entity exists for this address.                             |
| E09C05     | *Communication details* |        | 0-n     |            | Composite element containing a single communication number, address or locator for the patron. Repeatable for different communication types. |
| E09D05.1   | Communication type      |        | 1       | Code       | LCF code list **CMT**                                                                                                                        |
| E09D05.2   | Communication locator   |        | 1       | String     | The number, address or locator                                                                                                               |
| **E09D06** | **Language**            |        | **1**   | **Code**   | **Language for communication with contact                                                                                                    
                                                                        ISO three-letter language code, e.g. ‘eng’**                                                                                                  |
| *E09C07*   | *Contact note*          |        | 0-n     |            | A note attached to the LMS record for this contact.                                                                                          |
| E09D07.1   | Note type               |        | 0-1     | Code       | LCF code list **NOT**                                                                                                                        |
| E09D07.2   | Note date-time          |        | 0-1     | DateTime   |                                                                                                                                              |
| E09D07.3   | Note text               |        | 1       | String     |                                                                                                                                              |

### E10 TITLE CLASSIFICATION SCHEME

#### Description

An identified scheme for classification of titles.

#### Properties

| *Id*       | *Element*                            | *SIP2 ID*    | *Card.* | *Format*   | *Description* |
|------------|--------------------------------------|-------|---------|------------|----------------------|
| **E10D01** | **Classification scheme identifier** |       | **1**   | **String** | **The LMS identifier used when referring to this scheme.** |
| **E10D02** | **Scheme name**                      |       | **1**   | **String** | **A name or short description of the scheme**              |
| *E10C03*   | *Scheme description / note*          |       | 0-1     |            | Further, more extensive description of the scheme          |
| E10D03.1   | Note type                            |       | 0-1     | Code       | LCF code list **NOT**                                      |
| E10D03.2   | Note date-time                       |       | 0-1     | DateTime   |                                                            |
| E10D03.3   | Note text                            |       | 1       | String     |                                                            |

### 

### E11 TITLE CLASSIFICATION CODE

#### Description

An identified scheme for classification of titles.

#### Properties

| *Id*       | *Element*                           | *SIP2 ID*    | *Card.* | *Format*   | *Description* |
|------------|-------------------------------------|-------|---------|------------|----------------------|
| **E11D01** | **Classification identifier**       |       | **1**   | **String** | **A system identifier for the classification**                                                 |
| **E11D02** | **Classification code**             |       | **1**   | **String** | **A code or number used as a label for the classification.**                                   |
| **E11D03** | **Classification scheme reference** |       | **1**   | **String** | **The LMS identifier for the classification scheme to which this classification code belongs** |
| E11D04     | Classification heading              |       | 0-1     | String     | A heading or name for the classification.                                                      |
| *E11C05*   | *Classification description / note* |       | 0-1     |            |                                                                                                |
| E11D05.1   | Note type                           |       | 0-1     | Code       | LCF code list **NOT**                                                                          |
| E11D05.2   | Note date-time                      |       | 0-1     | DateTime   |                                                                                                |
| E11D05.3   | Note text                           |       | 1       | String     |                                                                                                |

NOTE – If the scheme is appropriate, the classification identifier may the chosen to be the same as the classification code.

### E12 SELECTION CRITERION

#### Description

An identified property of an entity that can be used as a selection criterion when retrieving a list of instances of that entity.

#### Properties

| *Id*       | *Element*                  | *SIP2 ID*    | *Card.* | *Format*   | *Description* |
|------------|----------------------------|-------|---------|------------|----------------------|
| **E12D01** | **Identifier**             |       | **1**   | **String** | **System identifier of the selection criterion type**                                                          |
| **E12D02** | **Criterion type name**    |       | **1**   | **String** | **Name of the selection criterion type, to be used in item list requests.**                                    |
| E12D03     | Entity type                |       | 0-n     | Code       | ONIX code list **ENT**<br/>If applicable, the types of entity for which this is a valid selection criterion.                               |
| E12D04     | Criterion type description |       | 0-1     | String     | A description of the criterion type and the domain and range of its values.                                    |
| E12D05     | Criterion value scheme     |       | 0-1     | String     | Identifier of the scheme from which values of this criterion type are drawn, to be used in item list requests. |
| *E12C06*   | *Criterion note*           |       | 0-n     |            |                                                                                                                |
| E12D06.1   | Note type                  |       | 0-1     | Code       | LCF code list **NOT**                                                                                          |
| E12D06.2   | Note date-time             |       | 0-1     | DateTime   |                                                                                                                |
| E12D06.3   | Note text                  |       | 1       | String     |                                                                                                                |

NOTE – The selection criterion identifier may be the same as the name. In any case, the name must be unique.

Common components
-----------------

The following data elements and composites are typically used for control of message handling and authentication between the terminal application and the LMS. In some implementations these may be used in message headers and trailers, but in many, if not most, implementations these will be handled at a different level in the messaging protocol stack (e.g. in HTTP or SSL) and not in the message payload. They are primarily included here because of their inclusion in SIP2.

### Q00 Elements common to requests

| *Id*     | *Element*                   | *SIP2 ID*    | *Card.* | *Format* | *Description* |
|----------|-----------------------------|-------|---------|-----------------|---------------|
| *Q00C01* | *User ID *                  | CN    | 0-1     |                                                 | Composite element.                                                                                                                                                        |
| Q00D01.1 | Encryption algorithm        |       | 0-1     | Code | LCF code list **ECR**<br/>The specific encryption algorithm, if any, employed by the terminal application for encrypting the user ID. If omitted, the string value may or may not be encrypted.      |
| Q00D01.2 | String value                |       | 1       | String                                          | The encrypted or unencrypted string. Element Q00D01.1 may indicate the encryption algorithm employed, if any. Mandatory in each composite.                                |
| *Q00C02* | *Password*                  | CO    | 0-1     |                                                 | Composite element. It would be unusual for the password not to be encrypted.                                                                                              |
| Q00D02.1 | Encryption algorithm        |       | 0-1     | Code                                            | LCF code list **ECR**<br/>The specific encryption algorithm, if any, employed by the terminal application for encrypting the password. If omitted, the string value may or may not be encrypted.     |
| Q00D02.2 | String value                |       | 1       | String                                          | The encrypted or unencrypted string. Element Q00D02.1 may indicate the encryption algorithm employed, if any. Mandatory in each composite.                                |
| Q00D03   | Institution identifier      | AO    | 0-1     | String                                          | LMS identifier for the institution, if terminals may be in one of several institutions.                                                                                   |
| *Q00C04* | *Terminal ID*               |       | 0-1     | String                                          | LMS identifier for the device or terminal on which the terminal application is running.                                                                                   |
| Q00D04.1 | Encryption algorithm        |       | 0-1     | Code                                            | LCF code list **ECR**<br/>The specific encryption algorithm, if any, employed by the terminal application for encrypting the terminal ID. If omitted, the string value may or may not be encrypted.  |
| Q00D04.2 | String value                |       | 1       | String                                          | The encrypted or unencrypted string. Element Q00D04.1 may indicate the encryption algorithm employed, if any. Mandatory in each composite.                                |
| *Q00C05* | *Terminal password*         |       | 0-1     |                                                 |                                                                                                                                                                           |
| Q00D05.1 | Encryption algorithm        |       | 0-1     | Code                                            | LCF code list **ECR**                                                                                                                                                     |
| Q00D05.2 | String value                |       | 1       | String                                          | The encrypted or unencrypted string.                                                                                                                                      |
| Q00D06   | Terminal location reference | CP    | 0-1     | String                                          | The identifier for the location of the device or terminal on which the terminal application is running.                                                                   |
| Q00D07   | Request ID                  |       | 0-1     | String                                          | An ID of a request. If included in a request, it must also be included in the LMS response.                                                                               |
| Q00D08   | Request date-time           |       | 0-1     | DateTime                                        | ISO date-time<br/>The date-time at which the terminal application user submitted the request. Normally generated by the application.                                                         |
| Q00D09   | Previous request ID         |       | 0-1     | String                                          | Used when cancelling a previous request, in which case this element contains the identifier of the previous request (see element Q00D07).                                 |

### 

### R00 Elements common to responses

| *Id*     | *Element*             | *SIP2 ID*      | *Card.* | *Format* | *Description* |
|----------|-----------------------|---------|---------|-----------------|---------------|
| R00D01   | Response ID           |         | 0-1     | String                                          | An ID of a response.                                                                                                                                   |
| R00D02   | Response type         |         | 0-1     | Code                                            | LCF code list RST                                                                                                                                      |
| R00D03   | Request reference     |         | 0-1     | String                                          | The ID of the request to which this is the response. Mandatory if the request included a request ID.                                                   |
| R00D04   | Response date-time    |         | 0-1     | DateTime                                        | The date and time of the response.                                                                                                                     |
| *R00C05* | *Exception condition* |         | 0-n     |      | Response if there is an exception condition, in which case this and, optionally, one or more of the following message elements terminate the response. |
| R00D05.1 | Condition type        |         | 1       | Code                                            | LCF code list **EXC**<br/>Response code will often be specific to the function requested.                                                                                       |
| R00D05.2 | Reason request denied |         | 0-1     | Code                                            | LCF code list **RDN**<br/>Used if R00D05.1 contains ''08' (request denied)                                                                                                      |
| R00D05.3 | Element reference     |         | 0-1     | String                                          | A reference (e.g. the LCF element ID) that uniquely identifies the element in the request payload that generated the exception condition.              |
| *R00C06* | *Response message*    | AF / AG | 0-n     |                                                 | Composite element containing text to display or print on terminal.                                                                                     |
| R00D06.1 | Message display type  |         | 1       | Code | LCF code list **MGT**                                                                                                                                  |
| R00D06.2 | Message to display    |         | 1-n     | String                                          | Repeatable if display type is ‘single line’                                                                                                            |

Core functions
--------------

NOTE ON CARDINALITIES IN RESPONSE MESSAGES - The cardinalities for the elements of responses assume that there is no exception condition, which would be indicated by the inclusion of element R00D05 in a response. If there is an exception condition, only elements in table R00 above would be included in the response.

### 01 Retrieve entity instance information

This function may be used to retrieve information about an instance of an entity of any type. In practice the most likely uses of the function are to retrieve information about **titles**, **items** and **patrons**, but it could also be used to retrieve information about instances of any entity type, such as locations or charges.

#### Request

| *Id*       | *Element*                           | *SIP2 ID*     | *Card.* | *Format*   | *Description* |
|------------|-------------------------------------|--------|---------|------------|----------------------|
| **Q01D01** | **Entity type**                     |        | **1**   | **Code**   | **LCF code list ENT<br/>The entity type of the item about which information is requested. Information may be requested for any of the entity types E01 to E12 defined above.**                                                                                                             |
| **Q01D02** | **Entity instance identifier**      | **\*** | **1**   | **String** | **The primary (LMS) identifier for the entity instance.**                                                                                                                                                                                                         |
| Q01D03     | Requested item detailed information |        | 0-n     | Code       | LCF code list **MND**, **IMD** or **PNT**, depending upon entity type specified in Q01D01.<br/>Indicates the type of information to be included in the response. May be repeated if several types of information are requested, unless the code indicates that all details are to be included. If omitted, the details to be included are determined by the LMS.  |

\* The correspondence with a SIP2 element depends upon the entity type. For entity types 'patron' and 'item' the correspondence is with SIP2 elements AA and AB respectively. The only other entity type that is likely to be specified with any frequency is ‘manifestation’.

#### Response

NOTE – The elements included in the response will depend upon both the entity type and whether a specific level of detail has been requested, by the inclusion of one or more elements Q01D03 in the request. Elements marked as mandatory may only be omitted if there has been an exception condition and the response is in effect empty.

| *Id*     | *Element* | *SIP2 ID*    | *Card.* | *Format* | *Description* |
|----------|-----------|-------|---------|----------|---------------|
| *R01C01* | Entity element as determined by the specified entity type – see E01 to E12 above – taking into account any instances of element Q01D03 in the request. |       | 0-n     |          |               |

### 02 Retrieve entity instance list

This function may be used to retrieve a list of entity instances, with or without detailed information for each entity instance in the list. Normally the list would be retrieved with minimal information (mandatory elements only) or no detailed information apart from the identifier of the item.

#### Request

| *Id*       | *Element* | *SIP2 ID*    | *Card.* | *Format*                 | *Description* |
|------------|-----------|-------|---------|--------------------------|----------------------|
| **Q02D01** | **Entity type**                                                                   |       | **1**   | **Code**                 | **LCF code list ENT<br/>The entity type of the item about which information is requested. Information may be requested for any of the entity types E01 to E12 defined above.**                                                                                                                                                                                               |
| *Q02C02*   | *Selection criterion*                                                             |       | 0-n     |                          | A criterion for selecting instances to be retrieved. If multiple selection criteria are specified, all must apply to all items retrieved. If no selection criteria are specified, all items of the specified entity type are to be included in the list.                                                                                            |
| Q02D02.1   | Selection criterion reference                                                     |       | 1       | String                   | A reference to an identified selection criterion (see E12 above)                                                                                                                                                                                                                                                                                    |
| Q02D02.2   | Criterion value                                                                   |       | 1       | String                   |                                                                                                                                                                                                                                                                                                                                                     |
| Q02D03     | Requested instance detailed information                                           |       | 0-n     | Code                     | LCF code list **MND**, **IMD** or **PNT**, depending upon entity type specified in Q02D01.<br/>Indicates the type of information to be included in the response. May be repeated if several types of information are requested, unless the code indicates that all details are to be included. If omitted, minimal details are included as determined by the LMS.                                                                                   |
| Q02D04     | Requested maximum number of instances in response                                 |       | 0-1     | Positive integer         | If present, the maximum number of instances from the list matching the specified selection criteria that are desired in the response. If not present, the entire list of instances matching the specified selection criteria should be included in the response. Responses should, wherever possible, honour this maximum when requested.           |
| Q02D05     | Index, in the complete list of instances found, of first instance in the response |       | 0-1     | Positive integer or zero | If present, the desired index of the first instance in the response in the list of instances that match the specified selection criteria. For example, an offset value ‘10’ would imply that the first instance in the response should be the eleventh instance in the list. Responses should, wherever possible, honour this index when requested. |

\* The correspondence with a SIP2 element depends upon the entity type. For entity types 'patron' and 'item' the correspondence is with SIP2 elements AA and AB respectively. The only other entity type that is likely to be specified with any frequency is 'title'.

#### Response

| *Id*     | *Element* | *SIP2 ID*    | *Card.* | *Format*                 | *Description* |
|----------|-----------|-------|---------|--------------------------|----------------------|
| R02D01   | Entity type                                                                                                                                                 |       | 0-1     | Code                     | LCF code list **ENT**<br/>Mandatory if the number of instances in the response is greater than zero.                                                                                                                                                                                                                                                    |
| *Q02C02* | *Selection criterion*                                                                                                                                       |       | 0-n     |                          | A criterion used for selecting instances, as specified in the request. It is recommended that if selection criteria are included in the request, they should also be included in the response for reference purposes.                                                                                                                                 |
| Q02D02.1 | Selection criterion reference                                                                                                                               |       | 1       | String                   | A reference to an identified selection criterion (see E12 above)                                                                                                                                                                                                                                                                                      |
| Q02D02.2 | Criterion value                                                                                                                                             |       | 1       | String                   |                                                                                                                                                                                                                                                                                                                                                       |
| R02D03   | Number of instances in the list matching the selection criteria specified in the request                                                                    |       | 0-1     | Positive integer         |                                                                                                                                                                                                                                                                                                                                                       |
| R02D04   | Number of instances in this response                                                                                                                        |       | 0-1     | Positive integer         |                                                                                                                                                                                                                                                                                                                                                       |
| R02D05   | Offset from beginning of the ordered list to first instance in this response                                                                                |       | 0-1     | Positive integer or zero | If present, the integer value added to ‘1’ to determine the first instance in the list of instances that match the specified selection criteria to be included in the response. For example, an offset value ‘10’ would imply that the first item in the response should be the eleventh instance in the list. If omitted, the default value is zero. |
| R02D06   | Entity identifier                                                                                                                                           |       | 0-n     | String                   | If the number of selected instances is greater than zero, either one or more of this element or one or more of R02C07 must be included in the response.                                                                                                                                                                                               |
| *R02C07* | Entity elements as determined by the specified entity type – see E01 to E11 above – and taking into account any instances of element Q02D03 in the request. |       | 0-n     |                          |                                                                                                                                                                                                                                                                                                                                                       |

### 

### 03 Create entity item

This function is used to create a new item of a specific entity type. In practice it is most often used to create a new reservation or a new loan.

#### Request

| *Id*       | *Element* | *SIP2 ID*    | *Card.* | *Format* | *Description* |
|------------|-----------|-------|---------|----------|----------------------|
| **Q03D01** | **Entity type**                                                                                                 |       | **1**   | **Code** | **LCF code list ENT<br/>The entity type of the item to be created. **  |
|            | Other elements, excluding the LMS identifier, as determined by the specified entity type – see E01 to E112above |       |         |          |                                               |

#### Response

| *Id*       | *Element*           | *SIP2 ID*    | *Card.* | *Format*   | *Description* |
|------------|---------------------|-------|---------|------------|----------------------|
| **R03D01** | **Entity type**     |       | **1**   | **Code**   | **LCF code list ENT<br/>The entity type of the item created in response to the request. **                                                   |
| **R03D02** | **Item identifier** |       | **1**   | **String** | **The primary identifier for the inventory item, assigned by the LMS if a new item has been successfully created.** |

### 

### 04 Modify entity item

This function is used to modify an existing item of a specific entity type.

#### Request 

| *Id*       | *Element* | *SIP2 ID*    | *Card.* | *Format*   | *Description* |
|------------|-----------|-------|---------|------------|----------------------|
| **Q04D01** | **Entity type**                                                                  |       | **1**   | **Code**   | **LCF code list ENT**                          |
| **Q04D02** | **Item identifier**                                                              |       | **1**   | **String** | **The identifier of the item to be modified.** |
| **Q04D03** | **Modification type**                                                            |       | **1**   | **Code**   | **LCF code list MOT**                          |
|            | Other elements as determined by the specified entity type – see E01 to E12 above |       |         |            |                                                |

#### Response

| *Id*       | *Element*           | *SIP2 ID*    | *Card.* | *Format*   | *Description* |
|------------|---------------------|-------|---------|------------|----------------------|
| **R04D01** | **Entity type**     |       | **1**   | **Code**   | **LCF code list ENT<br/>The entity type of the item created in response to the request. **    |
| **R04D02** | **Item identifier** |       | **1**   | **String** | **The identifier for the item that has been successfully modified.** |

### 

### 05 Delete entity item

This function is used to delete an item of a specific entity type. Since deletion of an item involves removal of all references to this item, this function would not normally be implemented as a terminal application.

#### Request

| *Id*       | *Element*           | *SIP2 ID*    | *Card.* | *Format*   | *Description* |
|------------|---------------------|-------|---------|------------|----------------------|
| **Q05D01** | **Entity type**     |       | **1**   | **Code**   | **LCF code list ENT**                         |
| **Q05D02** | **Item identifier** |       | **1**   | **String** | **The identifier of the item to be deleted.** |

#### Response

| *Id*       | *Element*           | *SIP2 ID*    | *Card.* | *Format*   | *Description* |
|------------|---------------------|-------|---------|------------|----------------------|
| **R05D01** | **Entity type**     |       | **1**   | **Code**   | **LCF code list ENT<br/>The entity type of the item created in response to the request. **  |
| **R05D02** | **Item identifier** |       | **1**   | **String** | **The identifier of the item that has been successfully deleted**  |

Circulation management functions
--------------------------------

### 11 Check-out / renewal (create loan)

The check-out / renewal function combines the following core functions:

-   Unless this is a confirmation or cancellation of check-out or renewal, retrieve the patron, item and manifestation records to check the patron’s status and ensure that check-out is permitted and to check for any applicable fees.

-   If check-out / renewal is to proceed, create a loan record for the specified patron and item. If cancelling a check-out or renewal, search for and either delete or modify the loan record.

-   Search for any reservation record for the specified patron and manifestation (or item) and modify to change its status.

-   If fees apply, create a charge record for the applicable fee. If cancelling a check-out or renewal, search for and either delete or modify the charge record.

-   Modify the item record to update its circulation status and location and (optionally) add a reference to the loan record. If cancelling a previous check-out or renewal and deleting the associated loan record, remove any reference to this record from the item record.

-   Modify the patron record to update patron status and the number of items on loan and (optionally) add a reference to the loan record. If cancelling a previous check-out or renewal and deleting the associated loan record, remove any reference to this record from the patron record.

The terminal application must provide all the information required for all the necessary core functions to be performed.

#### Request

| *Id*       | *Element*           | *SIP2 ID*    | *Card.* | *Format* | *Description* |
|------------|---------------------|-------|---------|-----------------|---------------|
| **Q11D01** | **Request type**    |       | **1**   | **Code** | **LCF code list RQT<br/>Indicates type of check-out request. **                                                  |
| Q11D02     | Renewal type        |       | 0-1     | Code                                                | LCF code list RNQ<br/>Indicates that the request is a renewal request and which type                           |
| Q11D03     | Patron reference    | AA    | 0-1     | String                                              | Reference to the patron record. Mandatory in a new check-out.                           |
| Q11D04     | Item reference      | AB    | 0-1     | String                                              | Reference to the item in question. Mandatory unless cancelling a check-out / renewal.   |
| Q11D05     | Loan reference      |       | 0-1     | String                                              | Mandatory when renewing or cancelling a check-out or renewal.                           |
| Q11D06     | Loan end date       |       | 0-1     | DateTime                                            | If confirming check-out / renewal, the due date-time given to the patron for this item. |
| Q11D07     | Charge acknowledged | BO    | 0-1     | Flag                                                | Empty element indicating that a charge may be created.                                  |

#### Response

| *Id*   | *Element*                    | *SIP2 ID* | *Card.* | *Format* | *Description* |
|--------|------------------------------|-----------|---------|----------|---------------|
| R11D01 | Loan reference               |           | 0-1     | String   | LMS identifier for loan. Either a loan reference, or a copy of the loan record must be included in the response.                                                                                                     |
| R11C02 | Loan entity record           |           | 0-1     |          | See E05                                                                                                                                                                                                              |
| R11D03 | Item sensitive media warning |           | 0-1     | Code     | LCF code list **MEW**<br/>Same as E02D07. Flag indicating that the item contains a media component that is sensitive to some security setting devices. Mandatory on a new check-out unless the loan entity record is included in the response.  |
| R11D04 | Desensitize item security    |           | 0-1     | Code     | LCF code list **SCD**<br/>Same as E02D08. Flag indicating whether the security should or should not be desensitized / removed on check-out. Mandatory on a new check-out unless the loan entity record is included in the response.             |
| R11D05 | Charge reference             |           | 0-1     | String   | Reference to charge created with this loan.                                                                                                                                                                          |

### 

### 12 Check-in

The check-in function combines the following core functions:

-   Retrieve the item record and modify to update circulation status and location.

-   Retrieve the loan record for this item and modify it to update its status.

-   Retrieve the patron record and modify it to update the number of items on loan.

#### Request

| *Id*       | *Element*          | *SIP2 ID* | *Card.* | *Format* | *Description* |
|------------|--------------------|-----------|---------|----------|---------------|
| **Q12D01** | **Request type**   |           | **1**   | **Code** | **LCF code list RQT**                                                   |
| Q12D02     | Patron reference   | AA        | 0-1     | String                                             |                                                                         |
| **Q12D03** | **Item reference** | **AB**    | **0-1** | **String**                                         |                                                                         |
| Q12D04     | Loan reference     |           | 0-1     | String                                             |                                                                         |
| Q12D05     | Item return date   |           | 0-1     | DateTime                                           | In confirmation requests, the date the item was returned by the patron. |

#### Response

| Id     | *Element*                       | *SIP2 ID* | *Card.* | *Format* | *Description* |
|--------|---------------------------------|-----------|---------|----------|---------------|
| R12D01 | Loan reference                  |           | 0-1     | String                                            |                                                                                                                            |
| R12D02 | Patron reference                | AA        | 0-1     | String                                            |                                                                                                                            |
| R12D03 | Item reference                  | AB        | 0-1     | String                                            |                                                                                                                            |
| R12D04 | Item return location reference  | CL        | 0-1     | String                                            | LMS identifier for return location, e.g. sort bin.                                                                         |
| R12D05 | Item sensitive media warning    |           | 0-1     | Code   | LCF code list **MEW**<br/>Flag indicating that the item contains a media component that is sensitive to some security setting devices.                |
| R12D06 | Item requires special attention |           | 0-1     | Code                                              | LCF code list **SPA**<br/>Flag indicating that this item requires special attention before it is returned to its shelf location.                      |
| R12D07 | Special attention description   |           | 0-1     | String | Description of special attention required, if any.                                                                         |
| R12D08 | Charge reference                |           | 0-n     | String                                            | LMS identifier of any charge due on this item. Repeatable if more than one charge is due (e.g. loan fee and overdue fine). |

### 13 Patron payment

The patron payment function combines the following core functions:

-   Attempt to create a payment record for the amount to be paid. If cancelling a payment, the payment record is deleted or the payment status is modified.

-   Retrieve and modify the charge records to update the charge status.

#### Request

| *Id*       | *Element*                | *SIP2 ID* | *Card.* | *Format* | *Description* |
|------------|--------------------------|-----------|---------|----------|---------------|
| **Q13D01** | **Request type**         |           | **1**   | **Code**                                           | **LCF code list RQT**                                                                                                     |
| **Q13D02** | **Patron reference**     | **AA**    | **1**   | **String**                                         |                                                                                                                           |
| Q13D03     | Charge reference         |           | 0-n     | String                                             | Charge(s) against which to set this payment. If omitted, the LMS determines the charges against which to set the payment. |
| **Q13D04** | **Payment type**         |           | **1**   | **Code** | **LCF code list PYT**                                                                                                     |
| Q13D05     | Payment type description |           | 0-1     | String                                             | Further information on method of payment                                                                                  |
| **Q13D06** | **Payment amount**       |           | **1**   | **Value**                                          | **Currency value.**                                                                                                       |
| Q13D07     | Payment currency         |           | 0-1     | Code                                               | ISO three-letter currency code, e.g. ‘GBP’                                                                                |

#### Response

| *Id*       | *Element*            | *SIP2 ID* | *Card.* | *Format*   | *Description* |
|------------|----------------------|-----------|---------|------------|---------------|
| **R13D01** | **Patron reference** | **AA**    | **1**   | **String** |                                                                   |
| R13D02     | Payment Identifier   |           | 0-1     | String     | Included if attempt to make the payment is successful.            |
| R13D03     | Charge reference     |           | 0-n     |            | Mandatory if payment of any charge item is accepted or confirmed. |

### 14 Block patron account

Used to prevent unauthorised use of a patron account, such as when the patron’s library card is stolen or mislaid. This function is simply an application of core functions to retrieve and modify a patron entity. The patron's current record is retrieved and the patron status and library card status updated as appropriate. If necessary a blocked card message is added.

#### Request

| *Id*       | *Element*            | *SIP2 ID* | *Card.* | *Format* | *Description*         |
|------------|----------------------|-----------|---------|----------|-----------------------|
| **Q14D01** | **Patron reference** | **AA**    | **1**   | **String**                                      |                       |
| Q14D02     | Library card status  |           | 0-1     | Code | LCF code list **PCS** |
| Q14D03     | Blocked card message | AL        | 0-1     | String                                          |                       |

#### Response

| *Id*       | *Element*            | *SIP2 ID*    | *Card.* | *Format*   | *Description* |
|------------|----------------------|-------|---------|------------|----------------------|
| **R14D01** | **Patron reference** |       | **1**   | **String** | **The identifier for the Patron record that has been successfully modified.** |

### 

### 15 Un-block patron account

This function is very similar to function 14 Block patron. A patron record is retrieved and the patron status and library card status are updated as appropriate. Any blocked card message is removed.

#### Request

| *Id*       | *Element*            | *SIP2 ID* | *Card.* | *Format*   | *Description* |
|------------|----------------------|-----------|---------|------------|---------------|
| **Q15D01** | **Patron reference** | **AA**    | **1**   | **String** |               |

#### Response

| *Id*       | *Element*            | *SIP2 ID*    | *Card.* | *Format*   | *Description* |
|------------|----------------------|-------|---------|------------|---------------|
| **R15D01** | **Patron reference** |       | **1**   | **String** | **The identifier for the Patron record that has been successfully modified.** |

### 

### 16 Reserve manifestation / item

The reserve function combines the following core functions:

-   Unless this is a confirmation or cancellation of reservation, retrieve the patron, item and/or manifestation records to check the patron’s status and ensure that reservation is permitted and to check for any applicable fees.

-   If reservation is to proceed, create a reservation record for the specified patron and manifestation or item. If cancelling a reservation, search for and either delete or modify the reservation record.

-   If fees apply, create a charge record for the applicable fee. If cancelling a reservation, search for and either delete or modify the charge record.

-   Modify the manifestation or item record to add a reference to the reservation record. If cancelling a previous reservation and deleting the associated reservation record, remove any reference to this record from the associated manifestation or item record.

-   Modify the patron record to update patron status and the number of items on loan and (optionally) add a reference to the reservation record. If cancelling a previous reservation and deleting the associated reservation record, remove any reference to this record from the patron record.

#### Request

| *Id*       | *Element*                     | *SIP2 ID*   | *Card.* | *Format* | *Description* |
|------------|-------------------------------|-------------|---------|----------|---------------|
| **Q16D01** | **Request type**              | **BX / BI** | **1**   | **Code** | **LCF code list RQT**                                                                                                                                                                    |
| **Q16D02** | **Patron identifier**         | **AA**      | **1**   | **String**                                          |                                                                                                                                                                                          |
| **Q16D03** | **Item entity type**          |             | **1**   | **Code**                                            | **LCF code list ENT – only code values '01' and '02' are valid**                                                                                                                         |
| **Q16D04** | **Item identifier**           | **AB**      | **1**   | **String**                                          |                                                                                                                                                                                          |
| Q16D05     | Reservation type              | BY          | 0-1     | Code     | LCF code list **RVT**                                                                                                                                                                    |
| Q16D06     | Pick-up institution reference | AO          | 0-1     | String                                              | The LMS identifier of the branch library or other institution where the items are to be picked up by the patron. Normally only included if the reservation type is ‘04’.                 |
| Q16D07     | Pick-up location reference    | BS          | 0-1     | String                                              | The LMS identifier of the location where the items are to be picked up by the patron. Normally only included if the reservation type is ‘04’, either instead of or additional to Q16D06. |
| Q16D08     | Reservation start date        |             | 0-1     | DateTime                                            | Only used in confirmations.                                                                                                                                                              |
| Q16D09     | Reservation expiry date       | AH          | 0-1     | DateTime                                            | The date by which a reserved item will be picked up by the patron.                                                                                                                       |
| Q16D10     | Charge acknowledged           | BO          | 0-1     | Flag                                                | Empty element indicating that a charge may be created.                                                                                                                                   |

#### Response

| *Id*   | *Element*                 | *SIP2 ID* | *Card.* | *Format* | *Description* |
|--------|---------------------------|-----------|---------|----------|---------------|
| R16D01 | Reservation reference     |           | 0-1     | String   | Either a reservation reference or a copy of the reservation record must be included in the response. |
| R16D02 | Reservation entity record |           | 0-1     |          | See E06.                                                                                             |
| R16D03 | Charge reference          | BT / BV   | 0-1     | String   | LMS identifier for the charge associated with reservation of this manifestation or item.             |

Stock management functions
--------------------------

### 21 Retrieve location list

This function is the same as core function 02 for retrieving a list of entities of type E04 Location.

### 22 Retrieve title classification scheme list

This function is the same as core function 02 for retrieving a list of entities of type E10 Title classification scheme.

### 23 Retrieve title classification list

This function is the same as core function 02 for retrieving a list of entities of type E11 Title classification code.

### 24 Retrieve (stock) item list

This function combines the core functions for retrieval of a list of manifestations (entity type E01) and list of stock items (entity type E02).

### 25 Retrieve selection criterion type list

This function is the same as the core function 02 for retrieving a list of entities of type E12 Selection criterion.

 
-

[1] The acronym "LCF" derives from an informal, abbreviated name for the standard, coined during its development: "Library Communication Framework".

[2] The term ‘data model’ is avoided here, because it could lead to confusion between this specification and specifications of other standard data models used in library applications, especially in RFID applications.

[3] The “cardinality” of an element is the number of times that an element is allowed to be included at that point in a message. The allowed values are ‘0-1’, ‘1’, ‘0-n’ and ‘1-n’. These are equivalent to ‘non-mandatory and non-repeatable’, ‘mandatory and non-repeatable’, ‘non-mandatory and repeatable’ and ‘mandatory and repeatable’.

[4] NOTE – Elements in responses that are specified to be mandatory, i.e. they have cardinality ‘1’ or ‘1-n’, are mandatory *unless there is an exception condition*, in which case none of the specific response elements is included. If appropriate, information from the request may be included in the exception description element to assist in determining the cause of the exception condition.

[5] The ONIX code lists are maintained by EDItEUR. For the latest issue of the ONIX code lists see [*http://www.editeur.org/14/Code-Lists/*](numbering.xml).