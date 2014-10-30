***Book Industry Communication***

**Library Interoperability Standards**

**LCF Information Entities
XML bindings**

Version 1.0, 10 January 2014

This document specifies XML bindings for the information entities defined in version 1.0 of the LCF data communication framework. It is intended to be used with any implementation of LCF in which the information entities are encoded in XML, and specifically with the standard web service implementations of LCF.

This document also specifies a standard XML binding for the data framework for communicating exception conditions in LCF response messages.

The use of this document is subject to license terms and conditions that can be found *at* <http://www.bic.org.uk/bicstandardslicence.pdf>.

This document is subject to revision from time to time. The latest versions of this document, the LCF data framework specification, code lists and other resources supporting specific implementations of the LCF standard may be found at <http://www.bic.org/lcf>.

An XML schema is available that corresponds to this specification.

The namespace for these XML bindings is "http://ns.bic.org.uk/lcf/1.0"

E01 MANIFESTATION
-----------------

|        | *Element ID* | *XML structure*                  | *Card.* | *Data type* | *Notes*                                                                                                  |
|--------|--------------|----------------------------------|---------|-------------|----------------------------------------------------------------------------------------------------------|
| **1**  |              | **manifestation<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"<br/>version="1.0"**                   |         |             | **Top-level element with mandatory ‘version’ attribute**                                                 |
| **2**  | **E01D01**   | **identifier**                   | **1**   | **String**  |                                                                                                          |
| 3      | E01C02       | additional-manifestation-id      | 0-n     |             |                                                                                                          |
| 4      | E01D02.1     | manifestation-id-type            | 1       | Code        | MNI                                                                                                      |
| 5      | E01D02.2     | type-name                        | 0-1     | String      |                                                                                                          |
| 6      | E01D02.3     | value                            | 1       | String      |                                                                                                          |
| 7      | E01C03       | media-type                       | 0-n     |             |                                                                                                          |
| 8      | E01D03.1     | media-type-scheme                | 1       | Code        | MES                                                                                                      |
| 9      | E01D03.2     | scheme-name                      | 0-1     | String      |                                                                                                          |
| 10     | E01D03.3     | scheme-code                      | 1       | String      |                                                                                                          |
| 11     | E01C04       | title                            | 0-n     |             |                                                                                                          |
| 12     | E01D04.1     | title-type                       | 1       | Code        | TTL                                                                                                      |
| 13     | E01D04.2     | title-text                       | 1       | String      |                                                                                                          |
| 14     | E01D04.3     | subtitle                         | 0-1     | String      |                                                                                                          |
| 15     | E01C05       | contributor                      | 0-n     |             |                                                                                                          |
| 16     | E01D05.1     | contributor-role                 | 1       | Code        | ONIX code list 17                                                                                        |
| 17     | E01D05.2     | contributor-name                 | 0-1     | String      | Either a contributor name or an unnamed contributor code must be included in each contributor composite. |
| 18     | E01D05.3     | unnamed-contributor              | 0-1     | Code        | UNC                                                                                                      |
| 19     | E01C06       | series                           | 0-1     |             |                                                                                                          |
| 20     | E01C06.1     | title                            | 0-n     |             |                                                                                                          |
| 21     | E01D06.1.1   | title-type                       | 1       | Code        | TTL                                                                                                      |
| 22     | E01D06.1.2   | title-text                       | 1       | String      |                                                                                                          |
| 23     | E01D06.1.3   | subtitle                         | 0-1     | String      |                                                                                                          |
| 24     | E01D06.2     | volume-or-part                   | 0-1     | String      |                                                                                                          |
| 25     | E01D06.3     | other-manifestation-in-series-id | 0-n     | String      |                                                                                                          |
| 26     | E01D07       | edition-statement                | 0-1     | String      |                                                                                                          |
| 27     | E01D08       | publisher-name                   | 0-1     | String      |                                                                                                          |
| 28     | E01D09       | year-of-publication              | 0-1     | YYYY        |                                                                                                          |
| 29     | E01C10       | classification                   | 0-n     |             |                                                                                                          |
| 30     | E01D10.1     | class-scheme-ref                 | 1       | String      |                                                                                                          |
| 31     | E01D10.2     | class-term-ref                   | 1       | String      |                                                                                                          |
| 32     | E01D11       | cover-art                        | 0-n     | URI         |                                                                                                          |
| 33     | E01D12       | description                      | 0-1     | String      |                                                                                                          |
| 34     | E01C13       | loan-restriction                 | 0-n     |             |                                                                                                          |
| 35     | E01D13.1     | restriction-type                 | 1       | Code        | CRT                                                                                                      |
| 36     | E01D13.2     | value                            | 1       | String      |                                                                                                          |
| 37     | E01D13.3     | note                             | 0-1     | String      |                                                                                                          |
| 38     | E01C14       | loan-fee                         | 0-n     |             |                                                                                                          |
| 39     | E01D14.1     | fee-type                         | 1       | Code        | CHT                                                                                                      |
| 40     | E01D14.2     | amount                           | 1       | Decimal     |                                                                                                          |
| 41     | E01D14.3     | currency                         | 0-1     | Code        | ISO 3-letter code                                                                                        |
| 42     | E01D15       | patrons-in-hold-queue            | 0-1     | Integer     |                                                                                                          |
| 43     | E01D16       | manifestation-record-ref         | 0-1     | String      |                                                                                                          |
| **44** | **E01D17**   | **manifestation-status**         | **1**   | **Code**    | **MNS**                                                                                                  |
| 45     | E01D18       | items-in-stock                   | 0-1     | Integer     |                                                                                                          |
| 46     | E01D19       | item-ref                         | 0-n     | String      |                                                                                                          |
| 47     | E01C20       | reservation-ref                  | 0-n     | String      |                                                                                                          |
| 48     | E01C21       | note                             | 0-n     |             |                                                                                                          |
| 49     | E01D21.1     | note-type                        | 0-1     | Code        | NOT                                                                                                      |
| 50     | E01D21.2     | date-time                        | 0-1     | DateTime    |                                                                                                          |
| 51     | E01D21.3     | note-text                        | 1       | String      |                                                                                                          |

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
| **1**  |              | **item<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"<br/>version="1.0"**              |         |             | **Top-level element with mandatory ‘version’ attribute** |
| **2**  | **E02D01**   | **identifier**              | **1**   | **String**  |                                                          |
| 3      | E02C02       | additional-item-id          | 0-n     |             |                                                          |
| 4      | E02D02.1     | item-id-type                | 1       | Code        | IMI                                                      |
| 5      | E02D02.2     | type-name                   | 0-1     | String      |                                                          |
| 6      | E02D02.3     | value                       | 1       | String      |                                                          |
| **7**  | **E02D03**   | **manifestation-ref**       | **1**   | **String**  |                                                          |
| 8      | E02D04       | description                 | 0-1     | String      |                                                          |
| 9      | E02D05       | owner                       | 0-1     | String      |                                                          |
| 10     | E02C06       | associated-location         | 0-n     |             |                                                          |
| 11     | E02D06.1     | association-type            | 1       | Code        | LAT                                                      |
| 12     | E02D06.2     | location-ref                | 1-n     | String      |                                                          |
| **13** | **E02D07**   | **media-warning**           | **1**   | **Code**    | **MEW**                                                  |
| **14** | **E02D08**   | **security-desensitize**    | **1**   | **Code**    | **SCD**                                                  |
| 15     | E02C09       | loan-restriction            | 0-n     |             |                                                          |
| 16     | E02D09.1     | restriction-type            | 1       | Code        | CRT                                                      |
| 17     | E02D09.2     | value                       | 1       | String      |                                                          |
| 18     | E02D09.3     | note                        | 0-1     | String      |                                                          |
| 19     | E02C10       | loan-fee                    | 0-n     |             |                                                          |
| 20     | E02D10.1     | fee-type                    | 1       | Code        | CHT                                                      |
| 21     | E02D10.2     | amount                      | 1       | Decimal     |                                                          |
| 22     | E02D10.3     | currency                    | 0-1     | Code        | ISO 3-letter code                                        |
| **23** | **E02D11**   | **circulation-status**      | **1**   | **Code**    | **CIS**                                                  |
| 24     | E02D12       | reservation-ref             | 0-n     | String      |                                                          |
| 25     | E02D13       | patrons-in-hold-queue       | 0-1     | Integer     |                                                          |
| 26     | E02D14       | on-loan-ref                 | 0-1     | String      |                                                          |
| 27     | E02D15       | condition-code              | 0-1     | Code        | LMS-proprietary                                          |
| 28     | E02D16       | condition-description       | 0-1     | String      |                                                          |
| 29     | E02C17       | note                        | 0-n     |             |                                                          |
| 30     | E02D17.1     | note-type                   | 0-1     | Code        | NOT                                                      |
| 31     | E02D17.2     | date-time                   | 0-1     | DateTime    |                                                          |
| 32     | E02D17.3     | note-text                   | 1       | String      |                                                          |

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
| **1** |              | **patron<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"<br/>version=”1.0”**              |         |             | **Top-level element with mandatory ‘version’ attribute** |
| **2** | **E03D01**   | **identifier**              | **1**   | **String**  |                                                          |
| 3     | E03D02       | contact-ref                 | 0-1     | String      |                                                          |
| 3     | E03C03       | associated-location         | 0-n     |             |                                                          |
| 4     | E03D03.1     | association-type            | 1       | Code        | LAT                                                      |
| 5     | E03D03.2     | location-ref                | 1-n     | String      |                                                          |
| 6     | E03D04       | patron-status               | 0-n     | Code        | PNS                                                      |
| 7     | E03D05       | card-status                 | 0-1     | Code        | PCS                                                      |
| 8     | E03D06       | blocked-card-message        | 0-1     | String      | Only included if E03D08 is included.                     |
| 9     | E03D07       | loan-ref                    | 0-n     | String      |                                                          |
| 10    | E03D08       | on-loan-items               | 0-1     | Integer     |                                                          |
| 11    | E03D09       | loan-items-limit            | 0-1     | Integer     |                                                          |
| 12    | E03D10       | overdue-items               | 0-1     | Integer     |                                                          |
| 13    | E03D11       | overdue-items-limit         | 0-1     | Integer     |                                                          |
| 14    | E03D12       | recalled-items              | 0-1     | Integer     |                                                          |
| 15    | E03D13       | fees-due-items              | 0-1     | Integer     |                                                          |
| 16    | E03D14       | fines-due-items             | 0-1     | Integer     |                                                          |
| 17    | E03D15       | reservation-ref             | 0-n     | String      |                                                          |
| 18    | E03D16       | available-hold-items        | 0-1     | Integer     |                                                          |
| 19    | E03D17       | unavailable-hold-items      | 0-1     | Integer     |                                                          |
| 20    | E03D18       | hold-items-limit            | 0-1     | Integer     |                                                          |
| 21    | E03D19       | charge-ref                  | 0-n     | String      |                                                          |
| 22    | E03C20       | charge-limit                | 0-n     |             |                                                          |
| 23    | E03D20.1     | charge-type                 | 0-1     | Code        | CHT                                                      |
| 24    | E03D20.2     | amount                      | 1       | Decimal     |                                                          |
| 25    | E03D20.3     | currency                    | 0-1     | Code        | ISO currency code                                        |
| 26    | E03C21       | note                        | 0-n     |             |                                                          |
| 27    | E03D21.1     | note-type                   | 0-1     | Code        | NOT                                                      |
| 28    | E03D21.2     | date-time                   | 0-1     | DateTime    |                                                          |
| 29    | E03D21.3     | note-text                   | 1       | String      |                                                          |

E04 LOCATION
------------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes* |
|-------|--------------|-----------------------------|---------|-------------|----------------------------------------------------------|
| **1** |              | **location<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"<br/>version=”1.0”**              |         |             | **Top-level element with mandatory ‘version’ attribute** |
| **2** | **E04D01**   | **identifier**              | **1**   | **String**  |                                                          |
| 3     | E04C02       | additional-location-id      | 0-n     |             |                                                          |
| 4     | E04D02.1     | location-id-type            | 1       | Code        | LOI                                                      |
| 5     | E04D02.2     | type-name                   | 0-1     | String      |                                                          |
| 6     | E04D02.3     | value                       | 1       | String      |                                                          |
| 7     | E04D03       | name                        | 0-1     | String      |                                                          |
| 8     | E04D04       | location-type               | 0-1     | Code        | LOT                                                      |
| 9     | E04D05       | description                 | 0-1     | String      |                                                          |
| 10    | E04C06       | note                        | 0-n     |             |                                                          |
| 11    | E04D06.1     | note-type                   | 0-1     | Code        | NOT                                                      |
| 12    | E04D06.2     | date-time                   | 0-1     | DateTime    |                                                          |
| 13    | E04D06.3     | note-text                   | 1       | String      |                                                          |

E05 LOAN
--------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type*  | *Notes*                                                  |
|-------|--------------|-----------------------------|---------|--------------|----------------------------------------------------------|
| **1** |              | **loan<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"<br/>version=”1.0”**              |         |              | **Top-level element with mandatory ‘version’ attribute** |
| **2** | **E05D01**   | **identifier**              | **1**   | **String**   |                                                          |
| **3** | **E05D02**   | **patron-ref**              | **1**   | **String**   |                                                          |
| **4** | **E05D03**   | **item-ref**                | **1**   | **String**   |                                                          |
| **5** | **E05D04**   | **start-date**              | **1**   | **DateTime** |                                                          |
| 6     | E05D05       | end-due-date                | 0-1     | DateTime     |                                                          |
| 7     | E05D06       | end-date                    | 0-1     | DateTime     |                                                          |
| **8** | **E05D07**   | **loan-status**             | **1-n** | **Code**     | **LOS**                                                  |
| 9     | E05D08       | previous-loan-ref           | 0-1     | String       |                                                          |
| 10    | E05D09       | renewal-loan-ref            | 0-1     | String       |                                                          |
| 11    | E05D10       | recall-notice-date          | 0-1     | DateTime     |                                                          |
| 12    | E05D11       | charge-ref                  | 0-n     | String       |                                                          |
| 13    | E05C12       | note                        | 0-n     |              |                                                          |
| 14    | E05D12.1     | note-type                   | 0-1     | Code         | NOT                                                      |
| 15    | E05D12.2     | date-time                   | 0-1     | DateTime     |                                                          |
| 16    | E05D12.3     | note-text                   | 1       | String       |                                                          |

E06 RESERVATION
---------------

|        | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes*                                                               |
|--------|--------------|-----------------------------|---------|-------------|-----------------------------------------------------------------------|
| **1**  |              | **reservation<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"<br/>version=”1.0”**              |         |             | **Top-level element with mandatory ‘version’ attribute**              |
| **2**  | **E06D01**   | **identifier**              | **1**   | **String**  |                                                                       |
| **3**  | **E06D02**   | **reservation-type**        | **1**   | **Code**    | **RVT**                                                               |
| **4**  | **E06D03**   | **patron-ref**              | **1**   | **String**  |                                                                       |
| 5      | E06D04       | manifestation-ref           | 0-1     | String      | Either E06D04 or E06D05 must be included in each reservation instance |
| 6      | E06D05       | item-ref                    | 0-1     | String      |                                                                       |
| 7      | E06D06       | start-date                  | 0-1     | DateTime    |                                                                       |
| 8      | E06D07       | pickup-institution-ref      | 0-1     | String      |                                                                       |
| 9      | E06D08       | pickup-location-ref         | 0-1     | String      |                                                                       |
| 10     | E06D09       | pickup-date                 | 0-1     | DateTime    |                                                                       |
| 11     | E06D10       | end-date                    | 0-1     | DateTime    |                                                                       |
| **12** | **E06D11**   | **reservation-status**      | **1**   | **Code**    | **RVS**                                                               |
| 13     | E06D12       | loan-ref                    | 0-1     | String      |                                                                       |
| 14     | E06D13       | charge-ref                  | 0-n     | String      |                                                                       |
| 15     | E06C14       | note                        | 0-n     |             |                                                                       |
| 16     | E06D14.1     | note-type                   | 0-1     | Code        | NOT                                                                   |
| 17     | E06D14.2     | date-time                   | 0-1     | DateTime    |                                                                       |
| 18     | E06D14.3     | note-text                   | 1       | String      |                                                                       |

E07 CHARGE
----------

|        | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes*                                                  |
|--------|--------------|-----------------------------|---------|-------------|----------------------------------------------------------|
| **1**  |              | **charge<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"<br/>version=”1.0”**              |         |             | **Top-level element with mandatory ‘version’ attribute** |
| **2**  | **E07D01**   | **identifier**              | **1**   | **String**  |                                                          |
| **3**  | **E07D02**   | **patron-ref**              | **1**   | **String**  |                                                          |
| **4**  | **E07D03**   | **charge-type**             | **1**   | **Code**    | **CHT**                                                  |
| **5**  | **E07D04**   | **charge-status**           | **1**   | **Code**    | **CHS**                                                  |
| 6      | E07D05       | description                 | 0-1     | String      |                                                          |
| 7      | E07D06       | item-ref                    | 0-1     | String      |                                                          |
| 8      | E07D07       | manifestation-ref           | 0-1     | String      |                                                          |
| 9      | E07D08       | loan-ref                    | 0-1     | String      |                                                          |
| 10     | E07D09       | reservation-ref             | 0-1     | String      |                                                          |
| 11     | E07D10       | creation-date               | 0-1     | DateTime    |                                                          |
| 12     | E07D11       | payment-due-date            | 0-1     | DateTime    |                                                          |
| **13** | **E07D12**   | **charge-amount**           | **1**   | **Decimal** |                                                          |
| 14     | E07D13       | currency                    | 0-1     | Code        | ISO currency code                                        |
| 15     | E07D14       | paid-amount                 | 0-1     | Decimal     |                                                          |
| 16     | E07D15       | due-amount                  | 0-1     | Decimal     |                                                          |
| 17     | E07D16       | paid-date                   | 0-1     | DateTime    |                                                          |
| 18     | E07D17       | payment-ref                 | 0-n     | String      |                                                          |
| 19     | E07C18       | note                        | 0-n     |             |                                                          |
| 20     | E07D18.1     | note-type                   | 0-1     | Code        | NOT                                                      |
| 21     | E07D18.2     | date-time                   | 0-1     | DateTime    |                                                          |
| 22     | E07D18.3     | note-text                   | 1       | String      |                                                          |

E08 PAYMENT
-----------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes*                                                  |
|-------|--------------|-----------------------------|---------|-------------|----------------------------------------------------------|
| **1** |              | **payment<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"<br/>version=”1.0”**              |         |             | **Top-level element with mandatory ‘version’ attribute** |
| **2** | **E08D01**   | **identifier**              | **1**   | **String**  |                                                          |
| **3** | **E08D02**   | **patron-ref**              | **1**   | **String**  |                                                          |
| **4** | **E08D03**   | **payment-type**            | **1**   | **Code**    | **PYT**                                                  |
| 5     | E08D04       | description                 | 0-1     | String      |                                                          |
| **6** | **E08D05**   | **charge-ref**              | **1-n** | **String**  |                                                          |
| 7     | E08D06       | payment-date                | 0-1     | DateTime    |                                                          |
| **8** | **E08D07**   | **amount**                  | **1**   | **Decimal** |                                                          |
| 9     | E08D08       | currency                    | 0-1     | Code        | ISO currency code                                        |
| 10    | E08D09       | payment-status              | 0-1     | Code        | PYS                                                      |
| 11    | E08D10       | transaction-ref             | 0-1     | String      |                                                          |
| 12    | E08C11       | note                        | 0-n     |             |                                                          |
| 13    | E08D11.1     | note-type                   | 0-1     | Code        | NOT                                                      |
| 14    | E08D11.2     | date-time                   | 0-1     | DateTime    |                                                          |
| 15    | E08D11.3     | note-text                   | 1       | String      |                                                          |

E09 CONTACT
-----------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes*                                                  |
|-------|--------------|-----------------------------|---------|-------------|----------------------------------------------------------|
| **1** |              | **contact<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"<br/>version=”1.0”**              |         |             | **Top-level element with mandatory ‘version’ attribute** |
| **2** | **E09D01**   | **identifier**              | **1**   | **String**  |                                                          |
| **3** | **E09D02**   | **name**                    | **1**   | **String**  |                                                          |
| **4** | **E09D03**   | **patron-ref**              | **1-n** | **String**  |                                                          |
| 5     | E09D04       | address-line                | 0-n     | String      |                                                          |
| 6     | E09D05       | communication-detail        | 0-n     |             |                                                          |
| 7     | E09D05.1     | communication-type          | 1       | Code        | CMT                                                      |
| 8     | E09D05.2     | locator                     | 1       | String      |                                                          |
| 9     | E09D06       | language                    | 0-1     | Code        | ISO three-letter code                                    |
| 10    | E09C07       | note                        | 0-n     |             |                                                          |
| 11    | E09D07.1     | note-type                   | 0-1     | Code        | NOT                                                      |
| 12    | E09D07.2     | date-time                   | 0-1     | DateTime    |                                                          |
| 13    | D09D07.3     | note-text                   | 1       | String      |                                                          |

E10 TITLE CLASSIFICATION SCHEME
-------------------------------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes*                                                  |
|-------|--------------|-----------------------------|---------|-------------|----------------------------------------------------------|
| **1** |              | **class-scheme<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"<br/>version=”1.0”**              |         |             | **Top-level element with mandatory ‘version’ attribute** |
| **2** | **E10D01**   | **identifier**              | **1**   | **String**  | Mandatory except when creating a new entity record       |
| **3** | **E10D02**   | **name**                    | **1**   | **String**  |                                                          |
| 4     | E10C03       | note                        | 0-n     |             |                                                          |
| 5     | E10D03.1     | note-type                   | 0-1     | Code        | NOT                                                      |
| 6     | E10D03,2     | date-time                   | 0-1     | DateTime    |                                                          |
| 7     | E10D03.3     | note-text                   | 1       | String      |                                                          |

E11 TITLE CLASSIFICATION TERM
-----------------------------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes*                                                  |
|-------|--------------|-----------------------------|---------|-------------|----------------------------------------------------------|
| **1** |              | **class-term<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"<br/>version=”1.0”**              |         |             | **Top-level element with mandatory ‘version’ attribute** |
| **2** | **E11D01**   | **identifier**              | **1**   | **String**  |                                                          |
| **3** | **E11D02**   | **code**                    | **1**   | **String**  |                                                          |
| **4** | **E11D03**   | **class-scheme-ref**        | **1**   | **String**  |                                                          |
| 5     | E11D04       | heading                     | 0-1     | String      |                                                          |
| 6     | E11C05       | note                        | 0-n     | String      |                                                          |
| 7     | E11D05.1     | note-type                   | 0-1     | Code        | NOT                                                      |
| 8     | E11D05.2     | date-time                   | 0-1     | DateTime    |                                                          |
| 9     | E11D05.3     | note-text                   | 1       | String      |                                                          |

E12 SELECTION CRITERION
-----------------------

|                                                 | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes*                                                  |
|-------------------------------------------------|--------------|-----------------------------|---------|-------------|----------------------------------------------------------|
| **1**                                           |              | **property<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"<br/>version=”1.0”**              |         |             | **Top-level element with mandatory ‘version’ attribute** |
| **2**                                           | **E12D01**   | **identifier**              | **1**   | **String**  |                                                          |
| <span id="h.gjdgxs" class="anchor"></span>**3** | **E12D02**   | **name**                    | **1**   | **String**  |                                                          |
| 4                                               | E12D03       | entity-type                 | 0-n     | Code        | ENT                                                      |
| 5                                               | E12D04       | description                 | 0-1     | String      |                                                          |
| 6                                               | E12D05       | value-scheme-ref            | 0-1     | String      |                                                          |
| 7                                               | E12C06       | note                        | 0-n     | String      |                                                          |
| 8                                               | E12D06.1     | note-type                   | 0-1     | Code        | NOT                                                      |
| 9                                               | E12D06.2     | date-time                   | 0-1     | DateTime    |                                                          |
| 10                                              | E12D06.3     | note-text                   | 1       | String      |                                                          |

EXCEPTION CONDITIONS
--------------------

|       | *Element ID* | *XML structure*             | *Card.* | *Data type* | *Notes*                                                  |
|-------|--------------|-----------------------------|---------|-------------|----------------------------------------------------------|
| **1** |              | **lcf-exception<br/>xmlns=<br/>"http://ns.bic.org/lcf/1.0"<br/>version=”1.0”**              |         |             | **Top-level element with mandatory ‘version’ attribute** |
| **2** | **R00C05**   | **exception-condition**     | **1-n** |             |                                                          |
| **3** | **R00D05.1** | **condition-type**          | **1**   | **Code**    | **EXC**                                                  |
| 4     | R00D05.2     | reason-denied               | 0-1     | Code        | RDN                                                      |
| 5     | R00D05.3     | element-ref                 | 0-1     | String      |                                                          |
| 6     | R00C06       | message                     | 0-n     | Code        |                                                          |
| 7     | R00D06.1     | message-type                | 1       | String      | MGT                                                      |
| 8     | R00D06.2     | message-text                | 1-n     | String      |                                                          |
