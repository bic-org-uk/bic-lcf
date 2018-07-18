---
title: LCF v1.0.1 REST Authentication and Authorisation
menu: REST Authentication and Authorisation
weight: 5
---

# Book Industry Communication

## Library Interoperability Standards

## Library Data Communication Framework for Terminal Applications (LCF)

## REST Authentication and Authorisation

### Version 1.0.1

### 12 July 2018

---

### Authentication and Authorisation

This document defines authentication and authorisation mechanisms for the REST binding of the LCF data communication framework.

The use of this document is subject to license terms and conditions that can be found *at* <http://www.bic.org.uk/files/bicstandardslicence.pdf>.

#### Service Terminal Authentication & Authorisation
LCF is designed with a web service architecture, servicing a client/server model. A Service Terminal is any client consumer of an LCF web service. 

All LCF web services require authentication. Within the original definition of LCF's REST Protocol, this is implemented using HTTP BASIC authentication, providing a username and location code (in the format of an email address) and a complex password.

The implementation is therefore that the HTTP BASIC authentication is provided for each web service call. The LCF Server validates this authentication request, and where valid, it then processes the authorisation to dis/allow access to the requested web service. 

#### Patron Authentication & Authorisation

Authentication is via an URI, request structure and payload which would allow a Service Terminal to validate the credentials provided by a Patron as follows:

    GET /lcf/1.0/patrons/{id-value}/authorisations
    lcf-patron-credential: 1234 <--- use the same encoding as for HTTP/BASIC "id-value:pin" BASE64 or encoded with a pre-shared secret
    
    Responds with:
    HTTP/200
    Where the Body / Payload is an authorisation entity response. Note that the authorisation entity response could be empty, indicating that there are no authorisations granted.

    -- or --

    HTTP/401 - go get your access token from the IdP again, or if using HTTP BASIC, then your service terminal credentials were invalid.

    -- or --

    HTTP/403 - your access token or service terminal credentials were correct, however the id-value and pin combination are invalid.

    -- or --

    HTTP/404 - the Patron represented by iv-value does not exist.

To be clear, the authorisation request is initiated with a GET request to  /lcf/1.0/patrons/{id-value}/authorisations where an HTTP request header "lcf-patron-credential" is passed with the request. Essentially, the header lcf-patron-credential is an implementation of element [Q00D01.2](LCF-RESTWebServiceSpecification#format-for-request-uri).

The response to a successful authorisations request is a list of zero or more [AUTHORISATION entities](LCF-Dataframeworks#E13). 

Each AUTHORISATION entity within the list must state which authorisation is being granted. This is currently a controlled list - code list [AUT](LCF-CodeLists#AUT). 

**Note:** at the time of writing the only relevant item within the code list is "Parental Consent". Extensive modification to this list is expected, or vendors will be permitted to configure their own authorisation types at this point.
