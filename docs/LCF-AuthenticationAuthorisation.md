---
title: LCF v1.2.0 REST Authentication and Authorisation
menu: REST Authentication and Authorisation
weight: 5
---

# Book Industry Communication

## Library Interoperability Standards

## Library Data Communication Framework for Terminal Applications (LCF)

## REST Authentication and Authorisation

### Version 1.2.0

### DRAFT

---

### Authentication and Authorisation

This document defines authentication and authorisation mechanisms for the REST binding of the LCF data communication framework.

The use of this document is subject to license terms and conditions that can be found *at* <http://www.bic.org.uk/files/bicstandardslicence.pdf>.

#### Service Terminal Authentication
LCF is designed with a web service architecture, servicing a client/server model. A Service Terminal is any client consumer of an LCF web service. 

Where an LCF web service requires authentication of the Service Terminal, this is implemented in the LCF REST implementation using HTTP BASIC authentication, providing a username and location code (in the format of an email address) and a complex password. This would be encoded in the HTTP Header field "Authorization".

The implementation is therefore that the HTTP BASIC authentication should be provided for each web service call. The LCF Server validates this authentication request, and where valid, it then processes the authorisation to dis/allow access to the requested web service. Alternatively an external IdP (Identity Provider), using a protocol such as OAuth or OpenId, may be used for authentication.

A response code of 401 indicates that the Service Terminal credentials were incorrect, or (in the case of an external IdP) has expired and needs to be re-requested from the IdP.

    GET /lcf/1.0/patrons/{id-value}
    Authorization: BASIC dGVybWluYWxAbG9jYXRpb246cGFzc3dvcmQ=
    
    Responds with:
    HTTP/200
    Where the Body / Payload is a patron entity response
    
    -- or --
    
    HTTP/401 - Service Terminal credentials were invalid, or need to be obtained from the IdP again
    
    -- or --
    
    HTTP/404 - the Patron represented by id-value does not exist


#### Patron Authentication

Where an LCF web service requires authentication of a Patron, this is done by using the HTTP header field "lcf-patron-credential". This should use the same format as HTTP BASIC authentication, i.e. the value "patron-id:password" encoded using BASE64, prepended by "BASIC ". Alternatively if an external IdP (Identity Provider) using a protocol such as OAuth or OpenId, is used for authentication, the token from the IdP can also be passed via this field.

A response code of 403 indicates that the patron credentials were incorrect, or (in the case of an external IdP) has expired and needs to be re-requested from the IdP.

    GET /lcf/1.0/patrons/{id-value}
    lcf-patron-credential: BASIC cGF0cm9uLWlkOnBhc3N3b3Jk
    
    Responds with:
    HTTP/200
    Where the Body / Payload is a patron entity response
    
    -- or --
    
    HTTP/403 - The id-value and password\pin combination for the patron are invalid, or need to be obtained from the IdP again
    
    -- or --
    
    HTTP/404 - the Patron represented by id-value does not exist

#### Determining if an Operation requires Authentication

The client should attempt the operation with no authentication information (neither terminal authentication via HTTP Basic nor user authentication via lcf-patron-credential HTTP header) 

A response code of 200\201 means that no authentication is required.
A response of 401 means that terminal authentication is required.
A response of 403 means that patron authentication is required.

(if both terminal and patron authentication is required, the server may respond with either 401/403, and may respond to a subsequent request with a similar message should the client send only one of the required authentication).

Care should be taken not to use operations which have side effects (e.g. POST, PUT, DELETE) purely for testing whether Authentication is required.

#### Patron Authorisation

Authorisation requests are initiated with a GET request to /lcf/1.0/patrons/{id-value}/authorisations

The response to a successful authorisations request is a list of zero or more [AUTHORISATION entities](LCF-Dataframeworks.md#E13). 

Each AUTHORISATION entity within the list must state which authorisation is being granted. This is currently a controlled list - code list [AUT](LCF-CodeLists.md#AUT). 


    GET /lcf/1.0/patrons/{id-value}/authorisations
    Authorization: BASIC dGVybWluYWxAbG9jYXRpb246cGFzc3dvcmQ=
    lcf-patron-credential: BASIC cGF0cm9uLWlkOnBhc3N3b3Jk
    
    Responds with:
    HTTP/200
    Where the Body / Payload is an authorisation entity response. Note that the authorisation entity response could be empty, indicating that there are no authorisations granted.
    
    -- or --
    
    HTTP/401 - Service Terminal credentials were invalid, or need to be obtained from the IdP again
    
    -- or --
    
    HTTP/403 - The id-value and password\pin combination are invalid, or need to be obtained from the IdP again
    
    -- or --
    
    HTTP/404 - the Patron represented by id-value does not exist

