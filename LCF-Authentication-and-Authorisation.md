# Authentication and Authorisation

At the #Plugfest2 event and detailed in Issues [#24](https://github.com/anthonywhitford/bic-lcf/issues/24) and [#55](https://github.com/anthonywhitford/bic-lcf/issues/55) there have been discussions about the authentication mechanisms available in LCF relating to both Patrons and Service Terminals. This page defines what th outcome of those two conversations is. Within the LCF Review Panel meeting on 22nd February 2018, all attendees agreed that Patron Authentication was a critical issue that required immediate resolution. We agreed that the content of issues [#24](https://github.com/anthonywhitford/bic-lcf/issues/24) and [#55](https://github.com/anthonywhitford/bic-lcf/issues/55) would be written up and approved for LCF inclusion automatically on Friday 2nd March 2018.

If there are any challenges to the adoption of this change, please highlight this immediately by raising a high priority issue within the issue tracker and assigning it directly to Anthony Whitford, or any of the other Technical Editors of this standard. 

## Service Terminal Authentication
LCF is designed with a web service architecture, servicing a client/server model. A Service Terminal is any client consumer of an LCF web service. 

All LCF web services require authentication. Within the original definition of LCF's REST Protocol, this is implemented using HTTP BASIC authentication, providing a username and location code (in the format of an email address) and a complex password.

During #Plugfest2 there was discussion about evolving this to make use of Open ID Connect (or similar) standard. At this time the decision is that this change will be deferred.

