---
title: LCF ChangeLog v1.3.0
menu: Change Log for v1.3.0
weight: 7
---

# Benefits introduced from LCF v1.2.0 to LCF v1.3.0

In December 2023, the BIC performed a soft release of the Library Communication Framework v1.3 standard, further enabling Library vendors to develop interoperability using real-time web service standards. 

This new revision of the Library Communication Framework builds upon earlier releases and includes feedback from LCF Consortium members, helping ensure that LCF adoption continues to grow and delivers value to library customers. 

We would like to express special thanks to the following BIC member vendors who were instrumental in the completion of this release:
*	Bibliotheca
*	Civica
*	Insight Media Ltd
Key improvements included within this release are:

## Structured Name Support
LCF has introduced a structured name extension (E03C36) to the Patron entity, aligning with the existing ONIX standard. This enables LCF users to represent person names more accurately, providing name information in separate fields, so the final presentation can be configured by each terminal client. This ensures flexibility for the terminal client and avoids error prone parsing of name information previously provided through a single field. 

## Improved Support for Serials and Periodicals
LCF 1.3 now includes a more detailed model for supporting Serial and Periodical content. The changes introduce modifications to the MANIFESTATION entity, deprecate the MNI code list and add the new Manifestation Type (MNT) code list. These changes allow LCF to correctly describe serial holdings and periodical materials.

## Quotations, Notifications and Acknowledgements
Library patrons must be informed of potential charges they may incur and be given the opportunity to change their choices, effectively declining fees before they are incurred. 

LCF 1.3 now includes the capability to inform the Patron of a monetary charge which would be incurred through their actions of checking-out or renewing an issuable item or placing a reservation. Typically, these would be classed as hire fees, or reservation fees within the library. The Patron can now confirm acceptance of any fees before completing the issue, renew or reservation processes. 

Included within these changes is the capability to inform the Patron where they have previously been loaned the same content from the library. The intention is to ensure that the Patron does not unknowingly borrow duplicate content from the library and incur a fee and would acknowledge they have been loaned the content before. 

These changes together help ensure the Patron can be fully informed of the impact of their choices. 
## Payment Modifications
Payment processes supported within LCF 1.3 now include the ability to make monetary donations to the library and put credit against future charges on a patron’s account. 

These two behaviours do no not require any pre-existing fine, fee or charge, instead enabling the provision of a deposit-type (E08D15), payment-purpose (E08D13) and beneficiary (E08D14), ensuring the reason for the payment is recorded. 

## Patron Self-Registration Improvement
Libraries often have the requirement to permit new Patrons to join the library using automated self-registration processes through their selected vendor. LCF 1.3 includes changes to the PATRON patron-status field (E03D04), enhancing the PNS code list to support a “Pending Patron” state. The intention is to ensure newly self-created Patron entities have a type identifier indicating they are unvalidated and do not have any other confirmed state. 

## Unstaffed Library Support
Changes within LCF 1.3 to support authorisation for Patrons to use unstaffed library locations have been completed. The changes included fit into two scenarios, one for real-time access control, which LCF already supported, and the other for determining whether a patron would have access to one or more library locations if they were unstaffed.

The changes affected the AUTHORISATION (E13) entity, through modifications to the AUT code list and the introduction of an optional list of location references (E10D05) indicating which locations the authorisation applies to. 

## Other Changes and Next Steps
Outside of these key changes in LCF 1.3, there have been minor changes and corrections to the existing documentation, and the provision of a draft example of OpenAPI support. 

Next steps for the Library Communication Framework are a theme of improving the performance of data access for lists of entities, implementing a validation framework for LCF profile conformance, and investigating inter-library loan support.

## Get in Touch
Please contact the technical editors or raise any issues through the [BIC GitHub project for LCF](https://github.com/bic-org-uk/bic-lcf/issues).

We would also be grateful if you could complete the implementation survey on [Microsoft Forms](https://forms.microsoft.com/Pages/ResponsePage.aspx?id=DQSIkWdsW0yxEjajBLZtrQAAAAAAAAAAAAO__c8FLadUNFUxMUVJNVI0TllQQ1BBTVozMVA5WTdMNy4u).

Any information you provide on the survey will help improve the LCF standard and the implementation journey for all LCF implementors. 

