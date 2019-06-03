---
title: LCF v1.2.0 Code Lists
menu: Code Lists
weight: 2
---

# Book Industry Communication

## Library Interoperability Standards

## Library Data Communication Framework for Terminal Applications (LCF)

## Code Lists

### Issue 4

### DRAFT

---

This document defines code lists for use with LCF version 1.1.0.

The use of this document is subject to license terms and conditions that can be found *at* <http://www.bic.org.uk/files/bicstandardslicence.pdf>.

**NOTES**

1.  Code lists may be revised independently and more frequently than the
    overall data framework.

2.  A number of code lists that are either empty or contain legacy code
    values are expected to be revised as a matter or priority.

3.  Code IDs are not intended
    to be exchanged in messages. They identify code semantics to which
    the actual code values in implementation should correspond. Some
    implementations may adopt the short, numeric code values specified
    in this document while other implementations may adopt more verbose
    alpha-numeric code values.

The code lists defined are:

-   [AAT Library authority/institution association type](#AAT) *(added in v1.0.1)*
-   [AUT Authorisation code](#AUT) *(added in v1.0.1)*
-   [CAT Contact association type](#CAT) *(added in v1.0.1)*
-   [CHS Charge status](#CHS)
-   [CHT Charge type](#CHT)
-   [CIS Circulation status](#CIS)
-   [CMT Communication type](#CMT)
-   [CRT Check-out restriction type](#CRT)
-   [DTM Date or Date-time format](#DTM)
-   [ECR Encryption algorithm](#ECR)
-   [ELI Entity list type](#ELI) *(added in v1.2.0)*
-   [ENT Entity type](#ENT)
-   [EXC Exception condition response](#EXC)
-   [IMD Item detailed information type](#IMD)
-   [IMI Item identification scheme](#IMI)
-   [IMT Item media type / format](#IMT)
-   [INS Institution identification scheme](#INS)
-   [LAT Location association type](#LAT)
-   [LCS Library classification scheme](#LCS)
-   [LKT Resource access link type](#LKT) *(added in v1.0.1)*
-   [LOI Location identification scheme](#LOI)
-   [LOS Loan status](#LOS)
-   [LOT Location type](#LOT)
-   [MAC Message/alert display/delivery constraints](#MAC) *(added in v1.0.1)*
-   [MAD Message/alert delivery status](#MAD) *(added in v1.0.1)*
-   [MAP Message/alert priority](#MAP) *(added in v1.0.1)*
-   [MAT Message/alert type](#MAT) *(added in v1.0.1)*
-   [MAU Message/alert audience](#MAU) *(added in v1.0.1)*
-   [MES Media type / format scheme](#MES)
-   [MEW Media warning flag](#MEW)
-   [MGT Message display type](#MGT)
-   [MND Manifestation detailed information type](#MND)
-   [MNI Manifestation identification scheme](#MNI)
-   [MNS Manifestation status](#MNS)
-   [MOT Entity modification type](#MOT)
-   [NOT Note type](#NOT)
-   [PCS Patron’s library card status](#PCS)
-   [PGP Patron group association type](#PGP) *(added in v1.0.1)*
-   [PNI Patron identification scheme](#PNI) *(added in v1.0.1)*
-   [PNS Patron status condition type](#PNS)
-   [PNT Patron detailed information type](#PNT)
-   [PYS Payment status](#PYS)
-   [PYT Payment type](#PYT)
-   [RDN Reason for inability to approve request](#RDN)
-   [RNQ Renewal request type](#RNQ)
-   [RQT Request type](#RQT)
-   [RST Response type](#RST)
-   [RVQ Reservation request type](#RVQ)
-   [RVS Reservation status](#RVS)
-   [RVT Reservation type](#RVT)
-   [SCD Security desensitization flag](#SCD)
-   [SEL Selection criterion](#SEL) *(added in v1.0.1)*
-   [SPA Special attention required flag](#SPA)
-   [TFT Text format](#TFT)
-   [TTL Title type](#TTL)
-   [UNC Unnamed contributor type](#UNC)

### <a id="AAT"></a>AAT Library authority/institution association type *(added in v1.0.1)*

  *Code ID*      |*Code value*       |*Definition*                                                         |*Notes*
  -------------- | ----------------- |-------------------------------------------------------------------  |----------------------------------
  AAT01          | 01               | Is member of consortium                                              |
  AAT02          | 02               | Has consortium member                                                |  

### <a id="AUT"></a>AUT Authorisation code *(added in v1.0.1)*

  *Code ID*      |*Code value*       |*Definition*                                                         |*Notes*
  -------------- | ----------------- |-------------------------------------------------------------------  |----------------------------------
  AUT01          | PCI               | Parental consent has been granted for a child patron to access the Internet from library premises                                                                                      |
  AUT02          | PAY               | Consent has been granted for a Patron to proceed to make a payment against their account.                                                                                             | May only be used in LCF function 13 (Patron payment) responses.
  AUT03          | ACC               | Consent has been granted for the Patron to gain access to the library/site/building during un-staffed opening periods.                                                            | *Added in v1.1.0*

### <a id="CAT"></a>CAT Contact association type *(added in v1.0.1)*

  *Code ID*      |*Code value*       |*Definition*                                                         |*Notes*
  -------------- | ----------------- |-------------------------------------------------------------------  |----------------------------------
  CAT01          | 01               | Primary contact for authority/institution                            |
  CAT02          | 02               | Alternative contact for authority/institution                        |

### <a id="CHS"></a>CHS Charge status

  *Code ID*      |*Code value*      |*Definition*   |*Notes*
  -------------- |----------------- |-------------- |----------------------------------
  CHS01          |01                |Not yet paid   |
  CHS02          |02                |Part paid      |
  CHS03          |03                |Fully paid     |Used when recording past charges
  CHS04          |04                |Not yet payable|*Added in v1.1.0*

### <a id="CHT"></a>CHT Charge type (based upon SIP 2 fee type code list)

  *Code ID*   |*Code value*   |*Definition*                      |*Notes*
  ----------- |-------------- |--------------------------------- |-------------------------------------
  CHT01       |01             |Other / unknown                   |SIP 2 code ‘01’
  CHT02       |02             |Administrative                    |SIP 2 code ‘02’
  CHT03       |03             |Damage                            |SIP 2 code ‘03’
  CHT04       |04             |Overdue                           |SIP 2 code ‘04’
  CHT05       |05             |Processing                        |SIP 2 code ‘05’
  CHT06       |06             |Rental                            |SIP 2 code ‘06’
  CHT07       |07             |Replacement                       |SIP 2 code ‘07’
  CHT08       |08             |Computer access charge            |SIP 2 code ‘08’
  CHT09       |09             |Reservation fee                   |SIP 2 code ‘09’
  CHT10       |00             |Aggregate                         |Default value in fee total elements
  CHT11       |10             |Membership fee / subscription     |
  CHT12       |11             |Notice fee                        |
  CHT13       |12             |Referral to debt collection fee   |
  CHT14       |13             |Printing                          |*Added in v1.0.1*

### <a id="CIS"></a>CIS Circulation status (based upon SIP2 circulation status code list)

  *Code ID*   |*Code value*   |*Definition*                                                        |*Notes*
  ----------- |-------------- |------------------------------------------------------------------- |-----------------
  CIS01       |01             |Other / unknown                                                     |SIP 2 code ‘01’
  CIS02       |02             |On order                                                            |SIP 2 code ‘02’
  CIS03       |03             |Available                                                           |SIP 2 code ‘03’
  CIS04       |04             |On loan (charged)                                                   |SIP 2 code ‘04’
  CIS05       |05             |On loan (charged) – not to be recalled until earliest recall date   |SIP 2 code ‘05’
  CIS06       |06             |In process                                                          |SIP 2 code ‘06’
  CIS07       |07             |Recalled                                                            |SIP 2 code ‘07’
  CIS08       |08             |Waiting on hold shelf                                               |SIP 2 code ‘08’
  CIS09       |09             |Waiting to be re-shelved                                            |SIP 2 code ‘09’
  CIS10       |10             |In transit between library locations                                |SIP 2 code ‘10’
  CIS11       |11             |Claimed returned                                                    |SIP 2 code ‘11’
  CIS12       |12             |Lost                                                                |SIP 2 code ‘12’
  CIS13       |13             |Missing                                                             |SIP 2 code ‘13’
  CIS14       |14             |All copies withdrawn from circulation – see manifestation           |
  CIS15       |15             |Withdrawn from circulation for repair                               |
  CIS16       |16             |Withdrawn from circulation – reason unspecified                     |

### <a id="CMT"></a>CMT Communication type

  *Code ID*   |*Code value*   |*Definition*                      |*Notes*
  ----------- |-------------- |--------------------------------- |---------
  CMT01       |01             |Phone number – unspecified type   |
  CMT02       |02             |Home phone number                 |
  CMT03       |03             |Business phone number             |
  CMT04       |04             |Mobile phone number               |
  CMT05       |05             |Email address                     |
  CMT06       |06             |Postal address                    |*Added in v1.0.1*              |
  CMT07       |11             |Primary phone number              |A Patron may only reference one Contact with this communication type<br/>*Added in v1.0.1*                                                         |
  CMT08       |15             |Primary email address             |A Patron may only reference one Contact with this communication type<br/>*Added in v1.0.1*                                                         |
  CMT09       |16             |Primary postal address            |A Patron may only reference one Contact with this communication type<br/>*Added in v1.0.1*                                                         |

### <a id="CRT"></a>CRT Check-out restriction type

  *Code ID*   |*Code value*   |*Definition*      |*Notes*
  ----------- |-------------- |----------------- |------------------------------------------------------------------------
  CRT01       |01             |Lower age limit   |Value is the lower age limit in years. Default value is ‘unspecified’.

### <a id="DTM"></a>DTM Date or Date-time format

  *Code ID*   |*Code value*   |*Definition*          |*Notes*
  ----------- |-------------- |--------------------- |-----------------------------------------------------------------------------------------------
  DTM01       |01             |YYYYMMDDTHHMMSS       |The ‘T’ is a fixed character separating the date and time components, as defined by ISO 8601.
  DTM02       |02             |YYYY-MM-DDTHH:MM:SS   |
  DTM03       |11             |YYYYMMDD              |
  DTM04       |12             |YYYY-MM-DD            |

### <a id="ECR"></a>ECR Encryption algorithm

  *Code ID*   |*Code value*   |*Definition*   |*Notes*
  ----------- |-------------- |-------------- |-------------------------
  ECR01       |               |               |Code list to be defined

### <a id="ELI"></a>ELI Entity list type *(Added in v1.2.0)*

  *Code ID*   |*Code value*   |*Alpha value*   |*Definition*                  |*Notes*
  ----------- |-------------- |--------------- |----------------------------- |----------------
  ELI01       |01             |uri             |Requested list should contain entity reference URIs only | 
  ELI02       |02             |entity          |Requested list should contain the entities themselves | 

### <a id="ENT"></a>ENT Entity type

NOTE - The column headed "Alpha value" is intended for use in RESTful web service 
implementations of LCF. RESTful requests should always refer to the set of entities 
of a given type, and hence the use of the plural form.

  *Code ID*   |*Code value*   |*Alpha value*   |*Definition*                  |*Notes*
  ----------- |-------------- |--------------- |----------------------------- |----------------
  ENT01       |01             |manifestations  |Manifestation                 |LCF Entity E01
  ENT02       |02             |items           |Copy of a manifestation       |LCF Entity E02
  ENT03       |03             |patrons         |Patron                        |LCF Entity E03
  ENT04       |04             |locations       |Physical location             |LCF Entity E04
  ENT05       |05             |loans           |Loan                          |LCF Entity E05
  ENT06       |06             |reservations    |Reservation                   |LCF Entity E06
  ENT07       |07             |charges         |Charge                        |LCF Entity E07
  ENT08       |08             |payments        |Payment                       |LCF Entity E08
  ENT09       |09             |contacts        |Contact details               |LCF Entity E09
  ENT10       |10             |class-schemes   |Title classification scheme   |LCF Entity E10
  ENT11       |11             |class-terms     |Title classification code     |LCF Entity E11
  ENT12       |13             |authorisations  |Authorisation codes           |LCF Entity E13<br/>*Added in v1.0.1*
  ENT13       |14             |authorities     |Library authority / institution|LCF Entity E14<br/>*Added in v1.0.1*
  ENT14       |15             |messages        |Message / alert               |LCF Entity E15<br/>*Added in v1.0.1*
  
### <a id="EXC"></a>EXC Exception condition response

NOTE - In a web service implementation many of these responses may be
carried by an HTTP response code rather than in the response payload.

  *Code ID*   |*Code value*   | *Definition*   |*Notes*
  ----------- |-------------- |--------------- |-----------------------------------------------------------------
  EXC01       |01             |Service unavailable  |Equivalent to HTTP response code 503
  EXC02       |02             |invalid user ID or password (as supplied in Q00C01) |Specific case of HTTP response code 401.     
  EXC03       |03             |invalid terminal ID or password (as supplied in Q00C04) |Specific case of HTTP response code 401.
  EXC04       |04             |Service unable to process request |Equivalent to HTTP response code 500
  EXC05       |05             |Invalid entity reference          |For use in all entity-specific responses. Specific case of HTTP response code 404.
  EXC06       |06             |Invalid data in element           |For use whenever a request specifies data that does not conform to the data type for the data element in question, e.g. an undefined code value, a badly-formed date, or an invalid patron password.
  EXC07       |07             |Request denied                    |Equivalent to HTTP response code 403. 
  EXC08       |08             |No records match the selection criteria in the request. |*Deprecated in v1.0.1 &ndash; If no records match the selection criteria, the response contains an empty list.*
  EXC09       |09             |Too many records match the selection criteria in the request   |Further information may be provided in an exception description and/or response message. May be used in response to function 02 requests.

### <a id="IMD"></a>IMD Item detailed information type

  *Code ID*   |*Code value*   |*Definition*                           |*Notes*
  ----------- |-------------- |-------------------------------------- |-------------------
  IMD01      |01             |All item detailed information          |A short-hand for requesting all detailed information that is available for the item.
  IMD02      |02             |Item media type / format               |Element D01R03
  IMD03      |03             |Title on item                          |Element C01R04, title type TTL02
  IMD04      |04             |Other item titles                      |Element C01R04, all other title types, plus element C1106, if any, all title types
  IMD05      |05             |Contributor details                    |Element C01R05
  IMD06      |06             |Other item descriptive information     |Elements D01R07 – D01R13
  IMD07      |07             |Item owner information                 |Element D01R14
  IMD08      |08             |Item location information              |Elements D01R15 and D01R16
  IMD09      |09             |Item loan characteristics              |Element C01R17
  IMD10      |10             |Item check-out restrictions and fees   |Elements C01R18 and C01R19
  IMD11      |11             |Item circulation information           |Elements D01R21 – C01R23. NOTE – element D01R20 is mandatory in all responses.

### <a id="IMI"></a>IMI Item identification scheme

  *Code ID*   |*Code value*   |*Definition*   |*Notes*
  ----------- |-------------- |-------------- |---------
  IMI01       |01             |Proprietary    |

### <a id="IMT"></a>IMT Item media type / format (based upon SIP 2 media type code list)

  *Code ID*   |*Code value*   |*Definition*                   |*Notes*
  ----------- |-------------- |------------------------------ |--------------------------------------------------------------------
  IMT01       |000            |Other / unknown                |SIP 2 code ‘000’
  IMT02       |001            |Book                           |SIP 2 code ‘001’
  IMT03       |002            |Magazine                       |SIP 2 code ‘002’
  IMT04       |003            |Bound journal                  |SIP 2 code ‘003’
  IMT05       |004            |Audio tape                     |SIP 2 code ‘004’
  IMT06       |005            |Video tape (VHS or Betamax)    |SIP 2 code ‘005’
  IMT07       |006            |Data or software CD / CD-ROM   |SIP 2 code ‘006’
  IMT08       |007            |Magnetic diskette              |SIP 2 code ‘007’
  IMT09       |008            |Book with magnetic diskette    |SIP 2 code ‘008’
  IMT10       |009            |Book with CD / CD-ROM          |SIP 2 code ‘009’
  IMT11       |010            |Book with audio tape           |SIP 2 code ‘010’
  IMT12       |011            |DVD / Blu-ray                  |
  IMT13       |012            |Audio / music CD            |   
  IMT14       |013            |E-book                         |
  IMT15       |014            |Sheet music                  |  
  IMT16       |015            |Bound music score        |      
  IMT17       |016            |Microfilm / microform      |    
  IMT18       |017            |Map                            |
  IMT19       |018            |Toy                            |
  IMT20       |019            |Artefact                       |Needs further definition, especially to distinguish it from IMT01.

NOTE – This code list is to be revised in consultation with libraries. The existing codes are retained for reasons of backwards-compatibility.

### <a id="INS"></a>INS Institution identification scheme

  *Code ID*   |*Code value*   |*Definition*         |*Notes*
  ----------- |-------------- |-------------------- |---------------------------
  INS01       |01             |Proprietary scheme   |Other codes to be defined
  INS02       |02             |ISIL                 |

### <a id="LAT"></a>LAT Location association type

  *Code ID*   |*Code value*   |*Definition*                                               |*Notes*
  ----------- |-------------- |---------------------------------------------------------- |-----------------
  LAT01       |01             |Permanent location of item                                 |SIP2 field 'AQ'
  LAT02       |02             |Current location of item                                   |SIP2 field 'AP'
  LAT03       |03             |Patron's "home" institution / branch / site / department   |
  LAT04       |04             |Main location of authority/institution                     |*Added in v1.0.1*
  LAT05       |05             |Other location of authority/institution                    |*Added in v1.0.1*
  LAT06       |06             |Website of library authority/institution, branch or section|*Added in v1.0.1*

### <a id="LCS"></a>LCS Library classification scheme

  *Code ID*   |*Code value*   |*Definition*                         |*Notes*
  ----------- |-------------- |------------------------------------ |---------
  LCS01       |01             |Proprietary                          |
  LCS02       |02             |Dewey Decimal Classification (DDC)   |

### <a id="LKT"></a>LKT Resource access link type *(added in v1.0.1)*

  *Code ID*   |*Code value*   |*Definition*                         |*Notes*
  ----------- |-------------- |------------------------------------ |---------
  LKT01       |01             |Direct link to resource              |
  LKT02       |02             |Indirect link to resource            |

### <a id="LOI"></a>LOI Location identification scheme

  *Code ID*   |*Code value*   |*Definition*   |*Notes*
  ----------- |-------------- |-------------- |---------
  LOI01       |01             |Proprietary    
  LOI02       |02             |GLN            
  LOI03       |03             |SAN            
  LOI04       |04             |URI            |*Added in v1.0.1*
  LOI05       |05             |UPRN           |*Added in v1.0.1*

### <a id="LOS"></a>LOS Loan status

 *Code ID*                                          |*Code value*   |*Definition*                           |*Notes*
  ------------ |-------------- |-------------------------------------- |----------------
  LOS01        |01             |On loan to patron                      |
  LOS02        |02             |Overdue from patron                    |
  LOS03        |03             |Recalled                               |
  LOS04        |04             |Charge owed                            |
  LOS05        |05             |In transit between library locations   |
  LOS06        |06             |Claimed returned by patron             |
  LOS07        |07             |Lost                                   |
  LOS08        |08             |Checked in – no longer on loan         |Used when recording past loans
  LOS09        |09             |Superseded by renewal loan             |Used when recording past loans. Element E05D09 may contain renewal loan reference
  LOS10        |10             |Cancelled                              |Used when recording past loans
  LOS11        |11             |Renewal loan                           |
  
### <a id="LOT"></a>LOT Location type

*Code ID*      |*Code value*   |*Definition*                        |*Notes*
  ------------ |-------------- |----------------------------------- |------------------------------
  LOT01        |01             |Library / institution               |
  LOT02        |02             |Site within library / institution   |e.g. branch or building
  LOT03        |03             |Location within site                |e.g. department, room, shelf
  LOT04        |04             |Virtual location                    |Used for digital content<br/>*Added in v1.0.1*
  
### <a id="MAC"></a>MAC Message/alert display/delivery constraints *(added in v1.0.1)*

*Code ID*   |*Code value*   |*Definition*                        |*Notes*
  --------- |-------------- |----------------------------------- |------------------------------
  MAC01     |01             |Display/deliver between from/until dates | If no 'until' date is specified, display indefinitely
  MAC02     |02             |Display/deliver until acknowledged  |
  MAC03     |03             |Not for display/delivery - inactive |
  
### <a id="MAD"></a>MAD Message/alert delivery status *(added in v1.0.1)*

*Code ID*   |*Code value*   |*Definition*                        |*Notes*
  --------- |-------------- |----------------------------------- |------------------------------
  MAD01     |01             |Not yet delivered                   |
  MAD02     |02             |Delivered, not acknowledged         |
  MAD03     |03             |Delivered, acknowledged             |
  
### <a id="MAP"></a>MAP Message/alert priority *(added in v1.0.1)*

*Code ID*   |*Code value*   |*Definition*                        |*Notes*
  --------- |-------------- |----------------------------------- |------------------------------
  MAP01     |01             |High priority                       |
  MAP02     |02             |Medium priority                     |
  MAP03     |03             |Low priority                        |
  
### <a id="MAT"></a>MAT Message/alert type *(added in v1.0.1)*

*Code ID*   |*Code value*   |*Definition*                        |*Notes*
  --------- |-------------- |----------------------------------- |------------------------------
  MAT01     |01             |Action required                     |
  MAT02     |02             |Institution information             |e.g. opening hours, closures
  MAT03     |03             |Collection information              |e.g. acquisitions, disposals
  MAT04     |04             |Patron account information          |
  
### <a id="MAU"></a>MAU Message/alert audience *(added in v1.0.1)*

*Code ID*   |*Code value*   |*Definition*                        |*Notes*
  --------- |-------------- |----------------------------------- |------------------------------
  MAU01     |01             |All patrons                         |
  MAU02     |02             |Specified patrons and categories    |
  MAU03     |03             |Patrons related to specified loans  | *Added in v1.1.0*
  MAU04     |04             |Patrons related to specified reservations | *Added in v1.1.0*

### <a id="MES"></a>MES Media type / format scheme

  *Code ID*   |*Code value*   |*Definition*         |*Notes*
  ----------- |-------------- |-------------------- |---------
  MES01       |01             |Proprietary          |
  MES02       |02             |SIP2 media type, including LCF extensions |Any code value from code list [IMT](#IMT)
  MES03       |03             |ONIX code list 150   |
  MES04       |04             |ONIX code list 175   |
  MES05       |05             |MARC 21 media type   |*Added in v1.0.1*

### <a id="MEW"></a>MEW Media warning flag

  *Code ID*   |*Code value*   |*Definition*                           |*Notes*
  ----------- |-------------- |-------------------------------------- |---------
  MEW01       |00             |Unspecified / not applicable           |
  MEW02       |01             |Item contains magnetic media           |
  MEW03       |02             |Item does not contain magnetic media   |

### <a id="MGT"></a>MGT Message display type

  *Code ID*   |*Code value*   |*Definition*                                 |*Notes*
  ----------- |-------------- |-------------------------------------------- |---------
  MGT01       |01             |Whole message (e.g. for screen display)      |
  MGT02       |02             |Single line of message (e.g. for printing)   |
  MGT03       |03             | System message (not normally for display)   |

### <a id="MND"></a>MND Manifestation detailed information type

  *Code ID*   |*Code value*   |*Definition*                                  |*Notes*
  ----------- |-------------- |--------------------------------------------- |------------
  MND01       |01             |All manifestation detailed information        |A short-hand for requesting all detailed information that is available for the manifestation.
  MND02       |02             |Media type / format                           |Element E01C03
  MND03       |03             |Title of the manifestation                    |Element E01C04, title type TTL02
  MND04       |04             |Other item titles                             |Element E01C04, all other title types, plus element E0106, if any, all title types
  MND05       |05             |Contributor details                           |Element E01C05
  MND06       |06             |Other manifestation descriptive information   |Elements E01D07 – E01D12
  MND07       |07             |Manifestation loan characteristics            |Element E01C13
  MND08       |08             |Item check-out restrictions and fees          |Elements E01C14 and E01C15

### <a id="MNI"></a>MNI Manifestation identification scheme (based upon ONIX Code List 5)

  *Code ID*   |*Code value*   |*Definition*           |*Notes*
  ----------- |-------------- |---------------------- |--------------------------------------------------
  MNI01       |01             |Proprietary            |ONIX code ‘01’
  MNI02       |02             |ISBN-10                |ONIX code ‘02’ – 10-digit ISBN
  MNI03       |03             |GTIN-13                |ONIX code ‘03’ – normally used for 13-digit ISBN
  MNI04       |05             |ISMN                   |ONIX code ‘05’
  MNI05       |14             |GTIN-14                |ONIX code ‘14’
  MNI06       |17             |Legal deposit number   |ONIX code ‘17’

### <a id="MNS"></a>MNS Manifestation status

  *Code ID*   |*Code value*   |*Definition*                                    |*Notes*
  ----------- |-------------- |----------------------------------------------- |-----------------------------------------
  MNS01       |01             |Not yet in stock / holding                      |Awaiting receipt from supplier or owner
  MNS02       |02             |In stock / holding and available for loan       |
  MNS03       |03             |In stock / holding and not available for loan   |e.g. Reading Room only
  MNS04       |04             |Withdrawn from stock / holding                  |

### <a id="MOT"></a>MOT Entity modification type

  *Code ID*   |*Code value*   |*Alpha value*   |*Definition*    |*Notes*
  ----------- |-------------- |--------------- |----------------- |-----------------
  MOT01       |01             |replace         |Delete all elements of the entity and replace with those included in the request                                    |This is the only way to remove elements entirely from the entity record.
  MOT02       |02             |update          |Delete all elements of the types that are included in the request and replace with those included in the request.   |For repeatable elements all instances of the element are first removed from the entity record.

### <a id="NOT"></a>NOT Note type

  *Code ID*   |*Code value*   |*Definition*         |*Notes*
  ----------- |-------------- |-------------------- |--------------------
  NOT01       |01             |Entity description   |This code value is primarily a place-holder for development of the code list in future issues.

### <a id="PCS"></a>PCS Patron’s library card status

  *Code ID*   |*Code value*   |*Definition*                     |*Notes*
  ----------- |-------------- |-------------------------------- |---------------------
  PCS01       |01             |Card retained by patron          |
  PCS02       |02             |Card retained by library staff   |
  PCS03       |03             |Card location unknown            |Card lost or stolen

### <a id="PGP"></a>PGP Patron group association type

  *Code ID*   |*Code value*   |*Definition*                     |*Notes*
  ----------- |-------------- |-------------------------------- |---------------------
  PGP01       |01             |Patron member of group           |
  PGP02       |02             |Lead patron of group             |

### <a id="PNI"></a>PNI Patron identification scheme (based upon ONIX Code List 44) - *Added in v1.0.1*

  *Code ID*   |*Code value*   |*Definition*           |*Notes*
  ----------- |-------------- |---------------------- |--------------------------------------------------
  PNI01       |01             |Proprietary            |ONIX code ‘01’
  PNI02       |16             |ISNI                   |ONIX code ‘16’
  PNI03       |18             |LCCN                   |ONIX code ‘17’
  PNI04       |21             |ORCID                  |ONIX code ‘21’
  PNI05       |31             |VIAF ID                |ONIX code ‘31’

### <a id="PNS"></a>PNS Patron status condition type (based upon ANSI/NISO Z39.70)

  *Code ID*   |*Code value*   |*Definition*                                  |*Notes*
  ----------- |-------------- |--------------------------------------------- |-------------------------
  PNS01       |01             |Loan (charge) privileges denied               |
  PNS02       |02             |Renewal privileges denied                     |
  PNS03       |03             |Recall privileges denied                      |
  PNS04       |04             |Hold privileges denied                        |
  PNS05       |05             |Card reported lost                            |
  PNS06       |06             |Too many items loaned                         |
  PNS07       |07             |Too many items overdue                        |
  PNS08       |08             |Too many renewals                             |
  PNS09       |09             |Too many claims of items returned             |
  PNS10       |10             |Too many items lost                           |
  PNS11       |11             |Excessive outstanding fines                   |
  PNS12       |12             |Excessive outstanding fees other than fines   |
  PNS13       |13             |Recall overdue                                |
  PNS14       |14             |Too many items billed                         |
  PNS15       |15             |Blocked from PC use only                      |Allowed to borrow items
  PNS16       |16             |Account expired                               |*Added in v1.0.1*

### <a id="PNT"></a>PNT Patron detailed information type

  *Code ID*   |*Code value*   |*Definition*                       |*Notes*
  ----------- |-------------- |---------------------------------- |----------------------------
  PNT01       |00             |No details – i.e. status only      |
  PNT02       |01             |All details                        |
  PNT03       |02             |All personal, no account details   |See [E03 Patron](LCF-DataFrameworks.md#e03)
  PNT04       |03             |All account, no personal details   |See [E03 Patron](LCF-DataFrameworks.md#e03)
  PNT05       |10             |Items on loan                      |
  PNT06       |11             |Reserved items                     |
  PNT07       |12             |Overdue items                      |
  PNT08       |13             |Recalled items                     |
  PNT09       |14             |Unavailable hold items             |
  PNT10       |15             |Fees, other than fines, owed       |
  PNT11       |16             |Fines owed                         |

### <a id="PYS"></a>PYS Payment status

  *Code ID*   |*Code value*   |*Definition*                      |*Notes*
  ----------- |-------------- |--------------------------------- |--------------------------------------------------------------------
  PYS01       |01             |Payment accepted / acknowledged   |
  PYS02       |02             |Payment not accepted              |Further information, if any, should be included in a payment note.

### <a id="PYT"></a>PYT Payment type (extension of SIP 2 payment type code list)

  *Code ID*   |*Code value*   |*Definition*                     |*Notes*
  ----------- |-------------- |-------------------------------- |-------------------
  PYT01       |00             |Cash                             |SIP 2 code ‘00’
  PYT02       |01             |VISA                             |SIP 2 code ‘01’ – Probably DEPRECATED, since the card could be a debit or credit card.
  PYT03       |02             |Credit card – unspecified type   |SIP 2 code ‘02’
  PYT04       |03             |Debit card – unspecified type    |
  PYT05       |04             |E-payment – unspecified type     |Probably using some form of online banking or a system where the patron has an account with a local charging scheme.
  PYT06       |05             |Cheque                           |
  PYT07       |06             |Credit account                   |
  PYT08       |07             |Smart card                       |
  PYT09       |08             |Forgiven                         |Payment by the library of a correct charge
  PYT10       |09             |Waived                           |Payment by the library of an incorrect charge

### <a id="RDN"></a>RDN Reason for inability to approve request

  *Code ID*   |*Code value*   |*Definition*                      |*Notes*
  -------------- |-------------- |---------------------------------- |----------------------
  RDN01                                              |01             |Manifestation status exception                                    |The LMS is unable to approve the request due to the manifestation's current status (E01D17). Used in response to a request relating to a specific manifestation.
  RDN02                                              |02             |Item status exception                                             |The LMS is unable to approve the request due to the item's current circulation status (E02D12). Used in response to a request relating to a specific item.
  RDN03                                              |03             |Patron status exception                                           |The LMS is unable to approve the request due to the patron’s current status (E03C08). Used in response to a request relating to a specific patron.
  RDN04                                              |04             |No fee acknowledgement in request                                 |The LMS is unable to approve the request without acknowledgement that a fee is applicable.
  RDN05                                              |05             |Charge status exception – no payment due                          |
  RDN06                                              |06             |Charge status exception – under-payment                           |
  RDN07                                              |07             |Charge status exception – over-payment                            |
  RDN08   |08             |Unable to accept payment – see message                            |Further information, if any, should be conveyed in response message.
  RDN09                                              |09             |Unable to accept some/all payment items in request – see detail   

### <a id="RNQ"></a>RNQ Renewal request type

  *Code ID*   |*Code value*   |*Definition*                                                             |*Notes*
  ----------- |-------------- |----------------------------------------------- |-----------------------------------------------------------------
  RNQ01       |01             |Patron renewal request, for all items currently on loan to patron        |
  RNQ02       |02             |Third party renewal request, for all items currently on loan to patron   |
  RNQ03       |03             |Patron renewal request, for specified items                              |
  RNQ04       |04             |Third party renewal request, for specified items                         |
  RNQ05       |51             |Loan / renewal fee quotation request only                                |Not a loan request or confirmation, but simply a request for a loan or renewal fee quotation
  RNQ06       |99             |Cancel previous request                                                  |Cancels the previous new loan or renewal request for the same item. If there was no previous request or too long a pause since the previous request, the response should contain exception condition code EXC03.

### <a id="RQT"></a>RQT Request type

  *Code ID*   |*Code value*   |*Definition*                                               |*Notes*
  ----------- |-------------- |--------------------- |----------------------------------------------
  RQT01       |01             |New request                                                |
  RQT02       |02             |Confirmation request                                       |LMS may not block request, as the action has already been performed.
  RQT03       |03             |Cancel previous request                                    |Cancels a previous request. If there was no previous request or too long a pause since the previous request, the response should contain exception condition code EXC03. Approximately equivalent to use of SIP 2 field BI to indicate cancelation.
  RQT04       |04             |Loan / renewal or reservation fee quotation request only   |Not a loan / renewal or reservation request or confirmation, but simply a request for a loan / renewal or reservation fee quotation

### <a id="RST"></a>RST Response type

  *Code ID*   |*Code value*   |*Definition*                                                 |*Notes*
  ----------- |-------------- |------------------------------------------------------------ |---------
  RST01       |01             |Request successful                                           |
  RST02       |02             |Request unsuccessful – for details see exception condition   |

### <a id="RVQ"></a>RVQ Reservation request type

  *Code ID*   |*Code value*   |*Definition*                             |*Notes*
  ----------- |-------------- |---------------------------------------- |--------------------------------------------
  RVQ01       |01             |Reservation request                      |
  RVQ02       |02             |Modify previous reservation request      |
  RVQ03       |03             |Reservation fee quotation request only   |Not a reservation request, but simply a request for a reservation fee quotation
  RVQ04       |04             |Cancel previous reservation request      |Cancels the previous request to reserve the same item. If there was no previous request or too long a pause since the previous request, the response should contain exception condition code EXC03.

### <a id="RVS"></a>RVS Reservation status

  *Code ID*   |*Code value*   |*Definition*                             |*Notes*
  ----------- |-------------- |---------------------------------------- |-----------------------------------------
  RVS01       |01             |Item available - in hold queue           |
  RVS02       |02             |Unavailable hold item                    |
  RVS03       |03             |Reservation cancelled by patron          |Used when recording past reservations
  RVS04       |04             |Reservation cancelled by library staff   |Used when recording past reservations
  RVS05       |05             |Ended by check-out to patron             |Used when recording past reservations
  RVS06       |06             |Expired                                  |Reservation terminated on reaching expiry date without either check-out of the item or cancellation of the reservation. Used when recording past reservations.
  RVS07       |07             |Suspended                                |Reservation temporarily suspended. It is recommended to specify start and/or end dates of the suspension.<br/>*Added in v1.1.0*

### <a id="RVT"></a>RVT Reservation type (based upon SIP 2 hold type code list)

  *Code ID*   |*Code value*   |*Definition*                                                         |*Notes*
  ----------- |-------------- |------------------------------------------ |-----------------------------------------
  RVT01       |1              |Other                                                                |SIP code ‘1’
  RVT02       |2              |Any copy of the item                                                 |SIP code ‘2’
  RVT03       |3              |A specific copy of the item                                          |SIP code ‘3’ – The item identifier must specify the specific copy to be reserved
  RVT04       |4              |Any copy of the item at a specified branch library or sub-location   |SIP code ‘4’ – The institution identifier and/or location must specify the branch library and/or sub-location
  RVT05       |5              |Any copy of the item in a specified group of libraries               |

### <a id="SCD"></a>SCD Security desensitization flag

  *Code ID*   |*Code value*   |*Definition*                                                               |*Notes*
  ----------- |-------------- |-------------------------------------------------------------------------- |---------
  SCD01       |00             |Unspecified / not applicable                                               |
  SCD02       |01             |Item security should normally be desensitized / removed on check-out       |
  SCD03       |02             |Item security should not normally be desensitized / removed on check-out   |

### <a id="SEL"></a>SEL Selection criterion - *Added in v1.0.1*

  *Code ID*   |*Code value*   |*Alpha value*          |*Definition*                |*Notes*
  ----------- |-------------- |---------------------- |--------------------------- |----------------
  SEL01       |01             |manifestation-id       |Manifestation identifier    | See E01D01
  SEL02       |02             |item-id                |Item identifier             | See E02D01
  SEL03       |03             |patron-id              |Patron identifier           | See E03D01
  SEL04       |04             |location-id            |Location identifier         | See E04D01
  SEL05       |11             |circulation-status     |Circulation status          | See E02D11
  SEL06       |12             |loan-status            |Loan status                 | See E05D07
  SEL07       |21             |start-date             |Loan, reservation or message/alert start date | See E05D04, E06D06, E15D07
  SEL08       |22             |end-date               |Loan, reservation or message/alert end date | See E05D06, E06D10, E15D08
  SEL09       |23             |end-due-date           |Loan end due date           | See E05D05
  SEL10       |24             |recall-notice-date     |Loan recall notice date     | See E05D10
  SEL11       |25             |pickup-date            |Reservation pick-up date    | See E06D09
  SEL12       |26             |creation-date          |Charge creation date        | See E07D10
  SEL13       |27             |payment-due-date       |Charge payment due date     | See E07D11
  SEL14       |28             |paid-date              |Date charge paid in full    | See E07D16
  SEL15       |29             |payment-date           |Date payment made           | See E08D06
  SEL16       |30             |patron-expiration-date |Date patron account expired | See E03D30

### <a id="SPA"></a>SPA Special attention required flag

  *Code ID*   |*Code value*   |*Definition*                                    |*Notes*
  ----------- |-------------- |----------------------------------------------- |---------
  SPA01       |01             |Item does not require special attention         |
  SPA02       |02             |Item requires special attention (unspecified)   |

### <a id="TFT"></a>TFT Text format

  *Code ID*   |*Code value*   |*Definition*                                    |*Notes*
  ----------- |-------------- |----------------------------------------------- |---------
  TFT01       |01             |Plain text, ASCII encoding                      |
  TFT02       |02             |Plain text, ISO 8859-1 encoding                 |
  TFT03       |03             |Plain text, ISO 10646 / Unicode encoding        |
  TFT04       |11             |HTML 4                                          |
  TFT05       |12             |XHTML 1                                         |
  TFT06       |13             |HTML 5                                          |
  TFT07       |14             |MarkDown                                        |
  TFT08       |04             |Plain text, encoding specified at message level | *Added in v1.0.1*

### <a id="TTL"></a>TTL Title type (based upon ONIX Code List 15)

  *Code ID*   |*Code value*   |*Definition*                 |*Notes*
  ----------- |-------------- |---------------------------- |----------------
  TTL01       |00             |Undefined                    |ONIX code ‘00’
  TTL02       |01             |Title on item                |ONIX code ‘01’
  TTL03       |03             |Title in original language   |ONIX code ‘03’
  TTL04       |05             |Abbreviated title            |ONIX code ‘05’
  TTL05       |11             |Alternative title on cover   |ONIX code ‘11’
  TTL06       |13             |Expanded title               |ONIX code ‘13’

### <a id="UNC"></a>UNC Unnamed contributor type (based upon ONIX Code List 11)

  *Code ID*   |*Code value*   |*Definition*   |*Notes*
  ----------- |-------------- |-------------- |----------------
  UNC01       |01             |Unknown        |ONIX code ‘01’
  UNC02       |02             |Anonymous      |ONIX code ‘02’
  UNC03       |03             |et al.         |ONIX code ‘03’
