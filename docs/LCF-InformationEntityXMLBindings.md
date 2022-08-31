---
title: LCF v1.2.0 Information Entities XML bindings
menu: Information Entities XML bindings
weight: 3
---

# Book Industry Communication

## Library Interoperability Standards

## Library Data Communication Framework for Terminal Applications (LCF)

## Information Entities XML bindings

### Version x.x.0

### DRAFT

---

This document specifies XML bindings for the information entities defined in version 1.0 of the LCF data communication framework. It is intended to be used with any implementation of LCF in which the information entities are encoded in XML, and specifically with the standard web service implementations of LCF.

This document also specifies a standard XML binding for the data framework for communicating exception conditions in LCF response messages.

The use of this document is subject to license terms and conditions that can be found *at* <http://www.bic.org.uk/files/bicstandardslicence.pdf>.

The namespace for these XML bindings is "http://ns.bic.org.uk/lcf/1.0". This namespace will be used for all 1.x.x versions of this specification. From Version 1.1.0 onwards, wherever possible, the XML Bindings will be backwards compatible with earlier versions within the same Major version, for example, by only introducing optional, non-mandatory elements. However, clients and servers must be prepared to receive XML messages that might contain optional but unknown elements introduced in a newer versions, the contents of these elements being safe to ignore.

The datatypes 'string', 'int', 'decimal', 'anyURI', 'year', 'date' and 'dateTime' used in these XML bindings are specified in W3C XML Schema Part 2: Datatypes &ndash; see <a href="http://www.w3.org/TR/xmlschema-2/">http://www.w3.org/TR/xmlschema-2/</a>.

Data elements must be non-empty when included, as well as conforming to the specified datatype.

Identifiers in requests are mandatory except when creating a new entity. When creating an entity, the LMS may expect the terminal to provide the identifier in the case of Item and Patron entities, but when creating any other type of entity the LMS will generally assign its own identifier to the entity and ignore any identifier provided by the terminal.

An XML schema that corresponds to this specification is available at [https://github.com/bic-org-uk/bic-lcf/tree/vx.x.0/lcf-schema/src/main/resources](https://github.com/bic-org-uk/bic-lcf/tree/vx.x.0/lcf-schema/src/main/resources).

E01 MANIFESTATION
-----------------

|        | *Element ID* | *XML structure*                  | *Card.* | *Data type* | *Notes* |
|--------|--------------|----------------------------------|---------|-------------|---------|
| **1**  |              | **manifestation<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                       |         |             | **Top-level&nbsp;element**<br/>*'version' attribute removed in v1.0.1*                                 |
|   2    | E01D01       | identifier                       | 0-1     | string      | Mandatory except when creating a new entity, in which case the identifier may be assigned by the LMS                        |
|   3    | E01C02       | additional-manifestation-id      | 0-n     |             |         |
|   4    | E01D02.1     | manifestation-id-type            | 1       | Code        | [MNI](LCF-CodeLists.md#MNI)     |
|   5    | E01D02.2     | type-name                        | 0-1     | string      |         |
|   6    | E01D02.3     | value                            | 1       | string      |         |
|   7    | E01D22       | manifestation-type               | 0-1     | Code        | [MNT](LCF-CodeLists.md#MNT)     |
|   8    | E01C03       | media-type                       | 0-n     |             |         |
|   9    | E01D03.1     | media-type-scheme                | 1       | Code        | [MES](LCF-CodeLists.md#MES)     |
|  10    | E01D03.2     | scheme-name                      | 0-1     | string      |         |
|  11    | E01D03.3     | scheme-code                      | 1       | string      |         |
|  12    | E01C04       | title                            | 0-n     |             |         |
|  13    | E01D04.1     | title-type                       | 1       | Code        | [TTL](LCF-CodeLists.md#TTL)     |
|  14    | E01D04.2     | title-text                       | 1       | string      |         |
|  15    | E01D04.3     | subtitle                         | 0-1     | string      |         |
|  16    | E01C05       | contributor                      | 0-n     |             |         |
|  17    | E01D05.1     | contributor-role                 | 1       | Code        | ONIX code list 17                                                                                           |
|  18    | E01D05.2     | contributor-name                 | 0-1     | string      | Either a contributor name or an unnamed contributor code must be included in each contributor composite.                     |
|  19    | E01D05.3     | unnamed-contributor              | 0-1     | Code        | [UNC](LCF-CodeLists.md#UNC)     |
|  20    | E01C06       | series                           | 0-1     |             |         |
|  21    | E01C06.1     | title                            | 0-n     |             |         |
|  22    | E01D06.1.1   | title-type                       | 1       | Code        | [TTL](LCF-CodeLists.md#TTL)     |
|  23    | E01D06.1.2   | title-text                       | 1       | string      |         |
|  24    | E01D06.1.3   | subtitle                         | 0-1     | string      |         |
|  25    | E01D06.2     | volume-or-part                   | 0-1     | string      |         |
|  26    | E01D06.3     | other-manifestation-in-series-ref| 0-n     | string      | *Renamed in v1.0.1* |
|  27    | E01D07       | edition-statement                | 0-1     | string      |         |
|  28    | E01D08       | publisher-name                   | 0-1     | string      |         |
|  29    | E01D09       | year-of-publication              | 0-1     | year        |         |
|  30    | E01D23       | serial-holding-statement         | 0-1     | string      |         |
|  31    | E01D25       | serial-issue-enumeration         | 0-1     | string      |         |
|  32    | E01D26       | serial-issue-chronology          | 0-1     | string      |         |
|  33    | E01C10       | classification                   | 0-n     |             |         |
|  34    | E01D10.1     | class-scheme-ref                 | 1       | string      |         |
|  35    | E01D10.2     | class-term-ref                   | 1       | string      |         |
|  36    | E01D11       | cover-art                        | 0-n     | anyURI      |         |
|  37    | E01D12       | description                      | 0-1     | string      |         |
|  38    | E01C24       | associated-manifestation         | 0-n     |             |         |
|  39    | E01D24.1     | association-type                 | 1       | Code        | [MNA](LCF-CodeLists.md#MNA)     |
|  40    | E01D24.2     | manifestation-ref                | 1       | string      |         |
|  41    | E01C13       | loan-restriction                 | 0-n     |             |         |
|  42    | E01D13.1     | restriction-type                 | 1       | Code        | [CRT](LCF-CodeLists.md#CRT)     |
|  43    | E01D13.2     | value                            | 1       | string      |         |
|  44    | E01D13.3     | note                             | 0-1     | string      |         |
|  45    | E01C14       | loan-fee                         | 0-n     |             |         |
|  46    | E01D14.1     | fee-type                         | 1       | Code        | [CHT](LCF-CodeLists.md#CHT)     |
|  47    | E01D14.2     | amount                           | 1       | decimal     |         |
|  48    | E01D14.3     | currency                         | 0-1     | Code        | ISO 3-letter code                                                                                         |
|  49    | E01D15       | patrons-in-hold-queue            |0-1R[\[1\]](#Notes)                                                 | int         |         |
|  50    | E01D16       | manifestation-record             | 0-1     | string      | *Renamed in v1.0.1* |
| **51** | **E01D17**   | **manifestation-status**         | **1**   | **Code**    | **[MNS](LCF-CodeLists.md#MNS)** |
|  52    | E01D18       | items-in-stock                   | 0-1R    | int         |         |
|  53    | E01D19       | item-ref                         | 0-nR    | string      |         |
|  54    | E01D20       | reservation-ref                  | 0-nR    | string      |         |
|  55    | E01C21       | note                             | 0-n     |             |         |
|  56    | E01D21.1     | note-type                        | 0-1     | Code        | [NOT](LCF-CodeLists.md#NOT)     |
|  57    | E01D21.2     | date-time                        | 0-1     | dateTime    |         |
|  58    | E01D21.3     | note-text                        | 1       | string      |         |

*Example of a manifestation*

`<manifestation xmlns="http://ns.bic.org/lcf/1.0" version="1.0">`<br/>
&#xA0;`<identifier\>1234567890</identifier>`<br/>
&#xA0;`<media-type>`<br/>
&#xA0;`<media-type-scheme>02</media-type-scheme>`<br/>
&#xA0;`<scheme-code>001</scheme-code>`<br/>
&#xA0;`</media-type>`<br/>
&#xA0;`<title>`<br/>
&#xA0;&#xA0;`<title-type>01</title-type>`<br/>
&#xA0;&#xA0;`<title-text>Title on book</title-text>`<br/>
&#xA0;`</title>`<br/>
&#xA0;`<contributor>`<br/>
&#xA0;&#xA0;`<contributor-role>A01</contributor-role>`<br/>
&#xA0;&#xA0;`<contributor-name>Smith, J.</contributor-name>`<br/>
&#xA0;`</contributor>`<br/>
&#xA0;`<manifestation-status>02</manifestation-status>`<br/>
`</manifestation>`

E02 ITEM
--------

|        | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|--------|--------------|-----------------------------|---------|-------------|---------|
| **1**  |              | **item<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                         |        |              | **Top-level&nbsp;element**<br/>*'version' attribute removed in v1.0.1*                                |
|   2    | E02D01       | identifier                  | 0-1     | string      | Mandatory except when creating a new entity, in which case the identifier may be assigned by the LMS                         |
|   3    | E02C02       | additional-item-id          | 0-n     |             |         |
|   4    | E02D02.1     | item-id-type                | 1       | Code        | [IMI](LCF-CodeLists.md#IMI)     |
|   5    | E02D02.2     | type-name                   | 0-1     | string      |         |
|   6    | E02D02.3     | value                       | 1       | string      |         |
| **7**  | **E02D03**   | **manifestation-ref**       | **1**   | **string**  |         |
|   8    | E02D04       | description                 | 0-1     | string      |         |
|   9    | E02D05       | owner-ref                   | 0-1     | string      | *Tag name changed from 'owner' to 'owner-ref' in v1.0.1. References an Authority/Institution entity (E14)*                |
|  10    | E02C06       | associated-location         | 0-n     |             |         |
|  11    | E02D06.1     | association-type            | 1       | Code        | [LAT](LCF-CodeLists.md#LAT)     |
|  12    | E02D06.2     | location-ref                | 1       | string      | *Cardinality corrected in v1.0.1*                                                                                 |
|**13**  | **E02D07**   | **media-warning**           | **1**   | **Code**    | **[MEW](LCF-CodeLists.md#MEW)** |
|**14**  | **E02D08**   | **security-desensitize**    | **1**   | **Code**    | **[SCD](LCF-CodeLists.md#SCD)** |
|  15    | E02C09       | loan-restriction            | 0-n     |             |         |
|  16    | E02D09.1     | restriction-type            | 1       | Code        | [CRT](LCF-CodeLists.md#CRT)     |
|  17    | E02D09.2     | value                       | 1       | string      |         |
|  18    | E02D09.3     | restriction-note            | 0-1     | string      | *Name changed in v1.1.0*        |
|  19    | E02C10       | loan-fee                    | 0-n     |             |         |
|  20    | E02D10.1     | fee-type                    | 1       | Code        | [CHT](LCF-CodeLists.md#CHT)     |
|  21    | E02D10.2     | amount                      | 1       | decimal     |         |
|  22    | E02D10.3     | currency                    | 0-1     | Code        | ISO 3-letter code                                                                                    |
|**23**  | **E02D11**   | **circulation-status**      | **1**   | **Code**    | **[CIS](LCF-CodeLists.md#CIS)** |
|  24    | E02D12       | reservation-ref             | 0-nR    | string      |         |
|  25    | E02D13       | patrons-in-hold-queue       | 0-1R    | int         |         |
|  26    | E02D14       | on-loan-ref                 | 0-1R    | string      |         |
|  27    | E02D15       | condition-code              | 0-n     | Code        | LMS-proprietary<br/>*Cardinality corrected in v1.1.0*                                                                         |
|  28    | E02D16       | condition-description       | 0-1     | string      |         |
|  29    | E02C17       | note                        | 0-n     |             |         |
|  30    | E02D17.1     | note-type                   | 0-1     | Code        | [NOT](LCF-CodeLists.md#NOT)     |
|  31    | E02D17.2     | date-time                   | 0-1     | dateTime    |         |
|  32    | E02D17.3     | note-text                   | 1       | string      |         |

*Example of an item*

`<item xmlns="http://ns.bic.org/lcf/1.0" version="1.0">`<br/>
&#xA0;`<item-id>9876543210</item-id>`<br/>
&#xA0;`<manifestation-ref>1234567890</manifestation-ref>`<br/>
&#xA0;`<media-warning>02</media-warning>`<br/>
&#xA0;`<security-desensitize>01</security-desensitize>`<br/>
&#xA0;`<circulation-status>03</circulation-status>`<br/>
`</item>`

E03 PATRON
----------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|-------|--------------|-----------------------------|---------|-------------|---------|
| **1** |              | **patron<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                 |         |             | **Top-level&nbsp;element**<br/>*'version' attribute removed in v1.0.1*                                                        |
|   2   | E03D01       | identifier                  | 0-1     | string      | Mandatory except when creating a new entity, in which case the identifier may be assigned by the LMS                        |
|   3   | E03D26       | barcode-id                  | 0-1     | string      | *Added in v1.0.1*                 |
|   4   | E03C27       | additional-patron-id        | 0-n     |             | *Added in v1.0.1*                 |
|   5   | E03D27.1     | patron-id-type              | 1       | Code        | **[PNI](LCF-CodeLists.md#PNI)** |
|   6   | E02D27.2     | type-name                   | 0-1     | string      |         |
|   7   | E02D27.3     | value                       | 1       | string      |         |
| **8** | **E03D22**   | **name**                    | **1**   | **string**  | *Added in v1.0.1*                 |
|   9   | E03C36       | structured-name             | 0-1     |             | *Added in vx.x.0*                 |
|  10   | E03D36.1     | title-before-names          | 0-1     | string      |                                   |
|  11   | E03D36.2     | names-before-key            | 0-1     | string      |                                   |
|  12   | E03D36.3     | prefix-to-key               | 0-1     | string      |                                   |
|  13   | E03D36.4     | key-names                   | 1       | string      |                                   |
|  14   | E03D36.5     | names-after-key             | 0-1     | string      |                                   |
|  15   | E03D36.6     | suffix-to-key               | 0-1     | string      |                                   |
|  16   | E03D36.7     | letters-after-names         | 0-1     | string      |                                   |
|  17   | E03D36.8     | titles-after-names          | 0-1     | string      |                                   |
|  18   | E03D02       | contact-ref                 | 0-n     | string      |         |
|  19   | E03D23       | language                    | 0-1     | Code        | ISO three-letter code<br/>*Added in v1.0.1*                                                                                |
|  20   | E03C03       | associated-location         | 0-n     |             |         |
|  21   | E03D03.1     | association-type            | 1       | Code        | [LAT](LCF-CodeLists.md#LAT)    |
|  22   | E03D03.2     | location-ref                | 1       | string      | *Cardinality corrected in v1.0.1* |
|  23   | E03D35       | home-institution-ref        | 0-1     | string      | *added in v1.0.1, ID corrected in v1.1.0*                 |
|  24   | E03D04       | patron-status               | 0-nR    | Code        | [PNS](LCF-CodeLists.md#PNS)    |
|  25   | E03C24       | card-status-info            | 0-1R    |             | *Added in v1.0.1*<br/>*Cardinality corrected in v1.2.0*                 |
|  26   | E03D24.1     | card-status                 | 1R      | Code        | [PCS](LCF-CodeLists.md#PCS)    |
|  27   | E03D24.2     | blocked-card-message        | 0-1R    | string      |         |
|  28   | E03D28       | patron-category             | 0-1     | string      | *Added in v1.0.1*                 |
|  29   | E03D29       | patron-tag                  | 0-n     | string      | *Added in v1.0.1*                 |
|  30   | E03D32       | authorisation-ref           | 0-n     | string      | *Added in v1.0.1*                 |
|  31   | E03D30       | patron-expiration-date      | 0-1     | date        | *Added in v1.0.1*                 |
|  32   | E03C33       | associated-patron-group     | 0-n     |             | *Added in v1.0.1*                 |
|  33   | E03D33.1     | association-type            | 1       | Code        | [PGP](LCF-CodeLists.md#PGP)    |
|  34   | E03D33.5     | group-type                  | 0-1     | string      |         |
|  35   | E03D33.2     | patron-group-id             | 0-1     | string      |         |
|  36   | E03D33.3     | lead-patron-ref             | 0-n     | string      |         |
|  37   | E03D33.4     | patron-ref                  | 0-n     | string      |         |
|  38   | E03D07       | loan-ref                    | 0-nR    | string      |         |
|  39   | E03D08       | on-loan-items               | 0-1R    | int         |         |
|  40   | E03D09       | loan-items-limit            | 0-1     | int         |         |
|  41   | E03D10       | overdue-items               | 0-1R    | int         |         |
|  42   | E03D11       | overdue-items-limit         | 0-1     | int         |         |
|  43   | E03D12       | recalled-items              | 0-1R    | int         |         |
|  44   | E03D13       | fees-due-items              | 0-1R    | int         |         |
|  45   | E03D14       | fines-due-items             | 0-1R    | int         |         |
|  46   | E03D15       | reservation-ref             | 0-nR    | string      |         |
|  47   | E03D16       | available-hold-items        | 0-1R    | int         |         |
|  48   | E03D17       | unavailable-hold-items      | 0-1R    | int         |         |
|  49   | E03D18       | hold-items-limit            | 0-1     | int         |         |
|  50   | E03D19       | charge-ref                  | 0-nR    | string      |         |
|  51   | E03C20       | charge-limit                | 0-n     |             |         |
|  52   | E03D20.1     | charge-type                 | 0-1     | Code        | [CHT](LCF-CodeLists.md#CHT)   |
|  53   | E03D20.2     | amount                      | 1       | decimal     |         |
|  54   | E03D20.3     | currency                    | 0-1     | Code        | ISO currency code             |
|  55   | E03C31       | deposit-balance             | 0-1     |             | *Added in v1.0.1*                |
|  56   | E03D31.1     | amount                      | 1       | decimal     |         |
|  57   | E03D31.2     | currency                    | 0-1     | Code        | ISO currency code             |
|  58   | E03C34       | associated-message          | 0-n     |             |         |
|  59   | E03D34.1     | message-ref                 | 1       | string      |         |
|  60   | E03D34.2     | delivery-status             | 1       | Code        | [MAD](LCF-CodeLists.md#MAD)   |
|  61   | E03C21       | note                        | 0-n     |             |         |
|  62   | E03D21.1     | note-type                   | 0-1     | Code        | [NOT](LCF-CodeLists.md#NOT)   |
|  63   | E03D21.2     | date-time                   | 0-1     | dateTime    |         |
|  64   | E03D21.3     | note-text                   | 1       | string      |         |
|  65   | E03D25       | date-of-birth               | 0-1     | date        | *Added in v1.0.1*                |

E04 LOCATION
------------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|-------|--------------|-----------------------------|---------|-------------|---------|
| **1** |              | **location<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                 |         |             | **Top-level&nbsp;element**<br/>*'version' attribute removed in v1.0.1*                                                        |
|   2   | E04D01       | identifier                  | 0-1     | string      | Mandatory except when creating a new entity, in which case the identifier will be assigned by the LMS                       |
|   3   | E04C02       | additional-location-id      | 0-n     |             |         |
|   4   | E04D02.1     | location-id-type            | 1       | Code        | [LOI](LCF-CodeLists.md#LOI)     |
|   5   | E04D02.2     | type-name                   | 0-1     | string      |         |
|   6   | E04D02.3     | value                       | 1       | string      |         |
|   7   | E04D03       | name                        | 0-1     | string      |         |
|   8   | E04D04       | location-type               | 0-1     | Code        | [LOT](LCF-CodeLists.md#LOT)     |
|   9   | E04D09       | location-purpose            | 0-n     | Code        | [LOP](LCF-CodeLists.md#LOP)<br/>*Added in v1.2.0*    |
|  10   | E04D05       | description                 | 0-1     | string      |         |
|  11   | E04D07       | contact-ref                 | 0-n     | string      | *Added in v1.0.1*                  |
|  12   | E04C08       | associated-location         | 0-n     |             |         |
|  13   | E04D08.1     | association-type            | 1       | Code        | [LAT](LCF-CodeLists.md#LAT)    |
|  14   | E04D08.2     | location-ref                | 1       | string      |         |
|  15   | E04C06       | note                        | 0-n     |             |         |
|  16   | E04D06.1     | note-type                   | 0-1     | Code        | [NOT](LCF-CodeLists.md#NOT)     |
|  17   | E04D06.2     | date-time                   | 0-1     | dateTime    |         |
|  18   | E04D06.3     | note-text                   | 1       | string      |         |

E05 LOAN
--------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type*  | *Notes* |
|-------|--------------|-----------------------------|---------|--------------|---------|
| **1** |              | **loan<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                 |         |              | **Top-level&nbsp;element**<br/>*'version' attribute removed in v1.0.1*                                                         |
|   2   | E05D01       | identifier                  | 0-1     | string       | Mandatory except when creating a new entity, in which case the identifier will be assigned by the LMS                        |
| **3** | **E05D02**   | **patron-ref**              | **1**   | **string**   |         |
| **4** | **E05D03**   | **item-ref**                | **1**   | **string**   |         |
| **5** | **E05D04**   | **start-date**              | **1**   | **dateTime** |         |
|   6   | E05D05       | end-due-date                | 0-1     | dateTime     |         |
|   7   | E05D06       | end-date                    | 0-1     | dateTime     |         |
| **8** | **E05D07**   | **loan-status**             | **1-n** | **Code**     | **[LOS](LCF-CodeLists.md#LOS)** |
|   9   | *E05C13*     | access-link                 | 0-n     |              | *Added in v1.0.1*                  |
|  10   | E05D13.1     | link-type                   | 1       | Code         | [LKT](LCF-CodeLists.md#LKT)    |
|  11   | E05D13.2     | link                        | 1       | String       |         |
|  12   | E05D08       | previous-loan-ref           | 0-1     | string       |         |
|  13   | E05D09       | renewal-loan-ref            | 0-1R    | string       |         |
|  14   | E05D14       | reservation-ref             | 0-1R    | string       | *Added in v1.1.0* |
|  15   | E05D10       | recall-notice-date          | 0-1R    | dateTime     |         |
|  16   | E05D11       | charge-ref                  | 0-nR    | string       |         |
|  17   | E05C12       | note                        | 0-n     |              |         |
|  18   | E05D12.1     | note-type                   | 0-1     | Code         | [NOT](LCF-CodeLists.md#NOT)     |
|  19   | E05D12.2     | date-time                   | 0-1     | dateTime     |         |
|  20   | E05D12.3     | note-text                   | 1       | string       |         |

E06 RESERVATION
---------------

|        | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|--------|--------------|-----------------------------|---------|-------------|---------|
| **1**  |              | **reservation<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                  |         |             | **Top-level&nbsp;element**<br/>*'version' attribute removed in v1.0.1*                                                         |
|   2    | E06D01       | identifier                  | 0-1     | string      | Mandatory except when creating a new entity, in which case the identifier will be assigned by the LMS                        |
| **3**  | **E06D02**   | **reservation-type**        | **1**   | **Code**    | **[RVT](LCF-CodeLists.md#RVT)** |
| **4**  | **E06D03**   | **patron-ref**              | **1**   | **string**  |         |
|   5    | E06D04       | manifestation-ref           | 0-1     | string      | Either E06D04 or E06D05 must be included in each reservation instance                                                   |
|   6    | E06D05       | item-ref                    | 0-1     | string      |         |
|   7    | E06D06       | start-date                  | 0-1     | dateTime    |         |
|   8    | E06D07       | pickup-institution-ref      | 0-1     | string      |         |
|   9    | E06D08       | pickup-location-ref         | 0-1     | string      |         |
|  10    | E06D09       | pickup-date                 | 0-1     | dateTime    |         |
|  11    | E06D10       | end-date                    | 0-1     | dateTime    |         |
|**12**  | **E06D11**   | **reservation-status**      | **1**   | **Code**    | **[RVS](LCF-CodeLists.md#RVS)** |
|  13    | E06D15       | hold-queue-position         | 0-1     | int         | *Added in v1.0.1* |
|  14    | E06D12       | loan-ref                    | 0-1R    | string      |         |
|  15    | E06D13       | charge-ref                  | 0-nR    | string      |         |
|  16    | E06C16       | suspension-period           | 0-n     |             | *Added in v1.1.0* |
|  17    | E06D16.1     | start-date                  | 0-1     | dateTime    |         |
|  18    | E06D16.2     | end-date                    | 0-1     | dateTime    |         |
|  19    | E06C14       | note                        | 0-n     |             |         |
|  20    | E06D14.1     | note-type                   | 0-1     | Code        | [NOT](LCF-CodeLists.md#NOT)     |
|  21    | E06D14.2     | date-time                   | 0-1     | dateTime    |         |
|  22    | E06D14.3     | note-text                   | 1       | string      |         |

E07 CHARGE
----------

|        | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|--------|--------------|-----------------------------|---------|-------------|---------|
| **1**  |              | **charge<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                  |         |             | **Top-level&nbsp;element**<br/>*'version' attribute removed in v1.0.1*                                                         |
|   2    | E07D01       | identifier                  | 0-1     | string      | Mandatory except when creating a new entity, in which case the identifier will be assigned by the LMS                        |
| **3**  | **E07D02**   | **patron-ref**              | **1**   | **string**  |         |
| **4**  | **E07D03**   | **charge-type**             | **1**   | **Code**    | **[CHT](LCF-CodeLists.md#CHT)** |
| **5**  | **E07D04**   | **charge-status**           | **1**   | **Code**    | **[CHS](LCF-CodeLists.md#CHS)** |
|   6    | E07D05       | description                 | 0-1     | string      |         |
|   7    | E07D06       | item-ref                    | 0-1     | string      |         |
|   8    | E07D07       | manifestation-ref           | 0-1     | string      |         |
|   9    | E07D08       | loan-ref                    | 0-1     | string      |         |
|  10    | E07D09       | reservation-ref             | 0-1     | string      |         |
|  11    | E07D10       | creation-date               | 0-1     | dateTime    |         |
|  12    | E07D11       | payment-due-date            | 0-1     | dateTime    |         |
|**13**  | **E07D12**   | **charge-amount**           | **1**   | **decimal** |         |
|  14    | E07D13       | currency                    | 0-1     | Code        | ISO currency code                                                                                    |
|  15    | E07D14       | paid-amount                 | 0-1     | decimal     |         |
|  16    | E07D15       | due-amount                  | 0-1R    | decimal     |         |
|  17    | E07D16       | paid-date                   | 0-1     | dateTime    |         |
|  18    | E07D17       | payment-ref                 | 0-n     | string      |         |
|  19    | E07C18       | note                        | 0-n     |             |         |
|  20    | E07D18.1     | note-type                   | 0-1     | Code        | [NOT](LCF-CodeLists.md#NOT)     |
|  21    | E07D18.2     | date-time                   | 0-1     | dateTime    |         |
|  22    | E07D18.3     | note-text                   | 1       | string      |         |

E08 PAYMENT
-----------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|-------|--------------|-----------------------------|---------|-------------|---------|
|  **1** |              | **payment<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                 |         |             | **Top-level&nbsp;element**<br/>*'version' attribute removed in v1.0.1*                                                        |
|    2   | E08D01       | identifier                  | 0-1     | string      | Mandatory except when creating a new entity, in which case the identifier will be assigned by the LMS                       |
|  **3** | **E08D02**   | **patron-ref**              | **1**   | **string**  |         |
|  **4** | **E08D03**   | **payment-type**            | **1**   | **Code**    | **[PYT](LCF-CodeLists.md#PYT)** |
|    5   | E08D04       | description                 | 0-1     | string      |         |
|    6   | E08D05       | charge-ref                  | 0-n     | string      | *Non-mandatory in v1.0.1* |
|    7   | E08D15       | deposit-type                | 0-1     | Code        | **[CHT](LCF-CodeLists.md#CHT)**<br/>*Added in vx.x.0* |
|    8   | E08D13       | payment-purpose             | 0-1     | Code        | [PYP](LCF-CodeLists.md#PYP)<br/>*Added in vx.x.0* |
|    9   | E08D14       | beneficiary-ref             | 0-1     | string      | *Added in vx.x.0*               |
|   10   | E08D06       | payment-date                | 0-1     | dateTime    |         |
| **11** | **E08D07**   | **amount**                  | **1**   | **decimal** |         |
|   12   | E08D08       | currency                    | 0-1     | Code        | ISO currency code |
|   13   | E08D09       | payment-status              | 0-1     | Code        | [PYS](LCF-CodeLists.md#PYS)     |
|   14   | E08D10       | transaction-reference       | 0-1     | string      | *Renamed in v1.0.1* |
|   15   | E08D12       | authorisation-ref           | 0-1     | string      | *(Added in vx.x.0)*    |
|   16   | E08C11       | note                        | 0-n     |             |         |
|   17   | E08D11.1     | note-type                   | 0-1     | Code        | [NOT](LCF-CodeLists.md#NOT)     |
|   18   | E08D11.2     | date-time                   | 0-1     | dateTime    |         |
|   19   | E08D11.3     | note-text                   | 1       | string      |         |

E09 CONTACT
-----------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|-------|--------------|-----------------------------|---------|-------------|---------|
| **1** |              | **contact<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                 |         |             | **Top-level&nbsp;element**<br/>*'version' attribute removed in v1.0.1*                                                        |
|   2   | E09D01       | identifier                  | 0-1     | string      | Mandatory except when creating a new entity, in which case the identifier will be assigned by the LMS<br/>*Cardinality corrected in v1.0.1* |
|       | **<strike>E09D02</strike>** | **<strike>name</strike>** | **<strike>1</strike>** | **<strike>String</strike>** |                                         *Removed in v1.0.1* |
|   3   | E09D03       | patron-ref                 | 0-1     | string      | Mandatory unless E09D10 or E09D11 present<br/>*Cardinality changed in v1.0.1*                                               |
|   4   | E09D10       | location-ref               | 0-1     | string      | Mandatory unless E09D03 or E09D11 present<br/>*Added in v1.0.1*                                                             |
|   5   | E09D11       | institution-ref            | 0-1     | string      | Mandatory unless E09D03 or E09D10 present<br/>*Added in v1.0.1*                                                             |
|       | <strike>E09D04</strike> | <strike>address-line</strike> | <strike>0-n</strike> | <strike>string</strike> |                                                                     *Removed in v1.0.1* |
|       | <strike>E09C05</strike> | <strike>communication-detail</strike> | <strike>0-n</strike> |         |                                                                     *Removed in v1.0.1* |
| **6** | **E09D08**   | **communication-type**      | **1**   | **Code**    | **[CMT](LCF-CodeLists.md#CMT)** |
| **7** | **E09D09**   | **locator**                 | **1-n** | **string**  | *Repeatable v1.0.1*                                                                                |
|       | <strike>E09D06</strike> | <strike>language</strike> | <strike>0-1</strike> | <strike>Code</strike> | <strike>ISO three-letter code</strike><br/>                           *Removed in v1.0.1* |
|   8  | E09C07       | note                         | 0-n     |             |         |
|   9  | E09D07.1     | note-type                    | 0-1     | Code        | [NOT](LCF-CodeLists.md#NOT)     |
|  10  | E09D07.2     | date-time                    | 0-1     | dateTime    |         |
|  11  | E09D07.3     | note-text                    | 1       | string      |         |

E10 TITLE CLASSIFICATION SCHEME *(DEPRECATED in v1.2.0)*
-------------------------------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|-------|--------------|-----------------------------|---------|-------------|---------|
| **1** |              | **class-scheme<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                 |         |             | **Top-level&nbsp;element**<br/>*'version' attribute removed in v1.0.1*                                                        |
|   2   | E10D01       | identifier                  | 0-1     | string      | Mandatory except when creating a new entity, in which case the identifier will be assigned by the LMS                       |
| **3** | **E10D02**   | **name**                    | **1**   | **string**  |         |
|   4   | E10C03       | note                        | 0-n     |             |         |
|   5   | E10D03.1     | note-type                   | 0-1     | Code        | [NOT](LCF-CodeLists.md#NOT)     |
|   6   | E10D03,2     | date-time                   | 0-1     | dateTime    |         |
|   7   | E10D03.3     | note-text                   | 1       | string      |         |

E11 TITLE CLASSIFICATION TERM *(DEPRECATED in v1.2.0)*
-----------------------------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|-------|--------------|-----------------------------|---------|-------------|---------|
| **1** |              | **class-term<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                 |         |             | **Top-level&nbsp;element**<br/>*'version' attribute removed in v1.0.1*                                                        |
|   2   | E11D01       | identifier                  | 0-1     | string      | Mandatory except when creating a new entity, in which case the identifier will be assigned by the LMS                       |
| **3** | **E11D02**   | **class-code**              | **1**   | **string**  |         |
| **4** | **E11D03**   | **class-scheme-ref**        | **1**   | **string**  |         |
|   5   | E11D04       | heading                     | 0-1     | string      |         |
|   6   | E11C05       | note                        | 0-n     | string      |         |
|   7   | E11D05.1     | note-type                   | 0-1     | Code        | [NOT](LCF-CodeLists.md#NOT)     |
|   8   | E11D05.2     | date-time                   | 0-1     | dateTime    |         |
|   9   | E11D05.3     | note-text                   | 1       | string      |         |

E12 SELECTION CRITERION *(DEPRECATED in v1.0.1)*
------------------------------------------------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|-------|--------------|-----------------------------|---------|-------------|---------|
| **1** |              | **property<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                 |         |             | **Top-level&nbsp;element**<br/>*'version' attribute removed in v1.0.1*                                                        |
|   2   | E12D01       | identifier                  | 0-1     | string      | Mandatory except when creating a new entity, in which case the identifier will be assigned by the LMS                       |
| <span id="h.gjdgxs" class="anchor"></span>**3** | **E12D02**   | **name**  | **1**   | **string**  |         |
|   4   | E12D03       | entity-type                 | 0-n     | Code        | [ENT](LCF-CodeLists.md#ENT)     |
|   5   | E12D04       | description                 | 0-1     | string      |         |
|   6   | E12D05       | value-scheme-ref            | 0-1     | string      |         |
|   7   | E12C06       | note                        | 0-n     | string      |         |
|   8   | E12D06.1     | note-type                   | 0-1     | Code        | [NOT](LCF-CodeLists.md#NOT)     |
|   9   | E12D06.2     | date-time                   | 0-1     | dateTime    |         |
|  10   | E12D06.3     | note-text                   | 1       | string      |         |

E13 AUTHORISATION CODE *(added in v1.0.1)*
----------------------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|-------|--------------|-----------------------------|---------|-------------|---------|
| **1** |              | **authorisation<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                 |       |             | **Top-level&nbsp;element**<br/>                                |
|   2   | E13D01       | identifier                  | 0-1     | string      | Mandatory except when creating a new entity, in which case the identifier will be assigned by the LMS                       |
|   3   | E13D02       | authorisation-type          | 0-1     | Code        | [AUT](LCF-CodeLists.md#AUT) |
|   3   | E13D03       | heading                     | 0-1     | string      |         |
|   4   | E13C04       | note                        | 0-n     | string      |         |
|   5   | E13D04.1     | note-type                   | 0-1     | Code        | [NOT](LCF-CodeLists.md#NOT) |
|   6   | E13D04.2     | date-time                   | 0-1     | dateTime    |         |
|   7   | E13D04.3     | note-text                   | 1       | string      |         |
|   8   | E13D05       | location-ref                | 0-n     | string      | *Added in vx.x.0* |

E14 LIBRARY AUTHORITY/INSTITUTION *(added in v1.0.1)*
---------------------------------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|-------|--------------|-----------------------------|---------|-------------|---------|
| **1** |              | **authority<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                     |       |             | **Top-level&nbsp;element**<br/>                                |
|   2   | E14D01       | identifier                  | 0-1     | string      | Mandatory except when creating a new entity, in which case the identifier will be assigned by the LMS                       |
|   3   | E14C02       | additional-authority-id     | 0-n     |             |         |
|   4   | E14D02.1     | authority-id-type           | 1       | Code        | [INS](LCF-CodeLists.md#INS) |
|   5   | E14D02.2     | type-name                   | 0-1     | string      |         |
|   6   | E14D02.3     | value                       | 1       | string      |         |
| **7** | **E14D03**   | **name**                    | 1       | string      |         |
|   8   | E14D08       | library-statutory-status    | 0-1     | Code        | [LST](LCF-CodeLists.md#LST)<br/>*Added in v1.2.0*     |
|   9   | E14D09       | library-type                | 0-1     | Code        | [LTY](LCF-CodeLists.md#LTY)<br/>*Added in v1.2.0*     |
|  10   | E14C04       | associated-location         | 0-n     |             |         |
|  11   | E14D04.1     | association-type            | 1       | Code        | [LAT](LCF-CodeLists.md#LAT) |
|  12   | E14D04.2     | location-ref                | 1       | string      |         |
|  13   | E14C04.3     | library-location-service-period | 0-n |             | *Added in v1.2.0*    |
|  14   | E14D04.3.1   | period-name                 | 0-1     | string      |                                    |
|  15   | E14D04.3.2   | start-date                  | 1       | date        |                                    |
|  16   | E14D04.3.3   | end-date                    | 1       | date        |                                    |
|  17   | E14C04.3.4   | closed                      | 0-1     |             |                                    |
|  18   | E14D04.3.4.1 | days                        | 0-1     | List        | [WKD](LCF-CodeLists.md#WKD) |
|  19   | E14C04.3.5   | open                        | 0-n     |             |                                    |
|  20   | E14D04.3.5.1 | days                        | 0-1     | List        | [WKD](LCF-CodeLists.md#WKD) |
|  21   | E14C04.3.5.2 | open-time-period            | 1-n     |             |                                    |
|  22   | E14D04.3.5.2.1 | start-time                | 1       | time        |                                    |
|  23   | E14D04.3.5.2.2 | end-time                  | 1       | time        |                                    |
|  24   | E15D04.3.5.2.3 | staffed                   | 0-1     | Code      | [STA](LCF-CodeLists.md#STA) |
|  25   | E14C05       | associated-contact          | 0-n     |             |         |
|  26   | E14D05.1     | association-type            | 1       | Code        | [CAT](LCF-CodeLists.md#CAT) |
|  27   | E14D05.2     | contact-name                | 1       | string      |         |
|  28   | E14D05.3     | contact-ref                 | 1       | string      |         |
|  29   | E14C06       | associated-authority        | 0-n     |             |         |
|  30   | E14D06.1     | association-type            | 1       | Code        | [AAT](LCF-CodeLists.md#AAT) |
|  31   | E14D06.2     | authority-ref               | 1       | string      |         |
|  32   | E14C07       | note                        | 0-n     |             |         |
|  33   | E14D07.1     | note-type                   | 0-1     | Code        | [NOT](LCF-CodeLists.md#NOT) |
|  34   | E14D07.2     | date-time                   | 0-1     | dateTime    |         |
|  35   | E14D07.3     | note-text                   | 1       | string      |         |

E15 MESSAGE / ALERT *(added in v1.0.1)*
---------------------------------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|-------|--------------|-----------------------------|---------|-------------|---------|
| **1** |              | **message-alert<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                     |       |             | **Top-level&nbsp;element**<br/>                                |
|   2   | E15D01       | identifier                  | 0-1     | string      | Mandatory except when creating a new entity, in which case the identifier will be assigned by the LMS                       |
|   3   | E15D02       | authority-ref               | 0-1     | string      |         |
| **4** | **E15D03**   | **message-type**            | **1**   | **Code**    | **[MAT](LCF-CodeLists.md#MAT)** |
|   5   | E15D04       | priority                    | 0-1     | Code        | [MAP](LCF-CodeLists.md#MAP) |
|   6   | E15D05       | display-type                | 0-1     | Code        | [MGT](LCF-CodeLists.md#MGT) |
|   7   | E15D06       | display-constraint          | 0-1     | Code        | [MAC](LCF-CodeLists.md#MAC) |
|   8   | E15D07       | start-date                  | 0-1     | dateTime    |         |
|   9   | E15D08       | end-date                    | 0-1     | dateTime    |         |
|  10   | E15D09       | audience                    | 0-1     | Code        | [MAU](LCF-CodeLists.md#MAU) |
|  11   | E15D10       | patron-category             | 0-n     | string      |         |
|  12   | E15D11       | patron-ref                  | 0-n     | string      |         |
|  13   | E15D14       | loan-ref                    | 0-n     | string      | *Added in v1.1.0* |
|  14   | E15D15       | reservation-ref             | 0-n     | string      | *Added in v1.1.0* |
|  15   | **E15C12**   | **message-text**            | **1-n** |             | *Corrected in v1.2.0* |
|  16   | **E15D12.1** | **message-format**          | **1**   | Code        | **[TFT](LCF-CodeLists.md#TFT)** |
|  17   | **E15D12.2** | **text**                    | **1**   | string      |         |
|  18   | E15C13       | note                        | 0-n     |             |         |
|  19   | E15D13.1     | note-type                   | 0-1     | Code        | [NOT](LCF-CodeLists.md#NOT) |
|  20   | E15D13.2     | date-time                   | 0-1     | dateTime    |         |
|  21   | E15D13.3     | note-text                   | 1       | string      |         |
|  21   | E15C16       | delivery-summary            | 0-1     |             | *Added in v1.2.0*              |
|  22   | E15D16.1     | delivered                   | 0-1     | int         |         |
|  23   | E15D16.2     | acknowledged                | 0-1     | int         |         |
|  24   | E15C16.3     | delivery-to-patron-category | 0-n     |             |         |
|  25   | E15D16.3.1   | category-name               | 1       | string      |         |
|  26   | E15D16.3.2   | total-patrons-in-category   | 0-1     | int         |         |
|  27   | E15D16.3.3   | delivered                   | 0-1     | int         |         |
|  28   | E15D16.3.4   | acknowledged                | 0-1     | int         |         |
|  29   | E15C16.4     | delivery-to-related-patrons | 0-n     |             |         |
|  30   | E15D16.4.1   | total-related-patrons       | 0-1     | int         |         |
|  31   | E15D16.4.2   | delivered                   | 0-1     | int         |         |
|  32   | E15D16.4.3   | acknowledged                | 0-1     | int         |         |


EXCEPTION CONDITIONS
--------------------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|-------|--------------|-----------------------------|---------|-------------|---------|
| **1** |              | **lcf-exception<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"**                                 |         |             | **Top-level&nbsp;element**<br/>*'version' attribute removed in v1.0.1*                                                        |
| **2** | **R00C05**   | **exception-condition**     | **1-n** |             |         |
| **3** | **R00D05.1** | **condition-type**          | **1**   | **Code**    | **[EXC](LCF-CodeLists.md#EXC)** |
|   4   | R00D05.2     | reason-denied               | 0-1     | Code        | [RDN](LCF-CodeLists.md#RDN)     |
|   5   | R00D05.3     | element-id                  | 0-1     | string      |         |
|   6   | R00C06       | message                     | 0-n     |             |         |
|   7   | R00D06.1     | message-type                | 1       | string      | [MGT](LCF-CodeLists.md#MGT)     |
|   8   | R00D06.2     | message-text                | 1-n     | string      |         |

___


<a name="Notes"></a>[1] Elements where the cardinality is followed by 'R' are "response-only" or "read-only". These elements should only occur in responses from an LMS to a terminal application/device and will be ignored when included in requests.
