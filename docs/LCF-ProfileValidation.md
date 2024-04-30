---
title: LCF Profiles Validation Issue 3
menu: Implementation Profiles
weight: 6
---

# Book Industry Communication

## Library Interoperability Standards

## Library Communication Framework for Terminal Applications (LCF)

## Implementation Profile Validation

LCF has multiple operational profiles described at <https://github.com/bic-org-uk/bic-lcf/blob/develop/docs/LCF-ImplementationProfiles.md>.
Each profile describes a specific set of behaviours expected from LCF Client and Server interactions. The validation of these implementation profiles ensures that any client will work with any server provided both have been validated to the same compliance profile. 
Any validation process must be able to confirm both the client operation and the server operation to ensure that both halves of the equation can be confirmed. This also implies an internal self-check, where the LCF client validator works consistently with the LCF server validator, and both achieve positive certification when operating together.

To provide effective LCF validation, a validation process for both the client and the server must be provided. These validators should be provided in a method that empowers use by LCF Consortium members. 

The responsibilities of the Validation Client and Server are as below:

![image](https://github.com/bic-org-uk/bic-lcf/assets/6545701/53a7fcd6-8ead-4f16-b60b-7c77e9725e04)

Incumbent with the profile validation is the duty to determine whether the request and responses with the LCF standard have been understood. For example, whether the response to an LCF get instance list been understood by the caller. The validation process must include steps to provide the confidence that responses have been correctly processed. 


