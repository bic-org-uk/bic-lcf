# Authentication and Authorisation

At the #Plugfest2 event and detailed in Issues [#24](https://github.com/anthonywhitford/bic-lcf/issues/24) and [#55](https://github.com/anthonywhitford/bic-lcf/issues/55) there have been discussions about the authentication mechanisms available in LCF relating to both Patrons and Service Terminals. This page defines what th outcome of those two conversations is. Within the LCF Review Panel meeting on 22nd February 2018, all attendees agreed that Patron Authentication was a critical issue that required immediate resolution. We agreed that the content of issues [#24](https://github.com/anthonywhitford/bic-lcf/issues/24) and [#55](https://github.com/anthonywhitford/bic-lcf/issues/55) would be written up and approved for LCF inclusion automatically on Friday 2nd March 2018.

If there are any challenges to the adoption of this change, please highlight this immediately by raising a high priority issue within the issue tracker and assigning it directly to Anthony Whitford, or any of the other Technical Editors of this standard. 

## Service Terminal Authentication & Authorisation
LCF is designed with a web service architecture, servicing a client/server model. A Service Terminal is any client consumer of an LCF web service. 

All LCF web services require authentication. Within the original definition of LCF's REST Protocol, this is implemented using HTTP BASIC authentication, providing a username and location code (in the format of an email address) and a complex password.

During #Plugfest2 there was discussion about evolving this to make use of Open ID Connect (or similar) standard. At this time the decision is that this change will be deferred.

The implementation is therefore that the HTTP BASIC authentication is provided for each web service call. The LMCF Server validates this authentication request, and where valid, it then processes the authorisation to dis/allow access to the requested web service. 

## Patron Authentication & Authorisation

In [Issue #55](https://github.com/anthonywhitford/bic-lcf/issues/55) a proposal was put forward following conversation within #Plugfest2. This suggested a URI, request structure and payload which would allow a Service Terminal to validate the credentials provided by a Patron. That proposal is:

    GET /lcf/1.0/patrons/{unique-id}/authorisations<br/>
    patron-pin: 1234 <--- use the same encoding as for HTTP/BASIC "unique-id:pin" BASE64 or encoded with a pre-shared secret
    Reponds with:
    HTTP/200
    ... 
    -- or --
    HTTP/4xx - go get your access token from the IdP again, or if using HTTP BASIC, then your credentials were invalid for forbidden.

The response to a successful authorisations request is a list of zero or more "AUTHORISATION" entities. This is detailed within the LCF 1.01 standard, [here](https://github.com/anthonywhitford/bic-lcf/wiki/LCF-Version-1.0.1#e13). 

Each AUTHORISATION entity within the list must state which authorisation is being granted. This is currently a controlled list, available [here](https://github.com/anthonywhitford/bic-lcf/wiki/LCF-Code-Lists#AUT). Note that at the time of writing there is only a Parental Consent item within the code list, and therefore extensive modification to this list is expected, or vendors will be permitted to configure their own authorisation types at this point.


