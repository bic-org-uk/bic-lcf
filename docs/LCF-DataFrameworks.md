---
title: Library Data Communication Framework for Terminal Applications (LCF)
menu: Library Data Communication Framework for Terminal Applications
weight: 1
---

# Book Industry Communication

## Library Interoperability Standards

## Library Data Communication Framework for Terminal Applications (LCF)[\[1\]](#Notes)

### Version x.x.0

### DRAFT

---

This document defines data frameworks for messages to meet the data communication requirements of a standard set of business functions for terminal applications within libraries.

The use of this document is subject to license terms and conditions that can be found at <http://www.bic.org.uk/files/bicstandardslicence.pdf>.

Terminal applications typically involve the use of terminal devices and systems by library staff and patrons to carry out a range of business functions that involve data communication between a user terminal and a Library Management System (LMS). The user terminal communicates with the LMS to request that a specific function be executed. Execution of the function will normally involve retrieval of or changes to information held in the LMS. The LMS will respond to the request in a variety of ways, depending upon the nature of the request. Terminal applications include self-service applications used by library patrons, as well as other applications used by library staff.

The standard business functions defined by this document are applicable both in circulation management and in stock / holdings management. User terminals may implement any reasonable subset of the functions defined by this document in either of these areas of application, or in others.

Each function is defined in terms of a pair of messages exchanged between the user terminal and the LMS. In terms of the client-server model for system architectures, the user terminal and LMS respectively take the roles of “client” and “server”. In the execution of each function the user terminal issues a request to the LMS and receives a response in return.

The information that these functions retrieve or change related to a number of "entities" that are fundamental to library management. The principal entities involved are:

-   manifestations (titles) in a library's catalogues

-   items – individual copies of manifestations – in a library's stock / holdings

-   patrons – users entitled to borrow items from a library

-   locations – where items may be located, usually inside a library; the "home library" locations of patrons; or locations associated with library authorities/institutions

-   loans – of items to patrons

-   reservations – of manifestations or specific copies of manifestations for patrons

-   charges – fees and fines incurred by patrons for various reasons

-   payments – made by patrons in respect of charges incurred

-   contacts – contact details for persons or organizations represented by patrons.

Each entity and each request and response message-pair is defined in terms of a data framework[\[2\]](#Notes), or schema. A data framework specifies how to describe an entity in terms of a collection of properties (identifiers, name, etc.), and how to construct a message (request or response) in terms of entity descriptions and other parameters. Each data element and composite is defined in terms of what data it may contain and its meaning.

This document is inevitably influenced by the widespread use of the 3M™ Standard Interchange Protocol Version 2.00 (SIP2) by library systems. Where appropriate, the relationship between an LCF function or data element and the corresponding SIP2 message type or field is indicated, to promote interoperability wherever possible between SIP2 and the LCF standard.

Data frameworks for terminal applications
=========================================

<a name="entities"></a>Information entity types
------------------------

Data frameworks are defined for the following principal types of information entity:

-   [Manifestations](#e01)

-   [Items (individual copies of manifestations)](#e02)

-   [Patrons (identified library users)](#e03)

-   [Locations](#e04)

-   [Loans](#e05)

-   [Reservations](#e06)

-   [Charges](#e07)

-   [Payments](#e08)

-   [Contacts (contact details for persons or organisations represented by patrons)](#e09)

-   [Library authorities/institutions](#e14)

The data frameworks for the following other types of information entity are also defined:

-   [Classification schemes (e.g. for manifestation classification) - *DEPRECATED in v1.2.0*](#e10)

-   [Classification codes - *DEPRECATED in v1.2.0*](#e11)

-   [Entity properties recognised by the LMS (used for constructing entity selection criteria - *DEPRECATED in v1.0.1*)](#e12)

-   [Patron authorisation codes](#e13)

-   [Message / alert](#e15)

Each of the data frameworks for entity types defines the properties associated with that entity type. These properties may be either simple data elements or composites: more complex structures, being groupings of data elements and other composites.

<a name="functions"></a>Terminal application functions
------------------------------

Data frameworks are defined for the following terminal application functions:

-   Core functions that can theoretically be applied to any type of information entity

    -   [Retrieve entity record](#f01)

    -   [Retrieve entity list](#f02)

    -   [Create new entity record](#f03)

    -   [Modify existing entity record](#f04)

    -   [Delete/terminate entity record](#f05)

-   Applications of the core functions to circulation management

    -   [Check-out / renewal of item to patron](#f11)

    -   [Check-in item from patron](#f12)

    -   [Make / confirm patron payment](#f13)

    -   [Block patron account](#f14)

    -   [Un-block patron account](#f15)

    -   [Reserve title](#f16)
    
    -   [Set/reset patron password](#f17)
    
    -   [Set/reset patron PIN - *(Added in v1.2.0)*](#f18)

-   Applications of the core functions to stock management

    -   [Retrieve location list](#f21)

    -   [Retrieve item classification scheme list](#f22)

    -   [Retrieve classification list](#f23)

    -   [Retrieve stock / holding list](#f24)

    -   [Retrieve selection criterion type list - *(DEPRECATED in v1.0.1)*](#f25)

    -   [Retrieve list of available items at a specific location](#f26)

-   Applications of the core functions for various other purposes

    -   [Apply charge to patron account](#f31)

    -   [Acknowledge message/alert](#f32)

Each of the data frameworks for terminal application functions assumes that a function is implemented as a pair of messages exchanged between the terminal application and the LMS, connected over a network. The terminal application initiates the exchange by sending a request to the LMS to execute the function in question. The LMS then sends a response to the terminal application, indicating the outcome of the request.

Each entity and function is defined in terms of data elements. Data elements may be grouped into composites. Each element is identified by a number prefixed by ‘D’ for simple data elements and by ‘C’ for composite data elements.

In addition to defining data frameworks for each function, this standard also defines a data framework for common data components used to convey user identification information and other messaging control data in request and response messages.

NOTE – This document does not mandate that any specific underlying communication infrastructure be employed for connecting the terminal application and the LMS, and therefore does not mandate whether or how the common data components should be used. Their inclusion is to facilitate mapping between existing legacy messaging protocols (e.g. SIP2) and LCF.

Data frameworks for information entity types
--------------------------------------------

### <a name="e01"></a> E01 MANIFESTATION
[Back to entity list](#entities)

#### Description

An identified manifestation of an abstract work, e.g. a book, magazine, newspaper or recording (analogue or digital). Sometimes informally referred to as a "title", but this term is reserved in LCF for the title of a manifestation.

#### Properties

| *Id*       | *Element*                  | *SIP2 ID* | *Card.*[\[3\]](#Notes)                                                    | *Format*   | *Description*                  |
|------------|----------------------------|-----------|----------|------------|--------------------------------|
| **E01D01** | **Identifier**             |           | **1**[\[4\]](#Notes)                                                    | **String** | **The LCF identifier used when referring to this manifestation entity.**                                                                      |
| *E01C02*   | *Additional identifier*    |           | 1-n      |            | Composite element containing details of an additional identifier for the manifestation. |
| E01D02.1   | Identifier type            |           | 1        | Code       | Manifestation identifier type from ONIX Code List 5[\[5\]](#Notes).<br/>*LCF Code List MNI deleted in vx.x.0*                                                                                             |
| E01D02.2   | Identifier type name       |           | 0-1      | String     | If the identification scheme is proprietary, the name of the scheme. |
| E01D02.3   | Identifier value           |           | 1        | String     | The identifier string.         |
| E01D22     | Manifestation type         |           | 0-1      | Code       | LCF code list **[MNT](LCF-CodeLists.md#MNT)**<br/>*Added vx.x.0*                 |
| *E01C03*   | *Media type / format*      | CK        | 0-n      |            |                                |
| E01D03.1   | Media type / format scheme |           | 1        | Code       | LCF code list **[MES](LCF-CodeLists.md#MES)**<br/>Allowed values to include ONIX code lists 150 and 175, SIP2 media type and proprietary                                                                       |
| E01D03.2   | Scheme name                |           | 0-1      | String     | Name or description of proprietary scheme |
| E01D03.3   | Scheme code                |           | 1        | String     | Code from the specified scheme |
| *E01C04*   | *Title*                    | AJ        | 0-n      |            | Composite element containing a title of the manifestation. Repeatable for multiple types of title (e.g. full title, abbreviated title)                                                                     |
| E01D04.1   | Title type                 |           | 1        | Code       | Manifestation title type from ONIX Code List 15[\[5\]](#Notes).<br/>*Specific LCF Code List TTL deleted in vx.x.0*                                                                                             |
| E01D04.2   | Title text                 |           | 1        | String     |                                |
| E01D04.3   | Subtitle                   |           | 0-1      | String     |                                |
| *E01C05*   | *Contributor*              |           | 0-n      |            | Composite element containing author or other contributor. Repeatable for multiple contributors. |
| E01D05.1   | Contributor role           |           | 1        | Code       | Contributor role code from ONIX Code List 17[\[5\]](#Notes). |
| E01D05.2   | Contributor name           |           | 0-1      | String     | Either a contributor name or an unnamed contributor code must be included in each item contributor composite.                                                                                         |
| E01D05.3   | Unnamed contributor        |           | 0-1      | Code       | Unnamed contributor(s) type from ONIX Code List 19[\[5\]](#Notes).<br/>*Specific LCF Code List UNC deleted in vx.x.0*                                                                                         |
| *E01C06*   | *Series*                   |           | 0-1      |            | Composite element containing information about a series of which this manifestation is a member.                                            |
| *E01C06.1* | *Series title*             |           | 0-n      |            | Composite element containing the title of the series. Repeatable for multiple types of title. |
| E01D06.1.1 | Title type                 |           | 1        | Code       | Series title type from ONIX Code List 15[\[5\]](#Notes).<br/>*Specific LCF Code List TTL deleted in vx.x.0*                                                                                             |
| E01D06.1.2 | Title text                 |           | 1        | String     |                                |
| E01D06.1.3 | Subtitle                   |           | 0-1      | String     |                                |
| E01D06.2   | Volume or part             |           | 0-1      | String     | Volume or part number within series |
| E01D06.3   | Other manifestation within series|     | 0-n      | String     | The LCF identifier of another manifestation entity in the same series. Repeatable if there is more than one other manifestation in the same series.                                                          |
| E01D07     | Edition statement          |           | 0-1      | String     | Edition of the item            |
| E01D08     | Publisher name             |           | 0-1      | String     | Name of the publisher of the manifestation |
| E01D09     | Year of publication        |           | 0-1      | YYYY       | Year of publication of the manifestation |
| E01D23     | Serial holding statement   |           | 0-1      | String     | Description of the library's holding of a serial title. May only be included if the manifestation type (E01D22) is specified to be 'Serial title' (MNT02).<br/>*Added vx.x.0* |
| E01D25     | Serial issue enumeration   |           | 0-1      | String     | Numbers associated with a serial issue, as they appear on the title page; typically a volume and/or issue number. May only be included if the manifestation type (E01D22) is specified to be 'Serial issue' (MNT03).<br/>*Added vx.x.0*  |
| E01D26     | Serial issue chronology    |           | 0-1      | String     | Dates, periods or seasons associated with a serial issue, as they appear on the title page, for example the year for an annual publication. May only be included if the manifestation type (E01D22) is specified to be 'Serial issue' (MNT03).<br/>*Added vx.x.0*  |
| *E01C10*   | *Classification*           |           | 0-n      |            |                                |
| E01D10.1   | Classification scheme      |           | 1        | Code       | LCF code list **[LCS](LCF-CodeLists.md#LCS)**          |
| E01D10.2   | Scheme name                |           | 0-1      | String     | Name or description of proprietary scheme |
| E01D10.3   | Scheme code                |           | 1        | String     |                                |
| E01D11     | Item cover art             |           | 0-n      | URI        | URI reference to cover art resource |
| E01D12     | Other description          |           | 0-1      | String     | Other descriptive information about the manifestation. |
| *E01C24*   |*Associated manifestation*  |           | 0-n      |            | *Added vx.x.0*                 |
| E01D24.1   | Manifestation association type|        | 1        | Code       | LCF code list **[MNA](LCF-CodeLists.md#MNA)**              |
| E01D24.2   | Manifestation reference    |           | 1-n      | String     |                                |
| *E01C13*   | *Check-out restriction*    |           | 0-n      |            | Composite element containing details of a restriction on check-out of this manifestation. Repeatable for multiple restriction types.                                                                     |
| E01D13.1   | Restriction type           |           | 1        | Code       | LCF code list **[CRT](LCF-CodeLists.md#CRT)**<br/>The type of restriction imposed. |
| E01D13.2   | Restriction code / value   |           | 1        | String     | Restriction value of the specified type. |
| E01D13.3   | Restriction note           |           | 0-1      | String     | Free-text note or description of the restriction. |
| *E01C14*   | *Check-out fee*            | BO        | 0-n      |            | Composite element containing details of any fee required to check out this manifestation. Repeatable if there are fees of different types. NOTE – Infrequently used, as fees are rarely fixed for an individual manifestation and must be calculated at check-out time, based upon a variety of factors.                                                                               |
| E01D14.1   | Fee type                   | BT        | 1        | Code       | LCF code list **[CHT](LCF-CodeLists.md#CHT)**          |
| E01D14.2   | Fee amount                 | BV        | 1        | Value      | Currency value                 |
| E01D14.3   | Fee currency               | BH        | 0-1      | Code       | ISO three-letter currency code, e.g. ‘GBP’ |
| E01D15     | Number of patrons in hold queue | CF   | 0-1R[\[6\]](#Notes) | Integer |                        |
| E01D16     | Manifestation record reference  |      | 0-1      | String     | A reference (e.g. URI or query string) for retrieving a catalogue record for this manifestation from the LMS or online catalogue.                                                                              |
| **E01D17** | **Manifestation status**   |           | **1**    | **Code**   | LCF code list **[MNS](LCF-CodeLists.md#MNS)**          |
| E01D18     | Number of copies in stock / holding |  | 0-1R     | Integer    |                                |
| E01D19     | Item reference             |           | 0-nR     | String     | Reference to an item that is a copy of this manifestation |
| E01D20     | Reservation reference      |           | 0-nR     | String     | If this manifestation has been reserved, a reference to the reservation record in the hold queue. Repeatable if there are multiple reservations in the “hold queue”.                                      |
| *E01C21*   | *Manifestation note*       |           | 0-n      |            | A note attached to the LMS record for this title. |
| E01D21.1   | Note type                  |           | 0-1      | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)**          |
| E01D21.2   | Note date-time             |           | 0-1      | DateTime   |                                |
| E01D21.3   | Note text                  |           | 1        | String     |                                |

***

### <a name="e02"></a> E02 ITEM
[Back to entity list](#entities)

#### Description

An identified copy of a manifestation that is in a library's stock / holding.

#### Properties

| *Id*       | *Element*                  | *SIP2 ID* | *Card.*  | *Format*   | *Description*                  |
|------------|----------------------------|-----------|----------|------------|--------------------------------|
| **E02D01** | **Identifier**             | **AB**    | **1**[\[4\]](#Notes)                                                   | **String** | **The LCF identifier normally used when referring to this item entity.**                                                                          |
| *E02C02*   | *Additional identifier*    |           | 0-n      |            | Composite element containing details of an additional identifier for this item.                                                                     |
| E02D02.1   | Identifier type            |           | 1        | Code       | LCF code list **[IMI](LCF-CodeLists.md#IMI)**<br/>The identification scheme.                                                                                         |
| E02D02.2   | Identifier type name       |           | 0-1      | String     | If the identification scheme is proprietary, the name of the scheme.                                                                           |
| E02D02.3   | Identifier value           |           | 1        | String     | The identifier string.         |
| **E02D03** |**Manifestation reference** |           | **1**    | **String** | **Reference to the manifestation of which this item is an instance.**                                                                              |
| E02D04     | Item properties            | CH        | 0-1      | String     | Descriptive information about this item.                                                                                                          |
| E02D05     | Item owner                 | BG        | 0-1      | String     | A reference to an Institution entity (see E14) representing the owner of this item *(Modified description in v1.0.1)*                               |
| *E02C06*   | *Associated location*      |           | 0-n      |            | A location associated with this item.|
| E02D06.1   | Location association type  |           | 1        | Code       | LCF code list **[LAT](LCF-CodeLists.md#LAT)**                                                                                                  |
| E02D06.2   | Location reference         |           | 1        | String     | *Cardinality corrected in v1.0.1* |
| E02D07     | Item sensitive media warning |         | 1        | Code       | LCF code list **[MEW](LCF-CodeLists.md#MEW)**<br/>Flag indicating that the item contains a media component that is sensitive to some security setting devices.                                                                                                       |
| E02D08     | Desensitize item security  |           | 0-1      | Code       | LCF code list **[SCD](LCF-CodeLists.md#SCD)**<br/>Flag indicating that the security should or should not be desensitized / removed on check-out. |
| *E02C09*   | *Check-out restriction*    |           | 0-n      |            | Composite element containing details of a restriction on check-out of this item. Repeatable for multiple restriction types. Overrides the same check-out restrictions specified for the title.                                                                          |
| E02D09.1   | Restriction type           |           | 1        | Code       | LCF code list **[CRT](LCF-CodeLists.md#CRT)**                                                                                                  |
| E02D09.2   | Restriction code / value   |           | 1        | String     | Restriction value of the specified type.                                                                                                          |
| E02D09.3   | Restriction note           |           | 0-1      | String     | Free-text note or description of the restriction.                                                                                                   |
| *E02C10*   | *Check-out fee*            | BO        | 0-n      |            | Composite element containing details of any fee required to check out this item. Repeatable if there are fees of different types. NOTE – Rarely used, as fees are rarely fixed for an item and must be calculated at check-out time, based upon a variety of factors. If included, Overrides the same check-out fees specified for the title.                                           |
| E02D10.1   | Fee type                   | BT        | 1        | Code       | LCF code list **[CHT](LCF-CodeLists.md#CHT)**          |
| E02D10.2   | Fee amount                 | BV        | 1        | Value      | Currency value                 |
| E02D10.3   | Fee currency               | BH        | 0-1      | Code       | ISO three-letter currency code, e.g. ‘GBP’                                                                                                          |
| **E02D11** | **Circulation status**     |           | **1**    | **Code**   | **LCF code list [CIS](LCF-CodeLists.md#CIS)**          |
| E02D12     | Reservation reference      |           | 0-nR     | String     | If this item has been reserved, a reference to the reservation record in the hold queue. Repeatable if there are multiple reservations in the “hold queue”.                                                                                                        |
| E02D13     | Number of patrons in hold queue | CF   | 0-1R     | Integer    | Included only if this specific item is specified in the hold queue.                                                                                |
| E02D14     | Loan reference             |           | 0-1R     | String     | If this item is on loan, a reference to the active loan record is mandatory.                                                                        |
| E02D15     | Condition code / value     |           | 0-n      | Code       | A proprietary (i.e. LMS-specific) code value indicating the condition of the item.                                                               |
| E02D16     | Condition description      |           | 0-1      | String     | A textual description of the condition of the item.                                                                                         |
| *E02C17*   | *Item note*                |           | 0-n      |            | A note attached to the LMS record for this item.                                                                                                 |
| E02D17.1   | Note type                  |           | 0-1      | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)**          |
| E02D17.2   | Note date-time             |           | 0-1      | DateTime   |                                |
| E02D17.3   | Note text                  |           | 1        | String     |                                |


***

### <a name="e03"></a> E03 PATRON
[Back to entity list](#entities)

#### Description

An identified person or organization permitted to borrow an item from a library.

NOTE – Contact information is held in separate contact records for security and privacy reasons.See E09 below.

#### Properties

| *Id*       | *Element*                  | *SIP2 ID* | *Card.*  | *Format*   | *Description*                  |
|------------|----------------------------|-----------|----------|------------|--------------------------------|
| **E03D01** | **Identifier**             | **AA**    | **1**[\[4\]](#Notes)                                                    | **String** | **The LCF entity identifier normally used when referring to this patron.**                                                                          |
| E03D26     | Barcode identifier         |           | 0-1      | String     | The identifier on the patron's library card. Mandatory unless the LCF entity identifier is the same identifier.<br/>*Added in v1.0.1*            |
| *E03C27*   | *Additional identifier*    |           | 0-n      |            | Composite element containing details of an additional identifier for this patron.<br/>*Added in v1.0.1*                                                |
| E03D27.1   | Identifier type            |           | 1        | Code       | LCF code list **[PNI](LCF-CodeLists.md#PNI)**<br/>The identification scheme.                                                                                         |
| E03D27.2   | Identifier type name       |           | 0-1      | String     | If the identification scheme is proprietary, the name of the scheme.                                                                           |
| E03D27.3   | Identifier value           |           | 1        | String     | The identifier string.         |
| **E03D22** | **Name**                   | **AE**    | **1**    | **String** | **Name of primary contact for this patron.**<br/>*Added in v1.0.1*                                                                                   |
| *E03C36*   | Structured name            |           | 0-1      |            | Name of primary contact in structure form, following the model provided by ONIX. Only for use with personal names. Note that, for display purposes, structured names would normally be re-assembled in the order specified here.<br/>*Added in vx.x.0*   |
| E03D36.1   | Title before names         |           | 0-1      | String     | Qualifications and/or titles preceding a person’s names, eg ‘Professor’ or ‘HRH Prince’ or ‘Saint’.                                        |
| E03D36.2   | Names before key           |           | 0-1      | String     | Name(s) and/or initial(s) preceding a person’s key name(s), eg 'James J.'                                                                   |
| E03D36.3   | Prefix to key              |           | 0-1      | String     | A prefix which precedes the key name(s) but which is not to be treated as part of the key name, eg ‘van’ in Ludwig van Beethoven. This element may also be used for titles that appear after given names and before key names, eg ‘Lord’ in Alfred, Lord Tennyson.                    |
| E03D36.4   | Key names                  |           | 1        | String     | Key name(s), ie the name elements normally used to open an entry in an alphabetical list, eg ‘Smith’ or ‘Garcia Marquez’ or ‘Madonna’ or ‘Francis de Sales’ (in Saint Francis de Sales).  |
| E03D36.5   | Names after key            |           | 0-1      | String     | Name suffix, or name(s) following a person’s key name(s), eg ‘Ibrahim’ (in Anwar Ibrahim).                                                |
| E03D36.6   | Suffix to key              |           | 0-1      | String     | A suffix following a person’s key name(s), eg ‘Jr’ or ‘III’.                                                                                   |
| E03D36.7   | Letters after names        |           | 0-1      | String     | Qualifications and honors following a person’s names, eg ‘CBE FRS’.                                                                            |
| E03D36.8   | Titles after names         |           | 0-1      | String     | Titles following a person’s names, eg ‘Duke of Edinburgh’.                                                                              |
| E03D02     | Contact reference          |           | 0-n      | String     | Contact details for this patron<br/>*Repeatable in v1.0.1*                                                                                 |
| E03D23     | Language                   |           | 0-1      | Code       | Language for communication with primary contact<br/>ISO three-letter language code, e.g. ‘eng’<br/>*Added in v1.0.1*                              |
| *E03C03*   | *Associated location*      |           | 0-n      |            | A location associated with this patron.                                                                                                        |
| E03D03.1   | Location association type  |           | 1        | Code       | LCF code list **[LAT](LCF-CodeLists.md#LAT)**          |
| E03D03.2   | Location reference         |           | 1        | String     | *Cardinality corrected in v1.0.1* |
| E03D35     | Patron's home institution  |           | 0-1      | String     | Patron's home library/institution as represented by an Authority / Institution entity (E14)<br/>*(Added in v1.0.1, Id corrected in v1.1.0)*                                    |
| E03D04     | Patron status              |           | 0-nR     | Code       | LCF code list **[PNS](LCF-CodeLists.md#PNS)**              |
| **<strike>E03D04.1</strike>** | **<strike>Condition</strike>** |            | **<strike>1-n</strike>** | **<strike>Code</strike>** |                                                                   *Removed in v1.0.1* |
| *E03C24*   | *Library card status information* |    | 0-1R     |            | Status information on the patron's library card.<br/>*Added in v1.0.1*                                                                               |
| E03D24.1   | Library card status        |           | 1R       | Code       | LCF code list **[PCS](LCF-CodeLists.md#PCS)**<br/>*ID changed from E03C05 in v1.0.1*                                                           |
| E03D24.2   | Blocked card message       | AL        | 0-1R     | String     |*ID changed from E03D06 in v1.0.1* |
| E03D28     | Patron category            |           | 0-1      | String     | Library-specific code<br/>*Added in v1.0.1*                                                                                                        |
| E03D29     | Patron tag                 |           | 0-n      | String     | Library-specific tag<br/>*Added in v1.0.1*                                                                                                        |
| E03D32     | Patron authorisation reference |  | 0-n      | String     | Reference to an authorisation assigned to this patron - See [E13](#e13).<br/>*Added in v1.0.1*                                                                   |
| E03D30     | Patron expiration date     |           | 0-1      | Date       | Date upon which this Patron account expired or is due to expire<br/>*Added in v1.0.1*                                                                 |
| *E03C33*   | *Associated patron group*  |           | 0-n    |            | A group of patrons with which this patron is associated either as a leader or a member.<br/>*Added in v1.0.1*                                        |
| E03D33.1   | Patron group association type |        | 1        | Code       | LCF code list **[PGP](LCF-CodeLists.md#PGP)**                                                                                                  |
| E03D33.5   | Patron group type          |           | 0-1      | String     | A code assigned by the LMS, indicating the type of group, e.g. 'family', 'school'                                                                     |
| E03D33.2   | Patron group identifier    |           | 0-1      | String     | A unique identifier of the group |
| E03D33.3   | Lead patron reference      |           | 0-n      | String     | A leader of the group. A leader is a Patron entitled to perform actions on behalf of any member of the group.                                       |
| E03D33.4   | Patron reference           |           | 0-n      | String     | Other member of the group. Members of a group who are not leaders may only perform actions on their own account, not on behalf of other group members. |
| E03D07     | Loan reference             |           | 0-nR     | String     | A loan made to this patron. May include references to past as well as current (active) loans until the loan records are deleted.               |
| E03D08     | Number of items on loan    |           | 0-1R     | Integer    | Only applies to active loans.  |
| E03D09     | Loan items limit           | CB        | 0-1      | Integer    |                                |
| E03D10     | Number of overdue items    |           | 0-1R     | Integer    |                                |
| E03D11     | Overdue items limit        | CA        | 0-1      | Integer    |                                |
| E03D12     | Number of recalled items   |           | 0-1R     | Integer    |                                |
| E03D13     | Number of items for which fees other than fines are due |  | 0-1R   | Integer    |              |
| E03D14     | Number of items for which fines are due |  | 0-1R | Integer    |                                |
| E03D15     | Reservation reference      |           | 0-nR     | String     | A reservation associated with this patron                                                                                                         |
| E03D16     | Number of available hold items |       | 0-1R     | Integer    |                                |
| E03D17     | Number of unavailable hold items |     | 0-1R     | Integer    |                                |
| E03D18     | Hold items limit           | BZ        | 0-1      | Integer    |                                |
| E03D19     | Charge reference           |           | 0-nR     | String     | A charge associated with this patron. It is recommended that a patron record should include references to all unpaid charges.                        |
| *E03C20*   | *Charge limit*             | CC        | 0-n      |            | Composite element. The limit on charges (fees or fines) that this patron is allowed to owe. Repeatable if separate limits are specified for charges of different types.                                                                                               |
| E03D20.1   | Charge type                | BT        | 0-1      | Code       | LCF code list **[CHT](LCF-CodeLists.md#CHT)**<br/>May only be omitted if there is only one occurrence of the charge limit composite, in which case the amount is the limit on the aggregate of charges of all types.                                                  |
| E03D20.2   | Charge amount              | BV        | 1        | Value      | Currency value                 |
| E03D20.3   | Charge currency            | BH        | 0-1      | Code       | ISO three-letter currency code, e.g. ‘GBP’                                                                                                          |
| *E03C31*   | *Deposit balance*          |           | 0-1      |            | Balance of funds deposited, if the Patron maintains a balance available for settling future charges or fines<br/>*Added in v1.0.1*                          |
| E03D31.1   | Deposit amount             |           | 1        | Value      | Currency value                 |
| E03D31.2   | Deposit currency           |           | 0-1      | Code       | ISO three-letter currency code, e.g. ‘GBP’                                                                                                          |
| E03C34     | Associated message/alert   |           | 0-n      |            | A message/alert for display<br/>*Added in v1.0.1*                                                                                                        |
| E03D34.1   | Message reference          |           | 1        | String     |                                |
| E03D34.2   | Message delivery status    |           | 0-1      | Code       | LCF code list **[MAD](LCF-CodeLists.md#MAD)**<br/>                                                                                             |
| *E03C21*   | *Patron note*              |           | 0-n      |            | A note attached to the LMS record for this patron.                                                                                                        |
| E03D21.1   | Note type                  |           | 0-1      | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)**          |
| E03D21.2   | Note date-time             |           | 0-1      | DateTime   |                                |
| E03D21.3   | Note text                  |           | 1        | String     |                                |
| E03D25     | Date of birth              |           | 0-1      | Date       | Date of birth of the primary contact for this patron.<br/>*Added in v1.0.1*                                                                            |

### <a name="e04"></a> E04 LOCATION
[Back to entity list](#entities)

#### Description

A location associated with a library, such as:
-  an identified place where an item may be located, either inside or outside a library;
-  a library location associated with a patron, typically the patron's "home library";
-  a library location associated with a library authority/institution, such as the main or branch site of a library.

#### Properties

| *Id*       | *Element*                  | *SIP2 ID* | *Card.*  | *Format*   | *Description*                  |
|------------|----------------------------|-----------|----------|------------|--------------------------------|
| **E04D01** | **Identifier**             |           | **1**[\[4\]](#Notes)                                                    | **String** | **The LCF entity identifier normally used when referring to this location.**                                                                        |
| *E04C02*   | *Additional identifier*    |           | 0-n      |            | Composite element containing details of an additional identifier for this location.                                                                 |
| E04D02.1   | Identifier type            |           | 1        | Code       | LCF code list **[LOI](LCF-CodeLists.md#LOI)**<br/>The identification scheme                                                                                          |
| E04D02.2   | Identifier type name       |           | 0-1      | String     | If the identification scheme is proprietary, the name of the scheme.                                                                           |
| E04D02.3   | Identifier value           |           | 1        | String     | The identifier string.         |
| E04D03     | Location name              |           | 0-1      | String     |                                |
| E04D04     | Location type              |           | 0-1      | Code       | LCF code list **[LOT](LCF-CodeLists.md#LOT)**  |
| E04D09     | Location purpose           |           | 0-n      | Code       | LCF code list **[LOP](LCF-CodeLists.md#LOP)**<br/>*Added in v1.2.0* |
| E04D05     | Location description       |           | 0-1      | String     |                                |
| E04D07     | Contact reference          |           | 0-n      | String     | *Added in v1.0.1*                 |
| *E04C08*   | *Associated location*      |           | 0-n      |            | A location associated with this location.<br/>*Added in v1.0.1*                                                                                            |
| E04D08.1   | Location association type  |           | 1        | Code       | LCF code list **[LAT](LCF-CodeLists.md#LAT)**          |
| E04D08.2   | Location reference         |           | 1        | String     | *Cardinality corrected in v1.0.1* |
| *E04C06*   | *Location note*            |           | 0-n      |            | A note attached to the LMS record for this location.                                                                                             |
| E04D06.1   | Note type                  |           | 0-1      | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)**          |
| E04D06.2   | Note date-time             |           | 0-1      | DateTime   |                                |
| E04D06.3   | Note text                  |           | 1        | String     |                                |

***

### <a name="e05"></a> E05 LOAN
[Back to entity list](#entities)

#### Description

An identified event in which one or more items have been loaned to a patron.

#### Properties

| *Id*       | *Element*                  | *SIP2 ID* | *Card.*  | *Format*   | *Description*                  |
|------------|----------------------------|-----------|----------|------------|--------------------------------|
| **E05D01** | **Loan identifier**        |           | **1**[\[4\]](#Notes)                                                    | **String** | **The LCF entity identifier used when referring to this loan.**                                                                                 |
| **E05D02** | **Patron reference**       | **AA**    | **1**    | **String** |                                |
| **E05D03** | **Item reference**         | **AB**    | **1**    | **String** | **A loan applies to a single item** |
| **E05D04** | **Loan start date-time**   |           | **1**    |**DateTime**|                                |
| E05D05     | Loan end due date-time     |           | 0-1      | DateTime   | Omitted only if the loan is permanent or doesn't have a specific end date-time.                                                                         |
| E05D06     | Loan end date-time         |           | 0-1      | DateTime   | Actual end date-time. Used when recording past loans.                                                                                                    |
| **E05D07** | **Loan status**            |           | **1-n**  | **Code**   | **LCF code list [LOS](LCF-CodeLists.md#LOS)**          |
| *E05C13*   | Digital item access link   |           | 0-n      |            | A link to access the loaned item, typically only generated when the Loan entity is retrieved<br/>*Added in v1.0.1*                                            |
| E05D13.1   | Link type                  |           | 1        | Code       | LCF code list [LKT](LCF-CodeLists.md#LKT)<br/> |
| E05D13.2   | Link                       |           | 1        | String     |                                |
| E05D08     | Previous loan reference    |           | 0-1      | String     | Used when loan is a renewal                                                                                                        |
| E05D09     | Renewal loan reference     |           | 0-1R     | String     | Used when loan is superceded by a renewal loan                                                                                                           |
| E05D14     | Reservation reference      |           | 0-1R     | String     | Only included if maintaining records of reservations that have ended with the item being loaned to the patron.<br/>*Added in v1.1.0* |
| E05D10     | Recall notice date-time    | CJ        | 0-nR     | DateTime   | The date on which a recall notice for the item on loan was issued.                                                                                       |
| E05D11     | Charge reference           |           | 0-nR     | String     |                                |
| *E05C12*   | *Loan note*                |           | 0-n      |            | A note attached to the LMS record for this loan.                                                                                                          |
| E05D12.1   | Note type                  |           | 0-1      | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)**          |
| E05D12.2   | Note date-time             |           | 0-1      | DateTime   |                                |
| E05D12.3   | Note text                  |           | 1        | String     |                                |

***

### <a name="e06"></a> E06 RESERVATION
[Back to entity list](#entities)

#### Description

An identified event in which one or more titles have been reserved for a patron.

#### Properties

| *Id*       | *Element*                   | *SIP2 ID* | *Card.* | *Format*   | *Description*                  |
|------------|-----------------------------|-----------|---------|------------|--------------------------------|
| **E06D01** | **Reservation identifier**  |           | **1**[\[4\]](#Notes)                                                    | **String** | **The LCF entity identifier used when referring to this reservation.**                                                                          |
| **E06D02** | **Reservation type**        |           | **1**   | **Code**   | **LCF code list [RVT](LCF-CodeLists.md#RVT)**          |
| **E06D03** | **Patron reference**        | **AA**    | **1**   | **String** |                                |
| E06D04     | Manifestation reference     |           | 0-1     | String     | A reservation applies to either a single manifestation or a single item. Each reservation must have one or the other but not both.               |
| E06D05     | Item reference              |           | 0-1     | String     |                                |
| E06D06     | Reservation start date-time |           | 0-1     | DateTime   |                                |
| E06D07     | Pick-up site reference      | AO        | 0-1     | String     | The LCF entity identifier of the branch library or other site where the items are to be picked up by the patron. Normally only included if the reservation type is ‘04’.                                                                                      |
| E06D08     | Pick-up location reference  |           | 0-1     | String     | The LCF entity identifier of the location within the site where the items are to be picked up by the patron. Normally only included if the reservation type is ‘04’, either instead of or additional to E06D07.                                           |
| E06D09     | Pickup by date-time         | CM        | 0-1     | DateTime   | The date and optionally time by which the reserved item must be collected by the patron.                                                       |
| E06D10     | End date-time               |           | 0-1     | DateTime   | The date-time when the reservation ended, when the item was checked-out to the patron who had reserved it. Used when recording past reservations. |
| **E06D11** | **Reservation status**      |           | **1**   | **Code**   | **LCF code list [RVS](LCF-CodeLists.md#RVS)**          |
| E06D15     | Position in hold queue      |           | 0-1     | Integer    | Position of the reserved item in the hold queue<br/>*Added in v1.0.1*                                                                               |
| E06D12     | Loan reference              |           | 0-1R    | String     | Only included if maintaining records of reservations that have ended with the item being loaned to the patron.                                      |
| E06D13     | Charge reference            |           | 0-nR    | String     | Reference to a charge incurred by this reservation.|
| *E06C16*   | *Suspension period*         |           | 0-n     |            | A period during which this Reservation is suspended.<br/>*Added in v1.1.0*|
| E06D16.1   | Start date-time             |           | 0-1     | DateTime   |                                                    |
| E06D16.2   | End date-time               |           | 0-1     | DateTime   |                                                    |
| *E06C14*   | *Reservation note*          |           | 0-n     |            | A note attached to this reservation.|
| E06D14.1   | Note type                   |           | 0-1     | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)**          |
| E06D14.2   | Note date-time              |           | 0-1     | DateTime   |                                |
| E06D14.3   | Note text                   |           | 1       | String     |                                |

***

### <a name="e07"></a> E07 CHARGE
[Back to entity list](#entities)

#### Description

An identified charge made to a patron. May be a fee or a fine.

#### Properties

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*   | *Description*                  |
|------------|----------------------------|------------|---------|------------|--------------------------------|
| **E07D01** | **Charge identifier**      | **CG**     | **1**[\[4\]](#Notes)                                                    | **String** | **The LCF entity identifier used when referring to this charge.**                                                                               |
| **E07D02** | **Patron reference**       | **AA**     | **1**   | **String** |                                |
| **E07D03** | **Charge type**            | **BT**     | **1**   | **Code**   | **LCF code list [CHT](LCF-CodeLists.md#CHT)<br/>The type or category of charge.**                                                                                          |
| **E07D04** | **Charge status**          |            | **1**   | **Code**   | **LCF code list [CHS](LCF-CodeLists.md#CHS)**          |
| E07D05     | Charge description         |            | 0-1     | String     | Free-text description of charge. |
| E07D06     | item reference             | AB         | 0-1     | String     | An item to which this charge relates. Normally the single most precise reference (e.g. loan) will be sufficient.                            |
| E07D07     | Manifestation reference    |            | 0-1     | String     | A manifestation to which this charge relates. Normally the single most precise reference (e.g. loan) will be sufficient.                            |
| E07D08     | Loan reference             |            | 0-1     | String     | A loan to which this charge relates. Normally the single most precise reference (e.g. loan) will be sufficient.                                     |
| E07D09     | Reservation reference      |            | 0-1     | String     | A reservation to which this charge relates. Normally the single most precise reference (e.g. loan) will be sufficient.                            |
| E07D10     | Charge creation date-time  |            | 0-1     | DateTime   | The date and optionally time on which the charge was created / recorded.                                                                       |
| E07D11     | Payment due date-time      |            | 0-1     | DateTime   | The date and optionally time on which the charge becomes due for payment.                                                                      |
| **E07D12** | **Gross charge amount**    | **BV**     | **1**   | **Value**  | **Currency value of original charge**                                                                                                       |
| E07D13     | Charge currency            | BH         | 0-1     | Code       | ISO three-letter currency code, e.g. ‘GBP’                                                                                                          |
| E07D14     | Charge amount paid         |            | 0-1     | Value      | Used if charge has been paid in part or in full                                                                                                     |
| E07D15     | Net charge amount due      |            | 0-1R    | Value      | Charge remaining               |
| E07D16     | Payment date-time          |            | 0-1     | DateTime   | The date on which the charge was paid in full. Used when recording past charges.                                                                |
| E07D17     | Payment reference          |            | 0-n     | String     | Reference to a payment that wholly or partly clears this charge.                                                                                  |
| *E07C18*   | *Charge note*              |            | 0-n     |            | A note attached to this charge.|
| E07D18.1   | Note type                  |            | 0-1     | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)**          |
| E07D18.2   | Note date-time             |            | 0-1     | DateTime   |                                |
| E07D18.3   | Note text                  |            | 1       | String     |                                |

***

### <a name="e08"></a> E08 PAYMENT
[Back to entity list](#entities)

#### Description

An identified payment made by a patron to settle one or more charges.

#### Properties

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*   | *Description*                  |
|------------|----------------------------|------------|---------|------------|--------------------------------|
| **E08D01** | **Payment identifier**     | **AA**     | **1**[\[4\]](#Notes)                                                    | **String** | **The LCF entity identifier used when referring to this payment.**                                |
| **E08D02** | **Patron reference**       |            | **1**   | **String** |                                |
| **E08D03** | **Payment type**           |            | **1**   | **Code**   | **LCF code list [PYT](LCF-CodeLists.md#PYT)<br/>The type or method of payment.**                                                                                   |
| E08D04     | Payment description        |            | 0-1     | String     | Further information on type or method of payment.                                                                                                                      |
| E08D05     | Charge reference           |            | 0-n     | String     | One or more charges to which this payment relates.<br/>*Non-mandatory in v1.0.1, to allow for payments that don't relate to specific charges, but simply credit an account.* |
| E08D15     | Deposit type               |            | 0-1     | Code       | Payment made as a deposit against current or future charges of this type.<br/>**LCF code list [CHT](LCF-CodeLists.md#CHT)**<br/>*Added in vx.x.0*                 |
| E08D13     | Payment purpose            |            | 0-1     | Code       | LCF code list [PYP](LCF-CodeLists.md#PYP)<br/>The purpose of the payment.<br/>*(Added in vx.x.0)*                                                                |
| E08D14     | Beneficiary institution    |            | 0-1     | String     | Authority/institution to benefit from a donation. Must be included if the payment purpose is to make a donation.<br/>*(Added in vx.x.0)*                              |
| E08D06     | Payment date-time          |            | 0-1     |            | The date and optionally time at which the payment was made.                                                                                                          |
| **E08D07** | **Payment amount**         | **BV**     | **1**   | **Value**  | **Currency value**             |
| E08D08     | Payment currency           | BH         | 0-1     | Code       | ISO three-letter currency code, e.g. ‘GBP’                                                                                                                            |
| E08D09     | Payment status             |            | 0-1     | Code       | LCF code list **[PYS](LCF-CodeLists.md#PYS)** |
| E08D10     | Transaction reference      |            | 0-1     | String     |                                |
| E08D12     | Authorisation reference    |            | 0-1     | String     | Reference to an authorisation entity - see E13<br/>*(Added in vx.x.0)* |
| *E08C11*   | *Payment note*             |            | 0-n     | String     |A note attached to this payment.|
| E08D11.1   | Note type                  |            | 0-1     | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)** |
| E08D11.2   | Note date-time             |            | 0-1     | DateTime   |                                |
| E08D11.3   | Note text                  |            | 1       | String     |                                |

***

### <a name="e09"></a> E09 CONTACT
[Back to entity list](#entities)

#### Description

Contact details for the primary contact person or organization for a patron, location or authority/institution. *(Description changed in v1.0.1)*

#### Properties

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*   | *Description*                  |
|------------|----------------------------|------------|---------|------------|--------------------------------|
| **E09D01** | **Contact identifier**     |            | **1**[\[4\]](#Notes)                                                    | **String** | **The LCF entity identifier used when referring to this contact.**                                                                              |
| **<strike>E09D02</strike>** | **<strike>Name</strike>** | **<strike>AE</strike>** | **<strike>1</strike>** | **<strike>String</strike>** | **<strike>Name of person or organization.</strike>**<br/>       *Removed in v1.0.1* |
| E09D03     | Patron reference           |            | 0-1     | String     | Each instance of E09 must contain one and only one of E09D03, E09D10 or E09D11<br/>*Note added and cardinality changed in v1.0.1*   |
| E09D10     | Location reference         |            | 0-1     | String     | *Added in v1.0.1*                 |
| E09D11     | Authority/Institution reference |       | 0-1     | String     | *Added in v1.0.1*                 |
| <strike>E09D04</strike> | <strike>Address</strike> | <strike>BD</strike> | <strike>0-n</strike> | <strike>String</strike> | <strike>Repeatable if address is divided into multiple lines. Not included if a location entity exists for this address.</strike><br/>                                                 *Removed in v1.0.1* |
| *<strike>E09C05</strike>* | *<strike>Communication details</strike>* |        | <strike>0-n</strike> |      | <strike>Composite element containing a single communication number, address or locator for the patron. Repeatable for different communication types.</strike><br/>                                              *Removed in v1.0.1* |
| **E09D08** | **Communication type**     |            | **1**   | **Code**   | **LCF code list [CMT](LCF-CodeLists.md#CMT)**<br/>*Added in v1.0.1*                                                                                                        |
| **E09D09** | **Communication locator**  |            | **1-n** | **String** | The number, address or locator<br/>*Added in v1.0.1*                                                                                   |
| **<strike>E09D06</strike>** | **<strike>Language</strike>** |        | **<strike>1</strike>** | **<strike>Code</strike>** | **<strike>Language for communication with contact<br/>ISO three-letter language code, e.g. ‘eng’</strike>**<br/>                                                                    *Removed in v1.0.1* |
| *E09C07*   | *Contact note*             |            | 0-n     |            | A note attached to the LMS record for this contact.                                                                                              |
| E09D07.1   | Note type                  |            | 0-1     | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)**          |
| E09D07.2   | Note date-time             |            | 0-1     | DateTime   |                                |
| E09D07.3   | Note text                  |            | 1       | String     |                                |

***

### <a name="e10"></a> E10 TITLE CLASSIFICATION SCHEME *(DEPRECATED in v1.2.0)*
[Back to entity list](#entities)

#### Description

An identified scheme for classification of titles.

#### Properties

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*   | *Description*                  |
|------------|----------------------------|------------|---------|------------|--------------------------------|
| **E10D01** | **Classification scheme identifier** |  | **1**[\[4\]](#Notes)                                                    | **String** | **The LCF entity identifier used when referring to this scheme.**                                                                               |
| **E10D02** | **Scheme name**            |            | **1**   | **String** | **A name or short description of the scheme**                                                                                                       |
| *E10C03*   | *Scheme description / note*|            | 0-n     |            | Further, more extensive description of the scheme                                                                                                  |
| E10D03.1   | Note type                  |            | 0-1     | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)**          |
| E10D03.2   | Note date-time             |            | 0-1     | DateTime   |                                |
| E10D03.3   | Note text                  |            | 1       | String     |                                |

***

### <a name="e11"></a> E11 TITLE CLASSIFICATION TERM *(DEPRECATED in v1.2.0)*
[Back to entity list](#entities)

#### Description

A classification term in an identified scheme for classification of titles.

#### Properties

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*   | *Description*                  |
|------------|----------------------------|------------|---------|------------|--------------------------------|
| **E11D01** | **Classification identifier** |         | **1**[\[4\]](#Notes)                                                    | **String** | **The LCF entity identifier used when referring to this classification term.**                                                                  |
| **E11D02** | **Classification code**    |            | **1**   | **String** | **A code or number used as a label for the classification term.**                                                                                 |
| **E11D03** | **Classification scheme reference** |   | **1**   | **String** | **The LCF entity identifier for the classification scheme to which this classification term belongs**                                              |
| E11D04     | Classification term heading|            | 0-1     | String     | A heading or name for the classification term.                                                                                           |
| *E11C05*   | *Classification description / note* |   | 0-n     |            |                                |
| E11D05.1   | Note type                  |            | 0-1     | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)**          |
| E11D05.2   | Note date-time             |            | 0-1     | DateTime   |                                |
| E11D05.3   | Note text                  |            | 1       | String     |                                |

NOTE – If the scheme is appropriate, the classification identifier may the chosen to be the same as the classification code.

***

### <a name="e12"></a> E12 SELECTION CRITERION *(DEPRECATED in v1.0.1)*
[Back to entity list](#entities)

#### Description

An identified property of an entity that can be used as a selection criterion when retrieving a list of instances of that entity.

#### Properties

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*   | *Description*                  |
|------------|----------------------------|------------|---------|------------|--------------------------------|
| **E12D01** | **Identifier**             |            | **1**[\[4\]](#Notes)                                                    | **String** | **The LCF entity identifier used when referring to this selection criterion.**                                                                  |
| **E12D02** | **Criterion type name**    |            | **1**   | **String** | **Name of the selection criterion type, to be used in item list requests.**                                                                      |
| E12D03     | Entity type                |            | 0-n     | Code       | LCF code list **[ENT](LCF-CodeLists.md#ENT)**<br/>If applicable, the types of entity for which this is a valid selection criterion.                                 |
| E12D04     | Criterion type description |            | 0-1     | String     | A description of the criterion type and the domain and range of its values.                                                                        |
| E12D05     | Criterion value scheme     |            | 0-1     | String     | Identifier of the scheme from which values of this criterion type are drawn, to be used in item list requests.                                     |
| *E12C06*   | *Criterion note*           |            | 0-n     |            |                                |
| E12D06.1   | Note type                  |            | 0-1     | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)**          |
| E12D06.2   | Note date-time             |            | 0-1     | DateTime   |                                |
| E12D06.3   | Note text                  |            | 1       | String     |                                |

NOTE – The selection criterion identifier may be the same as the name. In any case, the name must be unique.

***

### <a name="e13"></a> E13 AUTHORISATION *(added in v1.0.1)*
[Back to entity list](#entities)

#### Description *(clarified in v1.1.0)*

A patron authorisation code: either a standard code from LCF code list [AUT](LCF-CodeLists.md#AUT) (E13D02) or a library-assigned heading or name (E13D03).

#### Properties

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*   | *Description*                  |
|------------|----------------------------|------------|---------|------------|--------------------------------|
| **E13D01** | **Authorisation identifier** |          | **1**[\[4\]](#Notes)                                                    | **String** | **The LCF entity identifier used when referring to this authorisation.**                        |
| E13D02     | Authorisation type         |            | 0-1     | Code       | LCF code list **[AUT](LCF-CodeLists.md#AUT)**                                                                                                    |
| E13D03     | Authorisation heading      |            | 0-1     | String     | A heading or name for the authorisation. Must be omitted if E13D02 is included.                                                          |
| *E13C04*   | *Authorisation description / note* |    | 0-n     |            |                                |
| E13D04.1   | Note type                  |            | 0-1     | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)**          |
| E13D04.2   | Note date-time             |            | 0-1     | DateTime   |                                |
| E13D04.3   | Note text                  |            | 1       | String     |                                |

***

### <a name="e14"></a> E14 LIBRARY AUTHORITY / INSTITUTION *(added in v1.0.1)*
[Back to entity list](#entities)

#### Description

A library authority or institution.

#### Properties

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*   | *Description*                  |
|------------|----------------------------|------------|---------|------------|--------------------------------|
| **E14D01** | **Authority/institution identifier** |  | **1**[\[4\]](#Notes)                                                    | **String** | **The LCF entity identifier used when referring to this authority/institution.**.               |
| *E14C02*   | *Additional identifier*    |           | 0-n     |            | Composite element containing details of an additional identifier for this authority or institution                                                     |
| E14D02.1   | Identifier type            |           | 1        | Code       | LCF code list **[INS](LCF-CodeLists.md#INS)**<br/>The identification scheme.                                                                   |
| E14D02.2   | Identifier type name       |           | 0-1      | String     | If the identification scheme is proprietary, the name of the scheme.                                                                           |
| E14D02.3   | Identifier value           |           | 1        | String     | The identifier string.         |
| **E14D03** | **Authority / institution name** |     | **1**    | **String** | **The name of this authority/institution**                                                                                        |
| **E14D03** | **Authority / institution name** |     | **1**    | **String** | **The name of this authority/institution**                                                                                        |
| E14D08     | Library statutory status   |           | 0-1      | Code       | LCF code list **[LST](LCF-CodeLists.md#LST)**<br/>*Added in v1.2.0*         |
| E14D09     | Library type               |           | 0-1      | Code       | LCF code list **[LTY](LCF-CodeLists.md#LTY)**<br/>*Added in v1.2.0*         |
| *E14C04*   | *Associated location*      |           | 0-n      |            | A location associated with this authority/institution.                                                                                         |
| E14D04.1   | Location association type  |           | 1        | Code       | LCF code list **[LAT](LCF-CodeLists.md#LAT)**          |
| E14D04.2   | Location reference         |           | 1        | String     |                                |
| *E14C04.3* | Library location service period |      | 0-n      |            | Only to be used for location association types LAT04 or LAT05<br/>See Notes 1-3 below on interpretation of repetitions of this composite element<br/>*Added in v1.2.0*    |
| E14D04.3.1 | Period name                |           | 0-1      | String     |                                   |
| E14D04.3.2 | Period start date inclusive |          | 1        | Date       |                                 |
| E14D04.3.3 | Period end date inclusive  |           | 1        | Date       |                                 |
|*E14C04.3.4*| Library closed             |           | 0-1      |            | Explicit statement that the library location is closed on the specified days in the service period. |
|E14D04.3.4.1| Days of the week           |           | 0-1      | String     | Days of the week are specified by a space-separated list of code values taken from LCF code list **[WKD](LCF-CodeLists.md#WKD)**. If omitted, the library location is closed on all days of the week during the specified service period. |
|*E14C04.3.5*| Library open               |           | 0-n      |            | Explicit statement that the library location is open for at least one time period on the specified days of the service period. See Note 4 below on interpretation of repetitions of this composite element. |
|E14D04.3.5.1| Days of the week           |           | 0-1      | String     | Days of the week are specified by a space-separated list of code values taken from LCF code list **[WKD](LCF-CodeLists.md#WKD)**. If omitted, the open time-period(s) apply to all days of the week during the specified service period. |
|*E14C04.3.5.2*| Open time-period         |           | 1-n      |            | A single continuous period of the day during which the library location is open. It is implied that the library location is closed at times outside open time-periods. |
|E14D04.3.5.2.1| Start time               |           | 1        | Time       |                                  |
|E14D04.3.5.2.2| End time                 |           | 1        | Time       |                                  |
|E14D04.3.5.2.3| Staffed / un-staffed     |           | 0-1      | Code       | LCF code list **[STA](LCF-CodeLists.md#STA)**     |
| *E14C05*   | *Associated contact*       |           | 0-n      |            | A contact associated with this authority/institution.                                                                                         |
| E14D05.1   | Contact association type   |           | 1        | Code       | LCF code list **[CAT](LCF-CodeLists.md#CAT)**          |
| E14D05.2   | Contact name               |           | 1        | String     |                                |
| E14D05.3   | Contact reference          |           | 1        | String     |                                |
| *E14C06*   | *Associated authority/institution* |   | 0-n      |            | Another authority/institution associated with this authority/institution.                                                                    |
| E14D06.1   | Authority/institution association type | | 1      | Code       | LCF code list **[AAT](LCF-CodeLists.md#AAT)**          |
| E14D06.2   | Authority/institution reference |      | 1        | String     |                                |
| *E14C07*   | *Authority/institution description / note* || 0-n |            |                                |
| E14D07.1   | Note type                  |            | 0-1     | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)**          |
| E14D07.2   | Note date-time             |            | 0-1     | DateTime   |                                |
| E14D07.3   | Note text                  |            | 1       | String     |                                |

**Notes on interpretation of repeated instances of E14C04.3 Library location service period**

1. If the period start/end dates of instances of E14C04.3 do not overlap, i.e. they are mutually exclusive, all are applicable.

2. If the date period of one instance of E14C04.3 is wholly contained within the date period of another instance, the instance with the wider scope is overridden by the instance with the narrow scope to the extent of the scope of the latter. An example would be to specify opening and closing times for an academic term in one instance and different times for a specific week of that term in a second instance.

3. If the date periods of two or more instances of E14C04.3 overlap, but the date period of any instance is not wholly contained within the date period of another instance, the instances cannot be interpreted unambiguously and these instances should be ignored.

4. If the days of the week of two or more instances of E14C04.3.4 and E14C04.3.5 overlap, the instances cannot be interpreted unambiguously and these instances should be ignored.

5.   If the time periods of two or more instances of E14C04.3.5<b><i>.2 in the same instance of E14C04.3.5</i></b> overlap, the instances cannot be interpreted unambiguously and these instances should be ignored.

***

### <a name="e15"></a> E15 MESSAGE / ALERT *(added in v1.0.1)*
[Back to entity list](#entities)

#### Description

A message or alert that may be communicated to a patron or group of patrons.

#### Properties

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*   | *Description*                  |
|------------|----------------------------|------------|---------|------------|--------------------------------|
| **E15D01** | **Message/alert identifier** |  | **1**[\[4\]](#Notes)                                                    | **String** | **The LCF entity identifier used when referring to this message/alert.**.                       |
| E15D02     | Associated authority/institution |      | 0-1     | String     |                                |
| **E15D03** | **Message/alert type**     |            | **1**   | **Code**   | LCF code list **[MAT](LCF-CodeLists.md#MAT)**                                                                                                  |
| E15D04     | Message/alert priority     |            | 0-1     | Code       | LCF code list **[MAP](LCF-CodeLists.md#MAP)**                                                                                                  |
| E15D05     | Message/alert display type |            | 0-1     | Code       | LCF code list **[MGT](LCF-CodeLists.md#MGT)**                                                                                                  |
| E15D06     | Display/delivery constraint |          | 0-1     | Code       | LCF code list **[MAC](LCF-CodeLists.md#MAC)**                                                                                                  |
| E15D07     | Display from date-time     |            | 0-1     | DateTime   |                                |
| E15D08     | Display until date-time    |            | 0-1     | DateTime   |                                |
| E15D09     | Message/alert audience     |            | 0-1     | Code       | LCF code list **[MAU](LCF-CodeLists.md#MAU)**                                                                                                  |
| E15D10     | Patron category            |            | 0-n     | String     | Only included if audience is specified patrons and categories |
| E15D11     | Patron reference           |            | 0-n     | String     | Only included if audience is specified patrons and categories |
| E15D14     | Loan reference             |            | 0-n     | String     | Only included if audience is patrons related to specified loans |
| E15D15     | Reservation reference      |            | 0-n     | String     | Only included if audience is patrons related to specified reservations |
| ***E15C12***  | **Message/alert text**  |            | **1-n** |            | Repeatable if the message/alert text is available in several alternative text formats                                                               |
| **E15D12.1**  | Text format             |            | **1**   | Code       | LCF code list **[TFT](LCF-CodeLists.md#TFT)**                                                                                                  |
| **E15D12.2**  | Text string             |            | **1**   | String     |                                |
| *E15C13*      | *Message/alert description / note* | | 0-n     |            |                                |
| E15D13.1      | Note type               |            | 0-1     | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)** |
| E15D13.2      | Note date-time          |            | 0-1     | DateTime   |                                |
| E15D13.3      | Note text               |            | 1       | String     |                                |
| *E15C16*      | Delivery information    |            | 0-1     |            | *Added in v1.2.0*              |
| E15D16.1      | Total delivered         |            | 0-1     | Integer    | Number of Patrons to whom this message/alert has been delivered |
| E15D16.2      | Total acknowledged      |            | 0-1     | Integer    | Number of Patrons from whom acknowledgements of this message/alert have been received |
| *E15C16.3*    | Delivery to Patron category |        | 0-n     |            | Delivery status for specific category of Patron |
| E15D16.3.1    | Category name           |            | 1       | String     |                                |
| E15D16.3.2    | Total Patrons in category |          | 0-1     | Integer    | Number of Patrons at whom this message/alert is aimed |
| E15D16.3.3    | Total delivered         |            | 0-1     | Integer    | Number of Patrons in category to whom this message/alert has been delivered |
| E15D16.3.4    | Total acknowledged      |            | 0-1     | Integer    | Number of Patrons in this category from whom acknowledgements of this message/alert have been received |
| *E15C16.4*    | Delivery to related Patrons |        | 0-n     |            | Delivery status for Patrons related to the specified Loans or Reservations |
| E15D16.4.1    | Total Patrons           |            | 0-1     | Integer    | Number of Patrons at whom this message/alert is aimed |
| E15D16.4.2    | Total delivered         |            | 0-1     | Integer    | Number of Patrons to whom this message/alert has been delivered |
| E15D16.4.3    | Total acknowledged      |            | 0-1     | Integer    | Number of Patrons from whom acknowledgements of this message/alert have been received |


Common components
-----------------

The following data elements and composites are typically used for control of message handling and authentication between the terminal application and the LMS. In some implementations these may be used in message headers and trailers, but in many, if not most, implementations these will be handled at a different level in the messaging protocol stack (e.g. in HTTP or SSL) and not in the message payload. They are primarily included here because of their inclusion in SIP2.

***

### Q00 Elements common to requests

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| *Q00C01*   | *User ID*                  | CN         | 0-1     |           | Composite element.              |
| Q00D01.1   | Encryption algorithm       |            | 0-1     | Code      | LCF code list **[ECR](LCF-CodeLists.md#ECR)**<br/>The specific encryption algorithm, if any, employed by the terminal application for encrypting the user ID. If omitted, the string value may or may not be encrypted.                                                                  |
| Q00D01.2   | String value               |            | 1       | String    | The encrypted or unencrypted string. Element Q00D01.1 may indicate the encryption algorithm employed, if any. Mandatory in each composite.          |
| *Q00C02*   | *Password*                 | CO         | 0-1     |           | Composite element. It would be unusual for the password not to be encrypted.                                                                  |
| Q00D02.1   | Encryption algorithm       |            | 0-1     | Code      | LCF code list **[ECR](LCF-CodeLists.md#ECR)**<br/>The specific encryption algorithm, if any, employed by the terminal application for encrypting the password. If omitted, the string value may or may not be encrypted.                                                                  |
| Q00D02.2   | String value               |            | 1       | String    | The encrypted or unencrypted string. Element Q00D02.1 may indicate the encryption algorithm employed, if any. Mandatory in each composite.          |
| Q00D03     | Institution identifier     | AO         | 0-1     | String    | LMS identifier for the institution, if terminals may be in one of several institutions.                                                            |
| *Q00C04*   | *Terminal ID*              |            | 0-1     | String    | LMS identifier for the device or terminal on which the terminal application is running.                                                         |
| Q00D04.1   | Encryption algorithm       |            | 0-1     | Code      | LCF code list **[ECR](LCF-CodeLists.md#ECR)**<br/>The specific encryption algorithm, if any, employed by the terminal application for encrypting the terminal ID. If omitted, the string value may or may not be encrypted.                                                         |
| Q00D04.2   | String value               |            | 1       | String    | The encrypted or unencrypted string. Element Q00D04.1 may indicate the encryption algorithm employed, if any. Mandatory in each composite.          |
| *Q00C05*   | *Terminal password*        |            | 0-1     |           |                                 |
| Q00D05.1   | Encryption algorithm       |            | 0-1     | Code      | LCF code list **[ECR](LCF-CodeLists.md#ECR)**           |
| Q00D05.2   | String value               |            | 1       | String    | The encrypted or unencrypted string.|
| Q00D06     | Terminal location reference| CP         | 0-1     | String    | The identifier for the location of the device or terminal on which the terminal application is running.                                           |
| Q00D07     | Request ID                 |            | 0-1     | String    | An ID of a request. If included in a request, it must also be included in the LMS response.                                                         |
| Q00D08     | Request date-time          |            | 0-1     | DateTime  | ISO date-time<br/>The date-time at which the terminal application user submitted the request. Normally generated by the application.              |
| Q00D09     | Previous request ID        |            | 0-1     | String    | Used when cancelling a previous request, in which case this element contains the identifier of the previous request (see element Q00D07).      |

***

### R00 Elements common to responses

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| R00D01     | Response ID                |            | 0-1     | String    | An ID of a response.            |
| R00D02     | Response type              |            | 0-1     | Code      | LCF code list **[RST](LCF-CodeLists.md#RST)**               |
| R00D07     | LCF version                |            | 0-1     | String    | Number of LCF version supported by the responding application. The string should use the same Semantic Versioning number format as LCF as a whole.<br/>*Added in v1.2.0* |
| R00D03     | Request reference          |            | 0-1     | String    | The ID of the request to which this is the response. Mandatory if the request included a request ID.                                               |
| R00D04     | Response date-time         |            | 0-1     | DateTime  | The date and time of the response.|
| *R00C05*   | *Exception condition*      |            | 0-n     |           | Response if there is an exception condition, in which case this and, optionally, one or more of the following message elements terminate the response.|
| R00D05.1   | Condition type             |            | 1       | Code      | LCF code list **[EXC](LCF-CodeLists.md#EXC)**<br/>Response code will often be specific to the function requested.                                                         |
| R00D05.2   | Reason request denied      |            | 0-1     | Code      | LCF code list **[RDN](LCF-CodeLists.md#RDN)**<br/>Used if R00D05.1 contains ''08' (request denied)                                                                       |
| R00D05.3   | Element reference          |            | 0-1     | String    | A reference (e.g. the LCF element ID) that uniquely identifies the element in the request payload that generated the exception condition.            |
| *R00C06*   | *Response message*         | AF / AG    | 0-n     |           | Composite element containing text to display or print on terminal.                                                                                  |
| R00D06.1   | Message display type       |            | 1       | Code      | LCF code list **[MGT](LCF-CodeLists.md#MGT)**           |
| R00D06.2   | Message to display         |            | 1-n     | String    | Repeatable if display type is ‘single line’                                                                                                          |

Core functions
--------------

NOTE ON CARDINALITIES IN RESPONSE MESSAGES - The cardinalities for the elements of responses assume that there is no exception condition, which would be indicated by the inclusion of element R00D05 in a response. If there is an exception condition, only elements in table R00 above would be included in the response.

### <a name="f01"></a> 01 Retrieve entity instance information
[Back to functions list](#functions)

This function may be used to retrieve information about an instance of an entity of any type. In practice the most likely uses of the function are to retrieve information about **titles**, **items** and **patrons**, but it could also be used to retrieve information about instances of any entity type, such as locations or charges.

#### Request

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| **Q01D01** | **Entity type**            |            | **1**   | **Code**  | **LCF code list [ENT](LCF-CodeLists.md#ENT)<br/>The entity type of the item about which information is requested. Information may be requested for any of the entity types E01 to E12 defined above.**                                                                                        |
| **Q01D02** | **Entity instance identifier** | **\*** | **1**   | **String**| **The primary (LMS) identifier for the entity instance.**                                                                                         |
| Q01D03     | Requested item detailed information |   | 0-n     | Code      | LCF code list **[MND\|LCF-CodeLists.md#MND]]**, **[IMD](LCF-CodeLists.md#IMD)** or **[[PNT](LCF-CodeLists.md#PNT)**, depending upon entity type specified in Q01D01.<br/>Indicates the type of information to be included in the response. May be repeated if several types of information are requested, unless the code indicates that all details are to be included. If omitted, the details to be included are determined by the LMS.                          |

\* The correspondence with a SIP2 element depends upon the entity type. For entity types 'patron' and 'item' the correspondence is with SIP2 elements AA and AB respectively. The only other entity type that is likely to be specified with any frequency is ‘manifestation’.

#### Response

NOTE – The elements included in the response will depend upon both the entity type and whether a specific level of detail has been requested, by the inclusion of one or more elements Q01D03 in the request. Elements marked as mandatory may only be omitted if there has been an exception condition and the response is in effect empty.

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| *R01C01*   | Entity element as determined by the specified entity type – see E01 to E12 above – taking into account any instances of element Q01D03 in the request.|  | 0-n  |           |                                 |

### <a name="f02"></a> 02 Retrieve entity instance list
[Back to functions list](#functions)

This function may be used to retrieve a list of entity instances, with or without detailed information for each entity instance in the list. Normally the list would be retrieved with minimal information (mandatory elements only) or no detailed information apart from the identifier of the item.

#### Request

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| **Q02D01** | **Entity type**            |            | **1**   | **Code**  | **LCF code list [ENT](LCF-CodeLists.md#ENT)<br/>The entity type of the item about which information is requested. Information may be requested for any of the entity types E01 to E12 defined above.**                                                                                        |
| *Q02C02*   | *Selection criterion*      |            | 0-n     |           | A criterion for selecting instances to be retrieved. If multiple selection criteria are specified, all must apply to all items retrieved. If no selection criteria are specified, all items of the specified entity type are to be included in the list.       |
| Q02D02.1   | Selection criterion code   |            | 0-1     | String    | LCF Code list **[SEL](LCF-CodeLists.md#SEL)**<br/>*Changed in v1.0.1*                                                                                                        |
| Q02D02.2   | Criterion value            |            | 1       | String    |                                 |
| Q02D03     | Requested instance detailed information | | 0-n   | Code      | LCF code list **[MND\|LCF-CodeLists.md#MND]]**, **[IMD](LCF-CodeLists.md#IMD)** or **[[PNT](LCF-CodeLists.md#PNT)**, depending upon entity type specified in Q02D01.<br/>Indicates the type of information to be included in the response. May be repeated if several types of information are requested, unless the code indicates that all details are to be included. If omitted, minimal details are included as determined by the LMS.                         |
| Q02D04     | Requested maximum number of instances in response | | 0-1 | Positive integer | If present, the maximum number of instances from the list matching the specified selection criteria that are desired in the response. If not present, the entire list of instances matching the specified selection criteria should be included in the response. Responses should, wherever possible, honour this maximum when requested.                      |
| Q02D05     | Index, in the complete list of instances found, of first instance in the response                                  |            | 0-1     | Positive integer or zero | If present, the desired index of the first instance in the response in the list of instances that match the specified selection criteria. For example, an offset value ‘10’ would imply that the first instance in the response should be the eleventh instance in the list. Responses should, wherever possible, honour this index when requested.          |

#### Response

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| R02D01     | Entity type                |            | 0-1     | Code      | LCF code list **[ENT](LCF-CodeLists.md#ENT)**<br/>Mandatory if the number of instances in the response is greater than zero.                                               |
| *R02C02*   | *Selection criterion*      |            | 0-n     |           | A criterion used for selecting instances, as specified in the request. It is recommended that if selection criteria are included in the request, they should also be included in the response for reference purposes.                                           |
| R02D02.1   | Selection criterion code   |            | 1       | Code      | LCF Code list **[SEL](LCF-CodeLists.md#SEL)**<br/>*Changed in v1.0.1*                                                                                                        |
| R02D02.2   | Criterion value            |            | 1       | String    |                                 |
| R02D03     | Number of instances in the list matching the selection criteria specified in the request                                   |            | 0-1     | Positive integer |                          |
| R02D04     | Number of instances in this response |  | 0-1     | Positive integer |                          |
| R02D05     | Offset from beginning of the ordered list to first instance in this response                                  |            | 0-1     | Positive integer or zero | If present, the integer value added to ‘1’ to determine the first instance in the list of instances that match the specified selection criteria to be included in the response. For example, an offset value ‘10’ would imply that the first item in the response should be the eleventh instance in the list. If omitted, the default value is zero.            |
| R02D06     | Entity identifier          |            | 0-n     | String    | If the number of selected instances is greater than zero, either one or more of this element or one or more of R02C07 must be included in the response.|
| *R02C07*   | Entity elements as determined by the specified entity type – see E01 to E11 above – and taking into account any instances of element Q02D03 in the request. | | 0-n  |           |                                 |

***

### <a name="f03"></a> 03 Create entity item
[Back to functions list](#functions)

This function is used to create a new item of a specific entity type. In practice it is most often used to create a new reservation or a new loan.

#### Request

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| **Q03D01** | **Entity type**            |            | **1**   | **Code**  | **LCF code list [ENT](LCF-CodeLists.md#ENT)<br/>The entity type of the item to be created.**                                                                              |
|            | Other elements, excluding the LCF entity identifier, as determined by the specified entity type – see E01 to E12 above                                 |            |         |           |                                 |

#### Response

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| R03D01     | Entity type                |            | 0-1     | Code      | LCF code list [ENT](LCF-CodeLists.md#ENT)<br/>The entity type of the item created in response to the request.<br/>*Cardinality changed in v1.2.0*                       |
| R03D02     | Item identifier            |            | 0-1     | String    | The LCF entity identifier for the inventory item, assigned by the LMS if a new item has been successfully created.<br/>*Cardinality changed in v1.2.0*           |

***

### <a name="f04"></a> 04 Modify entity item
[Back to functions list](#functions)

This function is used to modify an existing item of a specific entity type.

#### Request 

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| **Q04D01** | **Entity type**            |            | **1**   | **Code**  | **LCF code list [ENT](LCF-CodeLists.md#ENT)**           |
| **Q04D02** | **Item identifier**        |            | **1**   | **String**| **The identifier of the item to be modified.**                                                                                                    |
| **Q04D03** | **Modification type**      |            | **1**   | **Code**  | **LCF code list [MOT](LCF-CodeLists.md#MOT)**           |
|            | Other elements as determined by the specified entity type – see E01 to E12 above                                     |            |         |           |                                 |

#### Response

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| R04D01     | Entity type                |            | 0-1     | Code      | LCF code list [ENT](LCF-CodeLists.md#ENT)<br/>The entity type of the item created in response to the request.<br/>*Cardinality changed in v1.2.0*                       |
| R04D02     | Item identifier            |            | 0-1     | String    | The identifier for the item that has been successfully modified.<br/>*Cardinality changed in v1.2.0*                                                                  |

***

### <a name="f05"></a> 05 Delete entity item
[Back to functions list](#functions)

This function is used to delete an item of a specific entity type. Since deletion of an item involves removal of all references to this item, this function would not normally be implemented as a terminal application.

#### Request

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| **Q05D01** | **Entity type**            |            | **1**   | **Code**  | **LCF code list [ENT](LCF-CodeLists.md#ENT)**           |
| **Q05D02** | **Item identifier**        |            | **1**   | **String**| **The identifier of the item to be deleted.**                                                                                                     |

#### Response

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| R05D01     | Entity type                |            | 0-1     | Code      | LCF code list [ENT](LCF-CodeLists.md#ENT)<br/>The entity type of the item created in response to the request.<br/>*Cardinality changed in v1.2.0*                       |
| R05D02     | Item identifier            |            | 0-1     | String    | The identifier of the item that has been successfully deleted<br/>*Cardinality changed in v1.2.0*                                                                    |

Circulation management functions
--------------------------------

### <a name="f11"></a> 11 Check-out / renewal (create loan)
[Back to functions list](#functions)

The check-out / renewal function, if successfully executed, causes an LMS to perform a number of consequential actions to create, delete or modify various entity records. These actions are performed internally within the LMS, so how they are performed is beyond the scope of LCF. Depending upon the precise circumstances, some or all of the following entity record creation, modification or deletion actions might be performed by an LMS:

-   Unless this is a confirmation (request type RQT02) or cancellation (request type RQT03) of check-out or renewal, an LMS would typically retrieve the patron, item and manifestation records to check the patron’s status and ensure that check-out is permitted and to check for any applicable fees. An LMS may not block a confirmation request (equivalent to "no block" in SIP2). *(Modified in vx.x.0)*

-   If check-out / renewal is to proceed, an LMS would create a loan record for the specified patron and item and, in the case of renewal, modify or delete the existing loan record. If cancelling a check-out or renewal, an LMS would retrieve and either delete or modify the loan record.

-   If there is an associated reservation record for the specified patron and manifestation (or item), an LMS would retrieve and modify or delete this record.

-   If fees apply to check-out of this item, an LMS would create a charge record for the applicable fee. If cancelling a check-out or renewal, an LMS would retrieve and either delete or modify the charge record.

-   An LMS would modify the item record to update its circulation status and location and (optionally) add a reference to the loan record. If cancelling a previous check-out or renewal and deleting the associated loan record, an LMS would remove any reference to this loan record from the item record.

-   An LMS would modify the patron record to update patron status and the number of items on loan and (optionally) add a reference to the loan record. If cancelling a previous check-out or renewal and deleting the associated loan record, an LMS would remove any reference to this loan record from the patron record.

This implies that the terminal application must provide sufficient information in the request for all the necessary consequential actions to be performed by the LMS.

#### Request

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| **Q11D01** | **Request type**           |            | **1**   | **Code**  | **LCF code list [RQT](LCF-CodeLists.md#RQT)<br/>Indicates type of check-out request.**                                                                                   |
| Q11D02     | Renewal type               |            | 0-1     | Code      | LCF code list [RNQ](LCF-CodeLists.md#RNQ)<br/>Indicates that the request is a renewal request and which type                                                                |
| Q11D03     | Patron reference           | AA         | 0-1     | String    | Reference to the patron record. Mandatory in a new check-out.                                                                                  |
| Q11D04     | Item reference             | AB         | 0-1     | String    | Reference to the item in question. Mandatory unless cancelling a check-out / renewal (Q11D01 contains RQT03) or the renewal type (Q11D02) contains code value RNQ01 or RNQ02 (renewal of all items currently on loan to patron).<br/>*Description modified vx.x.0*                                                             |
| Q11D05     | Loan reference             |            | 0-1     | String    | Mandatory when making a renewal or when cancelling a check-out or renewal, unless the renewal type (Q11D02) contains code value RNQ01 or RNQ02 (renewal of all items currently on loan to patron).<br/>*Description modified vx.x.0*                                                                                        |
| Q11D06     | Loan end date              |            | 0-1     | DateTime  | If confirming check-out / renewal, the due date-time given to the patron for this item.                                                           |
| Q11D07     | Charge acknowledged        | BO         | 0-1     | Flag      | Empty element indicating that a charge may be created.                                                                                         |

#### Response

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| R11D01     | Loan reference             |            | 0-1     | String    | LCF entity identifier for loan. Either a single loan reference, or a copy of each loan record must be included in the response.<br/>*Description modified vx.x.0*                         |
| *R11C02*   | Loan entity record         |            | 0-n     |           | See E05. Repeatable only if the renewal type in the request is RNQ01 or RNQ02 (renewal of all items currently on loan to patron).<br/>*Description modified vx.x.0*                         |
| R11D03     | Item sensitive media warning |          | 0-1     | Code      | LCF code list **[MEW](LCF-CodeLists.md#MEW)**<br/>Same as E02D07. Flag indicating that a loaned item contains a media component that is sensitive to some security setting devices.<br/>*Description modified in vx.x.0*                        |
| R11D04     | Desensitize item security  |            | 0-1     | Code      | LCF code list **[SCD](LCF-CodeLists.md#SCD)**<br/>Same as E02D08. Flag indicating whether the security on a loaned item should or should not be desensitized / removed on check-out.<br/>*Description modified in vx.x.0*                                  |
| R11D05     | Charge reference           |            | 0-1     | String    | Reference to charge created with this loan. Omitted when two or more complete loan records (R11C02) are included in the response.<br/>*Description modified in vx.x.0* |
| R11D06     | Digital content access link |   | 0-1     | String    | Non-persistent link to be used by the patron to access checked-out digital content<br/>*Added in v1.0.1*                                                |

***

### <a name="f12"></a> 12 Check-in
[Back to functions list](#functions)

The check-in function, if successfully executed, causes an LMS to perform a number of consequential actions. These actions are performed internally within the LMS, so how they are performed is beyond the scope of LCF. Depending upon the precise circumstances, some or all of the following entity record modification or creation actions might be performed by an LMS:

-   Unless this is a cancellation (request type RQT03) of check-out or renewal, the LMS would retrieve the item record and modify to update circulation status and location. An LMS may not block a confirmation request (equivalent to "no block" in SIP2). *(Modified in vx.x.0)*

-   The LMS would retrieve the loan record for this item and modify it to update its status.

-   The LMS would retrieve the patron record and modify it to update the number of items on loan.

-   If appropriate (such as when the item is overdue, or when a loan fee is dependent upon the precise date and time of check-in), the LMS would create a charge record for any fine or fee due.

#### Request

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| **Q12D01** | **Request type**           |            | **1**   | **Code**  | **LCF code list [RQT](LCF-CodeLists.md#RQT)**           |
| Q12D02     | Patron reference           | AA         | 0-1     | String    |                                 |
| **Q12D03** | **Item reference**         | **AB**     | **0-1** | **String**|                                 |
| Q12D04     | Loan reference             |            | 0-1     | String    |                                 |
| Q12D05     | Item return date           |            | 0-1     | DateTime  | In confirmation requests, the date the item was returned by the patron.                                                                           |

#### Response

| Id         | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| R12D01     | Loan reference             |            | 0-1     | String    |                                 |
|*R12C09*    |*Loan entity record*        |            | 0-1     |           | See E05 *Added in v1.2.0*       |
| R12D02     | Patron reference           | AA         | 0-1     | String    |                                 |
| R12D03     | Item reference             | AB         | 0-1     | String    |                                 |
| R12D04     | Item return location reference| CL      | 0-1     | String    | LCF entity identifier for return location, e.g. sort bin.                                                                                       |
| R12D05     | Item sensitive media warning|           | 0-1     | Code      | LCF code list **[MEW](LCF-CodeLists.md#MEW)**<br/>Flag indicating that the item contains a media component that is sensitive to some security setting devices.        |
| R12D06     | Item requires special attention|        | 0-1     | Code      | LCF code list **[SPA](LCF-CodeLists.md#SPA)**<br/>Flag indicating that this item requires special attention before it is returned to its shelf location.              |
| R12D07     | Special attention description|          | 0-1     | String    | Description of special attention required, if any.                                                                                              |
| R12D08     | Charge reference           |            | 0-n     | String    | LCF entity identifier of any charge due on this item. Repeatable if more than one charge is due (e.g. loan fee and overdue fine).                  |

### <a name="f13"></a> 13 Patron payment
[Back to functions list](#functions)

The patron payment function, if successfully executed, causes an LMS to perform a number of consequential actions. These actions are performed internally within the LMS, so how they are performed is beyond the scope of LCF. Depending upon the precise circumstances, and assuming payment has been authorised or does not require authorisation, either or both of the following entity record modification or deletion actions might be performed by an LMS:

-   The LMS would create a payment record for the amount to be paid. If cancelling a payment, the payment record is deleted or the payment status is modified.

-   The LMS would retrieve and modify the relevant charge records to update their charge status.

#### Request

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| **Q13D01** | **Request type**           |            | **1**   | **Code**  | **LCF code list [RQT](LCF-CodeLists.md#RQT)** |
| **Q13D02** | **Patron reference**       | **AA**     | **1**   | **String**|                                 |
| Q13D03     | Charge reference           |            | 0-n     | String    | Charge(s) against which to set this payment. If omitted, the LMS determines the charges against which to set the payment.                          |
| Q13D09     | Deposit type               |            | 0-1     | Code      | Deposit made against future charges of this type.<br/>**LCF code list [CHT](LCF-CodeLists.md#CHT)**<br/>*Added in vx.x.0*                 |
| **Q13D04** | **Payment type**           |            | **1**   | **Code**  | **LCF code list [PYT](LCF-CodeLists.md#PYT)**           |
| Q13D05     | Payment type description   |            | 0-1     | String    | Further information on method of payment                                                                                                        |
| **Q13D06** | **Payment amount**         |            | **1**   | **Value** | **Currency value.**             |
| Q13D07     | Payment currency           |            | 0-1     | Code      | ISO three-letter currency code, e.g. ‘GBP’                                                                                                          |
| Q13D08     | Transaction reference      |            | 0-1     | String    | The identifier of the successful payment transaction. Only included if the request type (Q13D01) is '02' (Confirmation request).<br/>*Added in v1.0.1*                                                                       |

#### Response

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| R13D01     | Patron reference           | AA         | 0-1     | String    | *Cardinality changed in v1.2.0* |
| R13D02     | Payment Identifier         |            | 0-1     | String    | Included if attempt to make the payment is successful.                                                                                                 |
| R13D03     | Charge reference           |            | 0-n     |           | Mandatory if payment of any charge item is accepted or confirmed.                                                                                      |
| R13D05     | Deposit type               |            | 0-1     | Code      | Mandatory if a deposit payment is accepted or confirmed against current or future charges of the specified type.<br/>*Added in vx.x.0*                 |
| R13D04     | Authorisation reference    |            | 0-1     | String    | Reference to an authorisation entity when the LMS needs to authorise that a payment transaction can proceed. The authorisation must be of type AUT02.<br/>*Added in v1.0.1*                     |

### <a name="f14"></a> 14 Block patron account
[Back to functions list](#functions)

Used to prevent unauthorised use of a patron account, such as when the patron’s library card is stolen or mislaid. This function could alternatively be implemented using core functions to retrieve and modify a patron entity: the patron's current record is retrieved, the patron status and library card status are updated and any blocked card messages is added, as appropriate.

#### Request

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| **Q14D01** | **Patron reference**       | **AA**     | **1**   | **String**|                                 |
| Q14D02     | Library card status        |            | 0-1     | Code      | LCF code list **[PCS](LCF-CodeLists.md#PCS)**           |
| Q14D03     | Blocked card message       | AL         | 0-1     | String    |                                 |

#### Response

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| R14D01     | Patron reference           |            | 0-1     | String    | The identifier for the Patron record that has been successfully modified.<br/>*Cardinality changed in v1.2.0*                                                     |

***

### <a name="f15"></a> 15 Un-block patron account
[Back to functions list](#functions)

This function is very similar to function 14 Block patron. Any blocked card message is removed. This function could alternatively be implemented using core functions to retrieve and modify a patron entity: the patron's current record is retrieved and the patron status and library card status are updated as appropriate.

#### Request

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| **Q15D01** | **Patron reference**       | **AA**     | **1**   | **String**|                                 |

#### Response

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| R15D01     | Patron reference           |            | 0-1     | String    | The identifier for the Patron record that has been successfully modified.<br/>*Cardinality changed in v1.2.0*                                                     |

***

### <a name="f16"></a> 16 Reserve manifestation / item
[Back to functions list](#functions)

The reserve function, if successfully executed, causes an LMS to perform a number of consequential actions to create, delete or modify various entity records. These actions are performed internally within the LMS, so how they are performed is beyond the scope of LCF. Depending upon the precise circumstances, some or all of the following entity record creation, modification or deletion actions might be performed by an LMS:

-   Unless this is a confirmation or cancellation of reservation, the LMS would retrieve the patron, item and/or manifestation records to check the patron’s status and ensure that reservation is permitted and to check for any applicable fees.

-   If reservation is to proceed, the LMS would create a reservation record for the specified patron and manifestation or item. If cancelling a reservation, the LMS would either delete or modify the corresponding reservation record.

-   If fees apply, the LMS would create a charge record for the applicable fee. If cancelling a reservation, the LMS would either delete or modify the corresponding charge record.

-   The LMS would modify the manifestation or item record to add a reference to the reservation record. If cancelling a previous reservation and deleting the associated reservation record, the LMS would remove any reference to this record from the associated manifestation or item record.

-   The LMS would modify the patron record to update patron status and the number of items on loan and (optionally) add a reference to the reservation record. If cancelling a previous reservation and deleting the associated reservation record, the LMS remove any reference to this record from the patron record.

#### Request

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| **Q16D01** | **Request type**           | **BX / BI**| **1**   | **Code**  | **LCF code list [RQT](LCF-CodeLists.md#RQT)**           |
| **Q16D02** | **Patron reference**       | **AA**     | **1**   | **String**|                                 |
| **Q16D03** | **Item entity type**       |            | **1**   | **Code**  | **LCF code list [ENT](LCF-CodeLists.md#ENT) – only code values '01' and '02' are valid**                                                                               |
| **Q16D04** | **Item reference**         | **AB**     | **1**   | **String**|                                 |
| Q16D05     | Reservation type           | BY         | 0-1     | Code      | LCF code list **[RVT](LCF-CodeLists.md#RVT)**           |
| Q16D06     | Pick-up institution reference| AO       | 0-1     | String    | The LCF entity identifier of the branch library or other institution where the items are to be picked up by the patron. Normally only included if the reservation type is ‘04’.                                                                                      |
| Q16D07     | Pick-up location reference | BS         | 0-1     | String    | The LCF entity identifier of the location where the items are to be picked up by the patron. Normally only included if the reservation type is ‘04’, either instead of or additional to Q16D06.                                                                     |
| Q16D08     | Reservation start date     |            | 0-1     | DateTime  | Only used in confirmations.     |
| Q16D09     | Reservation expiry date    | AH         | 0-1     | DateTime  | The date by which a reserved item will be picked up by the patron.                                                                               |
| Q16D10     | Charge acknowledged        | BO         | 0-1     | Flag      | Empty element indicating that a charge may be created.                                                                                         |

#### Response

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| R16D01     | Reservation reference      |            | 0-1     | String    | Either a reservation reference or a copy of the reservation record must be included in the response.                                               |
|*R16C02*    |*Reservation entity record* |            | 0-1     |           | See E06.                        |
| R16D03     | Charge reference           | BT / BV    | 0-1     | String    | LCF entity identifier for the charge associated with reservation of this manifestation or item.                                                     |

### <a name="f17"></a> 17 Set/reset patron password
[Back to functions list](#functions)

This function sets the password associated with a Patron entity. Since, for security reasons, this password is not held as a property of the Patron entity, it cannot be set or retrieved using any of the core functions.

#### Request

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| **Q17D01** | **Patron reference**       | **AA**     | **1**   | **String**|                                 |
| **Q17D02** | **Patron password**        |            | **1**   | **String**| Encrypted password              |

#### Response

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| R17D01     | Patron reference           |            | 0-1     | String    | The identifier for the Patron record for which the password has been successfully set/reset.<br/>*Cardinality changed in v1.2.0*                                  |

### <a name="f18"></a> 18 Set/reset patron PIN
\[*Added in v1.2.0*\]

[Back to functions list](#functions)

This function sets the PIN associated with a Patron entity. Since, for security reasons, this PIN may not be held as a property of the Patron entity, it cannot be set or retrieved using any of the core functions.

#### Request

| *Id*       | *Element*            | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------|------------|---------|-----------|---------------------------------|
| **Q18D01** | **Patron reference** |            | **1**   | **String**|                                 |
| **Q18D02** | **Patron PIN**       |            | **1**   | **String**| Encrypted PIN                   |

#### Response

| *Id*       | *Element*            | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------|------------|---------|-----------|---------------------------------|
| R18D01 | Patron reference         |            | 0-1     | String    | The identifier for the Patron record for which the PIN has been successfully set/reset.                                                                             |

Stock management functions
--------------------------

### <a name="f21"></a> 21 Retrieve location list
[Back to functions list](#functions)

This function is the same as core function 02 for retrieving a list of entities of type E04 Location.

### <a name="f22"></a> 22 Retrieve title classification scheme list
[Back to functions list](#functions)

This function is the same as core function 02 for retrieving a list of entities of type E10 Title classification scheme.

### <a name="f23"></a> 23 Retrieve title classification list
[Back to functions list](#functions)

This function is the same as core function 02 for retrieving a list of entities of type E11 Title classification code.

### <a name="f24"></a> 24 Retrieve (stock) item list
[Back to functions list](#functions)

This function combines the core functions for retrieval of a list of manifestations (entity type E01) and list of stock items (entity type E02).

### <a name="f25"></a> 25 Retrieve selection criterion type list
\[*Deprecated in v1.2.0*\]

[Back to functions list](#functions)

This function is the same as the core function 02 for retrieving a list of entities of type E12 Selection criterion.

NOTE - Implementation of this function is now deprecated. A new approach to the expression of search and selection criteria for the retrieval of lists of entities is to be added in a future version.

### <a name="f26"></a> 26 Retrieve list of available items at a specific location
\[*Deprecated in v1.2.0*\]

NOTE - Implementation of this function is now deprecated. A new approach to the expression of search and selection criteria for the retrieval of lists of entities is to be added in a future version.

[Back to functions list](#functions)

This function selects all items that are available to be borrowed at a specific location and is the same as function 25 with specific Selection criteria: a specific location and a specific circulation status (CIS03 = 'Available').

Various other functions
-----------------------

### <a name="f31"></a> 31 Apply charge to patron account
[Back to functions list](#functions)

The function applies the following core function:

-   Unless this is a cancellation of a charge, create a charge record of the appropriate type and associate it with the corresponding patron record. If cancelling a charge, either delete the charge record or modify its status to indicate that it is cancelled.
-   Modify the patron record to add a reference to the new charge, or to remove the reference if cancelled.
-   Make any necessary change to patron status as a consequence of creating or cancelling the charge.

#### Request

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| **Q31D01** | **Request type**           | **BX / BI**| **1**   | **Code**  | **LCF code list [RQT](LCF-CodeLists.md#RQT)**           |
| **Q31D02** | **Charge type**            | **BT**     | **1**   | **Code**  | **LCF code list [CHT](LCF-CodeLists.md#CHT)**           |
| **Q31D03** | **Charge status**          |            | **1**   | **Code**  | **LCF code list [CHS](LCF-CodeLists.md#CHS)**           |
| **Q31D04** | **Patron reference**       | **AA**     | **1**   | **String**|                                 |
| Q31D05     | Payment due date-time      |            | 0-1     | DateTime  | The date and optionally time on which the charge becomes due for payment.                                                                            |
| **Q31D06** | **Gross charge amount**    | **BV**     | **1**   | **Value** | **Currency value of original charge**|
| Q31D07     | Charge currency            | BH         | 0-1     | Code      | ISO three-letter currency code, e.g. ‘GBP’                                                                                                          |
| *Q31C08*   | *Charge note*              |            | 0-n     |            | A note attached to this charge.|
| Q31D08.1   | Note type                  |            | 0-1     | Code       | LCF code list **[NOT](LCF-CodeLists.md#NOT)**          |
| Q31D08.2   | Note date-time             |            | 0-1     | DateTime   |                                |
| Q31D08.3   | Note text                  |            | 1       | String     |                                |

#### Response

| *Id*       | *Element*                  | *SIP2 ID*  | *Card.* | *Format*  | *Description*                   |
|------------|----------------------------|------------|---------|-----------|---------------------------------|
| **R31D01** | **Charge reference**       |            | **1**   | **String**| **The identifier for the Charge record that has been successfully created.**                                                                  |

### <a name="f32"></a> 32 Acknowledge message/alert
[Back to functions list](#functions)

The function modifies a Patron entity to change the delivery status of an associated Message/alert (E03D34.2) to 'Delivered, acknowledged' (MAD03), and is the same as function 04 applied to a Patron entity with entity modification type 'update' (MOT02), the request containing the associated Message/alert (E03C34) to be updated. The response is as for function 04.

___

<a name="Notes"></a>[1] The acronym "LCF" derives from an informal, abbreviated name for the standard, coined during its development: "Library Communication Framework".

[2] The term ‘data model’ is avoided here, because it could lead to confusion between this specification and specifications of other standard data models used in library applications, especially in RFID applications.

[3] The “cardinality” of an element is the number of times that an element is allowed to be included at that point in a message. The allowed values are ‘0-1’, ‘1’, ‘0-n’ and ‘1-n’. These are equivalent to ‘non-mandatory and non-repeatable’, ‘mandatory and non-repeatable’, ‘non-mandatory and repeatable’ and ‘mandatory and repeatable’. In general, elements in responses that are specified to be mandatory, i.e. they have cardinality ‘1’ or ‘1-n’, are mandatory *unless there is an exception condition*, in which case none of the specific response elements is included. If appropriate, information from the request may be included in the exception description element to assist in determining the cause of the exception condition.

[4] Identifiers in requests are mandatory except when creating a new entity. When creating an entity, the LMS may expect the terminal to provide the identifier in the case of Item, Patron and Authorisation entities, but when creating any other type of entity the LMS will generally assign its own identifier to the entity and ignore any identifier provided by the terminal. 

[5] The ONIX code lists are maintained by EDItEUR. For the latest issue of the ONIX code lists see [https://ns.editeur.org/onix/en](https://ns.editeur.org/onix/en).

[6] Elements where the cardinality is followed by 'R' are "response-only" or "read-only". These elements should only occur in responses from an LMS to a terminal application/device and will be ignored when included in requests.
