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

Incumbent with the profile validation is the duty to determine whether the request and responses with the LCF standard have been understood. For example, whether the response to an LCF get instance list has been understood by the caller. The validation process must include steps to provide the confidence that responses have been correctly processed. 

## Implementation Proposal
Provide two services:
1.	A mock server implementation that provides the LCF REST API endpoint, plus an overlay to provide the validation service controls and output. This implementation must be aware of when a test for a specific profile is starting, has ended, and report on the outcome. 

2.	A mock client implementation, driving the LCF REST API endpoint with specific behaviours.  This implementation must be able to trigger the start of a specific profile test, drive the REST API calls to fulfil the test, trigger the end of the profile test, and report on the outcome. 

## Test Management
To enable the server to trace the client's behaviour during profile validation, the server must understand where the client is within the validation process. This will require a method of communication with the server to inform it of the state of the test. Given that all REST service implementations are stateless, this behaviour must be provided outside of the normal operation of the service.

The proposal is to provide a simple Web UI and underlying API as part of the server implementation. The Web UI presents a simple human user interface enabling the user to select which profile is under test, activate the test, complete the test and view the outcome. The API underpinning the Web UI enables the same behaviour, enabling automation of the test cycle process if required by LCF Consortium members. This is in line with modern CI/CD pipeline creation. 

# Profiles

## Profile P00 - Core LMS Behaviour

## Profile P01 - Circulation

## Profile P02 - Record Management



