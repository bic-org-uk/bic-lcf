---
title: LCF ChangeLog v1.3.0
menu: Change Log for v1.3.0
weight: 7
---

# Change Log from LCF v1.2.0 to LCF v1.3.0

| Change                                          | Summary                                                      |
| ----------------------------------------------- | ------------------------------------------------------------ |
| Updating code list PNI, code value 18 (PNI03)   | Changed  Definition from 'LCCN' to 'NACO' to align with current issue of ONIX code  list 44.                     Corrected Note (code value '18' replaces '17'). See issue #304. |
| Resolving issues #84 and #292                   | Adding  Q00D10 (acknowledgement code) for use in requests, and R00C06.4 (applicable  charge) for use in exception responses, with notes and examples in the REST  implementation. See issues #84 and #292. |
| Add note to E03C36                              | See issue #286.                                              |
| E01C02 made non-mandatory                       | The  element is already non-mandatory in the XML binding, so making it  non-mandatory in the data framework eliminates an inconsistency. See issue  #293. |
| Location associated  with an authorisation type | Adding E13D05 to Data Framework and to  the XML Binding, to allow one or more library locations to be associated with  an Authorisation of type AUT03 (consent to gain access to the location when  un-staffed). See issue #295. |
| Alternative authentication methods              | The  Implementation Notes section of the REST web service specification is revised  to make it explicit that alternative standard authentication methods, such as  the bearer token method, may be used for terminal application authentication  or patron authentication. |
| Pickup location                                 | Adding the ability to associate a pickup  location with a manifestation or item. |
| Add value '17' to code list PNS                 | See  issue #281.                                             |
| Acknowledgement  required                       | Change agreed in issue #84, to require  that the client acknowledge that a request has been accepted. Note that the  proposed change corrects a typo in the issue discussion: 'in the description  of R00D06.3, 'R00D06.1 contains '10' " should read "R00D05.2  contains '10' ". |
| Update LCF-ImplementationProfiles.md            | Implementing  changes agreed to resolve issue #266 and in partial resolution of issue #258. |
| Update  LCF-RESTWebServiceSpecification.md      | Fixing inconsistencies in responses to  check-out and check-in requests. See issue #276. |
| Resolving issues 116, 117 and 118               | Adding  Note under section 11 Check-out / renewal, resolving issues #116 and #117 and  partially resolving issue #118. |
| Allow deposits  against future charges          | This addresses the issue raised by #268.                     |
| Clarification of RQT02 confirmation request     | Documentation  of code value RQT02, the elements in the Data Framework that use code list  RQT, and the description of the 'circulation' parameter in the REST web  service implementation of circulation functions 11 and 12 have been extended  to explain that a confirmation request implements the SIP2 "no  block" flag for use when confirming items that were checked out or in  while the terminal application was off-line. |
| Handling  serials/periodicals                   | Modifications to E01 Manifestation to  allow it to describe a serial title, a serial issue or a bound set, and to  enable association of related manifestations. |
| Modifications to R11D03 and R11D04              | Removing  an inconsistency between the Data Framework and the REST implementation. See  issue #265. |
| Add authorisation  reference to E08 Payment     | With reference to issue #269, I am  adding E08D12 to the Data Framework and the XML binding. |
| Simplification of Core Profile P00              | The  Core Profile is to be simplified to only require support for retrieval of  entities. See issue #266. |
| Update  LCF-DataFrameworks.md                   | Corrected property IDs in E14. See issue  #263.              |
| Remove code lists MNI, TTL and UNC              | Updated  the LCF Data Framework and Code Lists documentation to remove code lists MNI,  TTL and UNC. Updated the corresponding schema modules, including updating the  ONIX code lists module to Issue 49 (March 2020) of the ONIX code lists. See  issue #255. |
| Add structured personal names to Patron entity  | See  issue #80. Both the LCF Data Framework and the XML Binding will be modified. |
| Added generated  OpenAPI specification          | As per #206 added OpenAPI specification  (including json syntax specification) |
| Add E08D12 and E08D13                           | Support  for using a payment to make a donation.             |
| Add Q02D06                                      | Enables a request for a list of entities  to indicate whether the response should contain a list of entity identifiers  or the entities themselves. See issue #191. |